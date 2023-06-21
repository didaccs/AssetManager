using AssetManager.Application.Queries.Responses;
using AssetManager.Infrastructure.Persistence;
using MediatR;
using AssetManager.Common.Exceptions;
using AssetManager.Domain;
using AutoMapper;
using Common.AutoMapper;

namespace AssetManager.Application.Queries.Handlers;

public class GetProductHandler : IRequestHandler<GetProductQuery, GetProductsResponse>
{
    private readonly AssesmentDbContext _context;
    private readonly IMapper _mapper;
    private readonly HashIdToIntegerValueResolver _resolver;

    public GetProductHandler(AssesmentDbContext context, IMapper mapper, HashIdToIntegerValueResolver resolver)
    {
        _context = context;
        _mapper = mapper;
        _resolver = resolver;
    }

    public async Task<GetProductsResponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FindAsync(_resolver.Convert(request.ProductId, null));

        if (product == null)
            throw new NotFoundException(nameof(Product), request.ProductId.ToString());

        return _mapper.Map<GetProductsResponse>(product);
    }
}
