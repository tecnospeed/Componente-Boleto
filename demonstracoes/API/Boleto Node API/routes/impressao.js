const fs = require('fs')
const request = require('request')
const tokenSoftware = "f22b97c0c9a3d41ac0a3875aba69e5aa";
const cnpjSoftware = "01001001000113";

function criarArquivo(nome, conteudo) {
    fs.writeFile(nome, conteudo, (err) => {
        if (err) throw new Error(err)
    })
}
//Incluir impressão 
const imprimir = (req, res, next) => {
    let impressao = JSON.parse(req.body.entradaTexto)
    let options = {
        method: 'POST',
        url: 'http://homologacao.cobrancabancaria.tecnospeed.com.br:8080/api/v1/boletos/impressao/lote',
        headers: {
            'cpf-cedente': cnpjCedente,
            'token-sh': tokenSoftware,
            'cnpj-sh': cnpjSoftware
        },
        body: impressao,
        json: true
    }

    request(options, function (error, response, body) {
        if (error) throw new Error(error)
        let retorno = JSON.stringify(body, null, 2)
        res.render('', {
            dados: retorno
        })
    })
}
//Consultar impressão e se estiver processada realizar download
const consultar = (req, res, next) => {
    let protocoloImpresssao = req.body.protImpre
    let options = {
        method: 'GET',
        url: `http://homologacao.cobrancabancaria.tecnospeed.com.br:8080/api/v1/boletos/impressao/lote/${protocoloImpresssao}`,
        json: true,
        encoding: null,
        headers: {
            'cpf-cedente': cnpjCedente,
            'token-sh': tokenSoftware,
            'cnpj-sh': cnpjSoftware
        }
    }

    request(options, function (error, response, body) {
        if (error) {
            throw new Error(error)
        }
        let dados = JSON.stringify(body, null, 2)
        if (body._status != 'erro') {
            criarArquivo(protocoloImpresssao + ".pdf", body)
            res.render('index', {
                dados: dados,
                frase: "Situação da impressão: Arquivo salvado no computador ",
            })
        } else {
            res.render('index', {
                dados: dados,
                error:"Erro"
            })
        }
    })
}
module.exports = {
    imprimir,
    consultar
}