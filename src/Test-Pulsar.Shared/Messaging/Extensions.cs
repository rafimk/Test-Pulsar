using Microsoft.Extensions.DependencyInjection;
using Test_Pulsar.Shared.Abstractions.Messaging;

namespace Test_Pulsar.Shared.Messaging;

public static class Extensions
{
    public static IServiceCollection AddMessaging(this IServiceCollection services)
        => services
            .AddSingleton<IMessagePublisher, DefaultMessagePublisher>()
            .AddSingleton<IMessageSubscriber, DefaultMessageSubscriber>();
}