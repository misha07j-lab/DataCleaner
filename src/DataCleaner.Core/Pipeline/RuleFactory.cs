// ============================================================
// RuleFactory
// Фабрика создания правил очистки.
//
// Назначение:
// Создаёт набор IDataCleaningRule на основе CleaningOptions.
//
// Ответственность:
// - Анализ опций
// - Формирование списка правил
//
// Архитектурная роль:
// Инверсия управления.
// Позволяет расширять систему без изменения Pipeline.
// ============================================================
using System;
using System.Collections.Generic;

using DataCleaner.Core.Abstractions;
using DataCleaner.Core.Models;

using DataCleaner.Core.Rules.Duplicates;
using DataCleaner.Core.Rules.EmptyRows;
using DataCleaner.Core.Rules.Filter;
using DataCleaner.Core.Rules.RequiredColumns;
using DataCleaner.Core.Rules.Trim;

namespace DataCleaner.Core.Pipeline
{
    public static class RuleFactory
    {
        public static IReadOnlyList<IDataCleaningRule> Create(CleaningOptions options)
        {
            ArgumentNullException.ThrowIfNull(options);

            var rules = new List<IDataCleaningRule>();

            if (options.RemoveEmptyRows)
                rules.Add(new RemoveEmptyRowsRule());

            if (options.Trim)
                rules.Add(new TrimRule());

            if (options.RemoveDuplicates)
                rules.Add(new RemoveDuplicatesRule());

            if (options.RequiredMinColumns.HasValue)
                rules.Add(new RequiredColumnsRule(
                    options.RequiredMinColumns.Value,
                    ','
                ));

            if (!string.IsNullOrWhiteSpace(options.FilterContains))
                rules.Add(new SimpleFilterRule(
                    options.FilterContains,
                    options.FilterIncludeMatches));

            return rules;
        }
    }
}