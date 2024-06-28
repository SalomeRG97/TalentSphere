using AutoMapper;
using Admin.DTO;
using Admin.Interfaces;
using Admin.Entities.Models;

namespace Admin.Services
{
    public class ArlService : IArlService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ArlService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ArlDTO>> GetAll()
        {
            var data = await _unitOfWork.ArlRepository.GetAllAsync();
            return _mapper.Map<List<ArlDTO>>(data);
        }
        public async Task Add(ArlCreateDTO dto)
        {
            var data = await _unitOfWork.ArlRepository.GetOne(x => x.Nombre == dto.Nombre);
            if (data != null)
            {
                return;
            }
            var entity = _mapper.Map<Arl>(dto);
            _unitOfWork.ArlRepository.AddAsync(entity);
            await _unitOfWork.Commit();
        }
        public async Task Update(ArlDTO dto)
        {
            var data = await _unitOfWork.ArlRepository.GetOne(x => x.Id == dto.Id);
            if (data == null)
            {
                return;
            }
            var entity = _mapper.Map(dto, data);
            _unitOfWork.ArlRepository.UpdateAsync(entity);
            await _unitOfWork.Commit();
        }
        public async Task Delete(ArlDTO dto)
        {
            var data = await _unitOfWork.ArlRepository.GetOne(x => x.Id == dto.Id);
            if (data == null)
            {
                return;
            }
            var entity = _mapper.Map<Arl>(dto);
            _unitOfWork.ArlRepository.DeleteAsync(entity);
            await _unitOfWork.Commit();
        }
    }
}
