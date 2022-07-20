using Test_Pulsar.Api.Services;
using Test_Pulsar.Shared.Messaging;
using Test_Pulsar.Shared.Observability;
using Test_Pulsar.Shared.Pulsar;
using Test_Pulsar.Shared.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddHttpContextAccessor();
builder.Services.AddSerialization();
builder.Services.AddMessaging();
builder.Services.AddPulsar();
builder.Services.AddHostedService<NotifierMessagingBackgroundService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCorrelationId();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();