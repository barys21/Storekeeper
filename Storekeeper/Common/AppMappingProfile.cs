using AutoMapper;
using Storekeeper.Models;
using Storekeeper.ViewModels.Products;

namespace Storekeeper.Common
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<Product, CreateProductViewModel>().ReverseMap();
            CreateMap<Product, EditProductViewModel>().ReverseMap();
        }
    }
}
