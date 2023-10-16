using API.DTOs;
using AutoMapper;
using Core.Entitites;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    public class ProductUrlRes : IValueResolver<Product, ProductRetDTO, string>
    {
        private readonly IConfiguration _config;
        public ProductUrlRes(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Product source, ProductRetDTO destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _config["ApiUrl"] + source.PictureUrl;
            }
            return null;
        }
    }
}