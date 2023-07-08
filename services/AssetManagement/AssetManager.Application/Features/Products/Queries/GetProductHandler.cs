using AssetManager.Application.Infrastructure.Persistence;
using MediatR;
using AssetManager.Common.Exceptions;
using AssetManager.Application.Domain;
using AutoMapper;
using AssetManager.Common.AutoMapper;

namespace AssetManager.Application.Features.Products.Queries;

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
