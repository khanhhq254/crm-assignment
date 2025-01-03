using System.Text.Json.Serialization;

namespace CRMAPI.Application.Dtos.Customer;

public class CreateCustomerRequest
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("email")]
    public string Email { get; set; }
    
    [JsonPropertyName("isLead")]
    public bool IsLead { get; set; }
}