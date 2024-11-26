using AutoMapper;
using DoAnTedu.Dtos.Custermers;
using DoAnTedu.Models;

namespace DoAnTedu.Mapping
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, UpdateCustomer>().ReverseMap();
            CreateMap<Customer, UpdateCustomerMapper>().ReverseMap(); 
            CreateMap<crD1, UpdatecrD1>().ReverseMap();
            CreateMap<crD2, UpdatecrD2>().ReverseMap();
            CreateMap<crD3, UpdatecrD3>().ReverseMap();
            CreateMap<crD4, UpdatecrD4>().ReverseMap();
            CreateMap<crD5, UpdatecrD5>().ReverseMap();
        }
    }
}
