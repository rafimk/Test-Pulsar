using Microsoft.Extensions.DependencyInjection;
using Test_Pulsar.Shared.Abstractions.Messaging;
using Test_Pulsar.Shared.Messaging;

namespace Test_Pulsar.Shared.Pulsar;

public static class Extensions
{
    public static IServiceCollection AddPulsar(this IServiceCollection services)
        => services
            .AddSingleton<IMessagePublisher, PulsarMessagePublisher>()
            .AddSingleton<IMessageSubscriber, PulsarMessageSubscriber>();
}