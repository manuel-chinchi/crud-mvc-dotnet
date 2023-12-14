var urlDataCategories = "/Report/GetDataCategories";
var chartPie = $("#chart-pie");
var chartBar = $("#chart-bar");

$(document).ready(function () {
    /* enable and disable all type charts here */
    $('select').change(function () {
        var value = $(this).val();
        if (value == 'pie') {
            chartBar.hide();
            chartPie.show();
        }
        if (value == 'bar') {
            chartPie.hide();
            chartBar.show();
        }
    })
});