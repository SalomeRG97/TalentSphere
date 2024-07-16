namespace Admin.DTO
{
    public class FilesRecordDTO
    {
        public int Id { get; set; }
        public string IdentificadorEmpleado { get; set; }

        public string Nombre { get; set; } 

        public int ContentType { get; set; } 

        public string Ruta { get; set; }

        public string Guid { get; set; }
    }
}
