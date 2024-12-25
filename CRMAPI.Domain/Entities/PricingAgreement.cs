namespace CRMAPI.Domain.Entities;

public class PricingAgreement : BaseEntity
{
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
    public decimal AgreedPrice { get; set; }
    public DateTime AgreementDate { get; set; }

    public Customer Customer { get; set; }
}