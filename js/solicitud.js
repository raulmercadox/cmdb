$(document).ready(function () {
    // Produccion
    // var url = "http://pelma3w8pap10v/cmdb/Proyecto/listarsol?id=" + $(".informacionProyecto").attr("data-proyectoId");
    // Desarrollo
    var url = "/Proyecto/listarsol?id=" + $(".informacionProyecto").attr("data-proyectoId");
    $.get(url, function (data) {
        var arreglo = [];
        arreglo.push([]);
        for (var i = 0; i < data.length; i++) {
            var dato = [];
            dato.push(i);
            dato.push(data[i].Cantidad);
            arreglo[0].push(dato);
        }
        var ejeX = [];
        for (var i = 0; i < data.length; i++) {
            var dato = [];
            dato.push(i);
            dato.push(data[i].Ambiente);
            ejeX.push(dato);
        }
        Flotr.draw(
            document.getElementById("chart"),
            arreglo,
            {
                title: "Pases pendientes",
                bars: {
                    show: true
                },
                yaxis: {
                    min: 0,
                    tickDecimals: 0
                },
                xaxis: {
                    ticks:ejeX
                }
            }
        );

    });
});