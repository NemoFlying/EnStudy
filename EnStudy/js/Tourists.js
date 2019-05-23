$(function () {
    $(".showBtn").click(function () {
        var divH = $(".Section0").height();
        if (divH > 600) {
            $(".Section1").css("height", "332px");
        } else {
            $(".Section1").css("height", "auto");
        }
    });
    $(".show1Btn").click(function () {
        var divH = $(".Section2").height();
        if (divH > 600) {
            $(".Section2").css("height", "332px");
        } else {
            $(".Section2").css("height", "auto");
        }
    });
    $(".show2Btn").click(function () {
        var divH = $(".Section3").height();
        if (divH > 600) {
            $(".Section3").css("height", "332px");
        } else {
            $(".Section3").css("height", "auto");
        }
    });
});