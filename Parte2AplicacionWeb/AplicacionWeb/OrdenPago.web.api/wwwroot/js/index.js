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
    visualizarComponente("OrdenPago", llenarComboBancoOrdenPago);
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
            errorAjax(jqXHR);
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
            errorAjax(jqXHR);
        });
}

function registrarBanco() {
    debugger;
    var serialice = $('#frmBanco').serialize();

    $.post("/banco/registrar", serialice)
        .done(function (data) {
            debugger;
            succesAjax();
            limpiarBanco();
            llenarListaBanco();
        })
        .fail(function (jqXHR, textStatus, err) {
            debugger;
            errorAjax(jqXHR);
        });
}

function actualizarBanco() {
    debugger;
    var serialice = $('#frmBanco').serialize() + "&id=" + idBanco;

    $.post("/banco/actualizar", serialice)
        .done(function (data) {
            debugger;
            succesAjax();
            limpiarBanco();
            llenarListaBanco();
        })
        .fail(function (jqXHR, textStatus, err) {
            debugger;
            errorAjax(jqXHR);
        });

    return false;
}



function eliminarBanco() {
    debugger;
    $.post("/banco/eliminar", { "": idBanco })
        .done(function (data) {
            debugger;
            succesAjax();
            limpiarBanco();
            llenarListaBanco();
        })
        .fail(function (jqXHR, textStatus, err) {
            debugger;
            errorAjax(jqXHR);
        });
}

function limpiarBanco()
{
    idBanco = "";
    $("#txtNombre").val("");
    $("#txtDireccion").val("");
    $("#txtFecRegistro").val("");
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
            errorAjax(jqXHR);
        });
}

function llenarListaSucursal()
{
    listarSucursal(function (data) {
        $('#lstSucursales').empty();
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
    idSucursal = id;
    $.get("/sucursal/obtener/" + id)
        .done(function (data) {
            debugger;
            $("#txtNombre").val(data.nombre);
            $("#txtDireccion").val(data.direccion);
            $("#txtFecRegistro").val(data.fechaRegistro);
        })
        .fail(function (jqXHR, textStatus, err) {
            debugger;
            errorAjax(jqXHR);
        });
}

function registrarSucursal() {
    debugger;
    var serialice = $('#frmSucursal').serialize();

    $.post("/sucursal/registrar", serialice)
        .done(function (data) {
            debugger;
            succesAjax();
            limpiarSucursal();
            llenarSucursales();
        })
        .fail(function (jqXHR, textStatus, err) {
            debugger;
            errorAjax(jqXHR);
        });
}

function actualizarSucursal() {
    debugger;
    var serialice = $('#frmSucursal').serialize() + "&id=" + idSucursal;

    $.post("/sucursal/actualizar", serialice)
        .done(function (data) {
            debugger;
            succesAjax();
            limpiarSucursal();
            llenarSucursales();
        })
        .fail(function (jqXHR, textStatus, err) {
            debugger;
            errorAjax(jqXHR);
        });
}

function eliminarSucursal() {
    debugger;
    $.post("/sucursal/eliminar", { "": idSucursal })
        .done(function (data) {
            debugger;
            succesAjax();
            limpiarSucursal();
            llenarSucursales();
        })
        .fail(function (jqXHR, textStatus, err) {
            debugger;
            errorAjax(jqXHR);
        });
}

function limpiarSucursal() {
    idSucursal = "";
    $("#txtNombre").val("");
    $("#txtDireccion").val("");
    $("#txtFecRegistro").val("");
}






function llenarComboBancoOrdenPago() {
    listarBanco(
        function (data) {
            $('#cmbBanco').empty();
            for (var item in data) {
                $('#cmbBanco').append("<option value=" + data[item].id + ">" + data[item].nombre + "</option>")
            }
            llenarComboSucursalOrdenPago();
        }
    )
}

function llenarComboSucursalOrdenPago() {
    idBanco = $("#cmbBanco").val();
    listarSucursal(
        function (data) {
            $('#cmbSucursal').empty();
            for (var item in data) {
                $('#cmbSucursal').append("<option value=" + data[item].id + ">" + data[item].nombre + "</option>")
            }
            llenarOrdenPagoes();
        }
    )
}

function llenarOrdenPagoes() {
    debugger;
    idSucursal = $("#cmbSucursal").val();
    llenarListaOrdenPago();
}

function listarOrdenPago(llenarOrdenPago) {
    debugger;
    $.get("/OrdenPago/listar/" + idSucursal)
        .done(function (data) {
            debugger;
            llenarOrdenPago(data);
        })
        .fail(function (jqXHR, textStatus, err) {
            debugger;
            errorAjax(jqXHR);
        });
}

function llenarListaOrdenPago() {
    listarOrdenPago(function (data) {
        $('#lstOrdenPagoes').empty();
        for (var item in data) {
            agregarOrdenPagoLista(data[item].id, data[item].monto);
        }
    });
}

function agregarOrdenPagoLista(id, monto) {
    var boton = '<button type="button" class="list-group-item list-group-item-action"' +
        'onclick = "obtenerOrdenPago(\'' + id + '\')"> ' + monto + '</button>';
    $('#lstOrdenPagoes').append(boton);
}

function obtenerOrdenPago(id) {
    debugger;
    idOrdenPago = id;
    $.get("/OrdenPago/obtener/" + id)
        .done(function (data) {
            debugger;
            $("#txtMonto").val(data.monto);
            $("#cmbMoneda").val(data.moneda);
            $("#cmbEstado").val(data.estado);
            $("#txtFecPago").val(data.fechaPago);
        })
        .fail(function (jqXHR, textStatus, err) {
            debugger;
            errorAjax(jqXHR);
        });
}

function registrarOrdenPago() {
    debugger;
    var serialice = $('#frmOrdenPago').serialize();

    $.post("/OrdenPago/registrar", serialice)
        .done(function (data) {
            debugger;
            succesAjax();
            limpiarOrdenPago();
            llenarOrdenPagoes();
        })
        .fail(function (jqXHR, textStatus, err) {
            debugger;
            errorAjax(jqXHR);
        });
}

function actualizarOrdenPago() {
    debugger;
    var serialice = $('#frmOrdenPago').serialize() + "&id=" + idOrdenPago;

    $.post("/OrdenPago/actualizar", serialice)
        .done(function (data) {
            debugger;
            succesAjax();
            limpiarOrdenPago();
            llenarOrdenPagoes();
        })
        .fail(function (jqXHR, textStatus, err) {
            debugger;
            errorAjax(jqXHR);
        });
}

function eliminarOrdenPago() {
    debugger;
    $.post("/OrdenPago/eliminar", { "": idOrdenPago })
        .done(function (data) {
            debugger;
            succesAjax();
            limpiarOrdenPago();
            llenarOrdenPagoes();
        })
        .fail(function (jqXHR, textStatus, err) {
            debugger;
            errorAjax(jqXHR);
        });
}

function limpiarOrdenPago() {
    idOrdenPago = "";
    $("#txtMonto").val("");
    $("#txtFecPago").val("");
}


