// ============================================================
// CleaningOptions
// Конфигурация очистки.
//
// Назначение:
// Хранит параметры, переданные пользователем через CLI.
//
// Примеры:
// - RemoveDuplicates
// - TrimValues
// - RequiredColumns
// - FilterExpression
//
// Архитектурная роль:
// DTO уровня Core.
// ============================================================

namespace DataCleaner.Core.Models
{
    public sealed class CleaningOptions
    {
        public string InputPath { get; init; } = string.Empty;
        public string OutputPath { get; init; } = string.Empty;

        public bool RemoveEmptyRows { get; init; }
        public bool RemoveDuplicates { get; init; }
        public bool Trim { get; init; }

        public int? RequiredMinColumns { get; init; }

        public string? FilterContains { get; init; }
        public bool FilterIncludeMatches { get; init; }
    }
}