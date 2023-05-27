using AssetManager.Domain;
using AssetManager.Infrastructure.Persistence;
using MediatR;

namespace AssetManager.Application.Commands.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly AssesmentDbContext _context;

        public CreateProductHandler(AssesmentDbContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Category = request.Category,
                Name = request.Name
            };

            _context.Products.Add(product);
            
            await _context.SaveChangesAsync();
        }
    }
}
