using MediatR;

namespace AssetManager.Application.Features.Products.Queries;

public class GetAllProductSquery: IRequest<IEnumerable<GetProductsResponse>>
{
}
