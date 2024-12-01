using LocacaoMoto.Application.Configurations;
using LocacaoMoto.Application.DomainEvents;
using LocacaoMoto.Application.Handlers.Commands;
using LocacaoMoto.Application.Handlers.Events;
using LocacaoMoto.Application.Handlers.Queries;
using LocacaoMoto.Application.Interfaces.Services;
using LocacaoMoto.Application.Services;
using LocacaoMoto.Application.Services.Client;
using LocacaoMoto.Domain.Interfaces.Repositories;
using LocacaoMoto.Infrastructure.Queue;
using LocacaoMoto.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using System.Data;
using Npgsql;

namespace LocacaoMoto.IoC
{
    public static class DependencyInjectionExtension
    {
        public static void AddBuildServices(this IServiceCollection services)
        {
            services.AddSingleton<INotifier, Notifier>();
        }

        public static void AddMediatRApi(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(
                    typeof(MottoRequestHandler).Assembly,
                    typeof(DeliveryManRequestHandler).Assembly,
                    typeof(RentalRequestHandler).Assembly,
                    typeof(MottoCreatedEventHandler).Assembly,
                    typeof(MottoQueryHandlers).Assembly,
                    typeof(RentalQueryHandler).Assembly);
            });
        }

        public static void AddBuildRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IMottoRepository, MottoRepository>();
            services.AddScoped<IDeliveryManRepository, DeliveryManRepository>();
            services.AddScoped<IRentalRepository, RentalRepository>();
            services.AddTransient<MottoCreatedEventHandler>();
            services.AddSingleton<IRabbitClient, RabbitClient>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddSingleton<IDbConnection>(new NpgsqlConnection(connectionString));

        }

        public static void AddBuildOptions(this IServiceCollection services, IConfiguration configuration  )
        {
          
        }
    }
}
