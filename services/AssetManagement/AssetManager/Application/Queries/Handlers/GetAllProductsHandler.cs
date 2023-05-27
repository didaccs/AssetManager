using AssetManager.Application.Queries.Responses;
using AssetManager.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AssetManager.Application.Queries.Handlers
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductSquery, IEnumerable<GetProductsResponse>>
    {
        private readonly AssesmentDbContext _context;

        public GetAllProductsHandler(AssesmentDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetProductsResponse>> Handle(GetAllProductSquery request, CancellationToken cancellationToken)
        {
            var products = await _context.Products.ToListAsync();

            return products.Select(p =>
            new GetProductsResponse()
            {
                Category = p.Category,
                Id = p.Id,
                Name = p.Name
            });
        }
    }
}
