using Test_Pulsar.Shared.Messaging;
using Test_Pulsar.Shared.Observability;
using Test_Pulsar.Shared.Pulsar;
using Test_Pulsar.Shared.Serialization;
using Test_Pulsar.Subscriber.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddHttpContextAccessor()
    .AddSerialization()
    .AddMessaging()
    .AddPulsar()
    .AddHostedService<NotifierMessagingBackgroundService>();

var app = builder.Build();
app.UseCorrelationId();

app.MapGet("/", () => "FeedR Notifier");

app.Run();