using Force.Cqrs;
using Force.Ddd.DomainEvents;
using HightechAngular.Data;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace WorkService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)

                .UseDefaultServiceProvider(options =>
                {
                    options.ValidateScopes = false;
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddDbContext<ApplicationDbContext>(ApplicationContextFactory.SetOptions);
                    services.AddDbContextAndQueryables<ApplicationDbContext>();
                    services.AddAsyncInitializer<ApplicationDbContextInitializer>();
                    services.AddScoped<DbContext, ApplicationDbContext>();

                    services.AddScoped<IHandler<IEnumerable<ProductPurchased>>, OrderDomainEventHandler>();
                    services.AddScoped<IHandler<IEnumerable<IDomainEvent>>, DomainEventDispatcher>();
                    services.AddHostedService<Worker>();
                });
    }
}
