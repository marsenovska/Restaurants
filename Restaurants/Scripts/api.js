$(function () {
    $.getJSON('/api/restaurant', function (restaurants) {
        $(restaurants).each(function (i, item) {
            $("#restaurantTitle").html("Choose a restaurant to visit!");
            $("#restaurants").append("<p>" + item.Name + "</p>");
        });
    });
});

$(function () {
    $("#searchBtn").click(
        function () {
        var jsonData = JSON.stringify({ name: $("#searchField").val(), category: $("#category").val() });
        $.ajax({
            type: "POST",
            url: "/api/restaurant",
            data: jsonData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (items) {
                var numItems = items.length;
                $("#searchResults").html(" ");
                if (numItems > 0) {
                    for (var i = 0; i < numItems; i++) {
                        $("#searchTitle").html("Why don't you try:");
                        $("#searchResults").append("<tr><td style='padding:10px; padding-left:0'>" + items[i].Name + "</td><td style='padding:10px'>" + items[i].Type + "</td><td style='padding:10px'>" + items[i].Address + "</td><td style='padding:10px'>" + items[i].Phone + "</td></tr>");
                    }
                } else {
                    $("#searchTitle").html("There are no restaurants that match the searched criteria!");
                    $("#searchResults").html(" ");
                }
            }
        });
    });
});

$("#searchField").keypress(function (event) {
    if (event.keyCode === 13) {
        event.preventDefault();
        $("#searchBtn").click();
        return false;
    }
});