using LocacaoMoto.Application.Configurations;
using LocacaoMoto.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddOptions<RabbitConfig>()
    .BindConfiguration(nameof(RabbitConfig));

builder.Services.AddBuildOptions(builder.Configuration);
builder.Services.AddBuildRepositories(builder.Configuration);
builder.Services.AddBuildServices();
builder.Services.AddMediatRApi();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
