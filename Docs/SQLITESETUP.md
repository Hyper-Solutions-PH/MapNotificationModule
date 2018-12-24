## Setting up Sqlite
I am using Sqlite to store Order details of notification service so to setup our Sqlite application we need to add few packages.

First move the terminal to the Sqlite class library.
```
$ cd SignalR_GoogleMap_Sqlite
```
Now will add three packages.
```
$ dotnet add package Microsoft.EntityFrameworkCore -v 2.1.1
$ dotnet add package Microsoft.EntityFrameworkCore.Design -v 2.1.1
$ dotnet add package Microsoft.EntityFrameworkCore.Sqlite -v 2.1.1
```
These dependencies will help us to add DbContext of Sqlite. So lets create one for us. We will also create a provider which will provide **CRUD**(Create, Read, Update and Delete) operations from DbContext.

First we will create few files in our class library that will hold the context and the provider data.

![Sqlite Project Directory](Images/sqlite_project_directory.PNG)

This will look like this.

## Create Order Model

We are using few properties that are necessary for crating our application you can change it later according to your need.

![OrderModel](Images/order_model.PNG)

## SqliteContext
We will create this context file to handle the database and will inject this context at the time of Startup. To do this first create the SqliteContext

![SqliteContext](Images/Sqlitecontext.PNG)

Now we are set to go and now we can use this class library for connecting to the Database.

## Add Project reference to web project

To use dependency injection for managing the dependencies we need to add project refence to the web application.

```
$ cd SignalR_GoogleMap_Web
$ dotnet add reference ..\SignalR_GoogleMap_Sqlite\SignalR_GoogleMap_Sqlite.csproj
```

This will add the reference of our Sqlite Class Library, now next step is to add packages to the web project.

```
$ dotnet add package Microsoft.EntityFrameworkCore -v 2.1.1
$ dotnet add package Microsoft.EntityFrameworkCore.Design -v 2.1.1
$ dotnet add package Microsoft.EntityFrameworkCore.Sqlite -v 2.1.1
```
We need to add dependency in the startup project to use Sqlite, ***Startup.cs*** file.

```
*Filepath: SignalR_GoogleMap_Web/Startup.cs*
---
services.AddEntityFrameworkSqlite().AddDbContext<SqliteContext>((serviceProvider, options) =>
           options.UseSqlite("Data Source=Orders.db",b=>b.MigrationsAssembly("SignalR_GoogleMap_RealTimeNotification"))
                  .UseInternalServiceProvider(serviceProvider));
---
```
Now you are all set to initialize you database. Run these commands.
```
$ dotnet ef migrations add InitialCreate
$ dotnet ef database update
```
This will create ***Migrations Folder*** and ***Order.db*** file in your web project. Which will look like this.

![Sqlite_Web_Project_Architecture](Images/Sqlite_Web_Project_Architecture.png)

We are all set now we will build our solution and run the Web Application.
```
$ cd..
$ dotnet build
$ dotnet run -p .\SignalR_GoogleMap_Web\SignalR_GoogleMap_RealTimeNotification.csproj
```
