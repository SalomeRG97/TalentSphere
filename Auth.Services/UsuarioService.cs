﻿using Auth.DTO;
using DTO.ServiceCall;
using Auth.Entities.Models;
using Auth.Interfaces.Repositories.Base;
using Auth.Interfaces.Services;
using AutoMapper;
using Exceptions;

namespace Auth.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UsuarioService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<UsuarioDTO>> GetAll()
        {
            var data = await _unitOfWork.UsuarioRepository.GetAllAsync();
            return _mapper.Map<List<UsuarioDTO>>(data);
        }
        public async Task Add(RequestActivarEmpleado dto)
        {
            try
            {
                var user = new UsuarioDTO
                {
                    NumeroDocumento = dto.NumeroDocumento,
                    Correo = dto.CorreoEmpresarial,
                    Contrasenna = "dfsdfsdf",
                    Role = dto.CargoId,
                    CodigoValidacion = "65365",
                    ExpiracionCodigo = DateTime.Now
                };
                var data = await _unitOfWork.UsuarioRepository.GetOne(x => x.NumeroDocumento == user.NumeroDocumento);
                if (data != null)
                {
                    throw new BadRequestException("Ya existe un usuario con el número de documento especificado.");
                }
                var entity = _mapper.Map<Usuario>(user);
                await _unitOfWork.UsuarioRepository.AddAsync(entity);
                await _unitOfWork.Commit();
            }
            catch (BadRequestException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new InternalServerErrorException("Ha ocurrido un error inesperado, intente de nuevo más tarde. Si el error persiste, contacte con soporte.");
            }

        }
        //public async Task Update(ArlDTO dto)
        //{
        //    var data = await _unitOfWork.ArlRepository.GetOne(x => x.Id == dto.Id);
        //    if (data == null)
        //    {
        //        return;
        //    }
        //    var entity = _mapper.Map(dto, data);
        //    _unitOfWork.ArlRepository.UpdateAsync(entity);
        //    await _unitOfWork.Commit();
        //}
        //public async Task Delete(ArlDTO dto)
        //{
        //    var data = await _unitOfWork.ArlRepository.GetOne(x => x.Id == dto.Id);
        //    if (data == null)
        //    {
        //        return;
        //    }
        //    var entity = _mapper.Map<Arl>(dto);
        //    _unitOfWork.ArlRepository.DeleteAsync(entity);
        //    await _unitOfWork.Commit();
        //}
    }
}
