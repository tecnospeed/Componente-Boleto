<?php
include_once("addComponente.php");
try {
    $protBaixa = $_POST['protBaixa'];
    $curl = curl_init();
    curl_setopt_array($curl, array(
        CURLOPT_URL => "http://homologacao.cobrancabancaria.tecnospeed.com.br:8080/api/v1/boletos/baixa/lote/${protBaixa}",
        CURLOPT_CUSTOMREQUEST => "GET",
        CURLOPT_SSL_VERIFYPEER => 0,
        CURLOPT_SSL_VERIFYHOST => 0,
        CURLOPT_HTTPHEADER => array(
            "cnpj-cedente: $CNPJCedente",
            "cnpj-sh: $cnpjSH",
            "token-sh: $hashSH"
        ),
        CURLOPT_RETURNTRANSFER => true        
    ));
    $response = curl_exec($curl);
    $err = curl_error($curl);
    curl_close($curl);
    if ($err) {
        echo "cURL Error #:" . $err;
    } else {
        echo prettyPrint($response);
    }
} catch (Exception $e) {
    echo $e;
}