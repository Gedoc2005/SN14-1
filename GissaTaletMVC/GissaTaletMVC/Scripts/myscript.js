$(function () {
    $('input').on("keyup", function () {
        if ($('form').valid()) {
            $(".validation-summary-errors").hide();
        }
        else {
            $(".validation-summary-errors").show();
        }
    });
});

$(document).ajaxStop(function () {
    if ($('form').valid()) {
        $(".validation-summary-errors").hide();
    }
    else {
        $(".validation-summary-errors").show();
    }
    var nils = "Hej";
    console.log(nils);
});

