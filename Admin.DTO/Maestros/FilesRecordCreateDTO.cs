namespace Admin.DTO
{
    public class FilesRecordCreateDTO
    {
        public string Nombre { get; set; }

        public string ContentType { get; set; }

        public byte[]? FileLocation { get; set; }

        public string Ruta { get; set; }

        public string Guid { get; set; }
    }
}
