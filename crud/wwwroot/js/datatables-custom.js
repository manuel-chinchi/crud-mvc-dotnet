// Documentation 
// https://datatables.net/reference/option/language

$(document).ready(function () {
    $('table').DataTable({
        language: {
            info: 'Mostrando registro _START_ hasta el _END_',
            infoEmpty: '',
            infoFiltered: '',
            zeroRecords: 'No se encontraron registros coincidentes',
            search: 'Buscar:',
            lengthMenu: 'Mostrar _MENU_ registros',
            paginate: {
                previous: 'Anterior',
                next: 'Siguiente'
            }
        },
    });
});