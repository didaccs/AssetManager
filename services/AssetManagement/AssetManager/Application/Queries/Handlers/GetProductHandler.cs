using AssetManager.Application.Queries.Responses;
using AssetManager.Infrastructure.Persistence;
using MediatR;
using AssetManager.Common.Exceptions;
using AssetManager.Domain;
using AutoMapper;

namespace AssetManager.Application.Queries.Handlers;

public class GetProductHandler : IRequestHandler<GetProductQuery, GetProductsResponse>
{
    private readonly AssesmentDbContext _context;
    private readonly IMapper _mapper;

    public GetProductHandler(AssesmentDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GetProductsResponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FindAsync(request.ProductId);

        if (product == null)
            throw new NotFoundException(nameof(Product), request.ProductId.ToString());

        return _mapper.Map<GetProductsResponse>(product);
    }
}
