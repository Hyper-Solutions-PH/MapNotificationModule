# Setting Up SignalR
SignalR is a software library for Microsoft ASP.NET that allows server code to send asynchronous notifications to client-side web applications. The library includes server-side and client-side JavaScript components.

SignalR provides two models for communication:

`Persistent Connections`: 
The Persistent Connection API gives developer direct access to the low level communication protocol that SignalR exposes. This API uses the format of the actual message sent that needs to be specified and if the developer prefers to work with messaging and dispatching model rather than a remote invocation.

`Hubs`: 
It's a High Level API written over Persistent Connection. This API allows the client and server to call methods on each other directly. Hubs also allow you to pass strongly typed parameters to methods, enabling model binding.

## Adding SignalR
The SignalR server library is included in the Microsoft.AspNetCore.App metapackage. The JavaScript client library isn't automatically included in the project. For this tutorial, you use NPM to get the client library from node module.

To do this follow these steps:

- Create NPM project and install `@aspnet/signalr` package.
  ```
  $ npm init
  ```
  Accept all the options as we will not use it further. Now you will see the package file generated in the the main directory `MapNotificationModule`.
  
  Now install the `@aspnet/signalr` node package.
  ```
  $ npm install @aspnet/signalr
  ```
  It will take a while to install based on your internet connection.

  Now you can find `node_modules` folder containing all the packages for the project.

  <img src="images/Node_Package_Install.PNG" width=200>

- Add `signalr.js` to the Web project you will find this file inside your node module.
  ```
  Source File Path
  $ ~\node_modules\@aspnet\signalr\dist\browser\signalr.js
  Destination File Path
  $ ~\SignalR_GoogleMap_Web\wwwroot\signalr\signalr.js
  ```
  Copy `signalr.js` file from the source file path and paste it to the destination file path.

- That's it you are done with NPM now, you can remove the `nodemodule` folder, `package.json` and `package-lock.json` file from your source folder.
  
  This is how web project looks after this process.
  
  <img src="images/Removed_Node_Package.PNG" width=200>
- 