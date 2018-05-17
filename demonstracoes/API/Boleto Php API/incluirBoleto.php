<?php
include_once("addComponente.php");
try {
    $XML = "";
    $caminhoTx2 = file_get_contents($DirArq . "../uploads/Arquivo.tx2");
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
        CURLOPT_POSTFIELDS => json_encode(array('arquivo' => $caminhoTx2)),
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