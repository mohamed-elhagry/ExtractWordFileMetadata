using System.Collections.Concurrent;
using ExtractWordFileMetadata.Application.Exceptions;
using ExtractWordFileMetadata.Application.Interfaces;
using ExtractWordFileMetadata.Domain.Entities;

namespace ExtractWordFileMetadata.Application.UseCases
{
    public class ProcessFileUseCase: IProcessFileUseCase
    {
        private readonly IFileMetadataExtractor _fileMetadataExtractor;
        public ProcessFileUseCase(IFileMetadataExtractor fileMetadataExtractor)
        {
            _fileMetadataExtractor = fileMetadataExtractor;
        }
        public (List<WordFileMetadata> ProceesedFiles, List<WordFileMetadata> InvalidFiles) Execute(IEnumerable<string> filePaths)
        {
            var processedFiles = new ConcurrentBag<WordFileMetadata>();
            var invalidFiles = new ConcurrentBag<WordFileMetadata>();

            Parallel.ForEach(filePaths, filePath =>
            {
                try
                {
                    //extract Data
                    var metadata = _fileMetadataExtractor.ExtractMetadata(filePath);
                    if (metadata.IsFileDataComplete)
                    {
                        processedFiles.Add(metadata);
                    }
                    else
                    {
                        invalidFiles.Add(metadata);
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHandler.Handle(ex, $"Processing file: {filePath}");
                }

            });
            return (processedFiles.ToList(), invalidFiles.ToList());
        }
    }
}
