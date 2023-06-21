using AssetManager.Application.Queries.Responses;
using AssetManager.Domain;
using AutoMapper;
using Common.AutoMapper;

namespace AssetManager.Application.Queries.Mapping_Profiles;

public class GetAllProductsResponseMapping: Profile
{
    public GetAllProductsResponseMapping() =>
        CreateMap<Product, GetProductsResponse>()
        .ForMember(s => s.Id, opt => opt.MapFrom<IntegerToHashIdMemberValueResolver, int>(s=> s.Id));
}
