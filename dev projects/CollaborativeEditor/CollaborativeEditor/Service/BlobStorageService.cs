using Microsoft.Extensions.Configuration;
using Azure.Storage.Blobs;

public class BlobStorageService
{
    private readonly BlobContainerClient _blobContainerClient;

    public BlobStorageService(IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("BlobStorageConnectionString");
        var blobServiceClient = new BlobServiceClient(connectionString);
        _blobContainerClient = blobServiceClient.GetBlobContainerClient("documents");
        _blobContainerClient.CreateIfNotExists();
    }

    public async Task deleteBlobClient(int documentId)
    {
        var blobClient = _blobContainerClient.GetBlobClient($"document-{documentId}.txt");
        await blobClient.DeleteIfExistsAsync();
    }
    public async Task<string> SaveContentToBlobAsync(string blobName, string content)
    {
        var blobClient = _blobContainerClient.GetBlobClient(blobName);
        await blobClient.UploadAsync(new BinaryData(content), overwrite: true);
        return blobClient.Uri.ToString();
    }
}
