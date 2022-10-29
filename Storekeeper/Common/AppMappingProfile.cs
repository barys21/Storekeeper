using AutoMapper;
using Storekeeper.Dtos.Products;
using Storekeeper.Models;
using Storekeeper.ViewModels.Products;

namespace Storekeeper.Common
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            // Product
            CreateMap<Product, CreateProductViewModel>().ReverseMap();
            CreateMap<Product, EditProductViewModel>().ReverseMap();
            CreateMap<Product, WriteOffViewModel>().ReverseMap();
            CreateMap<WriteOffInput, WriteOffViewModel>().ReverseMap();
            CreateMap<MoveInput, MoveViewModel>().ReverseMap();
            CreateMap<Product, MoveViewModel>().ReverseMap();
        }
    }
}
