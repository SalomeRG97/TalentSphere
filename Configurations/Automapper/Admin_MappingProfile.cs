using AutoMapper;
using Admin.DTO;
using Admin.Entities.Models;
using Admin.DTO.Maestros;
using DTO.Jobs;

namespace Configuraciones.Automapper
{
    public class Admin_MappingProfile : Profile
    {
        public Admin_MappingProfile()
        {
            CreateMap<Arl, ArlDTO>().ReverseMap();
            CreateMap<Arl, ArlCreateDTO>().ReverseMap();
            CreateMap<Ceco, CecoDTO>().ReverseMap();
            CreateMap<Ceco, CecoCreateDTO>().ReverseMap();
            CreateMap<Cargo, CargoDTO>().ReverseMap();
            CreateMap<Cargo, CargoCreateDTO>().ReverseMap();
            CreateMap<ContratosLaborale, TipoContratoDTO>().ReverseMap();
            CreateMap<ContratosLaborale, TipoContratoCreateDTO>().ReverseMap();
            CreateMap<Ep, EpsDTO>().ReverseMap();
            CreateMap<Ep, EpsCreateDTO>().ReverseMap();
            CreateMap<FondosPensione, FondoPensionCreateDTO>().ReverseMap();
            CreateMap<FondosPensione, FondoPensionDTO>().ReverseMap();
            CreateMap<Servicio, ServicioCreateDTO>().ReverseMap();
            CreateMap<Servicio, ServicioDTO>().ReverseMap();
            CreateMap<TiposContrato, TipoContratoCreateDTO>().ReverseMap();
            CreateMap<TiposContrato, TipoContratoDTO>().ReverseMap();
            CreateMap<FileRecord, FilesRecordCreateDTO>().ReverseMap();
            CreateMap<FileRecord, FilesRecordDTO>().ReverseMap();
            CreateMap<Empleado, EmpleadoDTO>().ReverseMap();
            CreateMap<Empleado, CreateEmpleadoDTO>().ReverseMap();
            CreateMap<ContratosLaborale, CreateContratoLaboralDTO>().ReverseMap();
            CreateMap<BacklogsEvent, BacklogsEventDTO>().ReverseMap();
        }
    }
}
