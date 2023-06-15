using AutoMapper;
using EczacibasiHW1.Models.Entity;

namespace BookRentalApp.Models.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Book

            CreateMap<Book, Book>().ForMember(dest => dest.Id, opt => opt.Ignore());

            //Category

            CreateMap<Category, Category>().ForMember(dest => dest.Id, opt => opt.Ignore());

            //Customer

            CreateMap<Customer, Customer>().ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
