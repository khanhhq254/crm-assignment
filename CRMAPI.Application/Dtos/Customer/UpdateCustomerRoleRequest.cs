using System.Text.Json.Serialization;

namespace CRMAPI.Application.Dtos.Customer;

public class UpdateCustomerRoleRequest
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("isLead")]
    public bool IsLead { get; set; }
}