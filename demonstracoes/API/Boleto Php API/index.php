<?php
include_once("config.php");
include_once("addComponente.php");
?>
<!DOCTYPE html>
<head>
    <link rel="shortcut icon" href="<?= $url ?>images/icone.ico" type="image/x-icon"/>
    <title>TecnoSpeed TI Boleto</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="<?= $url ?>lib/css/style.css">
    <link rel="stylesheet" href="<?= $url ?>lib/css/bootstrap.min.css">
    <script type="text/javascript" src="<?= $url ?>lib/js/jquery.min.js"></script>
    <script type="text/javascript" src="<?= $url ?>lib/js/appDemo.js"></script>
    <script type="text/javascript" src="<?= $url ?>lib/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
    <script type="text/javascript" src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:300italic,400italic,600italic,700italic,800italic,400,800,700,600,300' rel='stylesheet' type='text/css'>
</head>
<script>
    $(document).ready(function(){
        $('[data-toggle="tooltip"]').tooltip();
    });
</script>
<?php
$tx2Padrao = "INCLUIRBOLETO\r\n\r\nCedenteContaNumero=12345\r\nCedenteContaNumeroDV=6\r\nCedenteConvenioNumero=1234123456\r\nCedenteContaCodigoBanco=341\r\nSacadoCPFCNPJ=28436161661\r\nSacadoEmail=email@sacado.com\r\nSacadoEnderecoNumero=987\r\nSacadoEnderecoBairro=Centro\r\nSacadoEnderecoCEP=87098765\r\nSacadoEnderecoCidade=Maringá\r\nSacadoEnderecoComplemento=Fundos\r\nSacadoEnderecoLogradouro=Rua teste, 987\r\nSacadoEnderecoPais=Brasil\r\nSacadoEnderecoUF=PR\r\nSacadoNome=Teste de Souza\r\nSacadoTelefone=4499999999\r\nSacadoCelular=44999999999\r\nTituloDataDesconto=05/01/2020\r\nTituloValorDesconto=0,01\r\nTituloDataEmissao=$dataAtual\r\nTituloDataVencimento=$dataVencimento\r\nTituloValorJuros=0,01\r\nTituloPrazoProtesto=30\r\nTituloMensagem01=Juros de 0,01 ao dia\r\nTituloMensagem02=Nao receber apos 30 dias de atraso\r\nTituloMensagem03=Titulo sujeito a protesto apos 30 dias\r\nTituloNossoNumero=$iniNumero\r\nTituloNumeroDocumento=$iniNumeroDocumento\r\nTituloValor=0,02\r\nTituloLocalPagamento=Pagável em qualquer banco até o vencimento.\r\n\r\nSALVARBOLETO";
if ($_POST['salvarTX2']) {
    try {
        $tx2 = $_FILES['arquivoTx2']['tmp_name'];
        $_UP['pasta'] = 'uploads/';
        $_UP['extensoes'] = 'tx2';
        $nome_final = "Arquivo.tx2";
        $extensao = strtolower(end(explode('.', $_FILES['arquivoTx2']['name'])));
        if ($extensao != $_UP['extensoes']) {
            ?>
            <script>
                alert("Por favor, envie arquivos com as seguintes extensões: tx2");
                window.location.href = '<?=$url?>';
            </script>
            <?php
            exit();
        }
        move_uploaded_file($_FILES['arquivoTx2']['tmp_name'], $_UP['pasta'] . $nome_final);
        $content = file_get_contents($DirArq . "../uploads/Arquivo.tx2");
        $file = fopen($DirArq . "../uploads/Arquivo.tx2", 'w');
        fwrite($file, base64_encode($content));
        fclose($file);
        ?>
        <script>
            $(document).ready(function () {
                $.post("incluirBoleto.php", function (retJson) {
                    $("#xmlRetorno").val(retJson);
                });
            });
        </script>
        <?php
    } catch (Exception $e) {
        echo $e;
    }
    ?>
    <?php
}
?>
<body style="background-color: #fff">
<div id="container">
    <!-- Header
        ================================================== -->
    <header class="clearfix" id="home">
        <!-- Static navbar -->
        <nav class="navbar navbar-default navbar-static-top">
            <div class="top-line">
                <div class="container">
                    <div class="row">
                        <ul class="top-socials col-xs-12 col-sm-3 col-md-3">
                            <li><a href="http://www.twitter.com/tecnospeed" target="_blank"><i class="fa fa-twitter"></i></a></li>
                            <li><a href="http://www.facebook.com/tecnospeed" target="_blank"><i class="fa fa-facebook"></i></a></li>
                            <li><a href="https://www.linkedin.com/company/tecnospeed-ti" target="_blank"><i class="fa fa-linkedin"></i></a></li>
                            <li><a href="https://plus.google.com/+TecnoSpeedTI" target="_blank"><i class="fa fa-google-plus"></i></a></li>
                            <li><a href="http://www.youtube.com/tecnospeedti" target="_blank"><i class="fa fa-youtube"></i></a></li>
                        </ul>
                        <ul class="top-info col-xs-12 col-sm-9 col-md-9">
                            <li><p class="text-highlight"><i class="fa fa-phone"></i>0800 006 9500 / 44 3037 9500</p></li>
                            <li><a href="http://www.tecnospeed.com.br/comercial"><i class="fa fa-comment"></i>Comercial</a></li>
                            <li><a href="http://www.tecnospeed.com.br/atendimento"><i class="fa fa-question-circle"></i>Suporte</a></li>
                            <li><a href="http://tecno-services.com:1338/" target="_blank"><i class="fa fa-lock"></i>Área Restrita</a></li>
                            <li><a href="mailto:contato@tecnospeed.com.br" target="_blank"><i class="fa fa-envelope"></i>contato@tecnospeed.com.br</a></li>
                        </ul>
                    </div>
                </div>
            </div>
            <!-- end topline -->
            <nav class="navigation">
                <div class="container">
                    <div class="logo logo-tecnospeed">
                        <a href="<?=$url?>"><img src="http://www.tecnospeed.com.br/images/logo.png" alt=""></a>
                    </div>

                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                    </div>
                    <div class="navbar-collapse collapse">
                        <ul class="nav navbar-nav">
                            <li class="drop"><a href="http://www.tecnospeed.com.br/produtos" class="scroll">Soluções</a>
                                <ul class="drop-down">
                                    <li><a href="http://www.tecnospeed.com.br/manager-edoc">Manager eDoc</a></li>
                                    <li><a href="http://www.tecnospeed.com.br/nfc-e">NFC-e</a></li>
                                    <li><a href="http://www.tecnospeed.com.br/tef">TEF</a></li>
                                    <li><a href="http://www.tecnospeed.com.br/nf-e">NF-e</a></li>
                                    <li><a href="http://www.tecnospeed.com.br/boleto">Boleto</a></li>
                                    <li><a href="http://www.tecnospeed.com.br/sat-fiscal">SAT Fiscal/CFe e MFe Ceará</a></li>
                                    <li><a href="http://www.tecnospeed.com.br/nfs-e">NFS-e</a></li>
                                    <li><a href="http://www.tecnospeed.com.br/mdf-e">MDF-e</a></li>
                                    <li><a href="http://www.tecnospeed.com.br/ct-e">CT-e</a></li>
                                    <li><a href="http://www.tecnospeed.com.br/gnre">GNRE</a></li>
                                    <li><a href="http://www.tecnospeed.com.br/validador">Validador Online</a></li>
                                </ul>
                            </li>
                            <li class="drop"><a class="scroll">Eventos</a>
                                <ul class="drop-down">
                                    <li><a href="http://www.tecnospeed.com.br/tecnoupdate" target="_blank">TecnoUpdate 7</a></li>
                                    <li><a href="http://www.tecnospeed.com.br/eventos">Eventos Online</a></li>
                                </ul>
                            </li>

                            <li><a href="http://www.tecnospeed.com.br/institucional">A Tecnospeed</a></li>


                            <li class="drop"><a class="scroll">Mídias</a>
                                <ul class="drop-down drop-midias">
                                    <li><a href="http://www.tecnospeed.com.br/ebook-nfc-e">eBook NFC-e</a></li>
                                    <li><a href="http://www.tecnospeed.com.br/ebook-nfs-e">eBook NFS-e</a></li>
                                    <li><a href="http://www.tecnospeed.com.br/rota-mdf-e">eBook MDF-e</a></li>
                                    <li><a href="http://www.tecnospeed.com.br/tecnoupdate/revista">Revista TecnoUpdate</a></li>
                                </ul>
                            </li>
                            <li class="drop"><a class="scroll">TSDN</a>
                                <ul class="drop-down left">
                                    <li><a href="http://www.tecnospeed.com.br/blog" target="_blank">Tecnospeed</a></li>
                                    <li><a href="http://ciranda.me/tsdn/blog/cfop" target="_blank">CFOP</a></li>
                                    <li><a href="http://ciranda.me/tsdn/blog/blog-do-desenvolvimento-tecnospeed" target="_blank">Desenvolvimento</a></li>
                                    <li><a href="http://ciranda.me/tsdn/blog/base-de-conhecimento" target="_blank">Conhecimento</a></li>
                                    <li><a href="http://ciranda.me/tsdn/blog/blog-da-consultoria-tecnica-tecnospeed" target="_blank">Consultoria</a></li>
                                    <li><a href="http://ciranda.me/tsdn/blog/molhoespecial" target="_blank">Molho Especial</a></li>
                                    <li><a href="http://www.tecnospeed.com.br/forum" target="_blank">Fórum</a></li>
                                </ul>
                            </li>
                            <li><a href="http://www.tecnospeed.com.br/contato">Contato</a></li>
                        </ul>
                    </div>
                </div>
            </nav>
        </nav>
    </header>
