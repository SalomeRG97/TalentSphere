using AutoMapper;
using Admin.DTO;
using Admin.Interfaces.Base;
using Admin.Interfaces.Service.Master;
using Admin.Entities.Models;
using Admin.Interfaces.Utilities;
using Microsoft.AspNetCore.Http;

namespace Admin.Services.Master;

public class FilesRecordService : IFilesRecordService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IManejadorArchivosLocal _manejadorArchivosLocal;

    public FilesRecordService(IMapper mapper, IUnitOfWork unitOfWork, IManejadorArchivosLocal manejadorArchivosLocal)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _manejadorArchivosLocal = manejadorArchivosLocal;
    }

    public async Task<List<FilesRecordDTO>> GetAll()
    {
        var data = await _unitOfWork.FilesRecordRepository.GetAllAsync();
        return _mapper.Map<List<FilesRecordDTO>>(data);
    }
    public async Task Create(FilesRecordDTO dto)
    {
        var existingFile = await _unitOfWork.FilesRecordRepository.GetOne(x =>
            x.IdentificadorEmpleado == dto.IdentificadorEmpleado && x.ContentType == dto.ContentType);

        if (existingFile != null)
        {
            _manejadorArchivosLocal.DeleteFile(existingFile.Ruta);
            _unitOfWork.FilesRecordRepository.DeleteAsync(existingFile);
        }
        var newEntity = _mapper.Map<FileRecord>(dto);
        await _unitOfWork.FilesRecordRepository.AddAsync(newEntity);
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
        var entity = _mapper.Map<FileRecord>(dto);
        _unitOfWork.FilesRecordRepository.DeleteAsync(entity);
        await _unitOfWork.Commit();
    }
    public async Task UploadFileEmpleado(string IdentificadorEmpleado, int ContentType, IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return;
        }

        using var ms = new MemoryStream();
        await file.CopyToAsync(ms);
        var content = ms.ToArray();

        var data = await _manejadorArchivosLocal.GuardarArchivo(file.FileName, "documentos", IdentificadorEmpleado, ContentType);
        await Create(data);
        await _manejadorArchivosLocal.GuardarEnRuta(data.Ruta, content);
    }
}
