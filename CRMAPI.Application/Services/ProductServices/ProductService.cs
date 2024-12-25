using System.Net;
using System.Text.Json;
using CRMAPI.Application.Dtos.Product;
using CRMAPI.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CRMAPI.Application.Services.ProductServices;

public class ProductService : IProductService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    private readonly ILogger<ProductService> _logger;
    private readonly ApplicationDbContext _dbContext;

    public ProductService(
        HttpClient httpClient, 
        IConfiguration configuration, 
        ILogger<ProductService> logger, 
        ApplicationDbContext dbContext)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _logger = logger;
        _dbContext = dbContext;
    }

    public async Task<ProductDto> GetProductsAsync(CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("[ProductService] Get product information from PIM");
            var response = await _httpClient.GetAsync(_configuration["Endpoints:ProductEndpoint"], cancellationToken);
            _logger.LogInformation($"[ProductService] Get product information from PIM response: {JsonSerializer.Serialize(response)}");
            if (response.StatusCode != HttpStatusCode.OK) return null!;
            var responseString = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<ProductDto>(responseString)!;
        }
        catch (Exception e)
        {
            _logger.LogError($"[ProductService] Error getting product information from PIM: {e.Message}");
            throw;
        }
    }
}