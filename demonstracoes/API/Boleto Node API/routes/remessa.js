const request = require('request')
const fs = require('fs')
const tokenSoftware = "f22b97c0c9a3d41ac0a3875aba69e5aa";
const cnpjSoftware = "01001001000113";

function criarArquivo(nome, conteudo) {
    fs.writeFile(nome, conteudo, (err) => {
        if (err) throw new Error(err)
    })
}

const remessa = (req, res, next) => {
    let nome = ""
    let remessa = ""
    let idIntegracao = req.body.idIntegracao
    let options = {
        method: 'POST',
        url: 'http://homologacao.cobrancabancaria.tecnospeed.com.br:8080/api/v1/remessas/lote',
        headers:
            {
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
        if (body._dados._sucesso[0] != undefined) {
            remessa = body._dados._sucesso[0].remessa
            nome = body._dados._sucesso[0].arquivo
            let remessaDecodificada = new Buffer(remessa, 'base64').toString('ascii')
            criarArquivo(nome, remessaDecodificada)
        }
        let retorno = JSON.stringify(body, null, 2)
        res.render('index', {
            dados: retorno
        })
    })
}
const baixa = (req, res, next) => {
    let idIntegracao = req.body.idIntegracao
    var options = {
        method: 'POST',
        url: 'http://homologacao.cobrancabancaria.tecnospeed.com.br:8080/api/v1/boletos/baixa/lote',
        headers:
            {
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
        res.render('index', { dados: retorno })
    })
}
const consultaBaixa = (req, res, next) => {
    let remessa = ""
    let nome = ""
    let protBaixa = req.body.protBaixa
    let options = {
        method: 'GET',
        url: `http://homologacao.cobrancabancaria.tecnospeed.com.br:8080/api/v1/boletos/baixa/lote/${protBaixa}`,
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
        if (body._dados != null) {
            remessa = body._dados._sucesso[0].remessa
            nome = body._dados._sucesso[0].arquivo
            let remessaDecodificada = new Buffer(remessa, 'base64').toString('ascii')
            criarArquivo(nome, remessaDecodificada)
        } else {

        }
        let retorno = JSON.stringify(body, null, 2)
        res.render('index', { dados: retorno })
    })
}
const remessaAlteracao = (req, res, next) => {
    let mudanca = JSON.parse(req.body.entradaTexto)

    var options = {
        method: 'POST',
        url: 'http://homologacao.cobrancabancaria.tecnospeed.com.br:8080/api/v1/boletos/altera/lote',
        headers:
            {
                'Content-Type': 'application/json',
                'cpf-cedente': cnpjCedente,
                'token-sh': tokenSoftware,
                'cnpj-sh': cnpjSoftware
            },
        body: mudanca,
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
const consultaAlteracao = (req, res, next) => {
    let remessa = ""
    let nome = ""
    let protAlteracao = req.body.protAlteracao
    let options = {
        method: 'GET',
        url: `http://homologacao.cobrancabancaria.tecnospeed.com.br:8080/api/v1/boletos/altera/lote/${protAlteracao}`,
        json: true,
        headers:
            {
                'Content-Type': 'application/json',
                'cpf-cedente': cnpjCedente,
                'token-sh': tokenSoftware,
                'cnpj-sh': cnpjSoftware
            }
    }
    request(options, function (error, response, body) {
        if (error) throw new Error(error)
        if (body._dados!= undefined) {
            remessa = body._dados._sucesso[0].remessa
            nome = body._dados._sucesso[0].arquivo
            let remessaDecodificada = new Buffer(remessa, 'base64').toString('ascii')
            criarArquivo(nome, remessaDecodificada)
        }
        let retorno = JSON.stringify(body, null, 2)
        res.render('index', {
            dados: retorno
        })
    })
}
module.exports = {
    remessa,
    baixa,
    consultaBaixa,
    remessaAlteracao,
    consultaAlteracao
}