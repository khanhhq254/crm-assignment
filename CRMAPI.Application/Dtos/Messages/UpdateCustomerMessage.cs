using CRMAPI.Application.Dtos.Customer;

namespace CRMAPI.Application.Dtos.Messages;

public class UpdateCustomerMessage
{
    public Guid Id { get; set; }
    public CustomerDto Customer { get; set; }
}