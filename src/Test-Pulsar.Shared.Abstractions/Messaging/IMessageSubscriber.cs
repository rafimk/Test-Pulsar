namespace Test_Pulsar.Shared.Abstractions.Messaging;

public interface IMessageSubscriber
{
    Task SubscribeAsync<T>(string topic, Action<MessageEnvelope<T>> handler) where T : class, IMessage;
}