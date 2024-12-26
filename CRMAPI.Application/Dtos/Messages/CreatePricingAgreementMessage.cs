using CRMAPI.Application.Dtos.PricingAgreement;

namespace CRMAPI.Application.Dtos.Messages;

public class CreatePricingAgreementMessage
{
    public Guid Id { get; set; }
    public PricingAgreementDto PricingAgreement { get; set; }
}