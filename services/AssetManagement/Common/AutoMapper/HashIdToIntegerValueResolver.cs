using AssetManager.Common.Exceptions;
using AutoMapper;
using Common.HashIds;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.AutoMapper
{
    public class HashIdToIntegerValueResolver : IValueResolver<string, int, int>
    {
        private readonly IConfiguration _configuration;

        public HashIdToIntegerValueResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public int Resolve(string source, int destination, int destMember, ResolutionContext context)
        {
            var hashSecurityKey = _configuration.GetValue<string>("App:hashSecurityKey");
            if (string.IsNullOrEmpty(hashSecurityKey))
                throw new AppConfigurationException();

            return source.FromHashId(hashSecurityKey);
        }
    }
}