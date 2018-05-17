function cadastrarCedente() {
  if (jsEntrada.value != "") {
    var settings = {
      "async": true,
      "crossDomain": true,
      "url": URLApi.value+"/api/v1/cedentes",
      "method": "POST",
      "headers": {
        "cnpj-sh": CnpjSH.value,
        "token-sh": tokenSH.value,
        "cnpj-cedente": cnpjCedente.value,
        "content-type": "application/json",
        "cache-control": "no-cache",
      },
      "processData": false,
      "data": jsEntrada.value
    }
    $.ajax(settings).done(function (incluirJson) {
      console.log(incluirJson);
      let json = JSON.stringify(incluirJson, null, 2);
      jsRetorno.value = json;
    });
  } else { alert("Por favor, informe um Json no campo 'Entrada'")}
}
function cadastrarConta() {
  if (jsEntrada.value != "") {
    var settings = {
      "async": true,
      "crossDomain": true,
      "url": URLApi.value+"/api/v1/cedentes/contas",
      "method": "POST",
      "headers": {
        "cnpj-sh": CnpjSH.value,
        "token-sh": tokenSH.value,
        "cnpj-cedente": cnpjCedente.value,
        "content-type": "application/json",
        "cache-control": "no-cache",
      },
      "processData": false,
      "data": jsEntrada.value
    }
    $.ajax(settings).done(function (incluirJson, err) {
      console.log(err)
      console.log(incluirJson);
      let json = JSON.stringify(incluirJson, null, 2);
      jsRetorno.value = json;
    });
  } else { alert("Por favor, informe um Json no campo 'Entrada'")}
}
function cadastrarConvenio() {
  if (jsEntrada.value != "") {
    var settings = {
      "async": true,
      "crossDomain": true,
      "url": URLApi.value+"/api/v1/cedentes/contas/convenios",
      "method": "POST",
      "headers": {
        "cnpj-sh": CnpjSH.value,
        "token-sh": tokenSH.value,
        "cnpj-cedente": cnpjCedente.value,
        "content-type": "application/json",
        "cache-control": "no-cache",
      },
      "processData": false,
      "data": jsEntrada.value
    }
    $.ajax(settings).done(function (incluirJson) {
      console.log(incluirJson);
      let json = JSON.stringify(incluirJson, null, 2);
      jsRetorno.value = json;
    });
  } else { alert("Por favor, informe um Json no campo 'Entrada'")}
}
function incluir() {
  if (jsEntrada.value != "") {
    var settings = {
      "async": true,
      "crossDomain": true,
      "url": URLApi.value+"/api/v1/boletos/lote",
      "method": "POST",
      "headers": {
        "cnpj-sh": CnpjSH.value,
        "token-sh": tokenSH.value,
        "cnpj-cedente": cnpjCedente.value,
        "content-type": "application/json",
        "cache-control": "no-cache",
      },
      "processData": false,
      "data": jsEntrada.value
    }
    jsEntrada.value = settings.data;
    $.ajax(settings).done(function (incluirJson) {
      console.log(incluirJson);
      let json = JSON.stringify(incluirJson, null, 2);
      jsRetorno.value = json;
      idintegracao.value = incluirJson._dados._sucesso[0].idintegracao;
    });
  } else { alert("Por favor, informe um Json no campo 'Entrada'")}
}
function consultarIds() {
  if (idintegracao.value != "") {
    var settings = {
        "async": true,
        "crossDomain": true,
        "url": URLApi.value+"/api/v1/boletos?idintegracao="+idintegracao.value,
        "method": "GET",
        "headers": {
          "cnpj-sh": CnpjSH.value,
          "token-sh": tokenSH.value,
          "cnpj-cedente": cnpjCedente.value,
          "cache-control": "no-cache",
        }
      }
      
      $.ajax(settings).done(function (consulta) {
        console.log(consulta);
        let json = JSON.stringify(consulta, null, 2);
        jsEntrada.value = "";
        jsRetorno.value = json;
      });
    } else { alert("Por favor, informe um IDintegracao no campo 'id Integragação'")}
}
function imprimirLote(){
  if (idintegracao.value != "") {
    if (tipoImpressao.value != "") {
      var settings = {
        "async": true,
        "crossDomain": true,
        "url": URLApi.value+"/api/v1/boletos/impressao/lote",
        "method": "POST",
        "headers": {
          "cnpj-sh": CnpjSH.value,
          "token-sh": tokenSH.value,
          "cnpj-cedente": cnpjCedente.value,
          "content-type": "application/json",
          "cache-control": "no-cache",
        },
        "processData": false,
        "data": "{\r\n  \"tipoImpressao\" : \"2\",\r\n  \"boletos\" : [\r\n    \"" + idintegracao.value + "\"\r\n  ]\r\n}\r\n\r\n"
      }
      
      $.ajax(settings).done(function (response) {
        console.log(response);
        let json = JSON.stringify(response, null, 2);
        jsRetorno.value = json;
        protImpressao.value = response._dados.protocolo;
      });
      jsEntrada.value = settings.data;
    } else { alert("Por favor, informe um Tipo de impressão no campo 'Tipo de Impressão'")}
    
  } else { alert("Por favor, informe um IDintegracao no campo 'id Integragação'")}
}

