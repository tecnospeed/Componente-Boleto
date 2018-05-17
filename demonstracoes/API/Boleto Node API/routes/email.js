
const request = require('request')
const tokenSoftware = "f22b97c0c9a3d41ac0a3875aba69e5aa";
const cnpjSoftware = "01001001000113";
//Incluir Email
const enviar = (req, res, next) => {
    let emailJson = JSON.parse(req.body.entradaTexto)
    let options = {
        method: 'POST',
        url: 'http://homologacao.cobrancabancaria.tecnospeed.com.br:8080/api/v1/email/lote',
        headers: {
            'Content-Type': 'application/json',
            'cpf-cedente': cnpjCedente,
            'token-sh': tokenSoftware,
            'cnpj-sh': cnpjSoftware
        },
        body: emailJson,
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
//Consultar o envio do email
const consultar = (req, res, next) => {
    let protocoloEmail = req.body.protEmail

    let options = {
        method: 'GET',
        url: `http://homologacao.cobrancabancaria.tecnospeed.com.br:8080/api/v1/email/lote/${protocoloEmail}`,
        json: true,
        headers: {
            'cpf-cedente': cnpjCedente,
            'token-sh': tokenSoftware,
            'cnpj-sh': cnpjSoftware
        }
    }

    request(options, function (error, response, body) {
        if (error) throw new Error(error)
        let retorno = JSON.stringify(body, null, 2)
        let status = body._status
        res.render('index', {
            dados: retorno,
            error: status,
        })
    })
}
module.exports = {
    enviar,
    consultar
}