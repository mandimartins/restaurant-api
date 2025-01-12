using AutoMapper;
using Restaurant.Data.Models;
using Restaurant.Data.ViewModel;
using Restaurant.Data.ViewModels;

namespace Restaurant.Data.Mappings
{
    public class MappingsConfig : Profile
    {
        public MappingsConfig()
        {
            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Menu, MenuViewModel>().ReverseMap();
        }
    }
}
