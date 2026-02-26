using System;
using System.Reflection;

namespace DataCleaner.Cli
{
    internal static class VersionPrinter
    {
        public static void Print()
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "unknown";
            Console.WriteLine($"DataCleaner v{version}");
        }
    }
}