using Admin.DTO;

namespace Admin.Interfaces.Utilities
{
    public interface IManejadorArchivosMinIO
    {
        Task<FilesRecordCreateDTO> GuardarArchivo(byte[] contenido, string nombreArchivo, string contentType, string bucket);
        Task<byte[]> ObtenerArchivo(string ruta, string bucket);
        Task<string> ObtenerArchivoEnBase64(string ruta, string bucket);
    }
}