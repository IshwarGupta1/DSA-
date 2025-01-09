namespace CollaborativeEditor.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string BlobUrl { get; set; } // URL for accessing the document in Azure Blob Storage
        public DateTime CreatedAt { get; set; }
        public List<DocumentVersion> Versions { get; set; } = new List<DocumentVersion>();
    }
}
