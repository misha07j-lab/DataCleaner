\# Repository Coding Rules — Automation CLI Toolkit



This repository follows strict production-ready architecture.



\## Architectural Boundaries



\- Core layer contains domain logic only.

\- CLI layer contains parsing, IO, ExitCodes, orchestration.

\- No business logic inside CLI.

\- No hidden static state.

\- No implicit side effects.



\## Contracts



\- All processing logic must respect IData\* interfaces.

\- Use explicit context objects (e.g., CleaningContext).

\- Avoid dynamic or reflection unless justified.



\## CLI Standard



\- Use ExitCodes enum (Success=0, InvalidArguments=1, FileNotFound=10, ProcessingError=20, UnhandledException=99).

\- Support --help and --version.

\- Async Main preferred.

\- Deterministic console output.



\## Code Quality



\- No demo-style shortcuts.

\- No auto-generated comments.

\- No magic numbers.

\- Clear naming over brevity.

\- Explain architectural reasoning before large suggestions.



\## Copilot Behavior Constraints



\- Do NOT generate entire tools.

\- Suggest structure first, then implementation.

\- Respect existing file structure.

\- If unsure, ask clarifying question instead of guessing.

