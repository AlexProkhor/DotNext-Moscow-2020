using Force.Ddd.DomainEvents;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Rabbit
{
    public class DomainEventMessage : IDomainEvent
    {
        [JsonConstructor]
        private DomainEventMessage(Dictionary<string, object> data, string eventType, DateTime happened)
        {
            Data = data;
            EventType = eventType;
            Happened = happened;
        }
        public DomainEventMessage(IDomainEvent domainEvent)
        {
            if (domainEvent == null)
            {
                throw new ArgumentNullException(nameof(domainEvent));
            }

            EventType = domainEvent.GetType().Name;
            Happened = domainEvent.Happened;

            var properties = domainEvent
                .GetType()
                .GetProperties()
                .Where(x => x.CanRead)
                .ToList();

            foreach (var p in properties)
            {
                this[p.Name] = p.GetValue(domainEvent);
            }
        }

        public string EventType { get; }

        public DateTime Happened { get; }

        public Dictionary<string, object> Data = new();

        public object this[string key]
        {
            get => Data.ContainsKey(key) == true ? Data[key] : default;
            set { Data[key] = value; }
        }
    }
}
