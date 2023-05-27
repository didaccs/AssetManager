using AssetManager.Application.Queries.Responses;
using MediatR;

namespace AssetManager.Application.Queries
{
    public class GetAllProductSquery: IRequest<IEnumerable<GetProductsResponse>>
    {
    }
}
