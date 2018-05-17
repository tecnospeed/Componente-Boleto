function listaCedentes() {
    $.post("listaCedentes.php", function (xmlAssinado) {
        $("#xmlRetorno").val(xmlAssinado);
    });
}




function enviartx2Padrao() {
    var tx2Padrao = $("#textAreaTX2Padrao").val();
    $.post("incluirBoletoPadrao.php", {tx2Padrao: tx2Padrao}, function (retJson) {
    $("#modalBoleto").modal('hide');
        $("#xmlRetorno").val(retJson);
        retJson = JSON.parse(retJson);
        var idintegracao = retJson._dados._sucesso[0].idintegracao;
        $("#idintegracao").val(idintegracao);
    });
}

function gerarRemessaLote() {
    var idGerarRemessa = $("#idintegracao").val();
    console.log(idGerarRemessa);
    $.post("gerarRemessa.php", {idGerarRemessa: idGerarRemessa}, function (retorno) {
        $("#xmlRetorno").val(retorno);
        var arqRemessa = JSON.parse(retorno);
        var nomeArquivo = arqRemessa._dados._sucesso[0].arquivo;
        var retornoRemessa = arqRemessa._dados._sucesso[0].remessa;
        $.post("salvarRemessa.php", {nomeArquivo: nomeArquivo, retornoRemessa: retornoRemessa}, function (retorno) {
            location.href = 'baixarArquivoRemessa.php?nomeArquivo=' + nomeArquivo;
        });
    });
}

function incluir() {
    $.post("incluirBoletoJson.php", function (xmlAssinado) {
        $("#xmlRetorno").val(xmlAssinado);
        xmlAssinado = JSON.parse(xmlAssinado);
        var idintegracao = xmlAssinado._dados._sucesso[0].idintegracao;
        $("#idintegracao").val(idintegracao);
    });

}
function emailLote() {
    var idemailLote = $("#protImpressao").val();  
    $.post("emailLote.php", function (retorno) {
        $("#xmlRetorno").val(retorno);  
    });
}function processarRetorno() {
    var idretorno = $("#protImpressao").val();  
    $.post("processarRetorno.php", function (retorno) {
        $("#xmlRetorno").val(retorno);  
    });
}

function gerarRemessaAlteracao() {
    var idalteracao = $("#protAlteracao").val();  
    $.post("gerarRemessaAlteracao.php", function (retorno) {
        $("#xmlRetorno").val(retorno);  
    });
}
function gerarRemessaBaixa() {
    var idintegracao = $("#idintegracao").val();
    console.log(idintegracao);
    $.post("gerarRemessaBaixa.php", {idintegracao: idintegracao}, function (retorno) {
        $("#xmlRetorno").val(retorno);
    });
}
function descartarBoleto() {
    var idintegracao = $("#idintegracao").val();
    console.log(idintegracao);
    $.post("descartarBoleto.php", {idintegracao: idintegracao}, function (retorno) {
        $("#xmlRetorno").val(retorno);
    });
}

function consultarRemessaBaixa() {
    var protBaixa = $("#protBaixa").val();
    $.post("consultarRemessaBaixa.php", {protBaixa: protBaixa}, function (xmlRetorno) {
        $("#modalConsulta").modal('hide');
        $("#xmlRetorno").val(xmlRetorno);
    });
}
function consultaRetornoProcessamento() {
    var protRetorno = $("#protRetorno").val();
    $.post("consultaRetornoProcessamento.php", {protRetorno: protRetorno}, function (xmlRetorno) {
        $("#modalConsulta").modal('hide');
        $("#xmlRetorno").val(xmlRetorno);
    });
}
function cosultarRemessaAlteração() {
    var protAlteracao = $("#protAlteracao").val();
    $.post("cosultarRemessaAlteração.php", {protAlteracao: protAlteracao}, function (xmlRetorno) {
        $("#modalConsulta").modal('hide');
        $("#xmlRetorno").val(xmlRetorno);
    });
}
function consultarEmailLote() {
    var protEmail = $("#protEmail").val();
    $.post("consultarEmailLote.php", {protEmail: protEmail}, function (xmlRetorno) {
        $("#modalConsulta").modal('hide');
        $("#xmlRetorno").val(xmlRetorno);
    });
}
function imprimirLote() {
    var idImprimirLote = $("#protImpressao").val();  
    $.post("imprimirLote.php", function (retorno) {
        $("#xmlRetorno").val(retorno);  
    });
}

//function imprimirLote() {
//    var idImprimirLote = $("#protImpressao").val();
    /*console.log(idGerarRemessa);*/
//    $.post("imprimirLote.php", {idImprimirLote: idImprimirLote}, function (retorno) {
//        $("#xmlRetorno").val(retorno);
//        var protImpressao = xmlAssinado._dados._sucesso[0].protocolo;
        /*$("#protImpressao").val(protocolo);*/
//        $("#protImpressao").val(protImpressao);
        /*$.post("salvarRemessa.php", {nomeArquivo: nomeArquivo, retornoRemessa: retornoRemessa}, function (retorno) {
            location.href = 'baixarArquivoRemessa.php?nomeArquivo=' + nomeArquivo;
        });*/
//    });
//}
function SalvarLoteImpressaoPDF() {
    var protImpressao = $("#protImpressao").val();
    var link = 'http://homologacao.cobrancabancaria.tecnospeed.com.br:8080/api/v1/boletos/impressao/lote/' + protImpressao;
    window.open(link, '_blank');
    
}

function consultarIds() {
    var idintegracao = $("#idintegracao").val();
    $.post("consultarIds.php", {idintegracao: idintegracao}, function (xmlRetorno) {
        $("#modalConsulta").modal('hide');
        $("#xmlRetorno").val(xmlRetorno);
    });
}

function imprimeBoletoFin() {
    var idintegracao = $("#idintegracao").val();
    if(!idintegracao){
        idintegracao = 'BJeENF32Al';
        
    }
    var link = 'http://homologacao.cobrancabancaria.tecnospeed.com.br:8080/api/v1/boletos/impressao/' + idintegracao;
    window.open(link, '_blank');
}



function enviaEmailBoleto() {
    var emailDest = $("#emailDest").val();
    $.post("enviaEmail.php", {destinatario: emailDest}, function (retorno) {
        $("#xmlRetorno").val(retorno);
        $('#modalenviaEmail').modal('hide');
    });
}
//
// function enviatx2Padrao() {
//     alert(retorno);
//     die();
//     $.post("incluirBoletoPadrao.php",{destinatario: 'teste'}, function (retorno) {
//         $("#xmlRetorno").val(retorno);
//         $('#modalenviaEmail').modal('hide');
//     });
// }