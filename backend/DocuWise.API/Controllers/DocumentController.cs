using DocuWise.API.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DocuWise.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DocumentController : ControllerBase
{
    private readonly IDocumentService _documentService;

    public DocumentController(IDocumentService documentService)
    {
        _documentService = documentService;
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromQuery] string filename)
    {
        var result = await _documentService.RegisterDocumentAsync(filename);
        if (result.IsFailure)
            return BadRequest(result.Error);
        
        return Ok(new { message = result.Value });
    }
    
}