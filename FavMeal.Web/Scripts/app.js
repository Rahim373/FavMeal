var options = {
    componentRestrictions: {
        country: 'bd'
    }
};

var initAutocomplete = function () {
    var input = document.getElementById("placeName");
    autocomplete = new google.maps.places.Autocomplete(input, options);
    autocomplete.addListener('place_changed',
        function () {
            var place = autocomplete.getPlace();
            document.getElementById("PlaceId").value = place.place_id;
            alert(place.name);
        });
}


$(document).ready(function () {
    $.ajax({
        url: "/Foods/Get?term=",
        context: document.body,
        method : "GET",
        success: function(response) {
            var dl = $("#foodnamedl");
            for (var i = 0; i < response.length; i++) {
               dl.append("<option value='" + response[i].Name + "'>");
            }
        }
    });
});