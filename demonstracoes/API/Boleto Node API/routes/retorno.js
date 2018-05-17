const request = require('request')
const tokenSoftware = "f22b97c0c9a3d41ac0a3875aba69e5aa";
const cnpjSoftware = "01001001000113";
const index = require('./index')
//Emitir retorno
const emitir = (req, res, next) => {
    let arquivoRetorno = req.body.entradaTexto
    var retornoCodificado = new Buffer(arquivoRetorno).toString('base64')
    var options = {
        method: 'POST',
        url: 'http://homologacao.cobrancabancaria.tecnospeed.com.br:8080/api/v1/retornos',
        headers:
            {
                'Content-Type': 'application/json',
                'cpf-cedente': cnpjCedente,
                'token-sh': tokenSoftware,
                'cnpj-sh': cnpjSoftware
            },
        body: { "arquivo": retornoCodificado },
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
//Consultar Status do retorno
const consultar = (req, res, next) => {
    let protRetorno = req.body.protRetorno
    let options = {
        method: 'GET',
        url: 'http://homologacao.cobrancabancaria.tecnospeed.com.br:8080/api/v1/retornos/' + protRetorno,
        json: true,
        headers:
            {
                'cpf-cedente': cnpjCedente,
                'token-sh': tokenSoftware,
                'cnpj-sh': cnpjSoftware
            },
    }
    request(options, function (error, response, body) {
        if (error) throw new Error(error)
        let retorno = JSON.stringify(body, null, 2)
        res.render('index', { dados: retorno })
    })
}
module.exports = {
    emitir,
    consultar
}