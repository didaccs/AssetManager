using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Common.HashIds;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetManager.Common.Exceptions;

namespace Common.AutoMapper
{
    public class IntegerToHashIdValueResolver : IMemberValueResolver<object, object, int, string>
    {
        private readonly IConfiguration _configuration;

        public IntegerToHashIdValueResolver(IConfiguration configuration)
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
