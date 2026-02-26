
// ============================================================
// RequiredColumnsRule
// Правило проверки обязательных колонок.
//
// Назначение:
// Проверяет наличие указанных колонок.
//
// Поведение:
// - Бросает DataCleanerException
//   при отсутствии обязательных колонок.
//
// ============================================================

using System;
using DataCleaner.Core.Abstractions;
using DataCleaner.Core.Models;
using System.Collections.Generic;
namespace DataCleaner.Core.Rules.RequiredColumns
{
    public sealed class RequiredColumnsRule : IDataCleaningRule
    {
        private readonly int _minColumns;
        private readonly char _delimiter;

        public RequiredColumnsRule(int minColumns, char delimiter)
        {
            if (minColumns <= 0) throw new ArgumentOutOfRangeException(nameof(minColumns));
            _minColumns = minColumns;
            _delimiter = delimiter;
        }

        public string Name => "RequiredColumns";

        public void Apply(CleaningContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (context.WorkingLines.Count == 0) return;

            var result = new List<string>(context.WorkingLines.Count);
            int removed = 0;

            foreach (var line in context.WorkingLines)
            {
                if (line == null) { removed++; continue; }

                var cols = line.Split(_delimiter);
                if (cols.Length >= _minColumns) result.Add(line);
                else removed++;
            }

            context.WorkingLines.Clear();
            context.WorkingLines.AddRange(result);
            context.SetIntMeta("InvalidColumnRowsRemoved", removed);
        }
    }
}