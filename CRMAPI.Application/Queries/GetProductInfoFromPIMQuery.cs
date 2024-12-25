using CRMAPI.Application.Dtos.Product;
using CRMAPI.Application.Services.ProductServices;
using MediatR;

namespace CRMAPI.Application.Queries;

public class GetProductInfoFromPIMQuery : IRequest<List<ProductItemDto>>
{
    
}

public class GetProductInfoFromPIMQueryHandler : IRequestHandler<GetProductInfoFromPIMQuery, List<ProductItemDto>>
{
    private readonly IProductService _productService;

    public GetProductInfoFromPIMQueryHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<List<ProductItemDto>> Handle(GetProductInfoFromPIMQuery request, CancellationToken cancellationToken)
    {
        var product = await _productService.GetProductsAsync(cancellationToken);
        return product.Products;
    }
}