</div>
<div class="container">
    <div class="row">
        <div class="col-xs-12" style="height: 55px;">
            <div style="padding: 10px 0" class="panel-title"><strong>Demonstração da API de Boleto em PHP </strong>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title">Dados Emitente <a href="http://docs.tecnospeed.com.br/boleto/Campos/" target="_blank"><i style="color: #fff;font-size: 20px !important; float: right;" class="fa fa-question-circle-o" aria-hidden="true" data-toggle="tooltip" title="Campos do boleto"></i></a></h3>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="bs-example" style="margin-bottom: 10px"
                             data-example-id="simple-justified-button-group">
                            <div class="btn-group btn-group-justified" role="group" aria-label="...">
                                <div class="btn-group" role="group">
                                    <div class="col-md-3">
                                        <strong>CNPJ Software House</strong>
                                        <input type="text" disabled class="form-control" id="CnpjSH"
                                               placeholder="CNPJ Software House"
                                               aria-describedby="basic-addon2" value="<?php echo $cnpjSH ?>">
                                    </div>
                                    <div class="col-md-3">
                                        <strong>Hash Software House</strong>
                                        <input type="text" disabled class="form-control" id="hashSH"
                                               placeholder="Hash Software House"
                                               aria-describedby="basic-addon2"
                                               value="<?php echo $hashSH ?>">
                                    </div>
                                    <div class="col-md-3">
                                        <strong>CNPJ Cedente</strong>
                                        <input type="text" disabled class="form-control" id="cnpjCedente"
                                               placeholder="CNPJ Cedente"
                                               aria-describedby="basic-addon2"
                                               value="<?php echo $CNPJCedente ?>">
                                    </div>
                                    <div class="col-md-3">
                                        <strong>Token Cedente</strong>
                                        <input type="text" disabled class="form-control" id="tokenCedente"
                                               placeholder="Token Cedente"
                                               value="<?php echo $tokenCedente ?>"
                                               aria-describedby="basic-addon2">
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="bs-example" data-example-id="simple-justified-button-group">
                            <div class="btn-group btn-group-justified" role="group" aria-label="...">
                                <div class="btn-group" role="group">
                                    <div class="col-md-9">
                                        <strong>URL</strong>
                                        <input type="text" disabled class="form-control" id="URL"
                                               placeholder="Cidade configurada para o Emitente"
                                               aria-describedby="basic-addon2"
                                               value="<?php echo $URL ?>">
                                    </div>
                                    <div class="col-md-2">
                                        <strong>Id Integração</strong>
                                        <input type="text" id="idintegracao"
                                               placeholder="Id Integração"
                                               aria-describedby="basic-addon2">
                                    </div>
                                    <div class="col-md-1">
                                        <i data-toggle="modal"
                                           style="position: relative!important; left: 15px!important; top: 25px!important;"
                                           data-target="#myModalExplicaConfiguracao"
                                           class="fa fa-code iconeCode" aria-hidden="true"></i>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="bs-example" data-example-id="simple-justified-button-group">
                            <div class="btn-group btn-group-justified" role="group" aria-label="...">
                                <div class="btn-group" role="group">
                                    <div class="col-md-3">
                                        <strong>Protocolo Impressão</strong>
                                        <input type="text" id="protImpressao"
                                               placeholder="Protocolo Impressão"
                                               aria-describedby="basic-addon2">
                                    </div>
                                    <div class="col-md-3">
                                        <strong>Protocolo Envio de E-Mail</strong>
                                        <input type="text" id="protEmail"
                                               placeholder="Protocolo Envio de E-Mail"
                                               aria-describedby="basic-addon2">
                                    </div><div class="col-md-3">
                                        <strong>Protocolo Upload de Retorno</strong>
                                        <input type="text" id="protRetorno"
                                               placeholder="Protocolo Upload de Retorno"
                                               aria-describedby="basic-addon2">
                                    </div>
                                    <!--<div class="col-md-1">
                                        <i data-toggle="modal"
                                           style="position: relative!important; left: 15px!important; top: 25px!important;"
                                           data-target="#myModalExplicaConfiguracao"
                                           class="fa fa-code iconeCode" aria-hidden="true"></i>
                                    </div>-->
                                </div>
                            </div>
                        </div>
                        <div class="bs-example" data-example-id="simple-justified-button-group">
                            <div class="btn-group btn-group-justified" role="group" aria-label="...">
                                <div class="btn-group" role="group">
                                    <div class="col-md-3">
                                        <strong>Protocolo Remessa Alteração</strong>
                                        <input type="text" id="protAlteracao"
                                               placeholder="Protocolo Remessa Alteração"
                                               aria-describedby="basic-addon2">
                                    </div>
                                    <div class="col-md-3">
                                        <strong>Protocolo Remessa Baixa</strong>
                                        <input type="text" id="protBaixa"
                                               placeholder="Protocolo Remessa Baixa"
                                               aria-describedby="basic-addon2">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-xs-12">
            <div class="panel panel-primary">
                <div class="panel-heading">

                    <h3 class="panel-title">Operações <a href="http://docs.tecnospeed.com.br/boleto/Delphi/introducao/" target="_blank"><i style="color: #fff;font-size: 20px !important; float: right;" class="fa fa-question-circle-o" aria-hidden="true" data-toggle="tooltip" title="Métodos do boleto"></i></a></h3>
                </div>
                <div class="panel-body">
                    <div class="bs-example" data-example-id="simple-justified-button-group">
                        <div class="btn-group btn-group-justified" role="group" aria-label="...">
                            <div class="btn-group" role="group">
                                <form class="wid" method="post">

                                    <button data-toggle="modal" data-target="#myModal" type="button"
                                            class="btn btn-default" id="configuraIni"
                                            title="Abrir arquivo ini para efetuar configurações.">
                                        1 - Configurar Ini
                                    </button>
                                    <i data-toggle="modal" data-target="#myModalExplicaIni"
                                       class="fa fa-code iconeCode" aria-hidden="true"></i>
                                    <div id="myModal" data-backdrop="static" class="modal fade" role="dialog">
                                        <div class="modal-dialog">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <h4 class="modal-title">Configuração do INI</h4>
                                                </div>
                                                <div class="modal-body">
                                                    <?php
                                                    include_once("config.php");
                                                    try {
                                                        $content = file_get_contents($DirArq . "boleto.ini");
                                                    } catch (Exception $e) {
                                                        echo "Arquivo não encontrado. Entre em contato com o suporte!";
                                                    }
                                                    ?>
                                                    <textarea disabled style="width: 100%;resize: none;" name="ini" id=""
                                                              cols="30"
                                                              rows="10"><?= $content ?></textarea>
                                                </div>
                                                <div class="modal-footer">
                                                    <button style="float: right;width: 94.4688px!important;"
                                                            type="button" data-dismiss="modal"
                                                            class="btn btn-danger">
                                                        Fechar
                                                    </button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </form>
                            </div>
                            <div class="btn-group" role="group">
                                <form class="wid" method="post" action="">
                                    <button onclick="listaCedentes()" type="button" class="btn btn-default"
                                            title="Consultar Cedentes">
                                        2 - Consultar Cedentes
                                    </button>
                                    <i data-toggle="modal" data-target="#myModalExplicaConsultaCedente"
                                       class="fa fa-code iconeCode" aria-hidden="true"></i>
                                </form>
                            </div>
                            <div class="btn-group" role="group">
                                <form class="wid" method="post" action="">
                                    <a data-toggle="modal" data-target="#modalBoleto">
                                        <button type="button" class="btn btn-default"
                                                title="Incluir Boleto">
                                            3 - Incluir Boleto via TX2
                                        </button>
                                    </a>
                                    <i data-toggle="modal" data-target="#myModalExplicaTX2"
                                       class="fa fa-code iconeCode" aria-hidden="true"></i>
                                </form>
                            </div>
                            <div class="btn-group" role="group">
                                <form class="wid">
                                    <button onclick="incluir()" type="button" class="btn btn-default">
                                        3.1 - Incluir Boleto via JSON
                                    </button>
                                    <i data-toggle="modal" data-target="#myModalExplicaJson"
                                       class="fa fa-code iconeCode" aria-hidden="true"></i>
                                </form>
                            </div>
                        </div>
                    </div>
                    <div class="bs-example" data-example-id="simple-justified-button-group">
                        <div class="btn-group btn-group-justified" role="group" aria-label="...">
                            <div class="btn-group" role="group">
                                <form class="wid">
                                    <button onclick="consultarIds()" type="button" class="btn btn-default">
                                        4 - Consultar Boleto
                                    </button>
                                    <i data-toggle="modal" data-target="#myModalExplicaConsultaBoleto"
                                       class="fa fa-code iconeCode" aria-hidden="true"></i>
                                </form>
                            </div>
                            <div class="btn-group" role="group">
                                <form class="wid">
                                    <button onclick="gerarRemessaLote()" type="button" class="btn btn-default">
                                        5 - Gerar Remessa Lote
                                    </button>
                                    <i data-toggle="modal" data-target="#myModalExplicaGerarRemessa"
                                       class="fa fa-code iconeCode" aria-hidden="true"></i>
                                </form>
                            </div>
                            <div class="btn-group" role="group">
                                <form class="wid">
                                    <button onclick="imprimeBoletoFin()" type="button" class="btn btn-default">
                                        6 - Imprime Boleto
                                    </button>
                                    <i data-toggle="modal" data-target="#myModalExplicaImprimeBoleto"
                                       class="fa fa-code iconeCode" aria-hidden="true"></i>
                                </form>
                            </div>
                            <div class="btn-group" role="group">
                                <form class="wid">
                                    <button type="button" data-toggle="modal" data-target="#modalenviaEmail"
                                            class="btn btn-default"
                                            title="Imprime a NFSe">
                                        7 - Enviar Boleto por e-mail
                                    </button>
                                    <i data-toggle="modal" data-target="#myModalExplicaEvioEmail"
                                       class="fa fa-code iconeCode" aria-hidden="true"></i>
                                </form>
                            </div>
                        </div>
                    </div>
                    <div class="bs-example" data-example-id="simple-justified-button-group">
                        <div class="btn-group btn-group-justified" role="group" aria-label="...">
                            <div class="btn-group" role="group">
                                <form class="wid">
                                    <button onclick="imprimirLote()" type="button" class="btn btn-default">
                                        6.1 - Solicitar impressao Lote
                                    </button>
                                    <i data-toggle="modal" data-target="#myModalExplicaSolicitarImpressaoLote"
                                       class="fa fa-code iconeCode" aria-hidden="true"></i>
                                </form>
                            </div>
                            <div class="btn-group" role="group">
                                <form class="wid">
                                    <button onclick="SalvarLoteImpressaoPDF()" type="button" class="btn btn-default">
                                        6.2 - Imprimir Lote
                                    </button>
                                    <i data-toggle="modal" data-target="#myModalExplicaImprimeBoletoLote"
                                       class="fa fa-code iconeCode" aria-hidden="true"></i>
                                </form>
                            </div>
                            <div class="btn-group" role="group">
                                <form class="wid">
                                    <button onclick="emailLote()" type="button" class="btn btn-default">
                                        7.1 - Solicitar e-mail Lote
                                    </button>
                                    <i data-toggle="modal" data-target="#myModalExplicaEmailLote"
                                       class="fa fa-code iconeCode" aria-hidden="true"></i>
                                </form>
                            </div>
                            <div class="btn-group" role="group">
                                <form class="wid">
                                    <button onclick="consultarEmailLote()" type="button" class="btn btn-default">
                                    7.2 - Consultar envio e-mail
                                    </button>
                                    <i data-toggle="modal" data-target="#myModalExplicaConsultaEmail"
                                       class="fa fa-code iconeCode" aria-hidden="true"></i>
                                </form>
                            </div>
                        </div>
                        <div class="bs-example" data-example-id="simple-justified-button-group">
                        <div class="btn-group btn-group-justified" role="group" aria-label="...">
                            <div class="btn-group" role="group">
                                <form class="wid">
                                    <button onclick="processarRetorno()" type="button" class="btn btn-default">
                                        8 - Upload de retorno
                                    </button>
                                    <i data-toggle="modal" data-target="#myModalExplicaUploadREtorno"
                                       class="fa fa-code iconeCode" aria-hidden="true"></i>
                                </form>
                            </div>
                            <div class="btn-group" role="group">
                                <form class="wid">
                                    <button onclick="consultaRetornoProcessamento()" type="button" class="btn btn-default">
                                        8.1 - Consultar de retorno
                                    </button>
                                    <i data-toggle="modal" data-target="#myModalExplicaUploadConsultaREtorno"
                                       class="fa fa-code iconeCode" aria-hidden="true"></i>
                                </form>
                            </div>
                            <div class="btn-group" role="group">
                                <form class="wid">
                                    <button onclick="gerarRemessaAlteracao()" type="button" class="btn btn-default">
                                        9 - Solicitar remessa de alteração&nbsp;&nbsp;&nbsp;
                                    </button>
                                    <i data-toggle="modal" data-target="#myModalExplicaGerarRemessaAlteracao"
                                       class="fa fa-code iconeCode" aria-hidden="true"></i>
                                </form>
                            </div>
                            <div class="btn-group" role="group">
                                <form class="wid">
                                    <button onclick="cosultarRemessaAlteração()" type="button" class="btn btn-default">
                                        9.1 - Cons. remessa de alteração&nbsp;&nbsp;
                                    </button>
                                    <i data-toggle="modal" data-target="#myModalExplicaConsultarRemessaAlteracao"
                                       class="fa fa-code iconeCode" aria-hidden="true"></i>
                                </form>
                            </div>                            
                        </div>
                        <div class="btn-group btn-group-justified" role="group" aria-label="...">
                        <div class="btn-group" role="group">
                            <form class="wid">
                                <button onclick="gerarRemessaBaixa()" type="button" class="btn btn-default">
                                    10.1 - Solicitar Remessa de Baixa&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </button>
                                <i data-toggle="modal" data-target="#myModalExplicaGerarRemessaBaixa"
                                   class="fa fa-code iconeCode" aria-hidden="true"></i>
                            </form>
                        </div> 
                        <div class="btn-group" role="group">
                            <form class="wid">
                                <button onclick="consultarRemessaBaixa()" type="button" class="btn btn-default">
                                    10.2 - Consultar Remessa de Baixa&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </button>
                                <i data-toggle="modal" data-target="#myModalExplicaDescartaBoleto"
                                   class="fa fa-code iconeCode" aria-hidden="true"></i>
                            </form>
                        </div> 
                        <div class="btn-group" role="group">
                            <form class="wid">
                                <button onclick="descartarBoleto()" type="button" class="btn btn-default">
                                    11 - Descartar Boleto&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </button>
                                <i data-toggle="modal" data-target="#myModalExplicaDescartaBoleto"
                                   class="fa fa-code iconeCode" aria-hidden="true"></i>
                            </form>
                        </div>  
                        <div class="btn-group" role="group">
                            <form class="wid">
                                <button onclick="descartarBoleto()" type="button" class="btn btn-default">
                                    .&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </button>
                                <i data-toggle="modal" data-target="#myModalExplicaDescartaBoleto"
                                   class="fa fa-code iconeCode" aria-hidden="true"></i>
                            </form>
                        </div>                      
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title">Retornos</h3>
                </div>
                <div class="panel-body">
                    <div>
                        <textarea name="xml" id="xmlRetorno" cols="30" style="width: 100%; resize: none;"
                                  rows="20"></textarea>
                    </div>
                </div>
            </div>
            <div style="color: #4286f4 !important;padding: 10px" class="panel-title col-xs-11"><strong>
                    Essas são apenas algumas funcionalidades do componente NF-e, confira a documentação para verificar
                    todos os métodos!
                </strong>
            </div>
            <div class="col-xs-1">
                <a target="_blank" href="http://docs.tecnospeed.com.br/boleto/">
                    <button style="float: right; background-color: #4286f4 ;"
                            type="button" data-dismiss="modal" class="btn btn-success">
                        Mais Informações
                    </button>
                </a>
            </div>
        </div>
    </div>
