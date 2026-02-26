// ============================================================
// CleaningContext
// Контекст выполнения очистки.
//
// Назначение:
// Передаёт конфигурацию и параметры выполнения
// во все правила очистки.
//
// Содержит:
// - CleaningOptions
// - Метаданные выполнения
// - Флаги verbose / dry-run и т.д.
//
// НЕ содержит:
// - Логику обработки
//
// Архитектурная роль:
// Связующее звено между CLI и Core.
// ============================================================

using System;
using System.Collections.Generic;
using System.Linq;

namespace DataCleaner.Core.Models
{
    public sealed class CleaningContext
    {
        public IReadOnlyList<string> OriginalLines { get; }
        public List<string> WorkingLines { get; }
        public Dictionary<string, object> Metadata { get; }

        public CleaningContext(IEnumerable<string> lines)
        {
            if (lines == null) throw new ArgumentNullException(nameof(lines));

            var copy = lines.ToList();
            OriginalLines = copy.AsReadOnly();
            WorkingLines = new List<string>(copy);
            Metadata = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        }

        public int GetIntMeta(string key, int defaultValue = 0)
        {
            if (Metadata.TryGetValue(key, out var value) && value is int i) return i;
            return defaultValue;
        }

        public void SetIntMeta(string key, int value) => Metadata[key] = value;
    }
}