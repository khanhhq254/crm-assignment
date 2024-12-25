namespace CRMAPI.Domain.Entities;

public class Customer : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public bool IsLead { get; set; }

    public List<PricingAgreement> PricingAgreements { get; set; }
}