var chartInstance; // se hace global para poder volver a instanciar el grafico sin causar problemas (ejecutar F5 sin causar error)
var chartInstance2; // idem.

// ejemplos
// https://codepen.io/chartjs/pen/YVWZbz

$(document).ready(function () {
    $.ajax({
        type: "POST",
        url: urlDataCategories,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (_data) {
            var dataLabels = [];
            var dataContent = [];

            for (var i = 0; i < _data.length; i++) {
                dataLabels.push(_data[i].name);
                dataContent.push(_data[i].quantity);
            }

            if (chartInstance) {
                chartInstance.destroy();
            }

            // pie chart
            chartInstance = new Chart(chartPie, {
                type: 'pie',
                data: {
                    labels: dataLabels,
                    datasets: [{
                        data: dataContent,
                        backgroundColor: ['#007bff', '#dc3545', '#ffc107', '#28a745'],
                    }],
                },
                options: {
                    // ADVERTENCIA: 
                    // estas opciones pueden llegar a causar problemas de redimensionamiento erroneo en el grafico pie. Si se habilitan se
                    // deben tambien ajustar las propiedades de la clase 'chart-container', o sea, el contenedor del elemento 'canvas', ver
                    // los ejemplos en https://codepen.io/chartjs/pen/YVWZbz y https://www.chartjs.org/docs/latest/configuration/responsive.html#important-note

                    //responsive: true,
                    //maintainAspectRatio: false,

                    //responsive: true,
                    //maintainAspectRatio: true,

                }
            });

            // bar chart
            chartInstance2 = new Chart(chartBar, {
                type: 'bar',
                data: {
                    labels: dataLabels,
                    datasets: [{
                        data: dataContent,
                        backgroundColor: ['#007bff', '#dc3545', '#ffc107', '#28a745'],
                    }],
                },
                options: {
                    scales: {
                        y: {
                            max: 10,
                            beginAtZero: true
                        }
                    },
                    maintainAspectRatio: false,
                    plugins: {
                        legend: {
                            display: false // hide the 'undefined' top legend into chart
                        }
                    }
                },
            });
        },
        error: function (error) {
            console.log(error);
        }
    });

    $("#btn-download-chart").on("click", function () {
        var chartIns;
        var chartName;

        if (!chartPie.is(":hidden")) {
            chartIns = chartInstance;
            chartName = "chart_pie.png";
        }
        if (!chartBar.is(":hidden")) {
            chartIns = chartInstance2;
            chartName = "chart_bar.png";
        }

        var image = chartIns.toBase64Image();
        var a = document.createElement('a');
        a.href = image;
        a.download = chartName;

        a.click();
    });
});

