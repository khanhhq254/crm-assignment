namespace CRMAPI.Application.Dtos.Customer;

public class CustomerDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public bool IsLead { get; set; }
}