</div>
<div id="modalenviaEmail" class="modal fade" role="dialog">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 class="modal-title" id="myLangeModalLabel">Enviar Email</h4>
            </div>
            <div class="modal-body">
                <input style="margin-bottom: 10px" type="text" class="form-control" id="emailDest"
                       placeholder="Email do destinatário"
                       aria-describedby="basic-addon2">
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>
                <button type="button" class="btn btn-primary" onclick="enviaEmailBoleto()" id="enviarEmail">
                    Enviar Email
                </button>
            </div>
        </div>
    </div>
</div>
<div id="modalBoleto" data-backdrop="static" class="modal fade" role="dialog">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <h4 class="modal-title">Incluir Boleto</h4>
            </div>
            <div class="modal-body">
                Padrão:
                <textarea name="textAreaTX2Padrao" style="width: 100%; resize: none;" id="textAreaTX2Padrao" cols="30"
                          rows="10"><?= $tx2Padrao ?></textarea>
                <form enctype="multipart/form-data" method="post">
                    Ou envie seu TX2:
                    <input type="file" name="arquivoTx2">
                    <button style="margin-top: 30px; float: right;width: 94.4688px;" type="submit"
                            name="salvarTX2" value="Salvar" class="btn btn-success">
                        Enviar
                    </button>
                    <button onclick="enviartx2Padrao()" name="enviarPadrao" type="button" class="btn btn-success"
                            style="margin-top: 30px;margin-right: 15px; float: left;width: 118px;">
                        Enviar Padrão
                    </button>
                    <button style="margin-top: 30px; float: right;width: 94.4688px; margin-right: 15px"
                            type="button" data-dismiss="modal"
                            class="btn btn-danger">
                        Cancelar
                    </button>
                </form>
            </div>
            <div class="modal-footer">

            </div>
        </div>
    </div>
