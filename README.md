# Mars Rover

A robust .NET terminal application for navigating rovers across the Martian plateau.

## 🚀 Project Architecture & Quality Gates

This project is built with a focus on modern C# standards and automated quality assurance.

### 🏗️ Global Configuration
- **Directory.Build.props**: Centralized project configuration to ensure consistent Target Framework (.NET 10), Nullable reference types, and Implicit Usings across all projects.
- **Strict Warnings**: `TreatWarningsAsErrors` is enabled globally to maintain a zero-warning codebase.
- **Code Style**: `EnforceCodeStyleInBuild` is active to ensure the project adheres to `.editorconfig` rules during every build.

### 🤖 Automation & CI/CD
- **GitHub Actions**: A `.github/workflows/build-and-test.yml` pipeline automatically validates every push to ensure the solution builds, the README is present, and all NUnit tests pass in a clean Linux environment.
- **Pull Request Template**: A standardized PR template is located in `.github/` to ensure consistent documentation of changes, testing steps, and impact analysis.

### 🛡️ Git Hooks & Standards
- **Husky.Net**: Implemented to manage local Git hooks.
- **Commit Linting**: A `commit-msg` hook enforces **Conventional Commits** (`feat:`, `fix:`, `docs:`, etc.). Commits that do not meet this standard are automatically rejected to keep the git history clean and professional.

## 📁 Folder Structure

```text
csharp-mars-rover/
├── .github/
│   ├── workflows/             # CI/CD Automation scripts
│   └── pull_request_template.md
├── MarsRover.Console/         # Main Entry Point (Terminal UI)
├── MarsRover.Tests/           # NUnit Test Suite
├── .husky/                    # Local Git Hook configurations
├── Directory.Build.props      # Global MSBuild settings
├── MarsRover.slnx             # Visual Studio Solution
└── README.md
```

## 🛠️ Getting Started

### Prerequisites
* .NET 10 SDK
* [Husky.Net](https://github.io) (for local commit linting)

### Development
1. Clone the repository.
2. Run `dotnet tool restore` to install Husky.
3. Run `dotnet husky install` to set up local git hooks.
4. Use `dotnet test` to run the suite of NUnit tests.