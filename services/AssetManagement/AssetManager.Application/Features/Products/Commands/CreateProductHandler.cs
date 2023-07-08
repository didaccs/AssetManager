using AssetManager.Application.Domain;
using AssetManager.Application.Infrastructure.Persistence;
using AutoMapper;
using MediatR;

namespace AssetManager.Application.Features.Products.Commands;

public class CreateProductHandler : IRequestHandler<CreateProductCommand>
{
    private readonly AssesmentDbContext _context;
    private readonly IMapper _mapper;

    public CreateProductHandler(AssesmentDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(request);

        _context.Products.Add(product);
        
        await _context.SaveChangesAsync();
    }
}
