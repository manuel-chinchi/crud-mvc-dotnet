// Documentation 
// https://datatables.net/reference/option/language
// https://datatables.net/extensions/buttons/examples/html5/columns.html

// utils
// https://stackoverflow.com/questions/45515559/how-to-call-datatable-csv-button-from-custom-button
// https://stackoverflow.com/questions/54352745/how-to-hook-up-custom-buttons-instead-of-the-datatables-buttons?noredirect=1&lq=1
// https://live.datatables.net/

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
                className: 'btn btn-primary dropdown-toggle',
                //action: function (e, dt, node, config) { }
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
        ],
        initComplete: function () {
            applyCustomStyles();
        },
        drawCallback: function (settings) {
            applyCustomStyles2();
        }
    });

    function applyCustomStyles() {
        $(".dt-button.buttons-collection span").remove();

        var listButtons = $(".dt-button.buttons-collection");
        listButtons.removeClass("dt-button buttons-collection");
        listButtons.addClass("btn btn-primary dropdown-toggle w-100");
        listButtons.text("Exportar ");
    }

    function applyCustomStyles2() {
        //$(".dataTables_paginate.paging_simple_numbers").addClass("btn-group");

        //var numbers = $(".dataTables_paginate.paging_simple_numbers span").contents();
        //$(".dataTables_paginate.paging_simple_numbers span").replaceWith(numbers);
        //$(".paginate_button").removeClass("paginate_button").addClass("btn btn-primary");

        // TODO si agrego estos esitlos los botones quedan alineados a la izq. cuando deberían quedar 
        //centrados en pantallas chicas. revisar la clase "btn-group" su prop. "display"
    }
});