\# DataCleaner — CSV Cleaning CLI (Market MVP)



A fast, deterministic command-line tool to clean and normalize CSV files for automation workflows: ETL prep, BI ingestion, recurring reporting, and CRM exports.



\## What it does

DataCleaner takes an input CSV, applies rule-based cleaning options, and produces a clean output CSV — consistently and repeatably.



\## Features

\- Duplicate removal (`--dedupe`)

\- Trim whitespace (`--trim`)

\- Minimum column validation (`--mincols <N>`)

\- Text filtering (`--filter <text>`)

\- Include mode for filtering (`--include`) \*(default is exclude mode)\*



\## Quick Start

Download `DataCleaner.Cli.exe` from GitHub Releases and run:



```bash

DataCleaner.Cli.exe --help

Usage

DataCleaner.Cli.exe --in <input.csv> --out <output.csv> \[--dedupe] \[--trim] \[--mincols <N>] \[--filter <text>] \[--include]

Examples



Remove duplicates + trim:

DataCleaner.Cli.exe --in input.csv --out output.csv --dedupe --trim

Validate minimum columns:

DataCleaner.Cli.exe --in input.csv --out output.csv --mincols 3

Filter rows containing text (exclude mode):

DataCleaner.Cli.exe --in input.csv --out output.csv --filter ERROR

Filter rows containing text (include mode):

DataCleaner.Cli.exe --in input.csv --out output.csv --filter OK --include

Use Cases



Cleaning CRM exports before re-import



Normalizing supplier CSV files for ETL pipelines



Preparing datasets for BI tools (Power BI / analytics)



Automating recurring CSV cleanup instead of manual Excel work



Download \& Integrity (SHA256)



Get the latest release from GitHub Releases.



SHA256 (DataCleaner.Cli.exe):

BE43863C9093EC32C543B2D2AA26363BA1EBCDB1F9E83FB5545F5DE770AC4982



Requirements



Windows x64 (self-contained .NET build)



License



MIT



