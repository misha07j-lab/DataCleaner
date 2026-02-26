// ============================================================
// RemoveEmptyRowsRule
// Правило удаления пустых строк.
//
// Назначение:
// Удаляет строки, не содержащие значений.
//
// Критерий пустоты:
// - Все ячейки null / empty / whitespace.
//
// ============================================================

using DataCleaner.Core.Abstractions;
using DataCleaner.Core.Models;
using System;
using System.Collections.Generic;

namespace DataCleaner.Core.Rules.EmptyRows
{
    public sealed class RemoveEmptyRowsRule : IDataCleaningRule
    {
        public string Name => "RemoveEmptyRows";

        public void Apply(CleaningContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (context.WorkingLines.Count == 0) return;

            var result = new List<string>(context.WorkingLines.Count);
            int removed = 0;

            foreach (var line in context.WorkingLines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    removed++;
                    continue;
                }

                result.Add(line);
            }

            context.WorkingLines.Clear();
            context.WorkingLines.AddRange(result);
            context.SetIntMeta("EmptyRowsRemoved", removed);
        }
    }
}