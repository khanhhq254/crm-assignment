using CRMAPI.Application.Dtos.Customer;
using CRMAPI.Application.Services.CustomerService;
using MassTransit;
using MediatR;

namespace CRMAPI.Application.Commands;

public class CreateCustomerCommand : IRequest<CustomerDto>
{
    public required string Payload { get; set; }
}

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerDto>
{
    private readonly ICustomerService _customerService;
    private readonly IBus _bus;

    public CreateCustomerCommandHandler(ICustomerService customerService, IBus bus)
    {
        _customerService = customerService;
        _bus = bus;
    }

    public async Task<CustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        return await _customerService.CreateNewCustomerAsync(request.Payload, cancellationToken);
    }
}