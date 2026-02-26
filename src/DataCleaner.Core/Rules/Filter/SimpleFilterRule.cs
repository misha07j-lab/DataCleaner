// ============================================================
// SimpleFilterRule
// Правило фильтрации строк.
//
// Назначение:
// Оставляет строки, соответствующие условию.
//
// Пример:
// Column == Value
//
// Может расширяться до сложных выражений.
//
// ============================================================

using System;
using DataCleaner.Core.Abstractions;
using DataCleaner.Core.Models;
using System.Collections.Generic;
namespace DataCleaner.Core.Rules.Filter
{
    public sealed class SimpleFilterRule : IDataCleaningRule
    {
        private readonly string _contains;
        private readonly bool _includeMatches;

        public SimpleFilterRule(string contains, bool includeMatches)
        {
            if (string.IsNullOrWhiteSpace(contains))
                throw new ArgumentException("Filter value cannot be empty.", nameof(contains));

            _contains = contains;
            _includeMatches = includeMatches;
        }

        public string Name => "SimpleFilter";

        public void Apply(CleaningContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (context.WorkingLines.Count == 0) return;

            var result = new List<string>(context.WorkingLines.Count);
            int removed = 0;

            foreach (var line in context.WorkingLines)
            {
                if (line == null) { removed++; continue; }

                bool match = line.Contains(_contains, StringComparison.OrdinalIgnoreCase);

                if ((_includeMatches && match) || (!_includeMatches && !match))
                    result.Add(line);
                else
                    removed++;
            }

            context.WorkingLines.Clear();
            context.WorkingLines.AddRange(result);
            context.SetIntMeta("FilteredRowsRemoved", removed);
        }
    }
}