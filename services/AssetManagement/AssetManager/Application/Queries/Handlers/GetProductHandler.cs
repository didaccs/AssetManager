using AssetManager.Application.Queries.Responses;
using AssetManager.Infrastructure.Persistence;
using MediatR;

namespace AssetManager.Application.Queries.Handlers
{
    public class GetProductHandler : IRequestHandler<GetProductQuery, GetProductsResponse>
    {
        private readonly AssesmentDbContext _context;

        public GetProductHandler(AssesmentDbContext context)
        {
            _context = context;
        }

        public async Task<GetProductsResponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FindAsync(request.ProductId);


            return new GetProductsResponse()
            {
                Category = product.Category,
                Id = product.Id,
                Name = product.Name
            };
        }
    }
}
