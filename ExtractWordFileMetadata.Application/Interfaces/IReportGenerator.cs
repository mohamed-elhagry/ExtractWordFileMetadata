
using ExtractWordFileMetadata.Domain.Entities;

namespace ExtractWordFileMetadata.Application.Interfaces
{
    public interface IReportGenerator
    {
        bool Generate(string outputPath, List<WordFileMetadata> ProceesedFiles, List<WordFileMetadata> InvalidFiles);
    }
}
