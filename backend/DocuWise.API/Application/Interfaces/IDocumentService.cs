using DocuWise.API.Shared.Results;

namespace DocuWise.API.Application.Interfaces;

public interface IDocumentService
{
    Task<Result<string>> RegisterDocumentAsync(string filename);
}