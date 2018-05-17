<?php
include_once("addComponente.php");
try {
    $dia = date("d");
    $mes = date("m");
    $ano = date("Y");
    $dataAtual = $dia . "/" . $mes . "/" . $ano;
    if ($mes == 11) {
        $mes = 01;
        $ano = $ano + 1;
    } elseif ($mes == 12) {
        $mes = 02;
        $ano = $ano + 1;
    } else {
        $mes = $mes + 2;
    }
    $dataVencimento = $dia . "/" . $mes . "/" . $ano;
    $iniNumero = parse_ini_file($DirArq . "nossoNumero.ini", true);
    $iniNumero = $iniNumero['NUMERO']['TituloNossoNumero'];
    $iniNumeroDocumento = $iniNumero['NUMERO']['TituloNumeroDocumento'];

    $curl = curl_init();
    curl_setopt_array($curl, array(
        CURLOPT_URL => "http://homologacao.cobrancabancaria.tecnospeed.com.br:8080/api/v1/boletos/lote",
        CURLOPT_CUSTOMREQUEST => "POST",
        CURLOPT_SSL_VERIFYPEER => 0,
        CURLOPT_SSL_VERIFYHOST => 0,
        CURLOPT_HTTPHEADER => array(
            "cnpj-cedente: $CNPJCedente",
            "cnpj-sh: $cnpjSH",
            "content-type: application/json",
            "token-sh: $hashSH",
        ),
        CURLOPT_POSTFIELDS => "[{\r\n  \"CedenteContaNumero\": \"12345\",\r\n  \"CedenteContaNumeroDV\": \"6\",\r\n  \"CedenteConvenioNumero\": \"1234123456\",\r\n  \"CedenteContaCodigoBanco\": \"341\",\r\n  \"SacadoCPFCNPJ\": \"28436161661\",\r\n  \"SacadoEmail\": \"email@sacado.com\",\r\n  \"SacadoEnderecoNumero\": \"987\",\r\n  \"SacadoEnderecoBairro\": \"Centro\",\r\n  \"SacadoEnderecoCEP\": \"87098765\",\r\n  \"SacadoEnderecoCidade\": \"Maringá\",\r\n  \"SacadoEnderecoComplemento\": \"Fundos\",\r\n  \"SacadoEnderecoLogradouro\": \"Rua teste, 987\",\r\n  \"SacadoEnderecoPais\": \"Brasil\",\r\n  \"SacadoEnderecoUF\": \"PR\",\r\n  \"SacadoNome\": \"Teste de Souza\",\r\n  \"SacadoTelefone\": \"4499999999\",\r\n  \"SacadoCelular\": \"44999999999\",\r\n  \"TituloDataDesconto\": \"05/01/2020\",\r\n  \"TituloValorDesconto\": \"0,01\",\r\n  \"TituloDataEmissao\": \"{$dataAtual}\",\r\n  \"TituloDataVencimento\": \"{$dataVencimento}\",\r\n  \"TituloValorJuros\": \"0,01\",\r\n  \"TituloPrazoProtesto\": \"30\",\r\n  \"TituloMensagem01\": \"Juros de 0,01 ao dia\",\r\n  \"TituloMensagem02\": \"Nao receber apos 30 dias de atraso\",\r\n  \"TituloMensagem03\": \"Titulo sujeito a protesto apos 30 dias\",\r\n  \"TituloNossoNumero\": \"{$iniNumero}\",\r\n  \"TituloNumeroDocumento\": \"{$iniNumeroDocumento}\",\r\n  \"TituloValor\": \"0,02\",\r\n  \"TituloLocalPagamento\": \"Pagável em qualquer banco até o vencimento.\"\r\n}]",
        CURLOPT_TIMEOUT => 30,
        CURLOPT_RETURNTRANSFER => true
    ));

    $response = curl_exec($curl);
    $err = curl_error($curl);
    curl_close($curl);

    if ($err) {
        echo "cURL Error #:" . $err;
    } else {
        $name = ($DirArq . "nossoNumero.ini");
        $iniNumero = $iniNumero + 1;
        $iniNumeroDocumento = $iniNumeroDocumento + 1;
        $text = "[NUMERO]\r\nTituloNossoNumero={$iniNumero}\r\nTituloNumeroDocumento={$iniNumeroDocumento}";
        $file = fopen($name, 'w');
        fwrite($file, $text);
        fclose($file);
        echo prettyPrint($response);
    }
} catch (Exception $e) {
    echo $e;
}