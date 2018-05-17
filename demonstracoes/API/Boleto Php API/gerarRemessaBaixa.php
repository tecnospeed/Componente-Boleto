<?php
include("addComponente.php");
try{
    $curl = curl_init();
    $id = $_POST['idintegracao'];
    echo ("Id :" . $id);
    curl_setopt_array($curl, array(
        CURLOPT_URL => "http://homologacao.cobrancabancaria.tecnospeed.com.br:8080/api/v1/boletos/baixa/lote",
        CURLOPT_CUSTOMREQUEST => "POST",
        CURLOPT_PORT => "8080",
        CURLOPT_RETURNTRANSFER => true,
        CURLOPT_SSL_VERIFYPEER => 0,
        CURLOPT_SSL_VERIFYHOST => 0,
        CURLOPT_POSTFIELDS => "[\"{$id}\"]",
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