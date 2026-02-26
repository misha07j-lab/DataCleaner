using DataCleaner.Core.Models;

namespace DataCleaner.Cli
{
    internal sealed class ParseResult
    {
        public bool ShowHelp { get; }
        public bool ShowVersion { get; }
        public CleaningOptions? Options { get; }

        private ParseResult(bool help, bool version, CleaningOptions? options)
        {
            ShowHelp = help;
            ShowVersion = version;
            Options = options;
        }

        public static ParseResult Help() => new ParseResult(true, false, null);

        public static ParseResult Version() => new ParseResult(false, true, null);

        public static ParseResult Success(CleaningOptions options) =>
            new ParseResult(false, false, options);
    }
}