using AutoMapper;
using Microsoft.Extensions.Configuration;
using Common.HashIds;
using AssetManager.Common.Exceptions;

namespace Common.AutoMapper
{
    public class HashIdToIntegerMemberValueResolver : IMemberValueResolver<object, object, string, int>
    {
        private readonly IConfiguration _configuration;

        public HashIdToIntegerMemberValueResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public int Resolve(object source, object destination, string sourceMember, int destMember, ResolutionContext context)
        {
            var hashSecurityKey = _configuration.GetValue<string>("App:hashSecurityKey");
            if (string.IsNullOrEmpty(hashSecurityKey))
                throw new AppConfigurationException();

            return sourceMember.FromHashId(hashSecurityKey);
        }
    }
}
