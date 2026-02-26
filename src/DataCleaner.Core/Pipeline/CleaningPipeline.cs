// ============================================================
// CleaningPipeline
// Оркестратор правил очистки.
//
// Назначение:
// Последовательно применяет набор IDataCleaningRule
// к CsvDocument.
//
// Ответственность:
// - Управление порядком выполнения правил
// - Передача CleaningContext
//
// НЕ содержит:
// - Конкретную логику очистки
//
// Архитектурная роль:
// Application Layer внутри Core.
// ============================================================

using System;
using DataCleaner.Core.Abstractions;
using DataCleaner.Core.Models;
using System.Collections.Generic;

namespace DataCleaner.Core.Pipeline
{
    public sealed class CleaningPipeline
    {
        private readonly IReadOnlyList<IDataCleaningRule> _rules;

        public CleaningPipeline(IReadOnlyList<IDataCleaningRule> rules)
        {
            _rules = rules ?? throw new ArgumentNullException(nameof(rules));
        }

        public CleaningContext Execute(CleaningContext context)
        {
            ArgumentNullException.ThrowIfNull(context);
            foreach (var rule in _rules)
            {
                rule.Apply(context);
            }

            return context;
        }
    }
}