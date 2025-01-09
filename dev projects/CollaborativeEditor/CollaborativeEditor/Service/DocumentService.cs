using Azure.Storage.Blobs;
using CollaborativeEditor.Api.Data;
using CollaborativeEditor.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

public class DocumentService : IDocumentService
{
    private readonly AppDbContext _context;
    private readonly BlobStorageService _blobStorageService;

    public DocumentService(AppDbContext context, BlobStorageService blobStorageService)
    {
        _context = context;
        _blobStorageService = blobStorageService;
    }

    public async Task<CollaborativeEditor.Models.Document> CreateDocumentAsync(string name, string content)
    {
        var document = new CollaborativeEditor.Models.Document
        {
            Name = name,
            Content = content,
            CreatedAt = DateTime.UtcNow
       
        };
        document.Versions.Add(new DocumentVersion
        {
            DocumentId = document.Id,
            Content = document.Content,
            VersionedAt = DateTime.UtcNow
        });

        // Save the content to Blob Storage and get the Blob URL
        string blobUrl = await _blobStorageService.SaveContentToBlobAsync($"document-{document.Id}.txt", content);

        // Create and save metadata for the uploaded file
        var fileMetadata = new FileMetadata
        {
            FileName = $"document-{document.Id}.txt",
            BlobUri = blobUrl,
            UploadedAt = DateTime.UtcNow
        };

        _context.FileMetadata.Add(fileMetadata);
        await _context.SaveChangesAsync();

        // Update the document's Blob URL
        document.BlobUrl = blobUrl;

        await _context.Documents.AddAsync(document);
        await _context.SaveChangesAsync();

        return document;
    }

    public async Task<CollaborativeEditor.Models.Document> UpdateDocumentAsync(int documentId, string content)
    {
        var document = await _context.Documents.Include(d => d.Versions).FirstOrDefaultAsync(d => d.Id == documentId);
        if (document == null) throw new Exception("CollaborativeEditor.Models.Document not found");

        // Create a new version for the document before updating
        document.Versions.Add(new DocumentVersion
        {
            DocumentId = documentId,
            Content = document.Content,
            VersionedAt = DateTime.UtcNow
        });

        document.Content = content;

        // Save the updated content to Blob Storage and get the Blob URL
        string blobUrl = await _blobStorageService.SaveContentToBlobAsync($"document-{documentId}.txt", content);

        // Create and save metadata for the updated file
        var fileMetadata = new FileMetadata
        {
            FileName = $"document-{documentId}.txt",
            BlobUri = blobUrl,
            UploadedAt = DateTime.UtcNow
        };

        _context.FileMetadata.Add(fileMetadata);
        await _context.SaveChangesAsync();

        // Update the document's Blob URL
        document.BlobUrl = blobUrl;
        await _context.SaveChangesAsync();

        return document;
    }

    public async Task<CollaborativeEditor.Models.Document> GetDocumentAsync(int documentId)
    {
        return await _context.Documents.Include(d => d.Versions).FirstOrDefaultAsync(d => d.Id == documentId);
    }

    public async Task<List<CollaborativeEditor.Models.Document>> GetAllDocumentsAsync()
    {
        return await _context.Documents.ToListAsync();
    }

    public async Task DeleteDocumentAsync(int documentId)
    {
        var document = await _context.Documents.FindAsync(documentId);
        if (document == null) throw new Exception("CollaborativeEditor.Models.Document not found");

        // Delete associated file metadata
        var fileMetadata = await _context.FileMetadata.Where(fm => fm.FileName == $"document-{documentId}.txt").FirstOrDefaultAsync();
        if (fileMetadata != null)
        {
            _context.FileMetadata.Remove(fileMetadata);
            await _context.SaveChangesAsync();
        }

        // Remove the document
        _context.Documents.Remove(document);
        await _context.SaveChangesAsync();

        // Delete the associated blob from Azure Blob Storage
        await _blobStorageService.deleteBlobClient(documentId);
    }

    // New method to get file metadata by document ID
    public async Task<FileMetadata> GetFileMetadataAsync(int documentId)
    {
        return await _context.FileMetadata
            .FirstOrDefaultAsync(fm => fm.FileName == $"document-{documentId}.txt");
    }

    // New method to get all file metadata
    public async Task<List<FileMetadata>> GetAllFileMetadataAsync()
    {
        return await _context.FileMetadata.ToListAsync();
    }
}
