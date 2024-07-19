using AutoMapper;
using Admin.DTO;
using Admin.Interfaces.Base;
using Admin.Interfaces.Service.Master;
using Admin.Entities.Models;
using Interfaces.Utilities;
using Exceptions;

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
    public async Task UploadFileEmpleado(FilesRecordDTO dto, byte[] file)
    {
        using (var transaction = _unitOfWork.BeginTransaction())
        {
            try
            {
                var newEntity = _mapper.Map<FileRecord>(dto);
                await _unitOfWork.FilesRecordRepository.AddAsync(newEntity);
                await _unitOfWork.Commit();

                var dataC = await _unitOfWork.ContratoLaboralRepository.GetByDocument(dto.IdentificadorEmpleado);
                if (dataC == null)
                {
                    throw new BadRequestException("No existe un empleado con el número de identificación especificado.");
                }
                if (dto.ContentType == 1)
                {
                    dataC.HojaVidaRef = dto.Nombre;
                }
                else
                {
                    dataC.SoportesRef = dto.Nombre;
                }

                var contrato = _mapper.Map<ContratosLaborale>(dataC);
                await _unitOfWork.ContratoLaboralRepository.UpdateAsync(contrato);
                await _unitOfWork.Commit();
                await _manejadorArchivosLocal.GuardarEnRuta(dto.Ruta, file);

                var existingFile = await _unitOfWork.FilesRecordRepository.GetOne(x => x.IdentificadorEmpleado == dto.IdentificadorEmpleado && x.ContentType == dto.ContentType);

                if (existingFile != null)
                {
                    _unitOfWork.FilesRecordRepository.DeleteAsync(existingFile);
                    await _unitOfWork.Commit();
                    _manejadorArchivosLocal.DeleteFile(existingFile.Ruta);
                }

                transaction.Commit();
            }
            catch (BadRequestException ex)
            {
                transaction.Rollback();
                throw ex;
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw new InternalServerErrorException("Ha ocurrido un error inesperado, intente de nuevo mas tarde, si el error persiste contacte con soporte.");
            }
        }
    }
}
