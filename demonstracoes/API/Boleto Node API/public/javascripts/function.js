var num = 11
const retorno =
  {
    "arquivo": "Arquivo Base64"
  }
var bodyNecessario = {
  "CedenteContaNumero": "54321",
  "CedenteContaNumeroDV": "0",
  "CedenteConvenioNumero": "321",
  "CedenteContaCodigoBanco": "341",
}
var incluirBody =
  {
    "CedenteContaNumero": "EDITAR",
    "CedenteContaNumeroDV": "EDITAR",
    "CedenteConvenioNumero": "EDITAR",
    "CedenteContaCodigoBanco": "EDITAR",
    "SacadoCPFCNPJ": "28436161661",
    "SacadoEmail": "email@sacado.com",
    "SacadoEnderecoNumero": "987",
    "SacadoEnderecoBairro": "Centro",
    "SacadoEnderecoCEP": "87098765",
    "SacadoEnderecoCidade": "Maringá",
    "SacadoEnderecoComplemento": "Fundos",
    "SacadoEnderecoLogradouro": "Rua teste, 987",
    "SacadoEnderecoPais": "Brasil",
    "SacadoEnderecoUF": "PR",
    "SacadoNome": "Teste de Souza",
    "SacadoTelefone": "4499999999",
    "SacadoCelular": "44999999999",
    "TituloDataDesconto": "05/01/2020",
    "TituloValorDesconto": "0,01",
    "TituloDataEmissao": "01/01/2020",
    "TituloDataVencimento": "01/01/2020",
    "TituloValorJuros": "0,01",
    "TituloPrazoProtesto": "30",
    "TituloMensagem01": "Juros de 0,01 ao dia",
    "TituloMensagem02": "Nao receber apos 30 dias de atraso",
    "TituloMensagem03": "Titulo sujeito a protesto apos 30 dias",
    "TituloNossoNumero": num,
    "TituloNumeroDocumento": "01012020",
    "TituloValor": "0,02",
    "TituloLocalPagamento": "Pagável em qualquer banco até o vencimento."
  }
const gerarEmail =
  {
    "IdIntegracao": ["idIntegracao"],
    "EmailNomeRemetente": "Empresa Exemplo",
    "EmailRemetente": "exemplo@remetente.com.br",
    "EmailAssunto": "Boleto para pagamento",
    "EmailMensagem": "Segue o link do boleto:<br> ${linkBoleto}<br>Considere não imprimir este email.<br><b>Código HTML dentro da Tag</b>",
    "EmailDestinatario": ["email1@tecnospeed.com.br", "email2@tecnospeed.com.br"],
    "EmailAnexarBoleto": true,
    "EmailConteudoHtml": true
  }
const gerarImpressao =
  {
    "TipoImpressao": 1,
    "Boletos": [
      "IdIntegracao1"
    ]
  }
const alterValor =
  {
    "Tipo": "1",
    "Boletos": [
      {
        "IdIntegracao": "IdIntegracao1",
        "TituloValor": "100,00"
      }
    ]
  }
const alterData =
  {
    "Tipo": "0",
    "Boletos": [
      {
        "IdIntegracao": "IdIntegracao1",
        "TituloDataVencimento": "20/06/2018"
      }
    ]
  }
const cadastrarCendente =

  {
    "CedenteRazaoSocial": "Empresa Teste Ltda",
    "CedenteNomeFantasia": "Empresa Teste",
    "CedenteCPFCNPJ": "EDITAR",
    "CedenteEnderecoLogradouro": "Av. Analista Jucá de Souza",
    "CedenteEnderecoNumero": "123",
    "CedenteEnderecoComplemento": "sala 987",
    "CedenteEnderecoBairro": "Centro",
    "CedenteEnderecoCEP": "87012345",
    "CedenteEnderecoCidadeIBGE": "4115200",
    "CedenteTelefone": "(44) 3033-1234",
    "CedenteEmail": "cobranca@boleto.com.br"
  }
const cadastrarConta =
  {
    "ContaCodigoBanco": "341",
    "ContaAgencia": "EDITAR",
    "ContaAgenciaDV": "EDITAR",
    "ContaNumero": "EDITAR",
    "ContaNumeroDV": "EDITAR",
    "ContaTipo": "CORRENTE",
    "ContaCodigoBeneficiario": "60473"
  }

const cadastrarConvenio =
  {
    "ConvenioNumero": "EDITAR",
    "ConvenioDescricao": "Convenio da tecnospeed",
    "ConvenioCarteira": "109",
    "ConvenioEspecie": "Boleto",
    "ConvenioPadraoCNAB": "400",
    "ConvenioNumeroRemessa": "1",
    "Conta": 168
  }
let contador = 0;
// var json = ""
//Funções gerar formulario de incluir boleto
$("#boleto").on("click", () => {
  // incluirBody.tituloNossoNumero = num
  json = JSON.stringify(incluirBody, null, 2)
  contador++
  if (contador > 2) {
    json = `, ${json}`
    var stringCompleta = json
    $("#entrada").val($("#entrada").val() + stringCompleta)
   }else{
    $("#entrada").val(json)
   }
num++
})
$("#upload").on("click", () => {
  $("#entrada").val("")
})
function gerarJson(formulario) {
  $("#entrada").val(JSON.stringify(formulario, null, 2))
  contador = 0;
}
function botaoEnviar(rota) {
  $("#envio").attr("action", `${rota}`).submit()
  contador = 0;
}


