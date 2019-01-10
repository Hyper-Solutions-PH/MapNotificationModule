# Setting up Google Map
Google Map is very popular map service provided by Google. Since it is paid you need to generate `Your-Api-Key`. Follow this [link](https://developers.google.com/maps/documentation/embed/get-api-key) to generate you API key and assign it to `Maps Javascript API`.

After getting `Your-Api-Key`, lets create our map using it. Follow these steps:

- Create new route in your MVC project `/Home/Map`
  ```c#
    /* 
    File: SignalR_GoogleMap_Web\Controllers\HomeController.cs
    Copy these lines
    */

    ---
    namespace SignalR_GoogleMap_Web.Controllers
    {
        public class HomeController : Controller
        {
            ----
            public IActionResult Map()
            {
                return View();
            }
        }
    }
  ```
  Create `SignalR_GoogleMap_Web\Views\Home\Map.cshtml` file and paste this code.
  ```cshtml
    @{
    ViewData["Title"] = "Google Map";
    }

    <h2>@ViewData["Title"] Real Time Notification</h2>

    <p>Open this page in the new tab and then create the orders from    Dashboard.</p>

    <style>
           /* Set the size of the div element that contains the map */
          #map {
            height: 500px;  /* The height is 400 pixels */
            width: 95%;  /* The width is the width of the web page */
            background-color: grey;
           }
    </style>

    <!--The div element for the map -->
    <div id="map"></div>
  ```
  This will create a `div` which will contain the map.
- Open `SignalR_GoogleMap_Web\wwwroot\js\site.js` and paste the following code.
  ```javascript
    // Initialize and add the map

    // imported google map js
    $.getScript('https://maps.googleapis.com/maps/api/js?   key=Your-Api-Key&callback=initMap',function () {
    });

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
                position: new google.maps.LatLng(-33.91539, 151.22820)  ,
                type: 'created'
            },
            {
                position: new google.maps.LatLng(26.449923, 80.331871)  ,
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
  ```
  So now lets see what is going on with this code. 
  ```javascript
  $.getScript('https://maps.googleapis.com/maps/api/js?   key=Your-Api-Key&callback=initMap',function () {
    });
  ```
  In the above snippet I have imported Google map js for integrating Google Map Api. You need to add `Your-Api-Key`.
  ```javascript
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
  ```
  As I am using custom markers for every order status I have used different colored icons to differentiate my status. You can add more order status if you need by coping your image to `SignalR_GoogleMap_Web\wwwroot\images\blue.png` and include in this list.
  ```javascript
    function initMap() {
      ---
    }
  ```
  This method is called at the time Map in initiated. So any operation that you want to do with Map need to be specified here.
  ```javascript
    // GoogleMap Options
    var mapOptions = {
        center: new google.maps.LatLng(0, 0),
        zoom: 2,
        minZoom: 1
    }
  ```
  Google Map provides different options for map, I am only using few of the important/Required options for the Google map.

  **Center (Required):** Specify latitude-longitude co-ordinates which you want to be center for the map.

  **Zoom/MinZoom (Optional):** This will specify how much default zoom you want your map to have at the time of load.
  ```javascript
    // The map initialize
    var map = new google.maps.Map(
        document.getElementById('map'), mapOptions);
  ```
  This will create your map instance with the options you have stated above.
  ```javascript
    // Static location for testing markers
    var markers = [
        {
            position: new google.maps.LatLng(-25.344, 131.036,
            type: 'cancel'
        },
        {
            position: new google.maps.LatLng(-33.91539,151.22820)  ,
            type: 'created'
        },
        {
            position: new google.maps.LatLng(26.449923,80.331871)  ,
            type: 'completed'
        }
    ];
  ```
  For testing purpose we are using static markers will do it dynamically in the `Next Chapter` when we will implement the communication between SignalR Server and Clients.
  ```javascript
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
                marker.setAnimatio(google.maps.Animation.BOUNCE);
            }
        }
    });
  ```
  In the above code snippet I have done a lot of thing which I am going to use in the `Next Chapter`.

  First thing first I have iterated locations and created a separate marker for the each location with the help of `google.maps.Marker` class and defined its `position` `icon` and `animation` attributes and associated it with the `map`. I am using `Bounce` animation for markers, you can change it according to Microsoft documentation. 

  Then to test animation I have added an `click` event listener which will add or remove animation.

- So last and final step is to add route open `SignalR_GoogleMap_Web\Views\Shared\_Layout.cshtml` and update this route.
  ```html
  ----
    <div class="navbar-collapse collapse">
        <ul class="nav navbar-nav">
            <li><a asp-area="" asp-controller="Home" asp-action="Index">Dashboard</a></li>
            <li><a asp-area="" asp-controller="Home" asp-action="Map">Google Map</a></li>
            <li><a asp-area="" asp-controller="Home" asp-action="Technology">Technology</a></li>
            <li><a href="https://abhinav2127.github.io/MapNotificationModule/">Tutorial</a></li>
            <li><a asp-area="" asp-controller="Home" asp-action="Contact">Contact</a></li>
        </ul>
    </div>
  ----
  ```

We are all set to go now you can build your project and run it. `Make sure you have added your Credit Card details while generating API-Key because it give exception if you exceed you daily limit of map load`

```
$ dotnet build
$ dotnet run -p .\SignalR_GoogleMap_Web\SignalR_GoogleMap_Web.csproj
```

Now we will work on connecting SignalR Server with Clients. See you in the next chapter.