<?php
include_once("addComponente.php");
try {
    $tx2Padrao = $_POST['tx2Padrao'];
    $tx2Padrao = base64_encode($tx2Padrao);

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
        CURLOPT_POSTFIELDS => json_encode(array('arquivo' => $tx2Padrao)),
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