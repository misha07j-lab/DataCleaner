namespace DataCleaner.Cli
{
    internal static class ExitCodes
    {
        public const int Success = 0;
        public const int InvalidArguments = 1;
        public const int FileNotFound = 10;
        public const int ProcessingError = 20;
        public const int UnhandledException = 99;
    }
}