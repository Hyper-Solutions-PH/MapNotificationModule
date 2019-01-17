# Create MVC WebApp

I'm using Visual Studio Code for this project to learn how I can use the command prompt to develop and deploy web applications. My main focus is to show you guys how we can work with these platforms.

In this tutorial, I am focusing on developing a production web application that will provide real-time order notification to all the clients using our `SignalR` hub. I'm gonna show you how we can use `SQLite` to store order details for development purpose.

So let's start with this tutorial. First, we will create our solution file, from where we can start on creating projects.

`Dotnet` provides a simple way to generate solution file from command prompt. Open the terminal by selecting `Ctrl + R` and type `cmd` in run window and press `enter`. Type the following command in the terminal.

```
$ mkdir MapNotificationModule
$ cd MapNotificationModule
```

Above snippet will create a directory for you inside which you can create your solution file. If you are using an existing directory, you can create a solution file.

```
$ dotnet new sln
```

The above snippet will create a new solution file for you. In case you don't specify the solution name it will take the parent directory name. For more details, you can refer to this [dotnet sln](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-sln).

After this, I will create a dotNet project for three different tasks. As I discussed earlier in this tutorial about using `SQLite` to store order records, I will create a test application to test my progress and a web interface for creating and managing orders and map notifications.

So let's create directories for storing projects.

```
$ mkdir SignalR_GoogleMap_Web
$ mkdir SignalR_GoogleMap_Sqlite
$ mkdir SignalR_GoogleMap_Tests
```

The above snippet will create new directories for holding your projects, which will look like this.

```
|- SignalR_GoogleMap_RealTimeNotification
    |- SignalR_GoogleMap_Web
    |- SignalR_GoogleMap_Sqlite
    |- SignalR_GoogleMap_Tests
- LICENSE
- .gitignore
- README.md
- SignalR_GoogleMap_RealTimeNotification.sln
```

## Sqlite project

SQLite is a small, fast and embeddable database where the database engine and the interface are combined into a single library. It also has the ability to store all the data in a single file. So if your application requires a standalone database, SQLite is perhaps the perfect choice for you. There are, of course, other reasons for choosing SQLite including:

- SQLite has a small memory footprint and only a single library is required to access databases, making it ideal for embedded database applications.
- SQLite has been ported to many platforms and runs even on Windows CE and Palm OS.
- SQLite is ACID-compliant, meeting all four criteria - Atomicity, Consistency, Isolation, and Durability.
- SQLite implements a large subset of the ANSI-92 SQL standard, including views, sub-queries and triggers.
- No problem of extra database drivers, ODBC configuration required. Just include the library and the data file with your application.
- SQLite has native language APIs for C/C++, PHP, Perl, Python, Tcl etc. Native API for C# is still not present.

### Using the Code

To use `SQLite` I will create a class library for database communication. So let's create class library.
```
$ cd SignalR_GoogleMap_Sqlite
$ dotnet new classlib
```

The above snippet will create a class library for you that will look like this.

```
|- SignalR_GoogleMap_Sqlite
    |- bin
- Class1.cs
- SignalR_GoogleMap_Sqlite.csproj
```

Now lets build our class library and move to the test project.

```
$ dotnet build
$ cd..
```
## Test Project

This project will contain all the test methods that we will write in future for testing our application based on Unit and Integration tests, to setup your test project use:

```
$ cd SignalR_GoogleMap_Tests
$ dotnet new xunit
```
This will create a test project based on xunit framework that will be used in future for writing tests, your directory will look like this.
```
|- SignalR_GoogleMap_Tests
    |- bin
    |- obj
- UnitTest1.cs
- SignalR_GoogleMap_Tests.csproj
```
Now after we have successfully created our test project we need to build and run test to verify our test project, to do so use:
```
$ dotnet build
$ dotnet test
$ cd..
```
This will build and run the test for you, isn't it ***AMAZING!!!***

