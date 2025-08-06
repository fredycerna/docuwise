namespace DocuWise.API.Application.Interfaces;

public interface IStorageService
{
    Task<bool> UploadFileAsync(string filename, Stream fileStream);
}