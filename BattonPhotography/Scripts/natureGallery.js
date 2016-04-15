$(function () {

    var nextLink = $("#nextLink").val();
    var previousLink = $("#previousLink").val();

    $(".galClick").click(function (e) {

        $("#natureImage").attr("src", $(this).data("img"));
        $("#largeLink").attr("href", $(this).data("img"));
        $("#linkName").html($(this).data("name"));

        if ($(this).data("name")) {
            var name = $(this).data("name").slice(0, -4);
            $("#itemName").val(name);
        }

        $("#galModal").modal({ show: true });
    });

    $("#nextButton").click(function () {
        $.get(nextLink, function (html) {
            $("body").html(html);
        });
    });

    $("#previousButton").click(function () {
        $.get(previousLink, function (html) {
            $("body").html(html);
        });
    });
});