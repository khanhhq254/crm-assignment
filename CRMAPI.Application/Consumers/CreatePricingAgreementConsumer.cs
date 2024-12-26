using System.Text.Json;
using CRMAPI.Application.Dtos;
using CRMAPI.Application.Dtos.Messages;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace CRMAPI.Application.Consumers;

public class CreatePricingAgreementConsumer : IConsumer<CreatePricingAgreementMessage>
{
    private readonly ILogger<CreatePricingAgreementConsumer> _logger;

    public CreatePricingAgreementConsumer(ILogger<CreatePricingAgreementConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<CreatePricingAgreementMessage> context)
    {
        _logger.LogInformation($"[{nameof(CreatePricingAgreementConsumer)}] Message from publisher: {JsonSerializer.Serialize(context.Message)}");
        return Task.CompletedTask;
    }
}