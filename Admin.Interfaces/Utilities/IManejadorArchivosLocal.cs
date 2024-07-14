using Admin.DTO;

namespace Admin.Interfaces.Utilities
{
    public interface IManejadorArchivosLocal
    {
        Task<FilesRecordCreateDTO> GuardarArchivo(byte[] contenido, string nombreArchivo, string contentType, string bucket);
        Task<byte[]> ObtenerArchivo(string bucket, string nombreArchivo);
        Task<string> ObtenerArchivoEnBase64(string bucket, string nombreArchivo);
    }
}