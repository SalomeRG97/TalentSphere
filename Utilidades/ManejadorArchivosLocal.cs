using Microsoft.AspNetCore.Hosting;
using Admin.Interfaces.Utilities;
using Admin.DTO;

namespace Utilidades
{
    public class ManejadorArchivosLocal : IManejadorArchivosLocal
    {
        private readonly string _carpetaBase;

        public ManejadorArchivosLocal(IWebHostEnvironment environment)
        {
            _carpetaBase = environment.WebRootPath;
        }

        public async Task<FilesRecordCreateDTO> GuardarArchivo(byte[] contenido, string nombreArchivo, string contentType, string bucket)
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

            await File.WriteAllBytesAsync(rutaArchivo, contenido);

            var fileRecord = new FilesRecordCreateDTO
            {
                Nombre = nombreArchivoConGuid,
                ContentType = contentType,
                Ruta = bucket,
                Guid = guid
            };

            return fileRecord;
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
    }
}
