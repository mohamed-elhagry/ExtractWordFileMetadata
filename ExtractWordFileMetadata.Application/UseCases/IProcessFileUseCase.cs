using ExtractWordFileMetadata.Domain.Entities;

namespace ExtractWordFileMetadata.Application.UseCases
{
    public interface IProcessFileUseCase
    {
        (List<WordFileMetadata> ProceesedFiles, List<WordFileMetadata> InvalidFiles) Execute(IEnumerable<string> filePaths);
    }
}
