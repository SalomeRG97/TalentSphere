using AutoMapper;
using Admin.DTO;
using Admin.Interfaces.Base;
using Admin.Interfaces.Service.Master;
using Admin.Entities.Models;

namespace Admin.Services.Master
{
    public class TipoContratoService : ITipoContratoService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TipoContratoService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<TipoContratoDTO>> GetAll()
        {
            var data = await _unitOfWork.TipoContratoRepository.GetAllAsync();
            return _mapper.Map<List<TipoContratoDTO>>(data);
        }
        public async Task Add(TipoContratoCreateDTO dto)
        {
            var data = await _unitOfWork.TipoContratoRepository.GetOne(x => x.Nombre == dto.Nombre);
            if (data != null)
            {
                return;
            }
            var entity = _mapper.Map<TiposContrato>(dto);
            _unitOfWork.TipoContratoRepository.AddAsync(entity);
            await _unitOfWork.Commit();
        }
        public async Task Update(TipoContratoDTO dto)
        {
            var data = await _unitOfWork.TipoContratoRepository.GetOne(x => x.Id == dto.Id);
            if (data == null)
            {
                return;
            }
            var entity = _mapper.Map(dto, data);
            _unitOfWork.TipoContratoRepository.UpdateAsync(entity);
            await _unitOfWork.Commit();
        }
        public async Task Delete(TipoContratoDTO dto)
        {
            var data = await _unitOfWork.TipoContratoRepository.GetOne(x => x.Id == dto.Id);
            if (data == null)
            {
                return;
            }
            var entity = _mapper.Map<TiposContrato>(dto);
            _unitOfWork.TipoContratoRepository.DeleteAsync(entity);
            await _unitOfWork.Commit();
        }
    }
}
