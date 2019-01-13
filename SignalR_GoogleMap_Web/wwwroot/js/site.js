// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
"use strict";
$('.delete').click(function() {
    debugger;
    var row = $(this).closest('tr');
    var orderId= row.find('th').text();
    $.ajax({
        url: "https://localhost:5001/Home/RemoveOrder?orderId=" + orderId, success: function (result) {
            if(result) {
                row.remove();
              }
        }
    });
});