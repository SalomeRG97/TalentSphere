using AutoMapper;
using Admin.DTO;
using Admin.Interfaces.Base;
using Admin.Interfaces.Service.Master;
using Admin.Entities.Models;

namespace Admin.Services.Master
{
    public class CargoService : ICargoService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CargoService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<List<CargoDTO>> GetAll()
        {
            var data = await _unitOfWork.CargoRepository.GetAllAsync();
            return _mapper.Map<List<CargoDTO>>(data);
        }
        public async Task Add(CargoCreateDTO dto)
        {
            var data = await _unitOfWork.CargoRepository.GetOne(x => x.Nombre == dto.Nombre);
            if (data != null)
            {
                return;
            }
            var entity = _mapper.Map<Cargo>(dto);
            _unitOfWork.CargoRepository.AddAsync(entity);
            await _unitOfWork.Commit();
        }
        public async Task Update(CargoDTO dto)
        {
            var data = await _unitOfWork.CargoRepository.GetOne(x => x.Id == dto.Id);
            if (data == null)
            {
                return;
            }
            var entity = _mapper.Map(dto, data);
            _unitOfWork.CargoRepository.UpdateAsync(entity);
            await _unitOfWork.Commit();
        }
        public async Task Delete(CargoDTO dto)
        {
            var data = await _unitOfWork.CargoRepository.GetOne(x => x.Id == dto.Id);
            if (data == null)
            {
                return;
            }
            var entity = _mapper.Map<Cargo>(dto);
            _unitOfWork.CargoRepository.DeleteAsync(entity);
            await _unitOfWork.Commit();
        }
    }
}
