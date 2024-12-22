using DocumentFormat.OpenXml.Packaging;
using ExtractWordFileMetadata.Application.Exceptions;
using ExtractWordFileMetadata.Application.Interfaces;
using ExtractWordFileMetadata.Domain.Entities;

namespace ExtractWordFileMetadata.Infrastructure.Services
{
    public class FileMetadataExtractor: IFileMetadataExtractor
    {
        public  WordFileMetadata ExtractMetadata(string filePath)
        {
            var metadata = new WordFileMetadata { FilePath = filePath };

            try
            {
                using var document = WordprocessingDocument.Open(filePath, false);
                var properties = document.PackageProperties;

                metadata.Title = properties.Title;
                metadata.Author = properties.Creator;
                metadata.CreationDate = properties.Created;
                metadata.NumberOfPages = 0;

                if (document.ExtendedFilePropertiesPart?.Properties.Pages?.Text != null)
                {
                    int _NumberOfPages = 0;
                    if (int.TryParse(document.ExtendedFilePropertiesPart.Properties.Pages.Text, out _NumberOfPages))
                    {
                        metadata.NumberOfPages = _NumberOfPages;
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                ExceptionHandler.Handle(ex, "File not found during ExtractMetadata");
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex, "General error during ExtractMetadata");
            }

            return metadata;
        }
    }
}
