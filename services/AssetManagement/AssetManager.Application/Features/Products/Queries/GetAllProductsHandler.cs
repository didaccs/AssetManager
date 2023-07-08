using AssetManager.Application.Infrastructure.Persistence;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AssetManager.Application.Features.Products.Queries;

public class GetAllProductsHandler : IRequestHandler<GetAllProductSquery, IEnumerable<GetProductsResponse>>
{
    private readonly AssesmentDbContext _context;
    private readonly IMapper _mapper;

    public GetAllProductsHandler(AssesmentDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetProductsResponse>> Handle(GetAllProductSquery request, CancellationToken cancellationToken)
    {
        var products = await _context.Products
                            .AsNoTracking()
                            .ToListAsync();

        return _mapper.Map<IEnumerable<GetProductsResponse>>(products);
    }
}
