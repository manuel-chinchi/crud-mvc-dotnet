// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $('#switchBgTheme').change(function () {
        var icon = $('#switchIconTheme');
        if ($(this).is(':checked')) {
            /*console.log('dia');*/
            icon.removeClass('fa-moon-o');
            icon.addClass('fa-sun-o');
        } else {
            icon.removeClass('fa-sun-o');
            icon.addClass('fa-moon-o');
        }
    });
});