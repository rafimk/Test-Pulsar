using System.Threading.Tasks;
using Test_Pulsar.Shared.Abstractions.Messaging;

namespace Test_Pulsar.Shared.Messaging;

internal sealed class DefaultMessagePublisher : IMessagePublisher
{
    public Task PublishAsync<T>(string topic, T message) where T : class, IMessage => Task.CompletedTask;
}