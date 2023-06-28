using AssetManager.Common.Exceptions;
using AutoMapper;
using AssetManager.Common.HashIds;
using Microsoft.Extensions.Configuration;

namespace AssetManager.Common.AutoMapper
{
    public class HashIdToIntegerValueResolver : IValueConverter<string, int>
    {
        private readonly IConfiguration _configuration;

        public HashIdToIntegerValueResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public int Convert(string source, ResolutionContext context)
        {
            var hashSecurityKey = _configuration.GetValue<string>("App:hashSecurityKey");
            if (string.IsNullOrEmpty(hashSecurityKey))
                throw new AppConfigurationException();

            return source.FromHashId(hashSecurityKey);
        }
    }
}