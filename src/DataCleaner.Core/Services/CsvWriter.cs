// ============================================================
// CsvWriter
// Реализация ICsvWriter.
//
// Назначение:
// Сохраняет CsvDocument в CSV-файл.
//
// Обрабатывает:
// - Кодировку
// - Форматирование
//
// Инфраструктурный слой.
// ============================================================

using System;
using System.Collections.Generic;
using System.IO;
using DataCleaner.Core.Abstractions;
using DataCleaner.Core.Errors;

namespace DataCleaner.Core.Services
{
    public sealed class CsvWriter : ICsvWriter
    {
        public void WriteAllLines(string path, IEnumerable<string> lines)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new DataCleanerException("Output path is empty.");
            try
            {
                File.WriteAllLines(path, lines);
            }
            catch (Exception ex)
            {
                throw new DataCleanerException($"Failed to write file: {ex.Message}");
            }
        }
    }
}