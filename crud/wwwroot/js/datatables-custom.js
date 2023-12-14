// Documentation 
// https://datatables.net/reference/option/language
// https://datatables.net/extensions/buttons/examples/html5/columns.html

$(document).ready(function () {
    tableRef.DataTable({
        language: {
            info: 'Mostrando registro _START_ hasta el _END_',
            infoEmpty: '',
            infoFiltered: '',
            zeroRecords: 'No se encontraron registros coincidentes',
            search: '',
            searchPlaceholder: "Buscar",
            lengthMenu: 'Mostrar _MENU_ registros',
            paginate: {
                previous: 'Anterior',
                next: 'Siguiente'
            },
            buttons: {
                copyTitle: 'Copiado al portapapeles',
                copySuccess: {
                    _: '%d líneas copiadas',
                },
            }
        },
        dom: 'lBfrtip',
        buttons: [
            {
                extend: 'collection',
                background: false,
                text: 'Exportar',
                buttons: [
                    {
                        extend: 'copy',
                        text: 'Copiar',
                        exportOptions: {
                            columns: tableCols
                        }
                    },
                    {
                        extend: 'csv',
                        exportOptions: {
                            columns: tableCols
                        }
                    },
                    {
                        extend: 'excel',
                        exportOptions: {
                            columns: tableCols
                        }
                    },
                    {
                        extend: 'pdf',
                        exportOptions: {
                            columns: tableCols
                        },
                    },
                ]
            },
        ]
    });
});