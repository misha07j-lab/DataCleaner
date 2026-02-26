// ============================================================
// CsvReader
// Реализация ICsvReader.
//
// Назначение:
// Загружает CSV-файл в CsvDocument.
//
// Обрабатывает:
// - Кодировку
// - Разделители
// - Ошибки чтения
//
// Инфраструктурный слой.
// ============================================================

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DataCleaner.Core.Abstractions;
using DataCleaner.Core.Errors;

namespace DataCleaner.Core.Services
{
    public sealed class CsvReader : ICsvReader
    {
        public List<string> ReadAllLines(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new DataCleanerException("Input path is empty.");
            if (!File.Exists(path))
                throw new FileNotFoundException($"File not found: {path}");
            try
            {
                return File.ReadAllLines(path).ToList();
            }
            catch (Exception ex)
            {
                throw new DataCleanerException($"Failed to read file: {ex.Message}");
            }
        }
    }
}