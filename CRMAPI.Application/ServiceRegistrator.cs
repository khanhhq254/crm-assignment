using System.Reflection;
using CRMAPI.Application.Consumers;
using CRMAPI.Application.Services.CustomerService;
using CRMAPI.Application.Services.PricingAgreementService;
using CRMAPI.Application.Services.ProductServices;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace CRMAPI.Application;

public static class ServiceRegistrator
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(ServiceRegistrator).Assembly));

        services.AddTransient<IProductService, ProductService>();
        services.AddTransient<ICustomerService, CustomerService>();
        services.AddTransient<IPricingAgreementService, PricingAgreementService>();
        
        services.AddMassTransit(x =>
        {
            x.AddConsumer<UpdateCustomerRoleConsumer>(); // Register consumer(s)
            x.AddConsumer<CreatePricingAgreementConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host("rabbitmq://localhost", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });
                cfg.ConfigureEndpoints(context);

                cfg.ReceiveEndpoint("update-customer-queue", e =>
                {
                    e.Bind("update-customer", bc =>
                    {
                        bc.ExchangeType = ExchangeType.Direct;
                    });
                    e.ConfigureConsumeTopology = false;
                    e.ExchangeType = ExchangeType.Direct;
                    e.AutoDelete = false;
                    
                    e.ConfigureConsumer<UpdateCustomerRoleConsumer>(context);
                });
                
                cfg.ReceiveEndpoint("pricing-agreement-queue", e =>
                {
                    e.Bind("pricing-agreement", bc =>
                    {
                        bc.ExchangeType = ExchangeType.Direct;
                    });
                    e.ConfigureConsumeTopology = false;
                    e.ExchangeType = ExchangeType.Direct;
                    e.AutoDelete = false;
                    e.ConfigureConsumer<CreatePricingAgreementConsumer>(context);
                });
            });
        });

        return services;
    }
}