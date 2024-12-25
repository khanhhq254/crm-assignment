using CRMAPI.Application.Commands;
using CRMAPI.Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CRMAPI.Controllers;

public class WebhookController : ApiControllerBase
{
    [HttpPost("create-customer")]
    public async Task<IActionResult> HandleCreateCustomerWebhook([FromBody]WebhookRequest request)
    {
        var result = await Mediator.Send(new CreateCustomerCommand()
        {
            Payload = request.Payload
        });

        return Ok(result);
    }
    
    [HttpPost("update-role")]
    public async Task<IActionResult> HandleUpdateCustomerWebhook([FromBody]WebhookRequest request)
    {
        var result = await Mediator.Send(new UpdateCustomerRoleCommand()
        {
            Payload = request.Payload
        });

        return Ok(result);
    }

    [HttpPost("register-pricing-agreement")]
    public async Task<IActionResult> HandleRegisterPricingAgreement([FromBody]WebhookRequest request)
    {
        var result = await Mediator.Send(new CreatePricingAgreementCommand()
        {
            Payload = request.Payload
        });
        return Ok(result);
    }
}