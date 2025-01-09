namespace CollaborativeEditor.Models
{
    public class DocumentVersion
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public string Content { get; set; }
        public DateTime VersionedAt { get; set; }
    }
}
