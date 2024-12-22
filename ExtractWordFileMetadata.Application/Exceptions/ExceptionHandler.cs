
namespace ExtractWordFileMetadata.Application.Exceptions
{
    public static class ExceptionHandler
    {
        public static void Handle(Exception ex)
        {
            //Log All Exceptions Details
            LogException(ex);

            switch (ex)
            {

            }
        }
        private static void LogException(Exception ex)
        {

        }
    }
}
