using AutoMapper;
using CRMAPI.Application.Dtos.PricingAgreement;
using CRMAPI.Application.Services.PricingAgreementService;
using MediatR;

namespace CRMAPI.Application.Commands;

public class CreatePricingAgreementCommand : IRequest<PricingAgreementDto>
{
    public string Payload { get; set; }
}

public class CreatePricingAgreementCommandHandler : IRequestHandler<CreatePricingAgreementCommand, PricingAgreementDto>
{
    private readonly IPricingAgreementService _pricingAgreementService;
    private readonly IMapper _mapper;

    public CreatePricingAgreementCommandHandler(IPricingAgreementService pricingAgreementService, IMapper mapper)
    {
        _pricingAgreementService = pricingAgreementService;
        _mapper = mapper;
    }

    public async Task<PricingAgreementDto> Handle(CreatePricingAgreementCommand request, CancellationToken cancellationToken)
    {
        var requestDto = _mapper.Map<CreatePricingAgreementRequest>(request.Payload);
        return await _pricingAgreementService.CreatePricingAgreementAsync(requestDto, cancellationToken);
    }
}