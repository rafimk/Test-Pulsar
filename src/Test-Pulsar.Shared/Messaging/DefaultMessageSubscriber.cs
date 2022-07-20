using System;
using System.Threading.Tasks;
using Test_Pulsar.Shared.Abstractions.Messaging;

namespace Test_Pulsar.Shared.Messaging;

internal sealed class DefaultMessageSubscriber : IMessageSubscriber
{
    public Task SubscribeAsync<T>(string topic, Action<MessageEnvelope<T>> handler) where T : class, IMessage => Task.CompletedTask;
}