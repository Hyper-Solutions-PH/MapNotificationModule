// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Initialize and add the map

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


function initMap() {
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
    var markers = [
        {
            position: new google.maps.LatLng(-25.344, 131.036),
            type: 'cancel'
        },
        {
            position: new google.maps.LatLng(-33.91539, 151.22820),
            type: 'created'
        },
        {
            position: new google.maps.LatLng(26.449923, 80.331871),
            type: 'completed'
        }
    ];
    
    // Create markers
    markers.forEach(function (feature) {
        var marker = new google.maps.Marker({
            position: feature.position,
            icon: markerImages[feature.type].icon,
            animation: google.maps.Animation.DROP,
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
initMap();
});


