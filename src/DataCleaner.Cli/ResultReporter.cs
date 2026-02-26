using System;
using DataCleaner.Core.Models;

namespace DataCleaner.Cli
{
    internal static class ResultReporter
    {
        public static void Print(CleaningContext context)
        {
            Console.WriteLine("OK");
            Console.WriteLine($"EmptyRowsRemoved: {context.GetIntMeta("EmptyRowsRemoved")}");
            Console.WriteLine($"DuplicatesRemoved: {context.GetIntMeta("DuplicatesRemoved")}");
            Console.WriteLine($"InvalidColumnRowsRemoved: {context.GetIntMeta("InvalidColumnRowsRemoved")}");
            Console.WriteLine($"FilteredRowsRemoved: {context.GetIntMeta("FilteredRowsRemoved")}");
        }
    }
}