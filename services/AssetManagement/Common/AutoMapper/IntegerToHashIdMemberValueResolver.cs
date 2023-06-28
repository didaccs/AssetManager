using AutoMapper;
using Microsoft.Extensions.Configuration;
using AssetManager.Common.HashIds;
using AssetManager.Common.Exceptions;

namespace AssetManager.Common.AutoMapper
{
    public class IntegerToHashIdMemberValueResolver : IMemberValueResolver<object, object, int, string>
    {
        private readonly IConfiguration _configuration;

        public IntegerToHashIdMemberValueResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Resolve(object source, object destination, int sourceMember, string destMember, ResolutionContext context)
        {
            var hashSecurityKey = _configuration.GetValue<string>("App:hashSecurityKey");
            if (string.IsNullOrEmpty(hashSecurityKey))
                throw new AppConfigurationException();

            return sourceMember.ToHashId(hashSecurityKey);
        }
    }
}
