using System.Text.Json.Serialization;

namespace CRMAPI.Application.Dtos.Product;

public class ProductDto
{
    [JsonPropertyName("products")]
    public List<ProductItemDto> Products { get; set; }
    
    [JsonPropertyName("total")]
    public int Total { get; set; }
    
    [JsonPropertyName("skip")]
    public int Skip { get; set; }
    
    [JsonPropertyName("limit")]
    public int Limit { get; set; }
}

public class ProductItemDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("price")]
    public decimal Price { get; set; }

    [JsonPropertyName("stock")]
    public decimal Stock { get; set; }

    [JsonPropertyName("brand")]
    public string Brand { get; set; }

    [JsonPropertyName("sku")]
    public string Sku { get; set; }
}