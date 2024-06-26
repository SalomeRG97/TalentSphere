using AutoMapper;
using Admin.DTO;
using Admin.Entities.Models;

namespace Admin.Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Arl, ArlDTO>();
            CreateMap<Arl, ArlCreateDTO>();
        }
    }
}
