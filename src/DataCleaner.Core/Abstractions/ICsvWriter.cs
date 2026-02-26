using System.Collections.Generic;

namespace DataCleaner.Core.Abstractions
{
    public interface ICsvWriter
    {
        void WriteAllLines(string path, IEnumerable<string> lines);
    }
}