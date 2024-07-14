namespace Admin.DTO.Files
{
    public class CreateFileRecordDTO
    {
        public string Bucket { get; set; }

        public string Nombre { get; set; }

        public string ContentType { get; set; }

        public string Guid { get; set; }
    }
}