using System.Runtime.InteropServices.JavaScript;
using DocuWise.API.Application.Interfaces;
using DocuWise.API.Shared.Results;

namespace DocuWise.API.Application.Services;

public class DocumentService : IDocumentService
{
    private readonly IStorageService _storageService;

    public DocumentService(IStorageService storageService)
    {
        _storageService = storageService;
    }


    public async Task<Result> UploadDocumentAsync(string filename, Stream fileStream)
    {
        if (string.IsNullOrWhiteSpace(filename))
            return Result.Failure(Error.Validation("filename is required"));

        var success = await _storageService.UploadFileAsync(filename, fileStream);

        if (!success)
            return Result.Failure(Error.Custom("Upload.Failed", "The document could not be uploaded"));

        return Result.Success();
    }
    
    
    public async Task<Result<string>> RegisterDocumentMetadataAsync(string filename)
    {
        if (string.IsNullOrWhiteSpace(filename))
            return Result<string>.Failure(Error.Validation("filename is required"));

        if (filename.Length > 100)
            return Result<string>.Failure(Error.Custom("Document.InvalidName", "Filename is too long"));
        
        //simulating success 
        return Result<string>.Success($"Document {filename} registered.");
    }
}