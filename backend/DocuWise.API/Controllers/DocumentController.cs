using DocuWise.API.Application.DTOs;
using DocuWise.API.Application.Interfaces;
using DocuWise.API.Shared.Results;
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

    [HttpPost("register-metadata")]
    public async Task<IActionResult> RegisterMetaData([FromQuery] string filename)
    {
        var result = await _documentService.RegisterDocumentMetadataAsync(filename);
        if (result.IsFailure)
            return BadRequest(result.Error);
        
        return Ok(new { message = result.Value });
    }


    [HttpPost("upload")]
    public async Task<IActionResult> Upload([FromForm] UploadDocumentRequest request)
    {
        var file = request.File;
        
        if (file == null || file.Length == 0)
            return BadRequest(Error.Validation("Empty file"));

        var result = await _documentService.UploadDocumentAsync(file.FileName, file.OpenReadStream());

        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(new { message = "File uploaded successfully." });
    }
    
}