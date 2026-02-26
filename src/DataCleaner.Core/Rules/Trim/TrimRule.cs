// ============================================================
// TrimRule
// Правило обрезки пробелов.
//
// Назначение:
// Удаляет лишние пробелы в ячейках CSV.
//
// Применяется:
// - Ко всем колонкам
//   или к выбранным.
//
// ============================================================
using System;
using DataCleaner.Core.Abstractions;
using DataCleaner.Core.Models;

namespace DataCleaner.Core.Rules.Trim
{
    public sealed class TrimRule : IDataCleaningRule
    {
        public string Name => "Trim";

        public void Apply(CleaningContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (context.WorkingLines.Count == 0) return;

            for (int i = 0; i < context.WorkingLines.Count; i++)
            {
                var line = context.WorkingLines[i];
                if (line != null)
                    context.WorkingLines[i] = line.Trim();
            }
        }
    }
}