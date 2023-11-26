if (navigator.geolocation) {
    navigator.geolocation.getCurrentPosition(showUserCity, showError);
} else {
    console.log("Geolocation is not supported by this browser.");
}

function showUserCity(position) {
    var userLocation = {
        lat: position.coords.latitude,
        lon: position.coords.longitude
    };

    var apiUrl = `https://nominatim.openstreetmap.org/reverse?lat=${userLocation.lat}&lon=${userLocation.lon}&format=json`;
    console.log(apiUrl);

    fetch(apiUrl)
        .then(response => response.json())
        .then(data => {
            if (data && data.address && data.address.province) {
                var city = data.address.province;

                // Set user's city dynamically into the weather widget link
                var weatherWidgetLink = document.getElementById('weatherW');
                weatherWidgetLink.href = `https://forecast7.com/en/${userLocation.lat}d${userLocation.lon}/${city.toLowerCase().replace(' ', '-')}/`;
                weatherWidgetLink.setAttribute('data-label_1', city.toUpperCase());
                weatherWidgetLink.textContent = city.toUpperCase() + ' WEATHER';
            } else {
                alert('City not found');
            }
        })
        .catch(error => {
            console.log('Error fetching data:', error);
            alert('Failed to fetch city information');
        });
}

function showError(error) {
    switch (error.code) {
        case error.PERMISSION_DENIED:
            console.log("User denied the request for Geolocation.");
            break;
        case error.POSITION_UNAVAILABLE:
            console.log("Location information is unavailable.");
            break;
        case error.TIMEOUT:
            console.log("The request to get user location timed out.");
            break;
        case error.UNKNOWN_ERROR:
            console.log("An unknown error occurred.");
            break;
    }
}