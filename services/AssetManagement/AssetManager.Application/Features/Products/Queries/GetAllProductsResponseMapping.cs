using AssetManager.Application.Domain;
using AutoMapper;
using AssetManager.Common.AutoMapper;

namespace AssetManager.Application.Features.Products.Queries;

public class GetAllProductsResponseMapping: Profile
{
    public GetAllProductsResponseMapping() =>
        CreateMap<Product, GetProductsResponse>()
        .ForMember(s => s.Id, opt => opt.MapFrom<IntegerToHashIdMemberValueResolver, int>(s=> s.Id));
}