function SalvarLoteImpressaoPDF(){
    if (protImpressao.value != "") {
        var link = URLApi.value+"/api/v1/boletos/impressao/lote/"+protImpressao.value;
        window.open(link, '_blank'); 
    } else { alert("Por favor, informe um protocolo de impressão no campo no campo 'Protocolo Impressão'")}
      
}

function emailLote(){
    var settings = {
        "async": true,
        "crossDomain": true,
        "url": URLApi.value+"/api/v1/email/lote",
        "method": "POST",
        "headers": {
            "cnpj-sh": CnpjSH.value,
            "token-sh": tokenSH.value,
          "cnpj-cedente": cnpjCedente.value,
          "content-type": "application/json",
          "cache-control": "no-cache",
        },
        "processData": false,
        "data": "{\r\n  \"IdIntegracao\": \""+idintegracao.value+"\",\r\n  \"EmailNomeRemetente\": \"Empresa Exemplo\",\r\n  \"EmailRemetente\": \"exemplo@remetente.com.br\",\r\n  \"EmailAssunto\": \"Boleto para pagamento\",\r\n  \"EmailMensagem\": \"Segue o link do boleto:| ${linkBoleto}|Considere não imprimir este email.\",\r\n  \"EmailDestinatario\": [\"guilherme.ganassin@tecnospeed.com.br\", \"guilhermetestetecno@gmail.com.br\"]\r\n}"
      }
      
      $.ajax(settings).done(function (response) {
        console.log(response);
        let json = JSON.stringify(response, null, 2);
        jsRetorno.value = json;
        protEmail.value = response._dados.protocolo;
      });
      jsEntrada.value = settings.data;
}

function consultarEmailLote() {
    var settings = {
        "async": true,
        "crossDomain": true,
        "url": URLApi.value+"/api/v1/email/lote/"+protEmail.value,
        "method": "GET",
        "headers": {
          "cnpj-sh": CnpjSH.value,
          "token-sh": tokenSH.value,
          "cnpj-cedente": cnpjCedente.value,
          "cache-control": "no-cache",
        }
      }
      
      $.ajax(settings).done(function (consulta) {
        console.log(consulta);
        let json = JSON.stringify(consulta, null, 2);
        jsEntrada.value = "";
        jsRetorno.value = json;
      });
}

function gerarRemessaLote() {
    var settings = {
        "async": true,
        "crossDomain": true,
        "url": URLApi.value+"/api/v1/remessas/lote",
        "method": "POST",
        "headers": {
          "cnpj-sh": CnpjSH.value,
          "token-sh": tokenSH.value,
          "cnpj-cedente": cnpjCedente.value,
          "content-type": "application/json",
          "cache-control": "no-cache",
        },
        "processData": false,
        "data": "[\""+idintegracao.value+"\"]"
      }
      
      $.ajax(settings).done(function (response) {
        console.log(response);
        let json = JSON.stringify(response, null, 2);
        jsRetorno.value = json;
      });
      jsEntrada.value = settings.data;
}
function gerarRemessaAlteracao() {
    var settings = {
        "async": true,
        "crossDomain": true,
        "url": URLApi.value+"/api/v1/boletos/altera/lote",
        "method": "POST",
        "headers": {
          "cnpj-sh": CnpjSH.value,
          "token-sh": tokenSH.value,
          "cnpj-cedente": cnpjCedente.value,
          "content-type": "application/json",
          "cache-control": "no-cache",
        },
        "processData": false,
        "data": "{\r\n  \"tipo\" : \"0\",\r\n  \"boletos\" : [\r\n    {\r\n    \"idintegracao\": \"B1e_cHxB8W\",\r\n    \"TituloDataVencimento\": \"20/06/2018\"\r\n    },\r\n    {\r\n    \"idintegracao\": \"S1xP967aSZ\",\r\n    \"TituloDataVencimento\": \"20/06/2018\"\r\n    }\r\n  ]\r\n}\r\n\r\n"
      }
      
      $.ajax(settings).done(function (response) {
        console.log(response);
        let json = JSON.stringify(response, null, 2);
        jsRetorno.value = json;
        protAlteracao.value = response._dados.protocolo;
      });
      jsEntrada.value = settings.data;
}

