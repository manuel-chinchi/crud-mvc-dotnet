var sheetThemeLight = "/lib/bootstrap/dist/css/bootstrap.css";
var sheetThemeDarkly = "/lib/bootswatch/css/bootstrap.css";
var sheetRef = $('#bootstrap-theme');

function cargarEstilos(file, callback) {
    // Crear un nuevo elemento link
    var newSheet = $('<link rel="stylesheet" type="text/css" href="' + file + '">');

    // Adjuntar el nuevo elemento link al head
    $('head').append(newSheet);

    // Esperar a que se carguen los estilos
    newSheet.on('load', function () {
        // Ejecutar la función de devolución de llamada
        if (callback && typeof callback === 'function') {
            callback();
        }
    });
}

function alternarEstilos(fileActivated, fileDeactivated) {
    // Cargar el nuevo archivo en segundo plano
    cargarEstilos(fileActivated, function () {
        // Desactivar el archivo anterior
        sheetRef.remove();

        // Cambiar la referencia de la hoja de estilos activa
        sheetRef.attr('id', '');
        $('head link[href="' + fileActivated + '"]').attr('id', 'main-css');
    });
}

function changeTheme(theme) {
    var urlChangeTheme = "/Base/ChangeTheme?theme=" + theme;
    $.ajax({
        type: "POST",
        url: urlChangeTheme,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.theme != null) {
                console.log("a:" + data.theme + ", b:" + data.themeActivated);
            }
        },
        error: function (error) {
            console.log(error);
        }
    });
}

$(document).ready(function () {
    var buttonListExportRef = $("button.dt-button.buttons-collection");

    $('#btn-switch-theme').change(function () {
        if ($(this).is(':checked')) {
            changeTheme(sheetThemeDarkly);
            alternarEstilos(sheetThemeDarkly, sheetThemeLight);
        } else {
            changeTheme(sheetThemeLight);
            alternarEstilos(sheetThemeLight, sheetThemeDarkly);
        }
    });

    /*$(".dt-button-collection").addClass("bg-dark");*/
    buttonListExportRef.on('click', function () {
        alert("sss");
    });
});
