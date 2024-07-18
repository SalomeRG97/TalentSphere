using Microsoft.AspNetCore.Hosting;
using Admin.Interfaces.Utilities;
using Admin.DTO;
using Microsoft.AspNetCore.Http;

namespace Utilidades
{
    public class ManejadorArchivosLocal : IManejadorArchivosLocal
    {
        private readonly string _carpetaBase;

        public ManejadorArchivosLocal(IWebHostEnvironment environment)
        {
            _carpetaBase = environment.WebRootPath;
        }
        public async Task<FilesRecordDTO> GuardarArchivo(string nombreArchivo, string bucket, string IdentificadorEmpleado, int ContentType)
        {
            var carpetaDestino = Path.Combine(_carpetaBase, bucket);

            if (!Directory.Exists(carpetaDestino))
            {
                Directory.CreateDirectory(carpetaDestino);
            }

            var extension = Path.GetExtension(nombreArchivo);
            var guid = Guid.NewGuid().ToString();
            var nombreArchivoConGuid = guid + extension;
            var rutaArchivo = Path.Combine(carpetaDestino, nombreArchivoConGuid);

            var fileRecord = new FilesRecordDTO
            {
                IdentificadorEmpleado = IdentificadorEmpleado,
                Nombre = nombreArchivoConGuid,
                ContentType = ContentType,
                Ruta = rutaArchivo,
                Guid = guid
            };

            return fileRecord;
        }
        public async Task GuardarEnRuta(string rutaArchivo, byte[] contenido)
        {
            await File.WriteAllBytesAsync(rutaArchivo, contenido);
        }

        public async Task<byte[]> ObtenerArchivo(string bucket, string nombreArchivo)
        {
            return await File.ReadAllBytesAsync(GenerarRutaArchivo(bucket, nombreArchivo));
        }

        public async Task<string> ObtenerArchivoEnBase64(string bucket, string nombreArchivo)
        {
            var bytes = await File.ReadAllBytesAsync(GenerarRutaArchivo(bucket, nombreArchivo));
            return Convert.ToBase64String(bytes);
        }

        private string GenerarRutaArchivo(string bucket, string nombreArhivo)
        {
            var carpeta = Path.Combine(_carpetaBase, bucket);
            return Path.Combine(carpeta, nombreArhivo);
        }
        public void DeleteFile(string rutaArchivoCompleta)
        {
            try
            {
                if (System.IO.File.Exists(rutaArchivoCompleta))
                {
                    System.IO.File.Delete(rutaArchivoCompleta);
                }
                else
                {
                    throw new FileNotFoundException($"El archivo no existe en la ruta especificada: {rutaArchivoCompleta}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar el archivo '{rutaArchivoCompleta}': {ex.Message}");
            }
        }

    }
}
