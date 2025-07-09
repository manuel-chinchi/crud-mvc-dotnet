var sheetThemeLight;
var sheetThemeDark;
var sheetRef = $('#bootstrap-theme');

function loadStyles(file, callback) {
    var newSheet = $('<link rel="stylesheet" type="text/css" href="' + file + '">');

    $('head').append(newSheet);

    newSheet.on('load', function () {
        if (callback && typeof callback === 'function') {
            callback();
        }
    });
}

function alternateStyles(fileActivated) {
    loadStyles(fileActivated, function () {
        sheetRef.remove();

        sheetRef.attr('id', '');
        $('head link[href="' + fileActivated + '"]').attr('id', 'bootstrap-theme');
    });
}

function changeTheme(themeOn, themeOff, switchIsActive) {
    var urlChangeTheme = "/Application/ChangeTheme?themeOn=" + themeOn + "&themeOff=" + themeOff + "&switchIsActive=" + switchIsActive;
    $.ajax({
        type: "POST",
        url: urlChangeTheme,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data != null) {
                alternateStyles(data.themeOn);
            }
        },
        error: function (error) {
            console.log(error);
        }
    });
}

$(document).ready(function () {
    $('#btn-switch-theme').change(function () {
        if ($(this).is(':checked')) {
            changeTheme(sheetThemeDark, sheetThemeLight, true);
        } else {
            changeTheme(sheetThemeLight, sheetThemeDark, false);
        }
    });
});
