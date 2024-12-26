using System.Text.Json;
using AutoMapper;
using CRMAPI.Application.Dtos;
using CRMAPI.Application.Dtos.PricingAgreement;
using CRMAPI.Domain.Entities;
using CRMAPI.Infrastructure.Persistence;
using MassTransit;

namespace CRMAPI.Application.Services.PricingAgreementService;

public class PricingAgreementService : IPricingAgreementService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly IBus _bus;

    public PricingAgreementService(ApplicationDbContext dbContext, IMapper mapper, IBus bus)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _bus = bus;
    }

    public async Task<PricingAgreementDto> CreatePricingAgreementAsync(CreatePricingAgreementRequest request, CancellationToken cancellationToken)
    {
        var pricingAgreement = new PricingAgreement()
        {
            CustomerId = request.CustomerId,
            ProductId = request.ProductId,
            AgreedPrice = request.AgreedPrice,
            AgreementDate = request.AgreementDate
        };
        await _dbContext.PricingAgreements.AddAsync(pricingAgreement, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);

        var publishEndpoint = await _bus.GetSendEndpoint(new Uri("exchange:pricing-agreement?type=direct"));
        
        await publishEndpoint.Send(new Message()
        {
            Id = new Guid(),
            Content = JsonSerializer.Serialize(pricingAgreement)
        }, cancellationToken);

        return _mapper.Map<PricingAgreementDto>(pricingAgreement);
    }
}