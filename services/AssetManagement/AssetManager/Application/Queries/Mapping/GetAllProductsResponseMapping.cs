using AssetManager.Application.Queries.Responses;
using AssetManager.Domain;
using AutoMapper;

namespace AssetManager.Application.Queries.Mapping_Profiles;

public class GetAllProductsResponseMapping: Profile
{
    public GetAllProductsResponseMapping() => CreateMap<Product, GetProductsResponse>();
}
