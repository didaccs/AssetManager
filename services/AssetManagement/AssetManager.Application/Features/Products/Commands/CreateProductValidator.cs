using FluentValidation;

namespace AssetManager.Application.Features.Products.Commands;

public class CreateProductValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductValidator()
    {
        RuleFor(r => r.Name).NotEmpty();
        RuleFor(r => r.Category).NotEmpty();
    }
}
