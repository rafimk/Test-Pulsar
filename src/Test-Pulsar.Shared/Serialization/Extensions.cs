using Microsoft.Extensions.DependencyInjection;
using Test_Pulsar.Shared.Abstractions.Serialization;

namespace Test_Pulsar.Shared.Serialization;

public static class Extensions
{
    public static IServiceCollection AddSerialization(this IServiceCollection services)
        => services.AddSingleton<ISerializer, SystemTextJsonSerializer>();
}