function adjuntarComponente(idComponente, funcionInicial) {
    debugger;
    var importado = document.getElementById('lnk' + idComponente).import;
    var componente = importado.getElementById('cpt' + idComponente);
    var contenedor = document.getElementById('cnt');
    contenedor.appendChild(componente.cloneNode(true));
    $("#cnt").show("slow");
    funcionInicial();
}

function visualizarComponente(idComponente, funcionInicial) {
    debugger;
    $("#cnt").hide("fast", function () {
        $("#cnt").empty();
        adjuntarComponente(idComponente, funcionInicial);
    });
}

function succesAjax()
{
    $("#altWarning").hide();
    $("#altDanger").hide();
    $("#altSuccess").hide();
    $('#altSuccess').html("Proceso exitoso!");
    $("#altSuccess").show();
}

function errorAjax(error)
{
    $("#altWarning").hide();
    $("#altDanger").hide();
    $("#altSuccess").hide();
    debugger;
    switch (error.responseJSON.tipo) {
        case "Validacion":
            $('#altWarning').html(error.responseJSON.mensajeUsuario);
            $("#altWarning").show();
            break;
        case "Error de sistema":
            $('#altDanger').html(error.responseJSON.mensajeUsuario);
            $("#altDanger").show();
            break;
    }
}