using AutoMapper;
using Auth.DTO;
using Auth.Entities.Models;

namespace Configuraciones.Automapper
{
    public class Auth_MappingProfile : Profile
    {
        public Auth_MappingProfile()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();

        }
    }
}
