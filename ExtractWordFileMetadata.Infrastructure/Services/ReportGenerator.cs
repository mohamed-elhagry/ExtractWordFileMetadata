
using ExtractWordFileMetadata.Application.Exceptions;
using ExtractWordFileMetadata.Application.Interfaces;
using ExtractWordFileMetadata.Domain.Entities;
using System.Text.Json;

namespace ExtractWordFileMetadata.Infrastructure.Services
{
    public class ReportGenerator: IReportGenerator
    {
        public bool Generate(string outputPath, List<WordFileMetadata> proceesedFiles, List<WordFileMetadata> invalidFiles)
        {
            try
            {
                var report = new
                {
                    FilesProcessed = proceesedFiles,
                    InvalidFiles = invalidFiles.Select(f => new { f.FilePath, Errors = f.GetMissingMetadata() })
                };

                var json = JsonSerializer.Serialize(report, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(outputPath, json);

                return true;
            }
            catch (FileNotFoundException ex)
            {
                ExceptionHandler.Handle(ex, "Error during report generation");
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex, "Error during report generation");
            }
            return false;

        }
    }
}
