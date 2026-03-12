using System;
using DataCleaner.Core.Errors;
using DataCleaner.Core.Models;

namespace DataCleaner.Cli
{
    internal static class ArgumentParser
    {
        public static ParseResult Parse(string[] args)
        {
            if (args == null || args.Length == 0)
                throw new DataCleanerException("Arguments are required. Use --help for usage.");

            if (Contains(args, "--help") || Contains(args, "-h"))
                return ParseResult.Help();

            if (Contains(args, "--version"))
                return ParseResult.Version();

            var options = ParseOptions(args);

            return ParseResult.Success(options);
        }

        private static CleaningOptions ParseOptions(string[] args)
        {
            string? input = null;
            string? output = null;

            bool dedupe = false;
            bool trim = false;
            int? minCols = null;
            string? filter = null;
            bool include = false;

            for (int i = 0; i < args.Length; i++)
            {
                var a = args[i];

                switch (a)
                {
                    case "--in":
                        input = NextValue(args, ref i, "--in");
                        break;

                    case "--out":
                        output = NextValue(args, ref i, "--out");
                        break;

                    case "--dedupe":
                        dedupe = true;
                        break;

                    case "--trim":
                        trim = true;
                        break;

                    case "--mincols":
                        var v = NextValue(args, ref i, "--mincols");
                        if (!int.TryParse(v, out var parsed) || parsed <= 0)

                            throw new DataCleanerException(
                                "Invalid --mincols value.");

                        minCols = parsed;
                        break;

                    case "--filter":
                        filter = NextValue(args, ref i, "--filter");
                        break;

                    case "--include":
                        include = true;
                        break;

                    default:

                        throw new DataCleanerException(
                            $"Unknown argument: {a}");
                }
            }

            if (string.IsNullOrWhiteSpace(input) || string.IsNullOrWhiteSpace(output))

                throw new DataCleanerException(
                    "Both --in and --out must be specified.");

            return new CleaningOptions
            {
                InputPath = input,
                OutputPath = output,
                RemoveEmptyRows = true,
                RemoveDuplicates = dedupe,
                Trim = trim,
                RequiredMinColumns = minCols,
                FilterContains = filter,
                FilterIncludeMatches = include
            };
        }

        private static string NextValue(string[] args, ref int i, string flag)
        {
            if (i + 1 >= args.Length)

                throw new DataCleanerException(
                    $"Missing value for {flag}.");

            i++;
            return args[i];
        }

        private static bool Contains(string[] args, string value)
        {
            foreach (var a in args)
                if (a.Equals(value, StringComparison.OrdinalIgnoreCase))
                    return true;

            return false;
        }
    }
}
