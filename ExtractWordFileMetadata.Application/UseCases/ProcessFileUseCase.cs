using System.Collections.Concurrent;
using ExtractWordFileMetadata.Application.Exceptions;
using ExtractWordFileMetadata.Domain.Entities;

namespace ExtractWordFileMetadata.Application.UseCases
{
    public class ProcessFileUseCase: IProcessFileUseCase
    {
        public (List<WordFileMetadata> ProceesedFiles, List<WordFileMetadata> InvalidFiles) Execute(IEnumerable<string> filePaths)
        {
            var processedFiles = new ConcurrentBag<WordFileMetadata>();
            var invalidFiles = new ConcurrentBag<WordFileMetadata>();

            Parallel.ForEach(filePaths, filePath =>
            {
                try
                {
                    //extract Data
                }
                catch (Exception ex)
                {
                    ExceptionHandler.Handle(ex, $"Processing file: {filePath}");
                }

            }
            return (processedFiles.ToList(), invalidFiles.ToList());
        }
    }
}
