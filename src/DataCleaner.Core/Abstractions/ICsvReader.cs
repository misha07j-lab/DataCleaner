using System.Collections.Generic;

namespace DataCleaner.Core.Abstractions
{
    public interface ICsvReader
    {
        List<string> ReadAllLines(string path);
    }
}