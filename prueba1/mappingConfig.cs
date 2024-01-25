using AutoMapper;
using prueba1.Models;

namespace prueba1
{
    public class mappingConfig : Profile
    {
        public mappingConfig()
        {
            CreateMap<Customer, CustomerCreateDto>();
            CreateMap<CustomerCreateDto, Customer>();
        }
    }
}
