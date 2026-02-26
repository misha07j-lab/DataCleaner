// ============================================================
// DataCleanerException
// Базовое доменное исключение проекта.
//
// Назначение:
// Представляет управляемую ошибку процесса очистки.
//
// Ответственность:
// - Инкапсулировать код ошибки
// - Передать сообщение верхнему уровню (CLI)
//
// Используется для:
// - Контролируемых ошибок обработки
// - Привязки к ExitCodes
//
// Архитектурная роль:
// Мост между Core и CLI.
// ============================================================

using System;

namespace DataCleaner.Core.Errors
{
    public class DataCleanerException : Exception
    {
        public DataCleanerException()
        {
        }

        public DataCleanerException(string message)
            : base(message)
        {
        }

        public DataCleanerException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}