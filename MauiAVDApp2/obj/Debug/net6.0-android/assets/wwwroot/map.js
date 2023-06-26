window.LoadGoogleMaps = function () {
    return new Promise((resolve) => {
        if (typeof google === "undefined") {
            var script = document.createElement("script");
            script.src = "https://maps.googleapis.com/maps/api/js?key=AIzaSyCT7Drg7-0cLPWId5AErlvqztMxocDx6UM&libraries=places&callback=InitMap";
            script.async = true;
            script.defer = true;
            document.body.appendChild(script);
            window.InitMap = resolve;
        } else {
            resolve();
        }
    });
};

window.CreateMap = function (elementId) {
    var mapOptions = {
        center: { lat: 0, lng: 0 },
        zoom: 10,
    };

    var map = new google.maps.Map(document.getElementById(elementId), mapOptions);
    return map;
};

window.AddBoatPins = function (boatData) {
    boatData.forEach(function (boat) {
        var marker = new google.maps.Marker({
            position: { lat: boat.latitude, lng: boat.longitude },
            map: window.map,
        });

        marker.addListener("click", function () {
            window.location.href = "/boat/" + boat.BoatId; // Replace with your own boat detail route
        });
    });
}

window.HandlePinClicks = function () {
    google.maps.event.addListener(window.map, "click", function () {
        // Do something when the map is clicked
    });
};
