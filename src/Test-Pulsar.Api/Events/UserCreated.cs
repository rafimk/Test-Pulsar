using Test_Pulsar.Shared.Abstractions.Messaging;

namespace Test_Pulsar.Api.Events;

internal record UserCreated(string Email, string UserName, string VerifyOTP) : IMessage;