using CRMAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRMAPI.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<PricingAgreement> PricingAgreements { get; set; }
    public DbSet<Customer> Customers { get; set; }
}