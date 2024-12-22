
using ExtractWordFileMetadata.Domain.Entities;

namespace ExtractWordFileMetadata.Application.Interfaces
{
    public interface IFileMetadataExtractor
    {
        WordFileMetadata ExtractMetadata(string filePath);
    }
}
