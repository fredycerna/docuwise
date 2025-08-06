using DocuWise.API.Shared.Results;

namespace DocuWise.API.Application.Interfaces;

public interface IDocumentService
{
    Task<Result<string>> RegisterDocumentMetadataAsync(string filename);
    Task<Result> UploadDocumentAsync(string filename, Stream fileStream);
}