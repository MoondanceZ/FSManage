$(function () {
    ////$("li")
    $("li>a").click(function () {
        //$(this).parents("ul").children().removeClass("active");
        $(this).parent().addClass("active");
    })
})