namespace CRMAPI.Application.Dtos.PricingAgreement;

public class CreatePricingAgreementRequest
{
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
    public decimal AgreedPrice { get; set; }
    public DateTime AgreementDate { get; set; }
}