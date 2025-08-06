namespace DocuWise.API.Application.DTOs;

public class UploadDocumentRequest
{
    public IFormFile? File { get; set; } = default;
}