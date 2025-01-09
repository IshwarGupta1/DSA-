namespace CollaborativeEditor.Models
{
    public class FileMetadata
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string BlobUri { get; set; }
        public DateTime UploadedAt { get; set; }
    }
}
