![ThreadSharp banner](https://raw.githubusercontent.com/itsWindows11/ThreadSharp/refs/heads/main/assets/banner.png)

[![CI Status](https://github.com/itsWindows11/ThreadSharp/actions/workflows/nuget.yml/badge.svg)](https://github.com/itsWindows11/ThreadSharp/actions/workflows/nuget.yml)

## Documentation

You can browse the documentation at [itswindows11.github.io/ThreadSharp](https://itswindows11.github.io/ThreadSharp/docs/).

## Usage

You can start by initializing a `ThreadsClient` with an access token:

```c#
ThreadsClient threadsClient = new ThreadsClient("access-token");
```

## Building the Code

### Prerequisites

Ensure you have following components:

- [Git](https://git-scm.com/).
- A .NET IDE of your choice, preferably [Visual Studio 2022](https://visualstudio.microsoft.com/vs/).
- [The .NET SDK](https://dotnet.microsoft.com/en-us/download/visual-studio-sdks).

### Git

Clone the repository:

```bash
git clone https://github.com/itsWindows11/ThreadSharp
```

### Build the project

- Open `ThreadSharp.sln`.
- Build `ThreadSharp.csproj` with `DEBUG` mode activated.

## License

Copyright (c) 2024 itsWindows11 & ThreadSharp contributors.

Licensed under the [MIT License](https://github.com/itsWindows11/ThreadSharp/blob/main/LICENSE).
