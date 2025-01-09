using CollaborativeEditor.Models;
using Microsoft.AspNetCore.Mvc;

namespace CollaborativeEditor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        // GET: api/document
        [HttpGet]
        public async Task<ActionResult<List<Document>>> GetAllDocuments()
        {
            var documents = await _documentService.GetAllDocumentsAsync();
            return Ok(documents);
        }

        // GET: api/document/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Document>> GetDocument(int id)
        {
            var document = await _documentService.GetDocumentAsync(id);
            if (document == null)
                return NotFound("Document not found.");
            return Ok(document);
        }

        // POST: api/document
        [HttpPost]
        public async Task<ActionResult<Document>> CreateDocument([FromBody] CreateDocumentRequest request)
        {
            // Assume request has name, content, and createdBy (user ID)
            var document = await _documentService.CreateDocumentAsync(request.Name, request.Content);
            return CreatedAtAction(nameof(GetDocument), new { id = document.Id }, document);
        }

        // PUT: api/document/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<Document>> UpdateDocument(int id, [FromBody] string content)
        {
            var document = await _documentService.UpdateDocumentAsync(id, content);
            return Ok(document);
        }

        // DELETE: api/document/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocument(int id)
        {
            try
            {
                await _documentService.DeleteDocumentAsync(id);
                return NoContent();
            }
            catch (System.Exception)
            {
                return NotFound("Document not found.");
            }
        }
    }
}