</div>
<?php
ini_set("highlight.comment", "#969896");
ini_set("highlight.default", "#c66");
ini_set("highlight.html", "#808080");
ini_set("highlight.keyword", "#b294bb; font-weight: bold");
ini_set("highlight.string", "#b5bd68");
ini_set("highlight.bg", "#1d1f21");
?>
<!--================== MODAIS EXPLICATIVOS =================-->
<div id="myModalExplicaConsultaEmail" class="modal bs-example-modal-lg fade" role="dialog"
aria-labelledby="myLargeModalLabel">
<div class="modal-dialog modal-lg">
   <div class="modal-content">
       <div class="modal-header">
           <button type="button" class="close" data-dismiss="modal">&times;</button>
           <h4 class="modal-title" id="myLangeModalLabel">Código para consultar boleto</h4>
       </div>
       <div class="modal-body" style="background-color: #1d1f21">
           <?php highlight_string('<?php
include_once("addComponente.php");
try {
    $protocoloEmail = $_POST[\'protEmail\'];
    $curl = curl_init();
    curl_setopt_array($curl, array(
        CURLOPT_URL => "http://homologacao.cobrancabancaria.tecnospeed.com.br:8080/api/v1/email/lote/${protocoloEmail}",
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
}');
                ?>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>
            </div>
        </div>
    </div>
</div>
<div id="myModalExplicaUploadREtorno" class="modal bs-example-modal-lg fade" role="dialog"
aria-labelledby="myLargeModalLabel">
<div class="modal-dialog modal-lg">
   <div class="modal-content">
       <div class="modal-header">
           <button type="button" class="close" data-dismiss="modal">&times;</button>
           <h4 class="modal-title" id="myLangeModalLabel">Código para consultar boleto</h4>
       </div>
       <div class="modal-body" style="background-color: #1d1f21">
           <?php highlight_string('<?php
include_once("addComponente.php");
try {
    
    $curl = curl_init();
    curl_setopt_array($curl, array(
        CURLOPT_URL => "http://homologacao.cobrancabancaria.tecnospeed.com.br:8080/api/v1/retornos/",
        CURLOPT_CUSTOMREQUEST => "POST",
        CURLOPT_SSL_VERIFYPEER => 0,
        CURLOPT_SSL_VERIFYHOST => 0,
        CURLOPT_HTTPHEADER => array(
            "cnpj-cedente: $CNPJCedente",
            "cnpj-sh: $cnpjSH",
            "content-type: application/json",
            "token-sh: $hashSH",
        ),
        CURLOPT_POSTFIELDS => "{\"arquivo\": \"NzU2MDAwMDAgICAgICAgICAyMTAyODQzNjgwMDAxODIgICAgICAgICAgICAgICAgICAgIDA0MzcwMDAwMDAwMDAzMTIzMTIwUFJJTlQgTUlESUEgQ09NVU5JQ0HDh0FPIFZJU1VBTFNJQ09PQiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAyMjEwMzIwMTgwODE1MzQwMDAwMDIwODUwMDAwMCAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIA0KNzU2MDAwMTFUMDEgIDA0MyAyMDEwMjg0MzY4MDAwMTgyICAgICAgICAgIDQzNzAwMDAwMDkwNDM3MDAwMDAwMDAwMzEyMzEyMFBSSU5UIE1JRElBIENPTVVOSUNBw4dBTyBWSVNVQUwgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIDAwMDAwMDAwMjEwMzIwMTgwMDAwMDAwMCAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIA0KNzU2MDAwMTMwMDAwMVQgMDYwNDM3MDAwMDAwMDAwMzEyMzEyMDAwMDAwMDAyMzcwMTAxMSAgICAgMTIzICAgICAgICAgICAgIDIwMDMyMDE4MDAwMDAwMDAwMDAxMDAwNzQ4MDczNjgwICAgICAgICAgICAgICAgICAgICAgICAgIDA5MjAxNDg1MTAyNDAwMDE2OUFOQSBMVUNJQSBWSUNFTlRFIC0gTUUgICAgICAgICAgICAgICAgICAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwNCAgICAgICAgICAgICAgICAgDQo3NTYwMDAxMzAwMDAyVSAwNjAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMTAwMDAwMDAwMDAwMDAwMTAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDIwMDMyMDE4MjAwMzIwMTggICAgMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICA3NTYwMDAwMDAwMDAwMDAwMDAwMDAwMCAgICAgICANCjc1NjAwMDE1ICAgICAgICAgMDAwMDA0MDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAwMDAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIA0KNzU2OTk5OTkgICAgICAgICAwMDAwMDEwMDAwMDYwMDAwMDAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgDQo=\"}",
        
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
}');
                ?>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>
            </div>
        </div>
    </div>
</div>
<div id="myModalExplicaUploadConsultaREtorno" class="modal bs-example-modal-lg fade" role="dialog"
aria-labelledby="myLargeModalLabel">
<div class="modal-dialog modal-lg">
   <div class="modal-content">
       <div class="modal-header">
           <button type="button" class="close" data-dismiss="modal">&times;</button>
           <h4 class="modal-title" id="myLangeModalLabel">Código para consultar boleto</h4>
       </div>
       <div class="modal-body" style="background-color: #1d1f21">
           <?php highlight_string('<?php
include_once("addComponente.php");
try {
    $protocoloRetonro = $_POST[\'protRetorno\'];
    $curl = curl_init();
    curl_setopt_array($curl, array(
        CURLOPT_URL => "http://homologacao.cobrancabancaria.tecnospeed.com.br:8080/api/v1/retornos/${protocoloRetonro}",
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
}');
                ?>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>
            </div>
        </div>
    </div>
</div>
<div id="myModalExplicaConfiguracao" class="modal bs-example-modal-lg fade" role="dialog"
     aria-labelledby="myLargeModalLabel">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 class="modal-title" id="myLangeModalLabel">Código Configuração</h4>
            </div>
            <div class="modal-body" style="background-color: #1d1f21">
                <?php highlight_string('<?php
include_once("config.php");
try {
    $url = "http://guilhermenunes:83/boleto-final/"; //caminho da URL
    $dirC = $DirArq . "boleto.ini";
    $ini_array = parse_ini_file($dirC, true);
    $cnpjSH = $ini_array[\'DADOS\'][\'CNPJSH\'];
    $hashSH = $ini_array[\'DADOS\'][\'HashSH\'];
    $CNPJCedente = $ini_array[\'DADOS\'][\'CNPJCedente\'];
    $tokenCedente = $ini_array[\'DADOS\'][\'tokenCedente\'];
} catch (Exception $e) {
    echo $e;
}
?>');
                ?>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>
            </div>
        </div>
    </div>
</div>
<div id="myModalExplicaEmailLote" class="modal bs-example-modal-lg fade" role="dialog"
     aria-labelledby="myLargeModalLabel">
    <div class="modal-dialog modal-lg">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 class="modal-title" id="myLangeModalLabel">Código para consultar boleto</h4>
            </div>
            <div class="modal-body" style="background-color: #1d1f21">
                <?php highlight_string('<?php
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
}');
                ?>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>
            </div>
        </div>
    </div>
</div>
<div id="myModalExplicaIni" class="modal bs-example-modal-lg fade" role="dialog" aria-labelledby="myLargeModalLabel">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 class="modal-title" id="myLangeModalLabel">Código INI</h4>
            </div>
            <div class="modal-body" style="background-color: #1d1f21">
                <?php highlight_string('<?php
include_once("config.php");
try {
    $content = file_get_contents($DirArq . "boleto.ini");
} catch (Exception $e) {
    echo "Arquivo não encontrado. Entre em contato com o suporte!";
}
    if ($_POST[\'salvarIni\']) {
    $name = ($DirArq . "boleto.ini");
    $text = $_POST[\'ini\'];
    $file = fopen($name, \'w\');
    fwrite($file, $text);
    fclose($file);
}
?>');
                ?>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>
            </div>
        </div>
    </div>
</div>
<div id="myModalExplicaConsultaCedente" class="modal bs-example-modal-lg fade" role="dialog"
     aria-labelledby="myLargeModalLabel">
    <div class="modal-dialog modal-lg">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 class="modal-title" id="myLangeModalLabel">Código Consulta Cedente</h4>
            </div>
            <div class="modal-body" style="background-color: #1d1f21">
                <?php highlight_string('<<?php
include_once("addComponente.php");

try {
    $curl = curl_init();
    curl_setopt($curl, CURLOPT_SSL_VERIFYPEER, 0);
    curl_setopt($curl, CURLOPT_SSL_VERIFYHOST, 0);
    curl_setopt_array($curl, array(
        CURLOPT_URL => "http://homologacao.cobrancabancaria.tecnospeed.com.br:8080/api/v1/cedentes",
        CURLOPT_CUSTOMREQUEST => "GET",
        CURLOPT_HTTPHEADER => array(
            "cnpj-cedente: $CNPJCedente",
            "cnpj-sh: $cnpjSH",
            "content-type: application/json",
            "token-sh: $hashSH",
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
?>');
                ?>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>
            </div>
        </div>
    </div>
</div>
<div id="myModalExplicaTX2" class="modal bs-example-modal-lg fade" role="dialog"
     aria-labelledby="myLargeModalLabel">
    <div class="modal-dialog  modal-lg">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 class="modal-title" id="myLangeModalLabel">Código para incluir via TX2</h4>
            </div>
            <div class="modal-body" style="background-color: #1d1f21">
                <?php highlight_string('<?php
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
        CURLOPT_POSTFIELDS => json_encode(array(\'arquivo\' => $caminhoTx2)),
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
}');
                ?>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>
            </div>
        </div>
    </div>
</div>
<div id="myModalExplicaJson" class="modal bs-example-modal-lg fade" role="dialog"
     aria-labelledby="myLargeModalLabel">
    <div class="modal-dialog  modal-lg">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 class="modal-title" id="myLangeModalLabel">Código para incluir via JSON</h4>
            </div>
            <div class="modal-body" style="background-color: #1d1f21">
                <?php highlight_string('<?php
include_once("addComponente.php");
try {
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
    $iniNumero = $iniNumero[\'NUMERO\'][\'TituloNossoNumero\'];
    $iniNumeroDocumento = $iniNumero[\'NUMERO\'][\'TituloNumeroDocumento\'];

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
        CURLOPT_POSTFIELDS => "[{ "CedenteContaNumero": "12345", "CedenteContaNumeroDV": "6", "CedenteConvenioNumero": "1234123456", 
        "CedenteContaCodigoBanco": "341", "SacadoCPFCNPJ": "28436161661", "SacadoEmail": "email@sacado.com", 
        "SacadoEnderecoNumero": "987",  "SacadoEnderecoBairro": "Centro", "SacadoEnderecoCEP": "87098765", 
        "SacadoEnderecoCidade": "Maringá", "SacadoEnderecoComplemento": "Fundos", "SacadoEnderecoLogradouro": "Rua teste, 987", 
        "SacadoEnderecoPais": "Brasil",  "SacadoEnderecoUF": "PR", "SacadoNome": "Teste de Souza", 
        "SacadoTelefone": "4499999999", "SacadoCelular": "44999999999", "TituloDataDesconto": "05/01/2020", 
        "TituloValorDesconto": "0,01", "TituloDataEmissao": "", "TituloDataVencimento": "", 
        "TituloValorJuros": "0,01", "TituloPrazoProtesto": "30", "TituloMensagem01": "Juros de 0,01 ao dia", 
        "TituloMensagem02": "Nao receber apos 30 dias de atraso", "TituloMensagem03": "Titulo sujeito a protesto apos 30 dias", 
        "TituloNossoNumero": "", "TituloNumeroDocumento": "01012020", "TituloValor": "0,02", 
        "TituloLocalPagamento": "Pagável em qualquer banco até o vencimento." }],
        CURLOPT_TIMEOUT => 30,
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
        $file = fopen($name, \'w\');
        fwrite($file, $text);
        fclose($file);
        echo prettyPrint($response);
    }
} catch (Exception $e) {
    echo $e;
}');
                ?>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>
            </div>
        </div>
    </div>
</div>
<div id="myModalExplicaConsultaBoleto" class="modal bs-example-modal-lg fade" role="dialog"
     aria-labelledby="myLargeModalLabel">
    <div class="modal-dialog modal-lg">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 class="modal-title" id="myLangeModalLabel">Código para consultar boleto</h4>
            </div>
            <div class="modal-body" style="background-color: #1d1f21">
                <?php highlight_string('<?php
include_once("addComponente.php");
try {
    $id = $_POST[\'idGerarRemessa\'];
    $codigo = ("idintegracao=" . $id);
    $curl = curl_init();
    curl_setopt_array($curl, array(
        CURLOPT_URL => "http://homologacao.cobrancabancaria.tecnospeed.com.br:8080/api/v1/boletos?{$codigo}",
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
}');
                ?>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>
            </div>
        </div>
    </div>
</div>
<div id="myModalExplicaDescartaBoleto" class="modal bs-example-modal-lg fade" role="dialog"
     aria-labelledby="myLargeModalLabel">
    <div class="modal-dialog modal-lg">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 class="modal-title" id="myLangeModalLabel">Código para consultar boleto</h4>
            </div>
            <div class="modal-body" style="background-color: #1d1f21">
                <?php highlight_string('<?php
include_once("addComponente.php");
try {
    $id = $_POST[\'idintegracao\'];
    $curl = curl_init();
    curl_setopt_array($curl, array(
        CURLOPT_URL => "http://homologacao.cobrancabancaria.tecnospeed.com.br:8080/api/v1/boletos/descarta/lote",
        CURLOPT_CUSTOMREQUEST => "POST",
        CURLOPT_SSL_VERIFYPEER => 0,
        CURLOPT_SSL_VERIFYHOST => 0,
        CURLOPT_HTTPHEADER => array(
            "cnpj-cedente: $CNPJCedente",
            "cnpj-sh: $cnpjSH",
            "content-type: application/json",
            "token-sh: $hashSH",
        ),
        CURLOPT_POSTFIELDS => "[\"{$id}\"]",
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
}');
                ?>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>
            </div>
        </div>
    </div>
</div>
<div id="myModalExplicaSolicitarImpressaoLote" class="modal bs-example-modal-lg fade" role="dialog"
     aria-labelledby="myLargeModalLabel">
    <div class="modal-dialog modal-lg">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 class="modal-title" id="myLangeModalLabel">Código para consultar boleto</h4>
            </div>
            <div class="modal-body" style="background-color: #1d1f21">
                <?php highlight_string('<?php
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
}');
                ?>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>
            </div>
        </div>
    </div>
</div>
<div id="myModalExplicaGerarRemessaBaixa" class="modal bs-example-modal-lg fade" role="dialog"
     aria-labelledby="myLargeModalLabel">
    <div class="modal-dialog modal-lg">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 class="modal-title" id="myLangeModalLabel">Código para gerar remessa</h4>
            </div>
            <div class="modal-body" style="background-color: #1d1f21">
                <?php highlight_string('<?php
include("addComponente.php");
try{
    $curl = curl_init();
    $id = $_POST[\'idintegracao\'];
    $emailDestinatario = $_POST[\'destinatario\'];
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
?>');
                ?>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>
            </div>
        </div>
    </div>
</div>
<div id="myModalExplicaGerarRemessaAlteracao" class="modal bs-example-modal-lg fade" role="dialog"
     aria-labelledby="myLargeModalLabel">
    <div class="modal-dialog modal-lg">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 class="modal-title" id="myLangeModalLabel">Código para gerar remessa</h4>
            </div>
            <div class="modal-body" style="background-color: #1d1f21">
                <?php highlight_string('<?php
include("addComponente.php");
try{
    $curl = curl_init();
    $id = $_POST[\'idintegracao\'];
    if(!$id){
        $id = "BJeENF32Al";
    }
    $linkBoleto = "http://homologacao.cobrancabancaria.tecnospeed.com.br:8080/api/v1/boletos/impressao/" . $id;
    $emailDestinatario = $_POST[\'destinatario\'];
    curl_setopt_array($curl, array(
        CURLOPT_URL => "http://homologacao.cobrancabancaria.tecnospeed.com.br:8080/api/v1/boletos/altera/lote",
        CURLOPT_CUSTOMREQUEST => "POST",
        CURLOPT_PORT => "8080",
        CURLOPT_RETURNTRANSFER => true,
        CURLOPT_SSL_VERIFYPEER => 0,
        CURLOPT_SSL_VERIFYHOST => 0,
        CURLOPT_POSTFIELDS => "{\"tipo\" : \"0\",\"boletos\": [{\"idintegracao\": \"B1e_cHxB8W\",\"TituloDataVencimento\": \"20/06/2018\"},{\"idintegracao\": \"S1xP967aSZ\",\"TituloDataVencimento\": \"20/06/2018\"}]}",
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
?>');
                ?>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>
            </div>
        </div>
    </div>
</div>
<div id="myModalExplicaConsultarRemessaAlteracao" class="modal bs-example-modal-lg fade" role="dialog"
     aria-labelledby="myLargeModalLabel">
    <div class="modal-dialog modal-lg">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 class="modal-title" id="myLangeModalLabel">Código para gerar remessa</h4>
            </div>
            <div class="modal-body" style="background-color: #1d1f21">
                <?php highlight_string('<?php
include_once("addComponente.php");
try {
    $protAlteracao = $_POST[\'protAlteracao\'];
    $curl = curl_init();
    curl_setopt_array($curl, array(
        CURLOPT_URL => "http://homologacao.cobrancabancaria.tecnospeed.com.br:8080/api/v1/boletos/altera/lote/${protAlteracao}",
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
    echo ("Teste" . $protAlteracao);
} catch (Exception $e) {
    echo $e;
}');
                ?>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>
            </div>
        </div>
    </div>
</div>
<div id="myModalExplicaGerarRemessa" class="modal bs-example-modal-lg fade" role="dialog"
     aria-labelledby="myLargeModalLabel">
    <div class="modal-dialog modal-lg">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 class="modal-title" id="myLangeModalLabel">Código para gerar remessa</h4>
            </div>
            <div class="modal-body" style="background-color: #1d1f21">
                <?php highlight_string('<?php
include_once("addComponente.php");
try {
    $id = $_POST[\'idGerarRemessa\'];
    $curl = curl_init();
    curl_setopt_array($curl, array(
        CURLOPT_URL => "http://homologacao.cobrancabancaria.tecnospeed.com.br:8080/api/v1/remessas/lote",
        CURLOPT_CUSTOMREQUEST => "POST",
        CURLOPT_SSL_VERIFYPEER => 0,
        CURLOPT_SSL_VERIFYHOST => 0,
        CURLOPT_HTTPHEADER => array(
            "cnpj-cedente: $CNPJCedente",
            "cnpj-sh: $cnpjSH",
            "content-type: application/json",
            "token-sh: $hashSH",
        ),
        CURLOPT_POSTFIELDS => "[\"{$id}\"]",
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
}');
                ?>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>
            </div>
        </div>
    </div>
</div>
<div id="myModalExplicaImprimeBoleto" class="modal bs-example-modal-lg fade" role="dialog"
     aria-labelledby="myLargeModalLabel">
    <div class="modal-dialog modal-lg">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 class="modal-title" id="myLangeModalLabel">Código para consultar nota por rps</h4>
            </div>
            <div class="modal-body" style="background-color: #1d1f21">
                <?php highlight_string('
                //script
                var link = \'http://homologacao.cobrancabancaria.tecnospeed.com.br:8080/api/v1/boletos/impressao/\' + idintegracao;
                window.open(link, \'_blank\');
                ');
                ?>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>
            </div>
        </div>
    </div>
</div>
<div id="myModalExplicaImprimeBoletoLote" class="modal bs-example-modal-lg fade" role="dialog"
     aria-labelledby="myLargeModalLabel">
    <div class="modal-dialog modal-lg">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 class="modal-title" id="myLangeModalLabel">Código para consultar nota por rps</h4>
            </div>
            <div class="modal-body" style="background-color: #1d1f21">
                <?php highlight_string('
                //script
                var link = \'http://homologacao.cobrancabancaria.tecnospeed.com.br:8080/api/v1/boletos/impressao/lote/\' + idintegracao;
                window.open(link, \'_blank\');
                ');
                ?>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>
            </div>
        </div>
    </div>
</div>
<div id="myModalExplicaEvioEmail" class="modal bs-example-modal-lg fade" role="dialog"
     aria-labelledby="myLargeModalLabel">
    <div class="modal-dialog modal-lg">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 class="modal-title" id="myLangeModalLabel">Código para consultar nota pelo número da mesma</h4>
            </div>
            <div class="modal-body" style="background-color: #1d1f21">
                <?php highlight_string('<?php
include("addComponente.php");
try{
    $curl = curl_init();
    $id = $_POST[\'idintegracao\'];
    $linkBoleto = "http://homologacao.cobrancabancaria.tecnospeed.com.br:8080/api/v1/boletos/impressao/" . $id;
    $emailDestinatario = $_POST[\'destinatario\'];
    curl_setopt_array($curl, array(
        CURLOPT_URL => "http://homologacao.cobrancabancaria.tecnospeed.com.br:8080/api/v1/email",
        CURLOPT_CUSTOMREQUEST => "POST",
        CURLOPT_PORT => "8080",
        CURLOPT_RETURNTRANSFER => true,
        CURLOPT_SSL_VERIFYPEER => 0,
        CURLOPT_SSL_VERIFYHOST => 0,
        CURLOPT_POSTFIELDS => "{\r\n  \"IdIntegracao\": \"$id\",\r\n  \"EmailNomeRemetente\": \"Nome Empresa Exemplo\",\r\n  
        \"EmailRemetente\": \"exemplo@remetente.com.br\",\r\n  \"EmailAssunto\": \"Teste do envio de email demonstração do Boleto\",\r\n 
         \"EmailMensagem\": \"Segue o link do boleto:| $linkBoleto|Considere não imprimir este email.\",\r\n 
          \"EmailDestinatario\": [\"$emailDestinatario\"]\r\n}",
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
?>');
                ?>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>
            </div>
        </div>
    </div>
</div>
</body>