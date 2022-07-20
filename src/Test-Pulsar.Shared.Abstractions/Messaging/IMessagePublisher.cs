namespace Test_Pulsar.Shared.Abstractions.Messaging;

public interface IMessagePublisher
{
    Task PublishAsync<T>(string topic, T message) where T : class, IMessage;
}