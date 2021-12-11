function enviarIdPublicacion(id) {
    $.ajax({
        type: 'GET',
        url: '/VerCarros/mostrarDetalles',
        data: { IDPublicacion: id },
        dataType: 'json',
        success: function (data) {



        },
        error: function (data) {




            //$("#tablaAjustes").hide();
        }
    });
}