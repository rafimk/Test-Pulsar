namespace Test_Pulsar.Shared.Abstractions.Mailing;

public interface IMailService
{
    Task SendEmailAsync(IMailRequest mailRequest);
}