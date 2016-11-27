$(document).ready(function(){
    function recuperarReceta(){
        $.getJSON("/api/receta/",
            function(data){
                $.each(data,function(key,val){
                    var str='('+val.Id+')'+ val.Tipo_Medicamento+ val.Nombre_Medicamento+val.Nombre_Paciente+val.Fecha;
                    $('<li/>',{html:str}).appendTo($('#Receta'));
                });
            });
    }
    recuperarReceta();
});

function buscarReceta(id, callback) {
    $.ajax({
        url: "/api/receta/",
        data: { id: id },
        type: "GET",
        contentType: "aplication/json;charset=utf-8",
        statusCode: {
            200: function (Receta) {
                callback(Receta);
            },
            404: function () {
                alert("Cliente no encontrado!");
            }
        }
    });

}

$('#buscarCliente').live({
    click: function () {
        var id = $('#IdReceta').val();
        buscarReceta(id, function (Receta) {
            var str = '(' + Receta.Id + ')' + Receta.Tipo_Medicamento + Receta.Nombre_Medicamento + Receta.Nombre_Paciente + Receta.Fecha;
            $('#Receta').html(str);

        });
    }
});

function crearReceta(nuevoReceta, callback) {
    $.ajax({
        url: "/api/receta/",
        data: JSON.stringify(nuevoReceta),
        type: "POST",
        contentType: "aplication/json;charset=utf-8",
        statusCode: {
            201: function (Receta) {
                callback(Receta);

            },
        }
    });
}

$('createCliente').live({
    click: function () {
        var nuevoReceta = {
            Nombre_Paciente: $(' Nombre_PacienteReceta').val()

        };

        crearReceta(nuevoReceta, function (Receta) {
            alert("El nuevo cliente a sido creado con el id" + Receta.Id);
        });

    }
});

function actualizarReceta(Receta, callback) {
    $.ajax({
        url: "/api/receta/",
        data: JSON.stringify(Receta),
        type: "PUT",
        contentType: "aplication/json;charset=utf-8",
        statusCode: {
            200: function () {
                callback();
            },
            404: function () {
                alert("Cliente no encontrado!");
            }
        }
    });
}

$('actualizarReceta').live({
    click: function () {
        var Receta = {
            Id: $('#Id').val(),
        };

        actualizarReceta(Receta, function () {
            alert("La receta se a actualizado.");
        });

    }
});

function eliminarReceta(Id, callback) {
    $.ajax({
        url: "/api/receta",
        data: JSON.stringify({Id:Id}),
        type: "DELETE",
        contentType: "aplication/json;charset=utf-8",
        statusCode: {
            204: function () {
                callback();
            },
            404: function () {
                alert("Cliente no encontrado!");
            }
        }
    });
}

$('eliminarReceta').live({
    click: function () {
        var Id = $('IdRecetaEliminar').val();
            Id: $('#Id').val(),
     
        eliminarReceta(Id, function () {
            alert("La receta se a Eliminado.");
        });

    }
});