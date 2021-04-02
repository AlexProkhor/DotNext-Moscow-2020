using Force.Cqrs;
using Force.Ddd.DomainEvents;
using Infrastructure.Rabbit;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WorkService
{
    public class Worker : BackgroundService
    {
        private const string ExchangeName = "domain-events";
        private readonly ILogger<Worker> _logger;
        private readonly IHandler<IEnumerable<IDomainEvent>> _domainEventDispatcher;

        public Worker(ILogger<Worker> logger, IHandler<IEnumerable<IDomainEvent>> domainEventDispatcher)
        {
            _logger = logger;
            _domainEventDispatcher = domainEventDispatcher;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.ExchangeDeclare(
            exchange: ExchangeName,
            type: ExchangeType.Fanout);

            var queueName = channel.QueueDeclare().QueueName;
            channel.QueueBind(
                queue: queueName,
                exchange: ExchangeName,
                routingKey: "");

            _logger.LogInformation($"Worker running at: {DateTimeOffset.Now}");

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000, stoppingToken);

                Console.WriteLine(" [*] Waiting for logs.");

                var consumer = new EventingBasicConsumer(channel);

                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Deserialize(body);

                    Dispatch(message);
                };

                channel.BasicConsume(
                    queue: queueName,
                    autoAck: true,
                    consumer: consumer);
            }
        }
        private static DomainEventMessage[] Deserialize(byte[] input)
        {
            var message = Encoding.UTF8.GetString(input);

            Console.WriteLine($" [x] {message}");

            return JsonConvert.DeserializeObject<DomainEventMessage[]>(message);
        }

        private void Dispatch(DomainEventMessage[] message)
        {
            var domainEvents = message
                .Select(CreateEvent)
                .Where(x => x != null)
                .ToList();

            _domainEventDispatcher.Handle(domainEvents);
        }

        private IDomainEvent CreateEvent(DomainEventMessage message)
        {
            var types = this.GetType().Assembly.GetTypes();
            var type = types.FirstOrDefault(x => x.Name == message.EventType);
            if (type == null)
            {
                return null!;
            }

            try
            {
                var domainEvent = Activator.CreateInstance(type);
                var properties = type.GetProperties().Where(x => x.CanRead && x.CanWrite).ToDictionary(x => x.Name, x => x);
                foreach (var p in properties)
                {
                    if (message.Data.ContainsKey(p.Key))
                    {
                        p.Value.SetValue(domainEvent, Convert.ChangeType(message.Data[p.Key], p.Value.PropertyType));
                    }
                }
                return (IDomainEvent)domainEvent!;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return null!;
            }
        }
    }
}
