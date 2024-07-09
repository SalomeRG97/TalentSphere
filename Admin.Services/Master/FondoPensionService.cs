using AutoMapper;
using Admin.DTO;
using Admin.Interfaces.Base;
using Admin.Interfaces.Service.Master;
using Admin.Entities.Models;

namespace Admin.Services.Master
{
    public class FondoPensionService : IFondoPensionService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public FondoPensionService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<FondoPensionDTO>> GetAll()
        {
            var data = await _unitOfWork.FondoPensionRepository.GetAllAsync();
            return _mapper.Map<List<FondoPensionDTO>>(data);
        }
        public async Task Add(FondoPensionCreateDTO dto)
        {
            var data = await _unitOfWork.FondoPensionRepository.GetOne(x => x.Nombre == dto.Nombre);
            if (data != null)
            {
                return;
            }
            var entity = _mapper.Map<FondosPensione>(dto);
            _unitOfWork.FondoPensionRepository.AddAsync(entity);
            await _unitOfWork.Commit();
        }
        public async Task Update(FondoPensionDTO dto)
        {
            var data = await _unitOfWork.FondoPensionRepository.GetOne(x => x.Id == dto.Id);
            if (data == null)
            {
                return;
            }
            var entity = _mapper.Map(dto, data);
            _unitOfWork.FondoPensionRepository.UpdateAsync(entity);
            await _unitOfWork.Commit();
        }
        public async Task Delete(FondoPensionDTO dto)
        {
            var data = await _unitOfWork.FondoPensionRepository.GetOne(x => x.Id == dto.Id);
            if (data == null)
            {
                return;
            }
            var entity = _mapper.Map<FondosPensione>(dto);
            _unitOfWork.FondoPensionRepository.DeleteAsync(entity);
            await _unitOfWork.Commit();
        }
    }
}
