

namespace ExtractWordFileMetadata.Domain.Entities
{
    public class WordFileMetadata
    {
        //Metadata
        public string Title { get; set; } 
        public string Author { get; set; }
        public DateTime? CreationDate { get; set; }
        public int NumberOfPages  { get; set; }

        //This has the given Path for this file.
        public string FilePath { get; set; } = string.Empty;
     
        //This will help for count the total words for each File.
        public int NumberOfWords { get; set; }

        //This flag for alert Valid with all required data.
        public bool IsFileDataComplete =>
            !string.IsNullOrWhiteSpace(Title) &&
            !string.IsNullOrWhiteSpace(Author) &&
            CreationDate.HasValue;

        public List<string> GetMissingMetadata ()
        {
            List<string> missingData = new List<string>();

            if (string.IsNullOrWhiteSpace(Title))
                missingData.Add("Title Is Missing.");
            if (string.IsNullOrWhiteSpace(Author))
                missingData.Add("Author Is Missing.");
            if (!CreationDate.HasValue)
                missingData.Add("CreationDate Is Missing.");

            return missingData;
        }
     }
}
