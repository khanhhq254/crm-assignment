using System.Text.Json;
using AutoMapper;
using CRMAPI.Application.Dtos;
using CRMAPI.Application.Dtos.Customer;
using CRMAPI.Domain.Entities;
using CRMAPI.Infrastructure.Persistence;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace CRMAPI.Application.Services.CustomerService;

public class CustomerService : ICustomerService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly IBus _bus;
    private readonly IPublishEndpoint _publishEndpoint;

    public CustomerService(ApplicationDbContext dbContext, IMapper mapper, IBus bus, IPublishEndpoint publishEndpoint)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _bus = bus;
        _publishEndpoint = publishEndpoint;
    }

    public async Task<CustomerDto> CreateNewCustomerAsync(string payload, CancellationToken cancellationToken)
    {
        var request = JsonSerializer.Deserialize<CreateCustomerRequest>(payload);

        var customer = new Customer()
        {
            Name = request?.Name ?? string.Empty,
            Email = request?.Email ?? string.Empty,
            IsLead = request is { IsLead: true },
        };

        await _dbContext.Customers.AddAsync(customer, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return _mapper.Map<CustomerDto>(customer);
    }

    public async Task<CustomerDto> UpdateCustomerRoleAsync(string payload, CancellationToken cancellationToken)
    {
        var request = JsonSerializer.Deserialize<UpdateCustomerRoleRequest>(payload);

        if (request == null)
        {
            throw new InvalidCastException();
        }
        
        var customer = await _dbContext.Customers.FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken: cancellationToken);

        if (customer == null)
        {
            throw new KeyNotFoundException();
        }

        customer.IsLead = request.IsLead;

        _dbContext.Customers.Update(customer);
        
        await _dbContext.SaveChangesAsync(cancellationToken);

        await _publishEndpoint.Publish<Message>(new Message()
        {
            Id = Guid.NewGuid(),
            Content = JsonSerializer.Serialize(customer)
        }, cancellationToken);

        return _mapper.Map<CustomerDto>(customer);
    }
}