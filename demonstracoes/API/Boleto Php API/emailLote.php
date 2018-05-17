<?php
include_once("addComponente.php");
try {
    
    $curl = curl_init();
    echo "Solicitando Impressão em Lotes \r\n";
    curl_setopt_array($curl, array(
        CURLOPT_URL => "http://homologacao.cobrancabancaria.tecnospeed.com.br:8080/api/v1/email/lote",
        CURLOPT_CUSTOMREQUEST => "POST",
        CURLOPT_SSL_VERIFYPEER => 0,
        CURLOPT_SSL_VERIFYHOST => 0,
        CURLOPT_HTTPHEADER => array(
            "cnpj-cedente: $CNPJCedente",
            "cnpj-sh: $cnpjSH",
            "content-type: application/json",
            "token-sh: $hashSH",
        ),
        CURLOPT_POSTFIELDS => "{\"arquivo\": \"SU5DTFVJUkVNQUlMDQpJZEludGVncmFjYW89cnlGVnE2OTR6DQpFbWFpbE5vbWVSZW1ldGVudGU9RXhlbXBsbyBkZSBlbnZpbyBkZSBlbWFpbA0KRW1haWxSZW1ldGVudGU9bHVpei5iZW5nb3ppQHRlY25vc3BlZWQuY29tLmJyDQpFbWFpbEFzc3VudG89Qm9sZXRvIHBhcmEgcGFnYW1lbnRvIFRFQ05PU1BFRUQNCkVtYWlsTWVuc2FnZW09PGh0bWw+PGJvZHk+PHA+PHN0cm9uZz5UZXN0ZTwvc3Ryb25nPiBkZSBlLW1haWwgZW0gSFRNTCA8YSBocmVmPSIke2xpbmtCb2xldG99Ij4gTGluazwvYT4NCkVtYWlsRGVzdGluYXRhcmlvPWx1aXouYmVuZ296aUB0ZWNub3NwZWVkLmNvbS5icg0KRW1haWxBbmV4YXJCb2xldG89dHJ1ZQ0KRW1haWxDb250ZXVkb0h0bWw9dHJ1ZQ0KVGlwb0ltcHJlc3Nhbz05OQ0KU0FMVkFSRU1BSUw=\"}",
        
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