namespace CRMAPI.Application.Dtos.PricingAgreement;

public class PricingAgreementDto
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
    public decimal AgreedPrice { get; set; }
    public DateTime AgreementDate { get; set; }
}