using CRMAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRMAPI.Infrastructure.Persistence.Configuration;

public class PricingAgreementConfiguration : IEntityTypeConfiguration<PricingAgreement>
{
    public void Configure(EntityTypeBuilder<PricingAgreement> builder)
    {
        builder.ToTable("pricing_agreements");
        
        builder.HasKey(s => s.Id);
        builder.HasOne(s => s.Customer).WithMany(s => s.PricingAgreements).HasForeignKey(s => s.CustomerId);
    }
}