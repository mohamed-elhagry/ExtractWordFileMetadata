
using System.Diagnostics;

namespace ExtractWordFileMetadata.Application.Exceptions
{
    public static class ExceptionHandler
    {
        public static void Handle(Exception ex, string context = "General")
        {
            //Log All Exceptions Details
            LogException(ex, context);

            switch (ex)
            {
                case FileNotFoundException fileNotFound:
                    Console.WriteLine($"[Error] File not found: {fileNotFound.FileName}");
                    break;
                case UnauthorizedAccessException unauthorized:
                    Console.WriteLine($"[Error] Access denied: {unauthorized.Message}");
                    break;
                case InvalidOperationException invalidOp:
                    Console.WriteLine($"[Error] Invalid operation: {invalidOp.Message}");
                    break;
                case FormatException formatEx:
                    Console.WriteLine($"[Error] Format error: {formatEx.Message}");
                    break;
                default:
                    // Handle general exceptions
                    Console.WriteLine($"[Error] An unexpected error occurred: {ex.Message}");
                    break;
            }
        }
        private static void LogException(Exception ex, string context)
        {
            Debug.WriteLine($"[Exception] Context: {context}, Message: {ex.Message}, StackTrace: {ex.StackTrace}");
            File.AppendAllText("error.log", $"{DateTime.Now}: Context: {context}, Message: {ex.Message}, StackTrace: {ex.StackTrace}\n");
        }
    }
}
