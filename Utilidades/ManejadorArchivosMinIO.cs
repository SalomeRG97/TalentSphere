using Microsoft.AspNetCore.Hosting;
using Admin.DTO;
using Interfaces.Utilities;
using Minio;
using Minio.Exceptions;
using System.Threading.Tasks;
using System.IO;
using Minio.DataModel.Args;

namespace Utilidades
{
    public class ManejadorArchivosMinIO : IManejadorArchivosMinIO
    {
        private readonly IMinioClient _minioClient;

        public ManejadorArchivosMinIO()
        {
            _minioClient = new MinioClient()
                                 .WithEndpoint("localhost:9000")
                                .WithCredentials("minioadmin", "minioadmin123")
                                .Build();
        }

        public async Task<FilesRecordCreateDTO> GuardarArchivo(byte[] contenido, string nombreArchivo, string contentType, string bucket)
        {
            try
            {
                bool found = await _minioClient.BucketExistsAsync(new BucketExistsArgs().WithBucket(bucket));
                if (!found)
                {
                    await _minioClient.MakeBucketAsync(new MakeBucketArgs().WithBucket(bucket));
                }

                using (var stream = new MemoryStream(contenido))
                {
                    var guid = Guid.NewGuid().ToString();
                    var extension = Path.GetExtension(nombreArchivo);
                    var nombreArchivoConGuid = guid + extension;

                    await _minioClient.PutObjectAsync(new PutObjectArgs()
                        .WithBucket(bucket)
                        .WithObject(nombreArchivoConGuid)
                        .WithStreamData(stream)
                        .WithObjectSize(stream.Length)
                        .WithContentType(contentType)
                    );

                    var fileRecord = new FilesRecordCreateDTO
                    {
                        Nombre = nombreArchivoConGuid,
                        ContentType = contentType,
                        Ruta = bucket,
                        Guid = guid
                    };

                    return fileRecord;
                }
            }
            catch (MinioException e)
            {
                throw new Exception($"Error al guardar el archivo en MinIO: {e.Message}");
            }
        }

        public async Task<byte[]> ObtenerArchivo(string ruta, string bucket)
        {
            try
            {
                using (var stream = new MemoryStream())
                {
                    await _minioClient.GetObjectAsync(new GetObjectArgs()
                        .WithBucket(bucket)
                        .WithObject(ruta)
                        .WithCallbackStream((minioStream) =>
                        {
                            minioStream.CopyTo(stream);
                        })
                    );

                    return stream.ToArray();
                }
            }
            catch (MinioException e)
            {
                // Manejar excepciones específicas de MinIO
                throw new Exception($"Error al obtener el archivo de MinIO: {e.Message}");
            }
        }

        public async Task<string> ObtenerArchivoEnBase64(string ruta, string bucket)
        {
            var bytes = await ObtenerArchivo(ruta, bucket);
            return Convert.ToBase64String(bytes);
        }
    }
}
