﻿using AutoMapper;
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
            CreateMap<FilesRecord, FilesRecordCreateDTO>().ReverseMap();
            CreateMap<FilesRecord, FilesRecordDTO>().ReverseMap();
        }
    }
}
