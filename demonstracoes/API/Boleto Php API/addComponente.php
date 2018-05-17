<?php
include_once("config.php");
try {
    $URL = "http://homologacao.cobrancabancaria.tecnospeed.com.br:8080";
    $dirC = $DirArq . "boleto.ini";
    $ini_array = parse_ini_file($dirC, true);
    $cnpjSH = $ini_array['DADOS']['CNPJSH'];
    $hashSH = $ini_array['DADOS']['HashSH'];
    $CNPJCedente = $ini_array['DADOS']['CNPJCedente'];
    $tokenCedente = $ini_array['DADOS']['tokenCedente'];



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

    function prettyPrint($json)
    {
        $result = '';
        $level = 0;
        $in_quotes = false;
        $in_escape = false;
        $ends_line_level = NULL;
        $json_length = strlen($json);

        for ($i = 0; $i < $json_length; $i++) {
            $char = $json[$i];
            $new_line_level = NULL;
            $post = "";
            if ($ends_line_level !== NULL) {
                $new_line_level = $ends_line_level;
                $ends_line_level = NULL;
            }
            if ($in_escape) {
                $in_escape = false;
            } else if ($char === '"') {
                $in_quotes = !$in_quotes;
            } else if (!$in_quotes) {
                switch ($char) {
                    case '}':
                    case ']':
                        $level--;
                        $ends_line_level = NULL;
                        $new_line_level = $level;
                        break;

                    case '{':
                    case '[':
                        $level++;
                    case ',':
                        $ends_line_level = $level;
                        break;

                    case ':':
                        $post = " ";
                        break;

                    case " ":
                    case "\t":
                    case "\n":
                    case "\r":
                        $char = "";
                        $ends_line_level = $new_line_level;
                        $new_line_level = NULL;
                        break;
                }
            } else if ($char === '\\') {
                $in_escape = true;
            }
            if ($new_line_level !== NULL) {
                $result .= "\n" . str_repeat("\t", $new_line_level);
            }
            $result .= $char . $post;
        }

        return $result;
    }
} catch (Exception $e) {
    echo $e;
}
?>