<?php
include("addComponente.php");
try{
    $curl = curl_init();
    $id = $_POST['idintegracao'];
    if(!$id){
        $id = "BJeENF32Al";
    }
    $linkBoleto = "http://homologacao.cobrancabancaria.tecnospeed.com.br:8080/api/v1/boletos/impressao/" . $id;
    $emailDestinatario = $_POST['destinatario'];
    curl_setopt_array($curl, array(
        CURLOPT_URL => "http://homologacao.cobrancabancaria.tecnospeed.com.br:8080/api/v1/email",
        CURLOPT_CUSTOMREQUEST => "POST",
        CURLOPT_PORT => "8080",
        CURLOPT_RETURNTRANSFER => true,
        CURLOPT_SSL_VERIFYPEER => 0,
        CURLOPT_SSL_VERIFYHOST => 0,
        CURLOPT_POSTFIELDS => "{\r\n  \"IdIntegracao\": \"$id\",\r\n  \"EmailNomeRemetente\": \"Nome Empresa Exemplo\",\r\n  \"EmailRemetente\": \"exemplo@remetente.com.br\",\r\n  \"EmailAssunto\": \"Teste do envio de email demonstração do Boleto\",\r\n  \"EmailMensagem\": \"Segue o link do boleto:| $linkBoleto|Considere não imprimir este email.\",\r\n  \"EmailDestinatario\": [\"$emailDestinatario\"]\r\n}",
        CURLOPT_HTTPHEADER => array(
            "cnpj-cedente: $CNPJCedente",
            "cnpj-sh: $cnpjSH",
            "content-type: application/json",
            "token-sh: $hashSH",
        ),
    ));

    $response = curl_exec($curl);
    $err = curl_error($curl);

    curl_close($curl);

    if ($err) {
        echo "cURL Error #:" . $err;
    } else {
        echo prettyPrint($response);
    }
}
catch(Exception $e){
    echo $e;
}
?>