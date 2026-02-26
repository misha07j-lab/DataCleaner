// ============================================================
// IDataCleaningRule
// Контракт правила очистки данных.
//
// Назначение:
// Определяет единый интерфейс для всех правил очистки.
//
// Ответственность:
// - Принять CsvDocument
// - Модифицировать его согласно логике правила
//
// НЕ отвечает за:
// - Чтение/запись файлов
// - Оркестрацию правил
//
// Основной метод:
// - void Apply(CsvDocument document, CleaningContext context)
//
// Архитектурная роль:
// Расширяемая точка системы.
// Позволяет добавлять новые правила без изменения Pipeline.
// ============================================================

using DataCleaner.Core.Models;

namespace DataCleaner.Core.Abstractions
{
    public interface IDataCleaningRule
    {
        void Apply(CleaningContext context);
    }
}