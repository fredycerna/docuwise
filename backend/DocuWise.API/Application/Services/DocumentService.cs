using System.Runtime.InteropServices.JavaScript;
using DocuWise.API.Application.Interfaces;
using DocuWise.API.Shared.Results;

namespace DocuWise.API.Application.Services;

public class DocumentService : IDocumentService
{
    public async Task<Result<string>> RegisterDocumentAsync(string filename)
    {
        if (string.IsNullOrWhiteSpace(filename))
            return Result<string>.Failure(Error.Validation("filename is required"));

        if (filename.Length > 100)
            return Result<string>.Failure(Error.Custom("Document.InvalidName", "Filename is too long"));
        
        //simulating success 
        return Result<string>.Success($"Document {filename} registered.");
    }
}