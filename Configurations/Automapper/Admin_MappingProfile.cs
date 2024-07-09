using AutoMapper;
using Admin.DTO;
using Admin.Entities.Models;

namespace Configuraciones.Automapper
{
    public class Admin_MappingProfile : Profile
    {
        public Admin_MappingProfile()
        {
            CreateMap<Arl, ArlDTO>().ReverseMap();
            CreateMap<Arl, ArlCreateDTO>().ReverseMap();
        }
    }
}
