<?php
include("addComponente.php");
try{
    $nomeArquivo = $_GET["nomeArquivo"];
    $arquivo = $DirArq . "arquivoRemessa/" . $nomeArquivo;

    if(file_exists($arquivo)){ // faz o teste se a variavel não esta vazia e se o arquivo realmente existe
        switch(strtolower(substr(strrchr(basename($arquivo),"."),1))){ // verifica a extensão do arquivo para pegar o tipo
            case "pdf": $tipo="application/pdf"; break;
            case "rem":
            case "txt": $tipo="text/plain"; break;
            case "exe": $tipo="application/octet-stream"; break;
            case "zip": $tipo="application/zip"; break;
            case "doc": $tipo="application/msword"; break;
            case "xls": $tipo="application/vnd.ms-excel"; break;
            case "ppt": $tipo="application/vnd.ms-powerpoint"; break;
            case "gif": $tipo="image/gif"; break;
            case "png": $tipo="image/png"; break;
            case "jpg": $tipo="image/jpg"; break;
            case "mp3": $tipo="audio/mpeg"; break;
            case "php": // deixar vazio por seurança
            case "htm": // deixar vazio por seurança
            case "html": // deixar vazio por seurança
        }
        header('Content-Description: File Transfer');
        header("Content-Type: ".$tipo); // informa o tipo do arquivo ao navegador
        header("Content-Length: ".filesize($arquivo)); // informa o tamanho do arquivo ao navegador
        header("Content-Disposition: attachment; filename=".basename($arquivo)); // informa ao navegador que é tipo anexo e faz abrir a janela de download, tambem informa o nome do arquivo
        header('Cache-Control: must-revalidate, post-check=0, pre-check=0');
        header('Pragma: public');
        header('Expires: 0');
        readfile($arquivo); // lê o arquivo
        exit; // aborta pós-ações
    }
}
catch(Exception $e){
    echo $e;
}
?>