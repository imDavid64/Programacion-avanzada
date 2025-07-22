$(function () {

    //--------------Acciones de botones registro y login--------------
    $("#btnNuevaPartida").on("click", function () {
        $("#display-newrun").css("display", "flex");
    });

    $("#btnCloseXNewRun").on("click", function () {
        $("#display-newrun").css("display", "none");
    });

    $("#btnCloseNewRun").on("click", function () {
        $("#display-newrun").css("display", "none");
    });
});