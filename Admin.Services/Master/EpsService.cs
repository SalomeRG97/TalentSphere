using AutoMapper;
using Admin.DTO;
using Admin.Interfaces.Base;
using Admin.Interfaces.Service.Master;
using Admin.Entities.Models;

namespace Admin.Services.Master
{
    public class EpsService : IEpsService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public EpsService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<EpsDTO>> GetAll()
        {
            var data = await _unitOfWork.EpsRepository.GetAllAsync();
            return _mapper.Map<List<EpsDTO>>(data);
        }
        public async Task Add(EpsCreateDTO dto)
        {
            var data = await _unitOfWork.EpsRepository.GetOne(x => x.Nombre == dto.Nombre);
            if (data != null)
            {
                return;
            }
            var entity = _mapper.Map<Ep>(dto);
            _unitOfWork.EpsRepository.AddAsync(entity);
            await _unitOfWork.Commit();
        }
        public async Task Update(EpsDTO dto)
        {
            var data = await _unitOfWork.EpsRepository.GetOne(x => x.Id == dto.Id);
            if (data == null)
            {
                return;
            }
            var entity = _mapper.Map(dto, data);
            _unitOfWork.EpsRepository.UpdateAsync(entity);
            await _unitOfWork.Commit();
        }
        public async Task Delete(EpsDTO dto)
        {
            var data = await _unitOfWork.EpsRepository.GetOne(x => x.Id == dto.Id);
            if (data == null)
            {
                return;
            }
            var entity = _mapper.Map<Ep>(dto);
            _unitOfWork.EpsRepository.DeleteAsync(entity);
            await _unitOfWork.Commit();
        }
    }
}
