"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/orderFeedHub").build();

connection.on("ReceiveMessage", function (data) {
    this.initMap(data);
}.bind(this));

connection.start().catch(function (err) {
    return console.error(err.toString());
});

// A way to send order details when order is added
// document.getElementById("sendButton").addEventListener("click", function (event) {
//     debugger;
//     connection.invoke("SendOrderDetail", "ReceiveMessage").catch(function (err) {
//         return console.error(err.toString());
//     });
//     event.preventDefault();
// });

var fetchOrderDetails = function () {
    connection.invoke("SendOrderDetail", "ReceiveMessage").catch(function (err) {
        return console.error(err.toString());
    });
}