using AssetManager.Application.Domain;
using AutoMapper;

namespace AssetManager.Application.Features.Products.Commands;

public class CreateProductCommandMapping: Profile
{
    public CreateProductCommandMapping() =>
        CreateMap<CreateProductCommand, Product>();
}
