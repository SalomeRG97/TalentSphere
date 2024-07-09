using AutoMapper;
using Admin.DTO;
using Admin.Interfaces.Base;
using Admin.Interfaces.Service.Master;
using Admin.Entities.Models;

namespace Admin.Services.Master
{
    public class ServicioService : IServicioService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ServicioService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<List<ServicioDTO>> GetAll()
        {
            var data = await _unitOfWork.ServicioRepository.GetAllAsync();
            return _mapper.Map<List<ServicioDTO>>(data);
        }
        public async Task Add(ServicioCreateDTO dto)
        {
            var data = await _unitOfWork.ServicioRepository.GetOne(x => x.Nombre == dto.Nombre);
            if (data != null)
            {
                return;
            }
            var entity = _mapper.Map<Servicio>(dto);
            _unitOfWork.ServicioRepository.AddAsync(entity);
            await _unitOfWork.Commit();
        }
        public async Task Update(ServicioDTO dto)
        {
            var data = await _unitOfWork.ServicioRepository.GetOne(x => x.Id == dto.Id);
            if (data == null)
            {
                return;
            }
            var entity = _mapper.Map(dto, data);
            _unitOfWork.ServicioRepository.UpdateAsync(entity);
            await _unitOfWork.Commit();
        }
        public async Task Delete(ServicioDTO dto)
        {
            var data = await _unitOfWork.ArlRepository.GetOne(x => x.Id == dto.Id);
            if (data == null)
            {
                return;
            }
            var entity = _mapper.Map<Servicio>(dto);
            _unitOfWork.ServicioRepository.DeleteAsync(entity);
            await _unitOfWork.Commit();
        }
    }
}
