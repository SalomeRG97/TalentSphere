using AutoMapper;
using DTO.ServiceCall;
using Admin.Interfaces.Base;
using Admin.Interfaces.Service.Master;
using Admin.Entities.Models;
using Admin.DTO.Maestros;
using Admin.Interfaces.Utilities.ApiAuth;
using Exceptions;

namespace Admin.Services.Master
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApiAuthService _apiAuthService;

        public EmpleadoService(IMapper mapper, IUnitOfWork unitOfWork, IApiAuthService apiAuthService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _apiAuthService = apiAuthService;
        }
        public async Task<List<RequestCreateEmpleado>> GetAll()
        {
            var empleadosData = await _unitOfWork.EmpleadoRepository.GetAllAsync();
            var contratosData = await _unitOfWork.ContratoLaboralRepository.GetAllAsync();

            var empleados = _mapper.Map<List<CreateEmpleadoDTO>>(empleadosData);
            var contratos = _mapper.Map<List<CreateContratoLaboralDTO>>(contratosData);

            var contratosPorEmpleadoId = contratos.ToDictionary(c => c.EmpleadoId);

            var result = new List<RequestCreateEmpleado>();

            foreach (var empleado in empleados)
            {
                if (contratosPorEmpleadoId.TryGetValue(empleado.Id, out var contrato))
                {
                    var requestCreateEmpleado = new RequestCreateEmpleado
                    {
                        Empleado = empleado,
                        Contrato = contrato
                    };
                    result.Add(requestCreateEmpleado);
                }
            }
            return result;
        }
        public async Task CreateEmpleado(RequestCreateEmpleado request)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                try
                {
                    var data = await _unitOfWork.EmpleadoRepository.GetOne(x => x.NumeroDocumento == request.Empleado.NumeroDocumento);
                    if (data != null)
                    {
                        throw new BadRequestException("Ya existe un empleado con el número de documento especificado.");
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

                    var darAltaEmpleado = new RequestActivarEmpleado
                    {
                        CorreoEmpresarial = empleado.CorreoEmpresarial,
                        CargoId = contrato.CargoId,
                        NumeroDocumento = empleado.NumeroDocumento
                    };
                    await _apiAuthService.ActivarEmpleado(darAltaEmpleado);

                    transaction.Commit();
                }
                catch (BadRequestException ex)
                {
                    transaction.Rollback();
                    throw;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw new InternalServerErrorException("Ha ocurrido un error inesperado, intente de nuevo mas tarde, si el error persiste contacte con soporte.");
                }
            }
        }
        public async Task UpdateEmpleado(RequestCreateEmpleado request)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                try
                {
                    var dataE = await _unitOfWork.EmpleadoRepository.GetOne(x => x.NumeroDocumento == request.Empleado.NumeroDocumento);
                    if (dataE == null)
                    {
                        throw new BadRequestException("No existe un empleado con el número de documento especificado.");
                    }
                    var empleado = _mapper.Map(request.Empleado, dataE);
                    empleado.ModifiedBy = "Salome Ruiz Gallego";
                    empleado.ModifiedDate = DateTime.Now;
                    await _unitOfWork.EmpleadoRepository.UpdateAsync(empleado);
                    await _unitOfWork.Commit();

                    var dataC = await _unitOfWork.ContratoLaboralRepository.GetOne(x => x.EmpleadoId == request.Contrato.EmpleadoId);
                    if (dataC == null)
                    {
                        return;
                    }
                    var contrato = _mapper.Map(request.Contrato, dataC);
                    await _unitOfWork.ContratoLaboralRepository.UpdateAsync(contrato);
                    await _unitOfWork.Commit();
                    if (empleado.Status == false)
                    {
                        var darBajaEmpleado = new RequestDesactivarEmpleado
                        {
                            NumeroDocumento = empleado.NumeroDocumento,
                            FechaDesactivacion = DateTime.Now
                        };
                        await _apiAuthService.DarBajaEmpleado(darBajaEmpleado);
                    }

                    transaction.Commit();
                }
                catch (BadRequestException ex)
                {
                    transaction.Rollback();
                    throw;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw new InternalServerErrorException("Ha ocurrido un error inesperado, intente de nuevo mas tarde, si el error persiste contacte con soporte.");
                }
            }
        }
        public async Task Delete(EmpleadoDTO dto)
        {
            var data = await _unitOfWork.EmpleadoRepository.GetOne(x => x.Id == dto.Id);
            if (data == null)
            {
                throw new BadRequestException("No existe un empleado con el número de documento especificado.");
            }
            var entity = _mapper.Map<Empleado>(dto);
            _unitOfWork.EmpleadoRepository.DeleteAsync(entity);
            await _unitOfWork.Commit();
        }
    }
}
