using AssetManager.Domain;
using AutoMapper;

namespace AssetManager.Application.Commands.Mapping;

public class CreateProductCommandMapping: Profile
{
    public CreateProductCommandMapping() =>
        CreateMap<CreateProductCommand, Product>();
}