## Web Project
At last we need to create our web profile for the project to create our web profile we will create a MVC(Model View Controller) project for storing all the nasty logic of SignalR and for managing the Orders. To create our web project use:
```
$ cd SignalR_GoogleMap_Web
$ dotnet new mvc
```
This will create new MVC project for you, it looks like this.

![alt text](Images/web_architecture.PNG)

Now we will build the application.
```
$ dotnet build
```
Now after all this thing we will add the projects to the solution so that we will build and manage project dependency.

## Adding projects to Solutions

To Add project you need to be in parent directory and by using these commands you can add your projects to the solution.

```
$ dotnet sln add SignalR_GoogleMap_Tests/SignalR_GoogleMap_Tests.csproj
$ dotnet sln add SignalR_GoogleMap_Sqlite/SignalR_GoogleMap_Sqlite.csproj
$ dotnet sln add SignalR_GoogleMap_Web/SignalR_GoogleMap_Web.csproj
```
Now we need to build the solution to find every thing is working fine. To do this run:
```
$ dotnet build
Microsoft (R) Build Engine version 15.9.20+g88f5fadfbe for .NET Core
Copyright (C) Microsoft Corporation. All rights reserved.

  Restore completed in 117.48 ms for D:\Projects\Github\.Net Projects\SignalR_GoogleMap_RealTimeNotification\SignalR_GoogleMap_Sqlite\SignalR_GoogleMap_Sqlite.csproj.
  Restore completed in 119.66 ms for D:\Projects\Github\.Net Projects\SignalR_GoogleMap_RealTimeNotification\SignalR_GoogleMap_Tests\SignalR_GoogleMap_Tests.csproj.
  Restore completed in 169.47 ms for D:\Projects\Github\.Net Projects\SignalR_GoogleMap_RealTimeNotification\SignalR_GoogleMap_Web\SignalR_GoogleMap_Web.csproj.
  SignalR_GoogleMap_Tests -> D:\Projects\Github\.Net Projects\SignalR_GoogleMap_RealTimeNotification\SignalR_GoogleMap_Tests\bin\Debug\netcoreapp2.1\SignalR_GoogleMap_Tests.dll
  SignalR_GoogleMap_Sqlite -> D:\Projects\Github\.Net Projects\SignalR_GoogleMap_RealTimeNotification\SignalR_GoogleMap_Sqlite\bin\Debug\netstandard2.0\SignalR_GoogleMap_Sqlite.dll
  SignalR_GoogleMap_RealTimeNotification -> D:\Projects\Github\.Net Projects\SignalR_GoogleMap_RealTimeNotification\SignalR_GoogleMap_Web\bin\Debug\netcoreapp2.1\SignalR_GoogleMap_Web.dll
  SignalR_GoogleMap_RealTimeNotification -> D:\Projects\Github\.Net Projects\SignalR_GoogleMap_RealTimeNotification\SignalR_GoogleMap_Web\bin\Debug\netcoreapp2.1\SignalR_GoogleMap_Web.Views.dll

Build succeeded.
    0 Warning(s)
    0 Error(s)

Time Elapsed 00:00:02.15
```

To run this website we will use:

```
$ dotnet run -p .\SignalR_GoogleMap_Web\SignalR_GoogleMap_Web.csproj

Using launch settings from .\SignalR_GoogleMap_Web\Properties\launchSettings.json...
info: Microsoft.AspNetCore.DataProtection.KeyManagement.XmlKeyManager[0]
      User profile is available. Using '~\AppData\Local\ASP.NET\DataProtection-Keys' as key repository and Windows DPAPI to encrypt keys at rest.
Hosting environment: Development
Content root path: D:\Projects\Github\.Net Projects\SignalR_GoogleMap_Web\SignalR_GoogleMap_Web
Now listening on: https://localhost:5001
Now listening on: http://localhost:5000
Application started. Press Ctrl+C to shut down.
```
This will run the project

[Previous Topic][1] <br>                                     [Next Topic][2]

[1]: ../README.md
[2]: SQLITESETUP.md