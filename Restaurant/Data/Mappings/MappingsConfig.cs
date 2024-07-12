using AutoMapper;
using Restaurant.Data.ViewModel;
using Restaurant.Data.Models;

namespace Restaurant.Data.Mappings
{
    public class MappingsConfig:Profile
    {

        public MappingsConfig()
        {
            CreateMap<Category, CategoryViewModel>().ReverseMap();
        }
    }
}
