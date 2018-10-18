var idBanco = "";
var idSucursal = "";
var idOrdenPago = "";

function visualizarBanco() {
    visualizarComponente("Banco", llenarListaBanco);
}

function visualizarSucursal() {
    visualizarComponente("Sucursal", llenarComboBancoSucursal);
}

function visualizarOrdenPago() {
    visualizarComponente("OrdenPago", listarBanco);
}

function listarBanco(llenarBanco) {
    debugger;
    $.get("/banco/listar")
        .done(function (data) {
            debugger;
            llenarBanco(data);
        })
        .fail(function (jqXHR, textStatus, err) {
            debugger;
        });
}

function llenarListaBanco()
{
    debugger;
    listarBanco(
        function (data) {
            debugger;
            $('#lstBancos').empty();
            for (var item in data) {
                agregarBancoLista(data[item].id, data[item].nombre);
            }
        }
    )
    
}

function agregarBancoLista(id, nombre)
{
    var boton = '<button type="button" class="list-group-item list-group-item-action"' +
        'onclick = "obtenerBanco(\'' + id + '\')"> ' + nombre + '</button>';
    $('#lstBancos').append(boton);
}

function obtenerBanco(id)
{
    debugger;
    idBanco = id;
    $.get("/banco/obtener/"+id)
        .done(function (data) {
            debugger;
            $("#txtNombre").val(data.nombre);
            $("#txtDireccion").val(data.direccion);
            $("#txtFecRegistro").val(data.fechaRegistro);
        })
        .fail(function (jqXHR, textStatus, err) {
            debugger;
        });
}

function guardarBanco() {
    debugger;
    var serialice = $('#frmBanco').serialize();

    if (idBanco === "") {
        $.post("/banco/registrar", serialice)
            .done(function (data) {
                debugger;
                listarBanco();
            })
            .fail(function (jqXHR, textStatus, err) {
                debugger;
            });
    }
    else
    {
        serialice = serialice + "&id=" + idBanco;
        $.post("/banco/actualizar", serialice)
            .done(function (data) {
                debugger;
                listarBanco();
            })
            .fail(function (jqXHR, textStatus, err) {
                debugger;
            });
    }

    return false;
}

function eliminarBanco() {
    debugger;
    $.post("/banco/eliminar", "{id:" + idBanco + "}")
        .done(function (data) {
            debugger;
            listarBanco();
        })
        .fail(function (jqXHR, textStatus, err) {
            debugger;
        });
}






function llenarComboBancoSucursal() {
    listarBanco(
        function (data) {
            $('#cmbBanco').empty();
            for (var item in data) {
                $('#cmbBanco').append("<option value=" + data[item].id + ">" + data[item].nombre + "</option>")
            }
            llenarSucursales();
        }
    )
}

function llenarSucursales()
{
    debugger;
    idBanco = $("#cmbBanco").val();
    llenarListaSucursal();
}

function listarSucursal(llenarSucursal) {
    debugger;
    $.get("/sucursal/listar/" + idBanco)
        .done(function (data) {
            debugger;
            llenarSucursal(data);
        })
        .fail(function (jqXHR, textStatus, err) {
            debugger;
        });
}

function llenarListaSucursal()
{
    listarSucursal(function (data) {
        for (var item in data) {
            agregarSucursalLista(data[item].id, data[item].nombre);
        }
    });
}


function agregarSucursalLista(id, nombre) {
    var boton = '<button type="button" class="list-group-item list-group-item-action"' +
        'onclick = "obtenerSucursal(\'' + id + '\')"> ' + nombre + '</button>';
    $('#lstSucursales').append(boton);
}

function obtenerSucursal(id) {
    debugger;
    idBanco = id;
    $.get("/sucursal/obtener/" + id)
        .done(function (data) {
            debugger;
            $("#txtNombre").val(data.nombre);
            $("#txtDireccion").val(data.direccion);
            $("#txtFecRegistro").val(data.fechaRegistro);
        })
        .fail(function (jqXHR, textStatus, err) {
            debugger;
        });
}

function guardarSucursal() {
    debugger;
    var serialice = $('#frmBanco').serialize();

    if (idSucursal === "") {
        $.post("/sucursal/registrar", serialice)
            .done(function (data) {
                debugger;
                llenarSucursales();
            })
            .fail(function (jqXHR, textStatus, err) {
                debugger;
            });
    }
    else {
        serialice = serialice + "&id=" + idSucursal;
        $.post("/sucursal/actualizar", serialice)
            .done(function (data) {
                debugger;
                llenarSucursales();
            })
            .fail(function (jqXHR, textStatus, err) {
                debugger;
            });
    }

    return false;
}

function eliminarSucursal() {
    debugger;
    $.post("/sucursal/eliminar", "{id:" + idSucursal + "}")
        .done(function (data) {
            debugger;
            llenarSucursales();
        })
        .fail(function (jqXHR, textStatus, err) {
            debugger;
        });
}












function listarOrdenPago() {
    debugger;
    $.get("/banco/listar")
        .done(function (data) {
            debugger;
            for (var item in data) {
                agregarBancoLista(data[item].id, data[item].nombre);
            }
        })
        .fail(function (jqXHR, textStatus, err) {
            debugger;
        });
}

function agregarOrdenPagoLista(id, nombre) {
    var boton = '<button type="button" class="list-group-item list-group-item-action"' +
        'onclick = "obtenerBanco(\'' + id + '\')"> ' + nombre + '</button>';
    $('#lstBancos').append(boton);
}

function obtenerOrdenPago(id) {
    debugger;
    idBanco = id;
    $.get("/banco/obtener/" + id)
        .done(function (data) {
            debugger;
            $("#txtNombre").val(data.nombre);
            $("#txtDireccion").val(data.direccion);
            $("#txtFecRegistro").val(data.fechaRegistro);
        })
        .fail(function (jqXHR, textStatus, err) {
            debugger;
        });
}

function guardarOrdenPago() {
    debugger;
    var serialice = $('#frmBanco').serialize();

    if (idBanco === "") {
        $.post("/banco/registrar", serialice)
            .done(function (data) {
                debugger;
            })
            .fail(function (jqXHR, textStatus, err) {
                debugger;
            });
    }
    else {
        serialice = serialice + "&id=" + idBanco;
        $.post("/banco/actualizar", serialice)
            .done(function (data) {
                debugger;
            })
            .fail(function (jqXHR, textStatus, err) {
                debugger;
            });
    }

    return false;
}

function eliminarOrdenPago() {
    debugger;
    $.post("/banco/eliminar", "{id:" + idBanco + "}")
        .done(function (data) {
            debugger;
        })
        .fail(function (jqXHR, textStatus, err) {
            debugger;
        });
}