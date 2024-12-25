using CRMAPI.Application.Dtos.PricingAgreement;

namespace CRMAPI.Application.Services.PricingAgreementService;

public interface IPricingAgreementService
{
    Task<PricingAgreementDto> CreatePricingAgreementAsync(CreatePricingAgreementRequest request, CancellationToken cancellationToken);
}