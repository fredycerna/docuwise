using DocuWise.API.Application.Interfaces;

namespace DocuWise.API.Application.Services;

public class FakeStorageService : IStorageService
{
    public async Task<bool> UploadFileAsync(string filename, Stream fileStream)
    {
        using var memory = new MemoryStream();
        await fileStream.CopyToAsync(memory);
        var size = memory.Length;
        
        //simulating success
        return size > 0;
    }
}