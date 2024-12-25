using System.Text.Json;
using CRMAPI.Application.Dtos;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace CRMAPI.Application.Consumers;

public class UpdateCustomerRoleConsumer : IConsumer<Message>
{
    private readonly ILogger<UpdateCustomerRoleConsumer> _logger;

    public UpdateCustomerRoleConsumer(ILogger<UpdateCustomerRoleConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<Message> context)
    {
        _logger.LogInformation($"[{nameof(UpdateCustomerRoleConsumer)}] Message from publisher: {JsonSerializer.Serialize(context.Message)}");
        return Task.CompletedTask;
    }
}