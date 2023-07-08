using MediatR;
using System.ComponentModel.DataAnnotations;

namespace AssetManager.Application.Features.Products.Queries;

public class GetProductQuery : IRequest<GetProductsResponse>
{
    [Required]
    public string ProductId { get; set; }

}
