![ThreadSharp banner](https://github.com/itsWindows11/ThreadSharp/blob/main/assets/banner.png?raw=true)

# <center>ThreadSharp</center>
<center>A C# API wrapper for the Threads API.</center>

![NuGet Version](https://img.shields.io/nuget/v/ThreadSharp)

## Documentation

You can browse the documentation at [itswindows11.github.io/ThreadSharp](https://itswindows11.github.io/ThreadSharp/docs/).

## Usage

You can start by initializing a `ThreadsClient` with an access token:

```c#
ThreadsClient threadsClient = new ThreadsClient("access-token");
```

Note that ThreadSharp doesn't handle authentication manually, so you will have to handle the authentication depending on your platform's OAuth2 library.
