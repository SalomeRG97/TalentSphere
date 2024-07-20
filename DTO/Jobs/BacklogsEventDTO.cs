namespace DTO.Jobs
{
    public class BacklogsEventDTO
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? CompletedAt { get; set; }

        public int EventType { get; set; }

        public string Json { get; set; }
    }
}
