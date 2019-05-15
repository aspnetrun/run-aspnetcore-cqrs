using AspnetRun.Application.Models;
using AspnetRun.Core.Entities;
using AutoMapper;

namespace AspnetRun.Application.Mapper
{
    public class ObjectMapper
    {
        public static IMapper Mapper => AutoMapper.Mapper.Instance;

        static ObjectMapper()
        {
            CreateMap();
        }

        private static void CreateMap()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Product, ProductModel>().ReverseMap();
                cfg.CreateMap<Category, CategoryModel>().ReverseMap();
            });
        }
    }
}
