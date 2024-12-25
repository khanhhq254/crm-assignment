using AutoMapper;
using CRMAPI.Application.Dtos.Customer;
using CRMAPI.Application.Dtos.PricingAgreement;
using CRMAPI.Domain.Entities;

namespace CRMAPI.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Customer, CustomerDto>();
        CreateMap<PricingAgreement, PricingAgreementDto>();
    }
}