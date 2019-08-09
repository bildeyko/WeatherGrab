$(document).ready(function () {
    $(".get-weather-btn").click(function () {
        var id = $(this).val();
        $(location).attr('href', '/'+id);
    });
});
