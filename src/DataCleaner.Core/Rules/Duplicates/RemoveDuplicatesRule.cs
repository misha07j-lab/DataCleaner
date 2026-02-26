// ============================================================
// RemoveDuplicatesRule
// Правило удаления дубликатов.
//
// Назначение:
// Удаляет повторяющиеся строки CSV.
//
// Логика:
// - Сравнение строк по всем колонкам
//   или по заданным ключам.
// - Использует HashSet для O(n) производительности
// - Сохраняет порядок первого вхождения
//
// Архитектурная роль:
// Конкретная реализация IDataCleaningRule.
// ============================================================

using DataCleaner.Core.Abstractions;
using DataCleaner.Core.Models;
using System;
using System.Collections.Generic;
namespace DataCleaner.Core.Rules.Duplicates
{
    public sealed class RemoveDuplicatesRule : IDataCleaningRule
    {
        public string Name => "RemoveDuplicates";

        public void Apply(CleaningContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (context.WorkingLines.Count == 0) return;

            var seen = new HashSet<string>();
            var unique = new List<string>(context.WorkingLines.Count);

            foreach (var line in context.WorkingLines)
            {
                if (seen.Add(line))
                    unique.Add(line);
            }

            int removed = context.WorkingLines.Count - unique.Count;

            context.WorkingLines.Clear();
            context.WorkingLines.AddRange(unique);
            context.SetIntMeta("DuplicatesRemoved", removed);
        }
    }
}