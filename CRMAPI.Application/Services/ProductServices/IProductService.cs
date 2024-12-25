using CRMAPI.Application.Dtos.Product;

namespace CRMAPI.Application.Services.ProductServices;

public interface IProductService
{
    Task<ProductDto> GetProductsAsync(CancellationToken cancellationToken = default);
}