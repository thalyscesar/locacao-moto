using LocacaoMoto.Consumer;
using LocacaoMoto.Consumer.Repositories;
using Npgsql;
using System.Data;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext,services) =>
    {
        services.AddSingleton<IDbConnection>(new NpgsqlConnection(hostContext.Configuration.GetConnectionString("DefaultConnection")));
        services.AddSingleton<IMottoRepository, MottoRepository>();
        
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
