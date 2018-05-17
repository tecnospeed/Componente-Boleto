<?php
include_once("addComponente.php");
try {
    $id = $_POST['idIntegracao'];
    $nomeArquivo = $_POST['nomeArquivo'];
    $name = ($DirArq . "arquivoRemessa/" . $nomeArquivo);
    $text = base64_decode($_POST['retornoRemessa']);
    $file = fopen($name, 'w');
    fwrite($file, $text);
    fclose($file);
    echo '<span style="color: #5cb85c;">OK</span>';
} catch (Exception $e) {
    echo '<span style="color: #d9534f;">Erro</span>';
}