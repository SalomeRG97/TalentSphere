using AutoMapper;
using Admin.DTO;
using Admin.Interfaces.Base;
using Admin.Interfaces.Service.Master;
using Admin.Entities.Models;

namespace Admin.Services.Master
{
    public class CecoService : ICecoService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CecoService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<CecoDTO>> GetAll()
        {
            var data = await _unitOfWork.CecoRepository.GetAllAsync();
            return _mapper.Map<List<CecoDTO>>(data);
        }
        public async Task Add(CecoCreateDTO dto)
        {
            var data = await _unitOfWork.CecoRepository.GetOne(x => x.Nombre == dto.Nombre);
            if (data != null)
            {
                return;
            }
            var entity = _mapper.Map<Ceco>(dto);
            _unitOfWork.CecoRepository.AddAsync(entity);
            await _unitOfWork.Commit();
        }
        public async Task Update(CecoDTO dto)
        {
            var data = await _unitOfWork.CecoRepository.GetOne(x => x.Id == dto.Id);
            if (data == null)
            {
                return;
            }
            var entity = _mapper.Map(dto, data);
            _unitOfWork.CecoRepository.UpdateAsync(entity);
            await _unitOfWork.Commit();
        }
        public async Task Delete(CecoDTO dto)
        {
            var data = await _unitOfWork.CecoRepository.GetOne(x => x.Id == dto.Id);
            if (data == null)
            {
                return;
            }
            var entity = _mapper.Map<Ceco>(dto);
            _unitOfWork.CecoRepository.DeleteAsync(entity);
            await _unitOfWork.Commit();
        }
    }
}
