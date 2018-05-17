<?php
include_once("addComponente.php");
try {
    
    $curl = curl_init();
    echo "Solicitando Impressão em Lotes \r\n";
    curl_setopt_array($curl, array(
        CURLOPT_URL => "http://homologacao.cobrancabancaria.tecnospeed.com.br:8080/api/v1/boletos/impressao/lote",
        CURLOPT_CUSTOMREQUEST => "POST",
        CURLOPT_SSL_VERIFYPEER => 0,
        CURLOPT_SSL_VERIFYHOST => 0,
        CURLOPT_HTTPHEADER => array(
            "cnpj-cedente: $CNPJCedente",
            "cnpj-sh: $cnpjSH",
            "content-type: application/json",
            "token-sh: $hashSH",
        ),
        CURLOPT_POSTFIELDS => "{\"tipoImpressao\":\"2\",\"boletos\":[\"BkxG3StC8-\",\"SJlQjrK0IW\",\"rJgml9Rh8W\"]}",
        
        CURLOPT_TIMEOUT => 30,
        CURLOPT_RETURNTRANSFER => true
    ));
    echo CURLOPT_POSTFIELDS;

    $response = curl_exec($curl);
    $err = curl_error($curl);
    curl_close($curl);

    if ($err) {
        echo "cURL Error #:" . $err;
    } else {
        fwrite($file, $text);
        fclose($file);
        echo prettyPrint($response);
    }
} catch (Exception $e) {
    echo $e;
}