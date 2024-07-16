using AutoMapper;
using Admin.DTO;
using Admin.Interfaces.Base;
using Admin.Interfaces.Service.Master;
using Admin.Entities.Models;

namespace Admin.Services.Master;

public class FilesRecordService : IFilesRecordService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public FilesRecordService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<FilesRecordDTO>> GetAll()
    {
        var data = await _unitOfWork.FilesRecordRepository.GetAllAsync();
        return _mapper.Map<List<FilesRecordDTO>>(data);
    }
    public async Task UploadFileEmpleado(int id, FilesRecordCreateDTO dto)
    {
        var data = await _unitOfWork.FilesRecordRepository.GetOne(x => x.Nombre == dto.Nombre);
        if (data != null)
        {
            return;
        }
        var entity = _mapper.Map<FilesRecord>(dto);
        _unitOfWork.FilesRecordRepository.AddAsync(entity);
        await _unitOfWork.Commit();
    }
    public async Task Update(FilesRecordDTO dto)
    {
        var data = await _unitOfWork.FilesRecordRepository.GetOne(x => x.Id == dto.Id);
        if (data == null)
        {
            return;
        }
        var entity = _mapper.Map(dto, data);
        _unitOfWork.FilesRecordRepository.UpdateAsync(entity);
        await _unitOfWork.Commit();
    }
    public async Task Delete(FilesRecordDTO dto)
    {
        var data = await _unitOfWork.FilesRecordRepository.GetOne(x => x.Id == dto.Id);
        if (data == null)
        {
            return;
        }
        var entity = _mapper.Map<FilesRecord>(dto);
        _unitOfWork.FilesRecordRepository.DeleteAsync(entity);
        await _unitOfWork.Commit();
    }
}
