# SignalR_GoogleMap_RealTimeNotification
Sample application based on .Net Core 2.1, SignalR and Google Maps for real time order booking from SQL.

# Installation

Create new web application using Net Core 2.1 if you are starting fresh, using:

```
$ dotnet new webapp
```

This will create new web application for you.

Then to install signalr js we will use *npm*, using:

```
$ npm init
```

This will create new ***package.json*** file.

Now, we need to copy the ***singler.js*** file from ***node_modules***.

```
$ ~\node_modules\@aspnet\signalr\dist\browser\signalr.js
$
$ ~\wwwroot\lib\signalr\signalr.js
```

This we will use later. Now the last and the final thing we need to do.