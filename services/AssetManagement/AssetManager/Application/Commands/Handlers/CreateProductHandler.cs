using AssetManager.Domain;
using AssetManager.Infrastructure.Persistence;
using AutoMapper;
using MediatR;

namespace AssetManager.Application.Commands.Handlers
{
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
}
