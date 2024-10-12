![ThreadSharp banner](https://github.com/itsWindows11/ThreadSharp/blob/main/assets/banner.png?raw=true)
<h4 align="center"> A C# API wrapper for the Threads API.</h4>
<p align="center">
  <a style="text-decoration:none" href="https://github.com/itsWindows11/ThreadSharp/actions/workflows/nuget.yml">
    <img src="https://github.com/itsWindows11/ThreadSharp/actions/workflows/nuget.yml/badge.svg" alt="CI Status" /></a>
  <!--<a style="text-decoration:none" href="https://discord.com/channels/714581497222398064/913496895006072843">
    <img src="https://img.shields.io/badge/discuss-on%20discord-5865F2" alt="Discord" /></a>-->
  <a style="text-decoration:none" href="https://www.nuget.org/packages/ThreadSharp">
    <img src="https://img.shields.io/nuget/v/ThreadSharp" alt="Discord" /></a>
</p>

> [!IMPORTANT]
> ThreadSharp is limited by the capabilities of the [Threads public API](https://developers.facebook.com/docs/threads/) and so not all features that you enjoy in the Threads app are available.

## Documentation

You can browse the documentation at [itswindows11.github.io/ThreadSharp](https://itswindows11.github.io/ThreadSharp/docs/).

## Contributing

There are multiple ways to participate in the community:

- Upvote popular feature requests.
- [Submit a new feature](https://github.com/itsWindows11/ThreadSharp/pulls).
- [File bugs and feature requests](https://github.com/itsWindows11/ThreadSharp/issues/new/choose).
- Review [source code changes](https://github.com/itsWindows11/ThreadSharp/commits).

## Usage

You can start by initializing a `ThreadsClient` with an access token:

```c#
ThreadsClient threadsClient = new ThreadsClient("access-token");
```

> [!NOTE]
> ThreadSharp doesn't handle authentication manually, so you will have to handle the authentication depending on your platform's OAuth2 library.

## Building the Code

### Prerequisites

Ensure you have following components:

- [Git](https://git-scm.com/)
- A .NET IDE of your choice, preferably [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)
- [The .NET SDK](https://dotnet.microsoft.com/en-us/download/visual-studio-sdks)

### Git

Clone the repository:

```git
git clone https://github.com/itsWindows11/ThreadSharp
```

### Build the project

- Open `ThreadSharp.sln`.
- Build `ThreadSharp.csproj` with `DEBUG` mode activated

## License

Copyright (c) 2024 `itsWindows11` & `ThreadSharp` contributors.

Licensed under the [MIT license](LICENSE).
