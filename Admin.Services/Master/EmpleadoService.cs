using AutoMapper;
using Admin.DTO;
using Admin.Interfaces.Base;
using Admin.Interfaces.Service.Master;
using Admin.Entities.Models;
using Admin.DTO.Maestros;
using System;
using Mysqlx;
using System.Diagnostics;

namespace Admin.Services.Master
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public EmpleadoService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<List<EmpleadoDTO>> GetAll()
        {
            var data = await _unitOfWork.EmpleadoRepository.GetAllAsync();
            return _mapper.Map<List<EmpleadoDTO>>(data);
        }
        public async Task Add(RequestCreateEmpleado request)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                try
                {
                    var data = await _unitOfWork.EmpleadoRepository.GetOne(x => x.NumeroDocumento == request.Empleado.NumeroDocumento);
                    if (data != null)
                    {
                        return;
                    }
                    var empleado = _mapper.Map<Empleado>(request.Empleado);
                    empleado.Guid = Guid.NewGuid().ToString();
                    empleado.Created = DateTime.Now;
                    empleado.ModifiedBy = "Salome Ruiz Gallego";
                    empleado.ModifiedDate = DateTime.Now;
                    empleado.Status = true;
                    await _unitOfWork.EmpleadoRepository.AddAsync(empleado);
                    await _unitOfWork.Commit();

                    var contrato = _mapper.Map<ContratosLaborale>(request.Contrato);
                    contrato.EmpleadoId = empleado.Id;
                    await _unitOfWork.ContratoLaboralRepository.AddAsync(contrato);
                    await _unitOfWork.Commit();

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
        }
        public async Task Update(EmpleadoDTO dto)
        {
            var data = await _unitOfWork.EmpleadoRepository.GetOne(x => x.Id == dto.Id);
            if (data == null)
            {
                return;
            }
            var entity = _mapper.Map(dto, data);
            _unitOfWork.EmpleadoRepository.UpdateAsync(entity);
            await _unitOfWork.Commit();
        }
        public async Task Delete(EmpleadoDTO dto)
        {
            var data = await _unitOfWork.EmpleadoRepository.GetOne(x => x.Id == dto.Id);
            if (data == null)
            {
                return;
            }
            var entity = _mapper.Map<Empleado>(dto);
            _unitOfWork.EmpleadoRepository.DeleteAsync(entity);
            await _unitOfWork.Commit();
        }
    }
}
