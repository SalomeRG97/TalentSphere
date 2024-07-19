using Admin.DTO;

namespace Interfaces.Utilities
{
    public interface IManejadorArchivosLocal
    {
        Task<FilesRecordDTO> GuardarArchivo(string nombreArchivo, string bucket, string IdentificadorEmpleado, int ContentType);
        Task<byte[]> ObtenerArchivo(string bucket, string nombreArchivo);
        Task<string> ObtenerArchivoEnBase64(string bucket, string nombreArchivo);
        void DeleteFile(string rutaArchivoCompleta);
        Task GuardarEnRuta(string rutaArchivo, byte[] contenido);
    }
}