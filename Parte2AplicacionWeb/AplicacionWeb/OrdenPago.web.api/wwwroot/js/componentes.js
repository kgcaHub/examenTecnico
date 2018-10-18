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