
const request = require('request')
const cedente = require('./cedente')
const tokenSoftware = "f22b97c0c9a3d41ac0a3875aba69e5aa";
const cnpjSoftware = "01001001000113";


//Consultar IDintegração
const idIntegracao = (req, res, next) => {
    let situacao = ""
    let id = ""
    let idIntegracao = req.body.idIntegracao
    if (idIntegracao != '') {
        var options = {
            method: 'GET',
            url: 'http://homologacao.cobrancabancaria.tecnospeed.com.br:8080/api/v1/boletos',
            qs: {
                idIntegracao: idIntegracao
            },
            json: true,
            headers: {
                'cpf-cedente': cnpjCedente,
                'token-sh': tokenSoftware,
                'cnpj-sh': cnpjSoftware
            },
        }
        request(options, (error, response, body) => {
            if (error) {
                throw new Error(error)
            }
            let retorno = JSON.stringify(body, null, 2)
            if (body._dados[0] != undefined) {
                situacao = body._dados[0].situacao
                id = body._dados[0].idintegracao
            } else {
                situacao = body._mensagem
            }
            res.render('index', {
                frase: "Situação do boleto: ",
                error: situacao,
                dados: retorno
            })
        })
    }
}
//Incluir boleto
const incluir = (req, res, next) => {
    let json = "[" + req.body.entradaTexto + "]"
    let jsonBoleto = JSON.parse(json)

    let options = {
        method: 'POST',
        url: 'http://homologacao.cobrancabancaria.tecnospeed.com.br:8080/api/v1/boletos/lote',
        headers: {
            'cpf-cedente': cnpjCedente,
            'token-sh': tokenSoftware,
            'cnpj-sh': cnpjSoftware
        },
        body: jsonBoleto,
        json: true
    }
    request(options, (error, response, body) => {
        if (error) throw new Error(error)
        let retorno = JSON.stringify(body, null, 2)
        res.render('index', {
            frase: "Status: ",
            error: body._status,
            dados: retorno
        })
    })
}
//Descartar Boleto
const descarta = (req, res, next) => {
    let idIntegracao = req.body.idIntegracao
    let options = {
        method: 'POST',
        url: 'http://homologacao.cobrancabancaria.tecnospeed.com.br:8080/api/v1/boletos/descarta/lote',
        headers: {
            'Content-Type': 'application/json',
            'cpf-cedente': cnpjCedente,
            'token-sh': tokenSoftware,
            'cnpj-sh': cnpjSoftware
        },
        body: [idIntegracao],
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
    idIntegracao,
    incluir,
    descarta
}