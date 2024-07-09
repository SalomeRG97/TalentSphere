using AutoMapper;
using Admin.DTO;
using Admin.Interfaces.Base;
using Admin.Interfaces.Service.Master;
using Admin.Entities.Models;

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
        public async Task Add(EmpleadoCreateDTO dto)
        {
            var data = await _unitOfWork.EmpleadoRepository.GetOne(x => x.NumeroDocumento == dto.NumeroDocumento);
            if (data != null)
            {
                return;
            }
            var entity = _mapper.Map<Empleado>(dto);
            _unitOfWork.EmpleadoRepository.AddAsync(entity);
            await _unitOfWork.Commit();
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
