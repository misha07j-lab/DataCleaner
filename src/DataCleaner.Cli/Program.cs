// ============================================================
// Program
// Точка входа CLI-приложения.
//
// Ответственность:
// - Парсинг аргументов
// - Формирование CleaningOptions
// - Вызов Core
// - Обработка исключений
// - Возврат ExitCode
//
// НЕ содержит:
// - Бизнес-логику очистки
//
// Соответствует Studio CLI Contract v1.0
// ============================================================

using DataCleaner.Core.Abstractions;
using DataCleaner.Core.Errors;
using DataCleaner.Core.Models;
using DataCleaner.Core.Pipeline;
using DataCleaner.Core.Services;
using System;
using System.IO;

namespace DataCleaner.Cli
{
    internal static class Program
    {
        public static int Main(string[] args)
        {
            try
            {
                var result = ArgumentParser.Parse(args);

                if (result.ShowHelp)
                {
                    HelpPrinter.Print();
                    return ExitCodes.Success;
                }

                if (result.ShowVersion)
                {
                    VersionPrinter.Print();
                    return ExitCodes.Success;
                }

                var options = result.Options!;

                // Composition root
                ICsvReader reader = new CsvReader();
                ICsvWriter writer = new CsvWriter();

                var lines = reader.ReadAllLines(options.InputPath);
                var context = new CleaningContext(lines);

                var rules = RuleFactory.Create(options);
                var pipeline = new CleaningPipeline(rules);

                pipeline.Execute(context);

                writer.WriteAllLines(options.OutputPath, context.WorkingLines);

                ResultReporter.Print(context);

                return ExitCodes.Success;
            }
            catch (FileNotFoundException ex)
            {
                Console.Error.WriteLine(ex.Message);
                return ExitCodes.FileNotFound;
            }

            catch (DataCleanerException ex)
            {
                Console.Error.WriteLine(ex.Message);
                return ExitCodes.InvalidArguments; // если это ошибки парсинга/валидации
            }

            catch (Exception)
            {
                Console.Error.WriteLine("Unhandled error.");
                return ExitCodes.UnhandledException;
            }
        }
    }
}