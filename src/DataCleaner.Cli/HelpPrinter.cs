using System;

namespace DataCleaner.Cli
{
    internal static class HelpPrinter
    {
        public static void Print()
        {
            Console.WriteLine("DataCleaner – market MVP");
            Console.WriteLine();
            Console.WriteLine("Usage:");
            Console.WriteLine("  DataCleaner.Cli --in <input.csv> --out <output.csv> [--dedupe] [--trim] [--mincols <N>] [--filter <text>] [--include]");
            Console.WriteLine();
            Console.WriteLine("Examples:");
            Console.WriteLine("  DataCleaner.Cli --in input.csv --out output.csv --dedupe --trim");
            Console.WriteLine("  DataCleaner.Cli --in input.csv --out output.csv --mincols 3");
            Console.WriteLine("  DataCleaner.Cli --in input.csv --out output.csv --filter ERROR");
            Console.WriteLine("  DataCleaner.Cli --in input.csv --out output.csv --filter OK --include");
        }
    }
}