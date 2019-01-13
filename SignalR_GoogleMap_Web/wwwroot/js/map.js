// Initialize and add the map

"use strict";

// imported google map js
$.getScript('https://maps.googleapis.com/maps/api/js?sensor=false&libraries=geometry,places&ext=.js', function () {
    // Custom marker icon image path
    var baseIconPath = "https://localhost:5001/";
    var markerImages = {
        completed: {
            icon: baseIconPath + 'images/green.png'
        },
        cancel: {
            icon: baseIconPath + 'images/red.png'
        },
        created: {
            icon: baseIconPath + 'images/blue.png'
        }
    };

    var orderStatus = function (status) {
        switch (status) {
            case "Completed":
                return "completed";
            case "Cancle":
                return "cancel";
            case "Pending":
                return "created";
        }
    };


    this.initMap = function (orderDetails) {
        if (!orderDetails) {
            this.fetchOrderDetails();
        }
        else {
            // GoogleMap Options
            var mapOptions = {
                center: new google.maps.LatLng(0, 0),
                zoom: 2,
                minZoom: 1
            }

            // The map initialize
            var map = new google.maps.Map(
                document.getElementById('map'), mapOptions);

            // Static location for testing markers
            var markers = [];

            orderDetails.forEach(function (order) {
                markers.push({
                    position: new google.maps.LatLng(order.latitude, order.longitude),
                    type: orderStatus(order.status),
                    label: order.orderTitle + '/' + order.id
                });
            });

            // Create markers
            markers.forEach(function (feature) {
                var marker = new google.maps.Marker({
                    position: feature.position,
                    icon: markerImages[feature.type].icon,
                    animation: google.maps.Animation.DROP,
                    title:feature.label,
                    map: map
                });
                marker.addListener('click', toggleBounce);
                function toggleBounce() {
                    if (marker.getAnimation() !== null) {
                        marker.setAnimation(null);
                    } else {
                        marker.setAnimation(google.maps.Animation.BOUNCE);
                    }
                }
            });
        }
    }
    this.initMap();
}.bind(this));