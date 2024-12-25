namespace CRMAPI.Application.Dtos.PricingAgreement;

public class PricingAgreementDto
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public Guid ProductId { get; set; }
    public decimal AgreedPrice { get; set; }
    public DateTime AgreementDate { get; set; }
}