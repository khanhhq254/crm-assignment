using System.Text.Json;
using CRMAPI.Application.Dtos.Customer;
using CRMAPI.Application.Services.CustomerService;
using CRMAPI.Domain.Entities;
using MediatR;

namespace CRMAPI.Application.Commands;

public class UpdateCustomerRoleCommand : IRequest<CustomerDto>
{
    public string Payload { get; set; }
}

public class UpdateCustomerRoleCommandHandler : IRequestHandler<UpdateCustomerRoleCommand, CustomerDto>
{
    private readonly ICustomerService _customerService;

    public UpdateCustomerRoleCommandHandler(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public async Task<CustomerDto> Handle(UpdateCustomerRoleCommand request, CancellationToken cancellationToken)
    {
        return await _customerService.UpdateCustomerRoleAsync(request.Payload, cancellationToken);
    }
}