function cosultarRemessaAlteração() {
    var settings = {
        "async": true,
        "crossDomain": true,
        "url": URLApi.value+"/api/v1/boletos/altera/lote/"+protAlteracao.value,
        "method": "GET",
        "headers": {
          "cnpj-sh": CnpjSH.value,
          "token-sh": tokenSH.value,
          "cnpj-cedente": cnpjCedente.value,
          "cache-control": "no-cache",
        }
      }
      
      $.ajax(settings).done(function (consulta) {
        console.log(consulta);
        let json = JSON.stringify(consulta, null, 2);
        jsEntrada.value = "";
        jsRetorno.value = json;
      });

}

function gerarRemessaBaixa() {
    var settings = {
        "async": true,
        "crossDomain": true,
        "url": URLApi.value+"/api/v1/boletos/baixa/lote",
        "method": "POST",
        "headers": {
          "cnpj-sh": CnpjSH.value,
          "token-sh": tokenSH.value,
          "cnpj-cedente": cnpjCedente.value,
          "content-type": "application/json",
          "cache-control": "no-cache",
        },
        "processData": false,
        "data": "[\""+idintegracao.value+"\"]"
      }
      
      $.ajax(settings).done(function (response) {
        console.log(response);
        let json = JSON.stringify(response, null, 2);
        jsRetorno.value = json;
        protBaixa.value = response._dados.protocolo;
      });
      jsEntrada.value = settings.data;
}

function consultarRemessaBaixa() {
    var settings = {
        "async": true,
        "crossDomain": true,
        "url": URLApi.value+"/api/v1/boletos/baixa/lote/"+protBaixa.value,
        "method": "GET",
        "headers": {
          "cnpj-sh": CnpjSH.value,
          "token-sh": tokenSH.value,
          "cnpj-cedente": cnpjCedente.value,
          "cache-control": "no-cache",
        }
      }
      
      $.ajax(settings).done(function (consulta) {
        console.log(consulta);
        let json = JSON.stringify(consulta, null, 2);
        jsEntrada.value = "";
        jsRetorno.value = json;
      });
}

function processarRetorno() { 
  if (jsEntrada.value != "") {
    var base64 = btoa(jsEntrada.value);
    console.log(base64);
    var settings = {
      "async": true,
      "crossDomain": true,
      "url": URLApi.value+"/api/v1/retornos",
      "method": "POST",
      "headers": {
        "cnpj-sh": CnpjSH.value,
        "token-sh": tokenSH.value,
        "cnpj-cedente": cnpjCedente.value,
        "content-type": "application/json",
        "cache-control": "no-cache",
      },
      "processData": false,
      "data": "{\"arquivo\":\""+base64+"\"}"
    }
    
    $.ajax(settings).done(function (response) {
      console.log(response);
      let json = JSON.stringify(response, null, 2);
      jsRetorno.value = json;
      protRetorno.value = response._dados.protocolo;
    });
    jsEntrada.value = settings.data;
  } else { alert("Por favor ensira um retorno no campo 'Entrada'")}

}

function consultaRetornoProcessamento() {
    var settings = {
        "async": true,
        "crossDomain": true,
        "url": URLApi.value+"/api/v1/retornos/"+protRetorno.value,
        "method": "GET",
        "headers": {
          "cnpj-sh": CnpjSH.value,
          "token-sh": tokenSH.value,
          "cnpj-cedente": cnpjCedente.value,
          "cache-control": "no-cache",
        }
      }
      
      $.ajax(settings).done(function (consulta) {
        console.log(consulta);
        let json = JSON.stringify(consulta, null, 2);
        jsEntrada.value = "";
        jsRetorno.value = json;
      });

}

function descartarBoleto() {
    var settings = {
        "async": true,
        "crossDomain": true,
        "url": URLApi.value+"/api/v1/boletos/descarta/lote",
        "method": "POST",
        "headers": {
          "cnpj-sh": CnpjSH.value,
          "token-sh": tokenSH.value,
          "cnpj-cedente": cnpjCedente.value,
          "content-type": "application/json",
          "cache-control": "no-cache",
        },
        "processData": false,
        "data": "[\""+idintegracao.value+"\"]"
      }
      
      $.ajax(settings).done(function (response) {
        console.log(response);
        let json = JSON.stringify(response, null, 2);
        jsRetorno.value = json;
      });
      jsEntrada.value = settings.data;
}