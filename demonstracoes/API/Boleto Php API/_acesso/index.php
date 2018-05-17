<?php
include_once("../config.php");
include_once("../addComponente.php");
$actual_link = $_SERVER['REQUEST_URI'];
$parteurl = explode('/', $actual_link);
$parteurl = $parteurl[2];
?>
<!DOCTYPE html>
<html>
<head>
    <link rel="shortcut icon" href="<?= $url ?>images/icone.ico" type="image/x-icon"/>
    <title>TecnoSpeed TI Boleto</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="<?= $url ?>lib/css/style.css">
    <link rel="stylesheet" href="<?= $url ?>lib/css/bootstrap.min.css">
    <script type="text/javascript" src="<?= $url ?>lib/js/jquery.min.js"></script>
    <script src="<?= $url ?>lib/js/appDemo.js"></script>
    <script type="text/javascript" src="<?= $url ?>lib/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
    <script type="text/javascript" src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:300italic,400italic,600italic,700italic,800italic,400,800,700,600,300'
          rel='stylesheet' type='text/css'>
</head>
<? $urlAcesso = "http://demo.tecnospeed.com.br/boleto/acesso/"; //caminho da URL?>
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
                            <li><a href="http://www.twitter.com/tecnospeed" target="_blank"><i
                                            class="fa fa-twitter"></i></a></li>
                            <li><a href="http://www.facebook.com/tecnospeed" target="_blank"><i
                                            class="fa fa-facebook"></i></a></li>
                            <li><a href="https://www.linkedin.com/company/tecnospeed-ti" target="_blank"><i
                                            class="fa fa-linkedin"></i></a></li>
                            <li><a href="https://plus.google.com/+TecnoSpeedTI" target="_blank"><i
                                            class="fa fa-google-plus"></i></a></li>
                            <li><a href="http://www.youtube.com/tecnospeedti" target="_blank"><i
                                            class="fa fa-youtube"></i></a></li>
                        </ul>
                        <ul class="top-info col-xs-12 col-sm-9 col-md-9">
                            <li><p class="text-highlight"><i class="fa fa-phone"></i>0800 006 9500 / 44 3037 9500</p>
                            </li>
                            <li><a href="http://www.tecnospeed.com.br/comercial"><i class="fa fa-comment"></i>Comercial</a>
                            </li>
                            <li><a href="http://www.tecnospeed.com.br/atendimento"><i class="fa fa-question-circle"></i>Suporte</a>
                            </li>
                            <li><a href="http://tecno-services.com:1338/" target="_blank"><i class="fa fa-lock"></i>Área
                                    Restrita</a></li>
                            <li><a href="mailto:contato@tecnospeed.com.br" target="_blank"><i
                                            class="fa fa-envelope"></i>contato@tecnospeed.com.br</a></li>
                        </ul>
                    </div>
                </div>
            </div>
            <!-- end topline -->
            <nav class="navigation">
                <div class="container">
                    <div class="logo logo-tecnospeed">
                        <a href="<?= $urlAcesso ?>"><img src="http://www.tecnospeed.com.br/images/logo.png" alt=""></a>
                    </div>

                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle" data-toggle="collapse"
                                data-target=".navbar-collapse">
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
                                    <li><a href="http://www.tecnospeed.com.br/sat-fiscal">SAT Fiscal/CFe e MFe Ceará</a>
                                    </li>
                                    <li><a href="http://www.tecnospeed.com.br/nfs-e">NFS-e</a></li>
                                    <li><a href="http://www.tecnospeed.com.br/mdf-e">MDF-e</a></li>
                                    <li><a href="http://www.tecnospeed.com.br/ct-e">CT-e</a></li>
                                    <li><a href="http://www.tecnospeed.com.br/gnre">GNRE</a></li>
                                    <li><a href="http://www.tecnospeed.com.br/validador">Validador Online</a></li>
                                </ul>
                            </li>
                            <li class="drop"><a class="scroll">Eventos</a>
                                <ul class="drop-down">
                                    <li><a href="http://www.tecnospeed.com.br/tecnoupdate" target="_blank">TecnoUpdate
                                            7</a></li>
                                    <li><a href="http://www.tecnospeed.com.br/eventos">Eventos Online</a></li>
                                </ul>
                            </li>

                            <li><a href="http://www.tecnospeed.com.br/institucional">A Tecnospeed</a></li>


                            <li class="drop"><a class="scroll">Mídias</a>
                                <ul class="drop-down drop-midias">
                                    <li><a href="http://www.tecnospeed.com.br/ebook-nfc-e">eBook NFC-e</a></li>
                                    <li><a href="http://www.tecnospeed.com.br/ebook-nfs-e">eBook NFS-e</a></li>
                                    <li><a href="http://www.tecnospeed.com.br/rota-mdf-e">eBook MDF-e</a></li>
                                    <li><a href="http://www.tecnospeed.com.br/tecnoupdate/revista">Revista
                                            TecnoUpdate</a></li>
                                </ul>
                            </li>
                            <li class="drop"><a class="scroll">TSDN</a>
                                <ul class="drop-down left">
                                    <li><a href="http://www.tecnospeed.com.br/blog" target="_blank">Tecnospeed</a></li>
                                    <li><a href="http://ciranda.me/tsdn/blog/cfop" target="_blank">CFOP</a></li>
                                    <li><a href="http://ciranda.me/tsdn/blog/blog-do-desenvolvimento-tecnospeed"
                                           target="_blank">Desenvolvimento</a></li>
                                    <li><a href="http://ciranda.me/tsdn/blog/base-de-conhecimento" target="_blank">Conhecimento</a>
                                    </li>
                                    <li><a href="http://ciranda.me/tsdn/blog/blog-da-consultoria-tecnica-tecnospeed"
                                           target="_blank">Consultoria</a></li>
                                    <li><a href="http://ciranda.me/tsdn/blog/molhoespecial" target="_blank">Molho
                                            Especial</a></li>
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
<div class="container" style="min-height: 785px;">
    <div class="col-xs-6 col-xs-offset-3">
        <div id="teste-online-boleto-d4cf5ae130b7b4867960"></div>
<script type="text/javascript" src="https://d335luupugsy2.cloudfront.net/js/rdstation-forms/stable/rdstation-forms.min.js"></script>
<script type="text/javascript">
 new RDStationForms('teste-online-boleto-d4cf5ae130b7b4867960-html', 'UA-54505819-1').createForm();
</script>
    </div>
</div>
<footer>
    <nav class="navbar navbar-default navbar-fixed-bottom">
        <div class="text-center">
            <h5>Todos os direitos reservados. <a href="http://tecnospeed.com.br/" target="_blank">Tecnospeed</a>
                © <?= date("Y") ?>.</h5>
    </nav>
</footer>
</body>
</html>
