using CollaborativeEditor.Models;

public interface IDocumentService
{
    // Methods related to documents
    Task<Document> CreateDocumentAsync(string name, string content);
    Task<Document> UpdateDocumentAsync(int documentId, string content);
    Task<Document> GetDocumentAsync(int documentId);
    Task<List<Document>> GetAllDocumentsAsync();
    Task DeleteDocumentAsync(int documentId);

    // Methods related to file metadata
    Task<FileMetadata> GetFileMetadataAsync(int documentId);
    Task<List<FileMetadata>> GetAllFileMetadataAsync();
}
