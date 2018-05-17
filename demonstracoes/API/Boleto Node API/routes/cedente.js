const request = require('request')
const tokenSoftware = "f22b97c0c9a3d41ac0a3875aba69e5aa"
const cnpjSoftware = "01001001000113"
//const cnpjCedente = "52736235371"
//Autenticar
const credenciais = (req, res, next) => {
  global.cnpjCedente = req.body.cnpjCedente
  res.render('index', {
    error: "Credenciais adicionadas"
  })
}
//Cadastrar cedente
const cadastrarCedente = (req, res, next) => {
  let cedente = JSON.parse(req.body.entradaTexto)
  var options = {
    method: 'POST',
    url: 'http://homologacao.cobrancabancaria.tecnospeed.com.br:8080/api/v1/cedentes',
    headers:
      {
        'Content-Type': 'application/json',
        'token-sh': tokenSoftware,
        'cnpj-sh': cnpjSoftware
      },
    body: cedente,
    json: true
  }
  request(options, function (error, response, body) {
    if (error) throw new Error(error)
    let retorno = JSON.stringify(body, null, 2)
    res.render('index', {
      dados: retorno
    })
  })
}
//Cadastra conta do cedente
const conta = (req, res, next) => {
  let conta = JSON.parse(req.body.entradaTexto)
  let options = {
    method: 'POST',
    url: 'http://homologacao.cobrancabancaria.tecnospeed.com.br:8080/api/v1/cedentes/contas',
    headers:
      {
        'Content-Type': 'application/json',
        'cpf-cedente': cnpjCedente,
        'token-sh': tokenSoftware,
        'cnpj-sh': cnpjSoftware
      },
    body: conta,
    json: true
  }

  request(options, function (error, response, body) {
    if (error) throw new Error(error)
    let retorno = JSON.stringify(body, null, 2)
    res.render('index', {
      dados: retorno
    })
  })
}
//Cadastrar Convênio do cedente
const convenio = (req, res, next) => {
  let convenio = JSON.parse(req.body.entradaTexto)

  var options = {
    method: 'POST',
    url: 'http://homologacao.cobrancabancaria.tecnospeed.com.br:8080/api/v1/cedentes/contas/convenios',
    headers:
      {
        'Content-Type': 'application/json',
        'cpf-cedente': cnpjCedente,
        'token-sh': tokenSoftware,
        'cnpj-sh': cnpjSoftware
      },
    body: convenio,
    json: true
  }
  request(options, function (error, response, body) {
    if (error) throw new Error(error)
    let retorno = JSON.stringify(body, null, 2)
    res.render('index', {
      dados: retorno
    })
  })
}
module.exports = {
  cadastrarCedente,
  conta,
  convenio,
  cnpjCedente,
  credenciais

}