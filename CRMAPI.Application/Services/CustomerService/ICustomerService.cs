using CRMAPI.Application.Dtos.Customer;

namespace CRMAPI.Application.Services.CustomerService;

public interface ICustomerService
{
    Task<CustomerDto> CreateNewCustomerAsync(string payload, CancellationToken cancellationToken);

    Task<CustomerDto> UpdateCustomerRoleAsync(string payload, CancellationToken cancellationToken);
}