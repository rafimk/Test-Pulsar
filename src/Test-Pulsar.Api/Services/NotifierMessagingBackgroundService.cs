using Test_Pulsar.Api.Events;
using Test_Pulsar.Shared.Abstractions.Messaging;

namespace Test_Pulsar.Api.Services;

internal sealed class NotifierMessagingBackgroundService : BackgroundService
{
    private readonly IMessageSubscriber _messageSubscriber;
    private readonly ILogger<NotifierMessagingBackgroundService> _logger;

    public NotifierMessagingBackgroundService(IMessageSubscriber messageSubscriber, 
        ILogger<NotifierMessagingBackgroundService> logger)
    {
        _messageSubscriber = messageSubscriber;
        _logger = logger;
    }
    
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _messageSubscriber.SubscribeAsync<UserCreated>("orders", messageEnvelope =>
        {
            var correlationId = messageEnvelope.CorrelationId;
            _logger.LogInformation($"User with ID: '{messageEnvelope.Message.Email}' Full Name : '{messageEnvelope.Message.UserName}' has been created. " +
                                   $"Correlation ID: '{correlationId}'.");
        });
        
        return Task.CompletedTask;
    }
}