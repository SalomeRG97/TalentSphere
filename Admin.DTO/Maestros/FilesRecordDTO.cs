namespace Admin.DTO
{
    public class FilesRecordDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; } 

        public string ContentType { get; set; } 

        public byte[]? FileLocation { get; set; }

        public string Ruta { get; set; }

        public string Guid { get; set; }
    }
}
