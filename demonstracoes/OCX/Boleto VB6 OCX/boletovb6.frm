VERSION 5.00
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Begin VB.Form Form1 
   Caption         =   "-"
   ClientHeight    =   10905
   ClientLeft      =   3195
   ClientTop       =   690
   ClientWidth     =   15000
   LinkTopic       =   "Form1"
   ScaleHeight     =   10905
   ScaleWidth      =   15000
   Begin VB.Frame Frame7 
      Caption         =   " Configurações"
      Height          =   2655
      Left            =   120
      TabIndex        =   42
      Top             =   960
      Width           =   4575
      Begin VB.CommandButton btnCarregarConfig 
         Caption         =   "Carregar Configurações"
         Height          =   375
         Left            =   2400
         TabIndex        =   49
         Top             =   2040
         Width           =   2055
      End
      Begin VB.TextBox txtTokenSoftwareHouse 
         Height          =   375
         Left            =   2400
         TabIndex        =   48
         Text            =   "f22b97c0c9a3d41ac0a3875aba69e5aa"
         Top             =   1320
         Width           =   2055
      End
      Begin VB.TextBox txtCnpjCedente 
         Height          =   405
         Left            =   120
         TabIndex        =   47
         Text            =   "01001001000113"
         Top             =   2040
         Width           =   2175
      End
      Begin VB.TextBox txtCNPJSoftwareHouse 
         Height          =   375
         Left            =   120
         TabIndex        =   46
         Text            =   "01001001000113"
         Top             =   1320
         Width           =   2055
      End
      Begin VB.Frame Frame6 
         Caption         =   "Ambiente"
         Height          =   735
         Index           =   1
         Left            =   120
         TabIndex        =   43
         Top             =   240
         Width           =   4335
         Begin VB.OptionButton opProducao 
            Caption         =   "Produção"
            Height          =   375
            Left            =   120
            TabIndex        =   45
            Top             =   240
            Width           =   1695
         End
         Begin VB.OptionButton opHomologacao 
            Caption         =   "Homologação"
            Height          =   375
            Left            =   1920
            TabIndex        =   44
            Top             =   240
            Width           =   1695
         End
      End
      Begin VB.Label Label1 
         Caption         =   "CNPJ da Software House"
         Height          =   255
         Left            =   120
         TabIndex        =   52
         Top             =   1080
         Width           =   1935
      End
      Begin VB.Label Label2 
         Caption         =   "CNPJ do Cedente"
         Height          =   255
         Left            =   120
         TabIndex        =   51
         Top             =   1800
         Width           =   1935
      End
      Begin VB.Label Label3 
         Caption         =   "Token da Software House"
         Height          =   255
         Left            =   2400
         TabIndex        =   50
         Top             =   1080
         Width           =   2055
      End
   End
   Begin VB.Frame Frame2 
      Caption         =   "E-mail"
      Height          =   2295
      Left            =   4920
      TabIndex        =   36
      Top             =   4080
      Width           =   5055
      Begin VB.TextBox edtProtocoloEmailLote 
         Height          =   375
         Left            =   2640
         TabIndex        =   41
         Text            =   "Protocolo E-mail"
         Top             =   600
         Width           =   2175
      End
      Begin VB.CommandButton btnConsultaEmailLote 
         Caption         =   "Consultar E-mail em Lote"
         Height          =   375
         Left            =   120
         TabIndex        =   38
         Top             =   1560
         Width           =   2175
      End
      Begin VB.CommandButton btnEnviarEmailLote 
         Caption         =   "E-Mail Lote"
         Height          =   375
         Left            =   120
         TabIndex        =   37
         Top             =   600
         Width           =   2175
      End
   End
   Begin VB.CommandButton btnCadastrarConvenio 
      Caption         =   "Cadastrar Convênio"
      Height          =   495
      Left            =   3240
      TabIndex        =   34
      Top             =   360
      Width           =   1455
   End
   Begin VB.CommandButton btnCadastrarConta 
      Caption         =   "Cadastrar Conta"
      Height          =   495
      Left            =   1680
      TabIndex        =   33
      Top             =   360
      Width           =   1455
   End
   Begin VB.CommandButton btnCadastrarCedente 
      Caption         =   "Cadastrar Cedente"
      Height          =   495
      Left            =   120
      TabIndex        =   32
      Top             =   360
      Width           =   1455
   End
   Begin MSComDlg.CommonDialog cmdAbrirArqRet 
      Left            =   13680
      Top             =   6720
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
   Begin VB.TextBox txtRetorno 
      Height          =   4095
      Left            =   7560
      MultiLine       =   -1  'True
      ScrollBars      =   2  'Vertical
      TabIndex        =   28
      Top             =   6600
      Width           =   7215
   End
   Begin VB.TextBox txtTx2 
      Height          =   4095
      Left            =   120
      MultiLine       =   -1  'True
      ScrollBars      =   2  'Vertical
      TabIndex        =   27
      Top             =   6600
      Width           =   7215
   End
   Begin VB.Frame Frame5 
      Caption         =   "Alteração de Remessa e Baixa"
      Height          =   3615
      Left            =   10080
      TabIndex        =   20
      Top             =   2760
      Width           =   4695
      Begin VB.ComboBox cbbGerarRemessaAlteracao 
         Height          =   315
         ItemData        =   "boletovb6.frx":0000
         Left            =   120
         List            =   "boletovb6.frx":000A
         TabIndex        =   31
         Top             =   480
         Width           =   2055
      End
      Begin VB.CommandButton cmdConsultarRemessaBaixada 
         Caption         =   "Consultar Remessa Baixa"
         Height          =   495
         Left            =   2400
         TabIndex        =   26
         Top             =   2880
         Width           =   2055
      End
      Begin VB.CommandButton cmdConsultarProtocoloRemessaAlteracao 
         Caption         =   "Consultar Remessa Alteração"
         Height          =   495
         Left            =   120
         TabIndex        =   25
         Top             =   2880
         Width           =   2055
      End
      Begin VB.TextBox txtProtocoloRemessaBaixada 
         Height          =   405
         Left            =   2400
         TabIndex        =   24
         Text            =   "Protocolo de Baixa"
         Top             =   1920
         Width           =   2055
      End
      Begin VB.TextBox txtProtocoloRetornoRemessaAlteracao 
         Height          =   405
         Left            =   120
         TabIndex        =   23
         Text            =   "Protocolo de Alteração"
         Top             =   1920
         Width           =   2055
      End
      Begin VB.CommandButton cmdGerarBaixa 
         Caption         =   "Gerar Baixa"
         Height          =   375
         Left            =   2400
         TabIndex        =   22
         Top             =   1320
         Width           =   2055
      End
      Begin VB.CommandButton cmdGerarRemessaAlteracao 
         Caption         =   "Gerar Remessa Alteração"
         Height          =   375
         Left            =   120
         TabIndex        =   21
         Top             =   1320
         Width           =   2055
      End
      Begin VB.Line Line1 
         X1              =   2280
         X2              =   2280
         Y1              =   480
         Y2              =   3360
      End
   End
   Begin VB.Frame Frame4 
      Caption         =   "Remessa e Retorno"
      Height          =   2175
      Left            =   10080
      TabIndex        =   14
      Top             =   240
      Width           =   4815
      Begin VB.TextBox txtProtocolo 
         Height          =   375
         Left            =   120
         TabIndex        =   19
         Text            =   "Protocolo de Upload"
         Top             =   1320
         Width           =   2055
      End
      Begin VB.CommandButton cmdConsultarRetornoProcessamento 
         Caption         =   "Consultar Retorno Processamento"
         Height          =   615
         Left            =   2520
         TabIndex        =   18
         Top             =   1080
         Width           =   2055
      End
      Begin VB.CommandButton cmdUploadRet 
         Caption         =   "Upload Retorno"
         Height          =   375
         Left            =   2520
         TabIndex        =   16
         Top             =   360
         Width           =   2055
      End
      Begin VB.CommandButton cmdGerarRemessa 
         Caption         =   "Gerar Remessa"
         Height          =   375
         Left            =   120
         TabIndex        =   15
         Top             =   360
         Width           =   2055
      End
      Begin VB.Label Label9 
         Caption         =   "Protocolo Upload Retorno"
         Height          =   255
         Left            =   120
         TabIndex        =   17
         Top             =   960
         Width           =   2295
      End
   End
   Begin VB.Frame Frame3 
      Caption         =   "Impressão "
      Height          =   3615
      Left            =   4920
      TabIndex        =   6
      Top             =   240
      Width           =   5055
      Begin VB.ComboBox cbbImpressora 
         Height          =   315
         Left            =   120
         TabIndex        =   40
         Top             =   480
         Width           =   4815
      End
      Begin VB.TextBox txtProtocoloRetornoImpressaoLote 
         Height          =   375
         Left            =   120
         TabIndex        =   12
         Text            =   "Protocolo de Impressão"
         Top             =   2040
         Width           =   2295
      End
      Begin VB.ComboBox cbbTipoImpressao 
         Height          =   315
         ItemData        =   "boletovb6.frx":0043
         Left            =   120
         List            =   "boletovb6.frx":0056
         TabIndex        =   10
         Top             =   1320
         Width           =   2295
      End
      Begin VB.CommandButton cmdImprimirLote 
         Caption         =   "Imprimir  Lote"
         Height          =   375
         Left            =   120
         TabIndex        =   9
         Top             =   3000
         Width           =   2295
      End
      Begin VB.CommandButton cmdSalvarPDFLote 
         Caption         =   "Salvar PDF Lote"
         Height          =   375
         Left            =   2640
         TabIndex        =   8
         Top             =   3000
         Width           =   2295
      End
      Begin VB.CommandButton cmdSolicitarImpressaoLote 
         Caption         =   "Solicitar Impressão em Lote"
         Height          =   375
         Left            =   2640
         TabIndex        =   7
         Top             =   1320
         Width           =   2295
      End
      Begin VB.Label Label5 
         Caption         =   "Impressora:"
         Height          =   255
         Left            =   120
         TabIndex        =   39
         Top             =   240
         Width           =   975
      End
      Begin VB.Label Label8 
         Caption         =   "Protocolo de Impressão"
         Height          =   255
         Left            =   120
         TabIndex        =   13
         Top             =   1800
         Width           =   2175
      End
      Begin VB.Label Label7 
         Caption         =   "Tipo de Impressão"
         Height          =   255
         Left            =   120
         TabIndex        =   11
         Top             =   1080
         Width           =   1455
      End
   End
   Begin VB.Frame Frame1 
      Caption         =   "Incluir e Consultar Boletos"
      Height          =   1575
      Left            =   120
      TabIndex        =   2
      Top             =   3840
      Width           =   4575
      Begin VB.CommandButton cmdConsultarBoleto 
         Caption         =   "Consultar Boleto"
         Height          =   375
         Left            =   2400
         TabIndex        =   5
         Top             =   360
         Width           =   2055
      End
      Begin VB.CommandButton cmdDescartarBoletos 
         Caption         =   "Descartar Boletos"
         Height          =   375
         Left            =   120
         TabIndex        =   4
         Top             =   960
         Width           =   2175
      End
      Begin VB.CommandButton cmdIncluir 
         BackColor       =   &H8000000C&
         Caption         =   "Incluir Boleto"
         Height          =   375
         Left            =   120
         MaskColor       =   &H00FFFFFF&
         TabIndex        =   3
         Top             =   360
         Width           =   2175
      End
   End
   Begin VB.TextBox txtIdIntegracao 
      Height          =   375
      Left            =   120
      TabIndex        =   0
      Text            =   "BJHumqz7G"
      Top             =   5880
      Width           =   4575
   End
   Begin VB.Label Label12 
      Caption         =   "Cadastro de Cedentes:"
      Height          =   255
      Left            =   120
      TabIndex        =   35
      Top             =   120
      Width           =   1935
   End
   Begin VB.Label Label11 
      Caption         =   "Retorno"
      Height          =   255
      Left            =   7560
      TabIndex        =   30
      Top             =   6360
      Width           =   615
   End
   Begin VB.Label Label10 
      Caption         =   "Arquivo de Entrada"
      Height          =   255
      Left            =   120
      TabIndex        =   29
      Top             =   6360
      Width           =   1455
   End
   Begin VB.Label Label4 
      Caption         =   "IdIntegracao"
      Height          =   255
      Left            =   120
      TabIndex        =   1
      Top             =   5640
      Width           =   1935
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public FBoletoX As spdBoletoX

Private Function ReadUTF8File(sFile) As String
    Const ForReading = 1
    Dim sPrefix

    With CreateObject("Scripting.FileSystemObject")
        sPrefix = .OpenTextFile(sFile, ForReading, False, False).Read(3)
    End With
    If Left(sPrefix, 3) <> Chr(&HEF) & Chr(&HBB) & Chr(&HBF) Then
        With CreateObject("Scripting.FileSystemObject")
            pvReadFile = .OpenTextFile(sFile, ForReading, False, Left(sPrefix, 2) = Chr(&HFF) & Chr(&HFE)).ReadAll()
            ReadUTF8File = pvReadFile
        End With
    Else
        With CreateObject("ADODB.Stream")
            .Open
            If Left(sPrefix, 2) = Chr(&HFF) & Chr(&HFE) Then
                .Charset = "Unicode"
            ElseIf Left(sPrefix, 3) = Chr(&HEF) & Chr(&HBB) & Chr(&HBF) Then
                .Charset = "UTF-8"
            Else
                .Charset = "_autodetect"
            End If
            .LoadFromFile sFile
            pvReadFile = .ReadText
            ReadUTF8File = pvReadFile
        End With
    End If
End Function

Private Sub btnCadastrarCedente_Click()
Dim CadastrarList As BoletoX.spdRetCadastrarCedente

 Set CadastrarList = FBoletoX.CadastrarCedente(txtTx2.Text)
 
 txtRetorno.Text = ".:: CADASTRAR CEDENTE ::."
 txtRetorno.Text = txtRetorno.Text & vbNewLine & "Mensagem : " & CadastrarList.Mensagem
 txtRetorno.Text = txtRetorno.Text & vbNewLine & "Status : " & CadastrarList.Status
 txtRetorno.Text = txtRetorno.Text & vbNewLine & "Erro de Conexão: " & CadastrarList.ErroConexao
 txtRetorno.Text = txtRetorno.Text & vbNewLine
  
  
  If (CadastrarList.Status = "SUCESSO") Then
    
  
    txtRetorno.Text = txtRetorno.Text & "CedenteRazaoSocial : " & CadastrarList.RazaoSocial & vbNewLine
    txtRetorno.Text = txtRetorno.Text & "CedenteNomeFantasia : " & CadastrarList.NomeFantasia & vbNewLine
    txtRetorno.Text = txtRetorno.Text & "Situacao : " & CadastrarList.Situacao & vbNewLine
    txtRetorno.Text = txtRetorno.Text & "Token : " & CadastrarList.Token & vbNewLine
    txtRetorno.Text = txtRetorno.Text & "IdCedente : " & CadastrarList.IdCedente & vbNewLine
    
    End If
End Sub

Private Sub btnCadastrarConta_Click()
Dim CadastrarContaList As BoletoX.spdRetCadastrarConta

    Set CadastrarContaList = FBoletoX.CadastrarConta(txtTx2.Text)
 
 txtRetorno.Text = ".:: CADASTRAR CONTA ::."
 txtRetorno.Text = txtRetorno.Text & vbNewLine & "Mensagem : " & CadastrarContaList.Mensagem
 txtRetorno.Text = txtRetorno.Text & vbNewLine & "Status : " & CadastrarContaList.Status
 txtRetorno.Text = txtRetorno.Text & vbNewLine & "Erro de Conexão: " & CadastrarContaList.ErroConexao
 txtRetorno.Text = txtRetorno.Text & vbNewLine
  
  
  If (CadastrarContaList.Status = "SUCESSO") Then
    
  
    txtRetorno.Text = txtRetorno.Text & "Id Conta: " & CadastrarContaList.IdConta & vbNewLine
    txtRetorno.Text = txtRetorno.Text & "Código Banco: " & CadastrarContaList.CodigoBanco & vbNewLine
    txtRetorno.Text = txtRetorno.Text & "Agência: " & CadastrarContaList.Agencia & vbNewLine
    txtRetorno.Text = txtRetorno.Text & "AgênciaDV: " & CadastrarContaList.AgenciaDV & vbNewLine
    txtRetorno.Text = txtRetorno.Text & "Conta: " & CadastrarContaList.Conta & vbNewLine
    txtRetorno.Text = txtRetorno.Text & "Conta DV: " & CadastrarContaList.ContaDV & vbNewLine
    txtRetorno.Text = txtRetorno.Text & "Tipo Conta: " & CadastrarContaList.TipoConta & vbNewLine
    txtRetorno.Text = txtRetorno.Text & "Código Beneficiário: " & CadastrarContaList.CodigoBeneficiario & vbNewLine
    txtRetorno.Text = txtRetorno.Text & "Código Empresa: " & CadastrarContaList.CodigoEmpresa & vbNewLine
    
    End If
End Sub

Private Sub btnCadastrarConvenio_Click()
Dim CadastrarConvenioList As BoletoX.spdRetCadastrarConvenio

    Set CadastrarConvenioList = FBoletoX.CadastrarConvenio(txtTx2.Text)
 
 txtRetorno.Text = ".:: CADASTRAR CONVENIO ::."
 txtRetorno.Text = txtRetorno.Text & vbNewLine & "Mensagem : " & CadastrarConvenioList.Mensagem
 txtRetorno.Text = txtRetorno.Text & vbNewLine & "Status : " & CadastrarConvenioList.Status
 txtRetorno.Text = txtRetorno.Text & vbNewLine & "Erro de Conexão: " & CadastrarConvenioList.ErroConexao
 txtRetorno.Text = txtRetorno.Text & vbNewLine
  
  
  If (CadastrarConvenioList.Status = "SUCESSO") Then
    
  
    txtRetorno.Text = txtRetorno.Text & "Id Convênio: " & CadastrarConvenioList.IdConvenio & vbNewLine
    txtRetorno.Text = txtRetorno.Text & "Número Convênio: " & CadastrarConvenioList.NumeroConvenio & vbNewLine
    txtRetorno.Text = txtRetorno.Text & "Descrição: " & CadastrarConvenioList.DescricaoConvenio & vbNewLine
    txtRetorno.Text = txtRetorno.Text & "Carteira: " & CadastrarConvenioList.Carteira & vbNewLine
    txtRetorno.Text = txtRetorno.Text & "Espécie: " & CadastrarConvenioList.Especie & vbNewLine
    txtRetorno.Text = txtRetorno.Text & "Padrão CNAB: " & CadastrarConvenioList.PadraoCNAB & vbNewLine
    txtRetorno.Text = txtRetorno.Text & "Utiliza VAN: " & CadastrarConvenioList.UtilizaVan & vbNewLine
    txtRetorno.Text = txtRetorno.Text & "Número Remessa: " & CadastrarConvenioList.NumeroRemessa & vbNewLine
    txtRetorno.Text = txtRetorno.Text & "Reiniciar Número Remessa: " & CadastrarConvenioList.ReiniciarDiariamente & vbNewLine
    
    End If
End Sub

Private Sub btnConsultaEmailLote_Click()
Dim RespostaEmailLote As spdRetConsultarEmailLote

Set RespostaEmailLote = FBoletoX.ConsultarEmailLote(edtProtocoloEmailLote.Text)

txtRetorno.Text = txtRetorno.Text & vbNewLine
txtRetorno.Text = ".:: Consulta de E-mails em Lote ::."
txtRetorno.Text = txtRetorno.Text & vbNewLine & " Mensagem : " & RespostaEmailLote.Mensagem
txtRetorno.Text = txtRetorno.Text & vbNewLine & " Status : " & RespostaEmailLote.Status
txtRetorno.Text = txtRetorno.Text & vbNewLine & " Situação : " & RespostaEmailLote.Situacao

If (RespostaEmailLote.ErroConexao <> "") Then
    txtRetorno.Text = txtRetorno.Text & "Erro Conexão: " + RespostaEmailLote.ErroConexao
    
End If

End Sub

Private Sub btnEnviarEmailLote_Click()
Dim EnviarLoteResposta As spdRetEnvioEmailLote

txtRetorno.Text = ""

Set EnviarLoteResposta = FBoletoX.EnviarEmailLote(txtTx2.Text)

txtRetorno.Text = ".:: Enviar E-mail Lote ::."
txtRetorno.Text = txtRetorno.Text & vbNewLine & " Mensagem : " & EnviarLoteResposta.Mensagem
txtRetorno.Text = txtRetorno.Text & vbNewLine & " Status : " & EnviarLoteResposta.Status
txtRetorno.Text = txtRetorno.Text & vbNewLine & "Protocolo : " & EnviarLoteResposta.Protocolo

edtProtocoloEmailLote.Text = EnviarLoteResposta.Protocolo

If (EnviarLoteResposta.Status = "ERRO") Then
    txtRetorno.Text = txtRetorno.Text & "ErroClasse: " & EnviarLoteResposta.ErroClasse
End If

If (EnviarLoteResposta.ErroConexao <> "") Then
    txtRetorno.Text = txtRetorno.Text & "Erro Classe: " + EnviarLoteResposta.ErroClasse

End If

txtRetorno.Text = txtRetorno.Text & vbNewLine



 

End Sub

Private Sub cmdConsultarBoleto_Click()
Dim ConsultarList As BoletoX.spdRetConsultarLista
Dim ConsultarItem As BoletoX.spdRetConsultarTituloItem

 Set ConsultarList = FBoletoX.Consultar(txtIdIntegracao.Text)

  txtRetorno.Text = ".:: Consultar Título ::."
  txtRetorno.Text = txtRetorno.Text & vbNewLine & "Mensagem : " & ConsultarList.Mensagem
  txtRetorno.Text = txtRetorno.Text & vbNewLine & "Status : " & ConsultarList.Status
  txtRetorno.Text = txtRetorno.Text & vbNewLine
  

  Do While ConsultarList.Count <> 0
  
     For i = 0 To ConsultarList.Count - 1
        Set ConsultarItem = ConsultarList.Item(i)
        txtRetorno.Text = txtRetorno.Text & "ITEM: " & Str((i + 1)) & vbNewLine
        txtRetorno.Text = txtRetorno.Text & "IdIntegracao: " & ConsultarItem.IdIntegracao & vbNewLine
        txtRetorno.Text = txtRetorno.Text & "Situacao: " + ConsultarItem.Situacao & vbNewLine
        txtRetorno.Text = txtRetorno.Text & "Motivo: " + ConsultarItem.Motivo & vbNewLine
        txtRetorno.Text = txtRetorno.Text & vbNewLine

        txtRetorno.Text = txtRetorno.Text & "CEDENTE:" & vbNewLine
        txtRetorno.Text = txtRetorno.Text & "Agencia: " + ConsultarItem.CedenteAgencia & vbNewLine
        txtRetorno.Text = txtRetorno.Text & "AgenciaDV: " + ConsultarItem.CedenteAgenciaDV & vbNewLine
        txtRetorno.Text = txtRetorno.Text & "Código Banco: " + ConsultarItem.CedenteCodigoBanco & vbNewLine
        txtRetorno.Text = txtRetorno.Text & "Carteira: " + ConsultarItem.CedenteCarteira & vbNewLine
        txtRetorno.Text = txtRetorno.Text & "Conta: " + ConsultarItem.CedenteCarteira & vbNewLine
        txtRetorno.Text = txtRetorno.Text & "Numero Convênio: " + ConsultarItem.CedenteNumeroConvenio & vbNewLine
        txtRetorno.Text = txtRetorno.Text & vbNewLine

        txtRetorno.Text = txtRetorno.Text & "SACADO:" & vbNewLine
        txtRetorno.Text = txtRetorno.Text & "CPFCNPJ: " + ConsultarItem.SacadoCPFCNPJ & vbNewLine
        txtRetorno.Text = txtRetorno.Text & "Nome: " + ConsultarItem.SacadoNome & vbNewLine
        txtRetorno.Text = txtRetorno.Text & "Telefone: " + ConsultarItem.SacadoTelefone & vbNewLine
        txtRetorno.Text = txtRetorno.Text & "Email: " + ConsultarItem.SacadoEmail & vbNewLine
        txtRetorno.Text = txtRetorno.Text & "Endereço Número: " + ConsultarItem.SacadoEnderecoNumero & vbNewLine
        txtRetorno.Text = txtRetorno.Text & "Endereço Bairro: " + ConsultarItem.SacadoEnderecoBairro & vbNewLine
        txtRetorno.Text = txtRetorno.Text & "Endereço CEP: " + ConsultarItem.SacadoEnderecoCEP & vbNewLine
        txtRetorno.Text = txtRetorno.Text & "Endereço Cidade: " + ConsultarItem.SacadoEnderecoCidade & vbNewLine
        txtRetorno.Text = txtRetorno.Text & "Endereço Complemento: " + ConsultarItem.SacadoEnderecoComplemento & vbNewLine
        txtRetorno.Text = txtRetorno.Text & "Endereço Logradouro: " + ConsultarItem.SacadoEnderecoLogradouro & vbNewLine
        txtRetorno.Text = txtRetorno.Text & "Endereço País: " + ConsultarItem.SacadoEnderecoPais & vbNewLine
        txtRetorno.Text = txtRetorno.Text & "Endereço UF: " + ConsultarItem.SacadoEnderecoUF & vbNewLine
        txtRetorno.Text = txtRetorno.Text & vbNewLine

        txtRetorno.Text = txtRetorno.Text & "TÍTULO:" & vbNewLine
        txtRetorno.Text = txtRetorno.Text & "Número Documento: " + ConsultarItem.TituloNumeroDocumento & vbNewLine
        txtRetorno.Text = txtRetorno.Text & "Origem Documento: " + ConsultarItem.TituloOrigemDocumento & vbNewLine
        txtRetorno.Text = txtRetorno.Text & "Nosso Número: " + ConsultarItem.TituloNossoNumero & vbNewLine
        txtRetorno.Text = txtRetorno.Text & "Data Emissão: " + ConsultarItem.TituloDataEmissao & vbNewLine
        txtRetorno.Text = txtRetorno.Text & "Data Vencimento: " + ConsultarItem.TituloDataVencimento & vbNewLine
        txtRetorno.Text = txtRetorno.Text & "Data Desconto: " + CStr(ConsultarItem.TituloDataDesconto) & vbNewLine
        txtRetorno.Text = txtRetorno.Text & "Valor Desconto: " + CStr(ConsultarItem.TituloValorDesconto) & vbNewLine
        txtRetorno.Text = txtRetorno.Text & "Valor Juros: " + CStr(ConsultarItem.TituloValorJuros) & vbNewLine
        txtRetorno.Text = txtRetorno.Text & "Prazo Protesto: " + ConsultarItem.TituloPrazoProtesto & vbNewLine
        txtRetorno.Text = txtRetorno.Text & "Mensagem 1: " + ConsultarItem.TituloMensagem01 & vbNewLine
        txtRetorno.Text = txtRetorno.Text & "Mensagem 2: " + ConsultarItem.TituloMensagem02 & vbNewLine
        txtRetorno.Text = txtRetorno.Text & "Mensagem 3: " + ConsultarItem.TituloMensagem03 & vbNewLine
        txtRetorno.Text = txtRetorno.Text & "Valor: " + CStr(ConsultarItem.TituloValor) & vbNewLine
        txtRetorno.Text = txtRetorno.Text & "Data Crédito: " + ConsultarItem.PagamentoDataCredito & vbNewLine
        txtRetorno.Text = txtRetorno.Text & "Título Pago: " + CStr(ConsultarItem.PagamentoRealizado) & vbNewLine
        txtRetorno.Text = txtRetorno.Text & "Valor Crédito: " + CStr(ConsultarItem.PagamentoValorCredito) & vbNewLine
        txtRetorno.Text = txtRetorno.Text & "Valor Outros Acréscimos: " + CStr(ConsultarItem.TituloValorOutrosAcrescimos) & vbNewLine
        txtRetorno.Text = txtRetorno.Text & "Valor Pago: " + CStr(ConsultarItem.PagamentoValorPago) & vbNewLine
        txtRetorno.Text = txtRetorno.Text & "Valor Taxa Cobrança: " + CStr(ConsultarItem.PagamentoValorTaxaCobranca) & vbNewLine
        txtRetorno.Text = txtRetorno.Text & "Valor Abatimento: " + CStr(ConsultarItem.TituloValorAbatimento) & vbNewLine
        txtRetorno.Text = txtRetorno.Text & "Valor Outras Despesas: " + CStr(ConsultarItem.PagamentoValorOutrasDespesas) & vbNewLine
        txtRetorno.Text = txtRetorno.Text & "Valor IOF: " + CStr(ConsultarItem.PagamentoValorIOF) & vbNewLine
        txtRetorno.Text = txtRetorno.Text & "Data Pagamento: " + ConsultarItem.PagamentoData & vbNewLine
        txtRetorno.Text = txtRetorno.Text & "Valor Outros Créditos: " + CStr(ConsultarItem.PagamentoValorOutrosCreditos) & vbNewLine
        txtRetorno.Text = txtRetorno.Text & "Pagamento Valor Desconto: " + CStr(ConsultarItem.PagamentoValorDesconto) & vbNewLine
        txtRetorno.Text = txtRetorno.Text & "Pagamento Valor Acréscimos: " + CStr(ConsultarItem.PagamentoValorAcrescimos) & vbNewLine
        txtRetorno.Text = txtRetorno.Text & "Pagamento Valor Abatimento: " + CStr(ConsultarItem.PagamentoValorAbatimento) & vbNewLine
        txtRetorno.Text = txtRetorno.Text & "Impressão Visualizada: " + CStr(ConsultarItem.ImpressaoVisualizada) & vbNewLine

        txtRetorno.Text = txtRetorno.Text & "OCORRÊNCIAS:" & vbNewLine
        txtRetorno.Text = txtRetorno.Text & vbNewLine
        
        txtRetorno.Text = txtRetorno.Text & vbNewLine
        
        If ConsultarItem.TituloOcorrencias.Count > 0 Then
            txtRetorno.Text = txtRetorno.Text & "OCORRÊNCIAS:" & vbNewLines
            
            For j = 0 To ConsultarItem.TituloOcorrencias.Count - 1
                txtRetorno.Text = txtRetorno.Text & "  Código: " & ConsultarItem.TituloOcorrencias.Item(j).Codigo 'Código da ocorrência
                txtRetorno.Text = txtRetorno.Text & " - " & ConsultarItem.TituloOcorrencias.Item(j).Mensagem & vbNewLine  'Mensagem de ocorrência
            Next j
        
            txtRetorno.Text = txtRetorno.Text & vbNewLine
    
        End If
        
      Next i
        
      ConsultarList.PaginaSeguinte

  Loop
End Sub
Private Sub cbbConsultarProtocoloRemessaAlteracao_Click()
Dim RetornoConsultarAlteracao As BoletoX.spdRetConsultarRemessaAlteracaoLista
Dim RetornoConsultarAlteracaoItem As BoletoX.spdRetConsultarRemessaAlteracaoItem

Set RetornoConsultarAlteracao = FBoletoX.ConsultarRemessaAlteracao(cmdConsultarProtocoloRemessaAlteracao)

txtRetorno.Text = ".:: CONSULTA ALTERAÇÃO ::."

txtRetorno.Text = txtRetorno.Text & vbNewLine & "Mensagem: " + RetornoConsultarAlteracao.Mensagem
txtRetorno.Text = txtRetorno.Text & vbNewLine & "Status: " + RetornoConsultarAlteracao.Status
txtRetorno.Text = txtRetorno.Text & vbNewLine & "Situaçao: " + RetornoConsultarAlteracao.Situacao

If RetornoConsultarAlteracao.ErroConexao <> "" Then
    txtRetorno.Text = txtRetorno.Text("Erro Conexão: " + RetornoConsultarAlteracao.ErroConexao)
If StrComp(RetornoConsultarAlteracao.Status, "ERRO") Then
    txtRetorno.Text ("ErroClasse: " + RetornoConsultarAlteracao.ErroClasse)
    
End If

txtRetorno.Text = ""

For i = 0 To RetornoConsultarAlteracao.Count - 1
Set RetornoConsultarAlteracaoItem = RetornoConsultarAlteracao.Item(i)
    txtRetorno.Text = txtRetorno.Text & " ITEM : " & CStr(i + 1) & vbNewLine
    txtRetorno.Text = txtRetorno.Text & " Remessa : " & RetornoConsultarAlteracaoItem.Remessa & vbNewLine
    txtRetorno.Text = txtRetorno.Text & " Banco : " & RetornoConsultarAlteracaoItem.Banco & vbNewLine
    txtRetorno.Text = txtRetorno.Text & " Conta : " & RetornoConsultarAlteracaoItem.Conta & vbNewLine
    txtRetorno.Text = txtRetorno.Text & " Convênio : " & RetornoConsultarAlteracaoItem.Convenio & vbNewLine
    txtRetorno.Text = txtRetorno.Text & " Erro : " & RetornoConsultarAlteracaoItem.Erro & vbNewLine
    txtRetorno.Text = txtRetorno.Text & " ErroClasse : " & RetornoConsultarAlteracaoItem.ErroClasse & vbNewLine
Next i

For j = o To RetornoConsultarAlteracaoItem.Titulos.Count - 1
    txtRetorno.Text = txtRetorno.Text & " IdIntegracao " + CStr(j + 1) + ":" + RetornoConsultarAlteracaoItem.Titulos.Item(j)

Next j

txtRetorno.Text = ""




txtRetorno.txt = ""

    
    






End Sub

Private Sub cmdConsultarProtocoloRemessaAlteracao_Click()
Dim RetornoConsultarAlteracao As spdRetConsultarRemessaAlteracaoLista

Set RetornoConsultarAlteracao = FBoletoX.ConsultarRemessaAlteracao(txtProtocoloRetornoRemessaAlteracao.Text)

txtRetorno.Text = ""
txtRetorno.Text = " .:: CONSULTA ALTERAÇÃO .:: "
txtRetorno.Text = txtRetorno.Text & vbNewLine & " Mensagem : " & RetornoConsultarAlteracao.Mensagem
txtRetorno.Text = txtRetorno.Text & vbNewLine & " Status : " & RetornoConsultarAlteracao.Status
txtRetorno.Text = txtRetorno.Text & vbNewLine & " Situação : " & RetornoConsultarAlteracao.Situacao

If (RetornoConsultarAlteracao.ErroConexao <> "") Then
    txtRetorno.Text = txtRetorno.Text & "ErroConexão: " & RetornoConsultarAlteracao.ErroConexao
End If

    
If StrComp(RetornoConsultarAlteracao.Status, "ERRO") Then
    txtRetorno.Text = txtRetorno.Text & " ErroClasse: " & RetornoConsultarAlteracao.ErroClasse
End If
    
txtRetorno.Text = ""

For i = 0 To RetornoConsultarAlteracao.Count - 1

    txtRetorno.Text = txtRetorno.Text & " ITEM : " & CStr(i + 1) & vbNewLine
    txtRetorno.Text = txtRetorno.Text & " Remessa : " & RetornoConsultarAlteracao.Item(i).Remessa & vbNewLine
    txtRetorno.Text = txtRetorno.Text & " Banco : " & RetornoConsultarAlteracao.Item(i).Banco & vbNewLine
    txtRetorno.Text = txtRetorno.Text & " Convenio : " & RetornoConsultarAlteracao.Item(i).Convenio & vbNewLine
    txtRetorno.Text = txtRetorno.Text & " Erro : " & RetornoConsultarAlteracao.Item(i).Erro & vbNewLine
    txtRetorno.Text = txtRetorno.Text & " ErroClasse : " & RetornoConsultarAlteracao.Item(i).ErroClasse & vbNewLine


    For j = 0 To RetornoConsultarAlteracao.Item(i).Titulos.Count - 1
        txtRetorno.Text = txtRetorno.Text & " IdIntegracao " & CStr(j + 1) & ":" & RetornoConsultarAlteracao.Item(i).Titulos.Item(j) & vbNewLine

    Next j
    
    txtRetorno.Text = txtRetorno.Text & vbNewLine
    
Next i

End Sub

Private Sub cmdConsultarRemessaBaixada_Click()
Dim retornoConsultarBaixa As spdRetConsultarRemessaBaixaLista

Set retornoConsultarBaixa = FBoletoX.ConsultarRemessaBaixa(txtProtocoloRemessaBaixada.Text)

txtRetorno.Text = ""
txtRetorno.Text = " .:: CONSULTA BAIXA .:: " & vbNewLine
txtRetorno.Text = txtRetorno.Text & vbNewLine & " Mensagem : " & retornoConsultarBaixa.Mensagem & vbNewLine
txtRetorno.Text = txtRetorno.Text & vbNewLine & " Status : " & retornoConsultarBaixa.Status & vbNewLine
txtRetorno.Text = txtRetorno.Text & vbNewLine & " Situação : " & retornoConsultarBaixa.Situacao & vbNewLine

If (retornoConsultarBaixa.ErroConexao <> "") Then
    txtRetorno.Text = txtRetorno.Text & "ErroConexão: " & retornoConsultarBaixa.ErroConexao & vbNewLine
End If

    
If StrComp(retornoConsultarBaixa.Status, "ERRO") Then
    txtRetorno.Text = txtRetorno.Text & " ErroClasse: " & retornoConsultarBaixa.ErroClasse & vbNewLine
End If
    
txtRetorno.Text = ""

For i = 0 To retornoConsultarBaixa.Count - 1

    txtRetorno.Text = txtRetorno.Text & " ITEM : " & CStr(i + 1) & vbNewLine
    txtRetorno.Text = txtRetorno.Text & " Remessa : " & retornoConsultarBaixa.Item(i).Remessa & vbNewLine
    txtRetorno.Text = txtRetorno.Text & " Banco : " & retornoConsultarBaixa.Item(i).Banco & vbNewLine
    txtRetorno.Text = txtRetorno.Text & " Convenio : " & retornoConsultarBaixa.Item(i).Convenio & vbNewLine
    txtRetorno.Text = txtRetorno.Text & " Erro : " & retornoConsultarBaixa.Item(i).Erro & vbNewLine
    txtRetorno.Text = txtRetorno.Text & " ErroClasse : " & retornoConsultarBaixa.Item(i).ErroClasse & vbNewLine


    For j = 0 To retornoConsultarBaixa.Item(i).Titulos.Count - 1
        txtRetorno.Text = txtRetorno.Text & " IdIntegracao " & CStr(j + 1) & ":" & retornoConsultarBaixa.Item(i).Titulos.Item(j) & vbNewLine
    Next j
    
    txtRetorno.Text = txtRetorno.Text & vbNewLine
    
Next i


End Sub

Private Sub cmdConsultarRetornoProcessamento_Click()
Dim retornoConsultaProcessamento As BoletoX.spdRetConsultarRetornoProcessamento
  Dim retornoConsultaProcessamentoItem As BoletoX.spdRetConsultarRetornoProcessamentoItem
  
  Set retornoConsultaProcessamento = FBoletoX.ConsultaRetornoProcessamento(txtProtocolo)
 
  txtRetorno.Text = ".:: CONSULTA RETORNO PROCESSAMENTO ::."
  txtRetorno.Text = txtRetorno.Text & vbNewLine & "Mensagem : " & retornoConsultaProcessamento.Mensagem
  txtRetorno.Text = txtRetorno.Text & vbNewLine & "Status : " & retornoConsultaProcessamento.Status
  txtRetorno.Text = txtRetorno.Text & vbNewLine & "Status : " & retornoConsultaProcessamento.Situacao

  txtRetorno.Text = txtRetorno.Text & vbNewLine
  
  
  For i = 0 To retornoConsultaProcessamento.Count - 1
    Set retornoConsultaProcessamentoItem = retornoConsultaProcessamento.Titulos(i)
    txtRetorno.Text = txtRetorno.Text & "Titulo : " & CStr(i + 1) & vbNewLine
    txtRetorno.Text = txtRetorno.Text & "IdIntegracao : " & retornoConsultaProcessamentoItem.IdIntegracao & vbNewLine
  Next i
End Sub

Private Sub cmdDescartarBoletos_Click()
Dim DescarteList As BoletoX.spdRetDescartarLista
  Dim DescarteItem As BoletoX.spdRetDescartarTituloItem
  
  Set DescarteList = FBoletoX.Descartar(txtIdIntegracao.Text)
  
  txtRetorno.Text = ""
  txtRetorno.Text = txtRetorno.Text & ".:: Descartar ::." & vbNewLine
  txtRetorno.Text = txtRetorno.Text & "Mensagem: " & DescarteList.Mensagem & vbNewLine
  txtRetorno.Text = txtRetorno.Text & "Status: " & DescarteList.Status & vbNewLine
  
  If (DescarteList.Status = "ERRO") Then
    txtRetorno.Text = txtRetorno.Text & "ErroClasse: " & DescarteList.ErroClasse
  End If
  
  For i = 0 To DescarteList.Count - 1
    Set DescarteItem = DescarteList.Item(i)
    txtRetorno.Text = txtRetorno.Text & "Item: " & (i + 1) & vbNewLine
    txtRetorno.Text = txtRetorno.Text & "IdIntegracao: " & DescarteItem.IdIntegracao & vbNewLine
    txtRetorno.Text = txtRetorno.Text & "Erro: " & DescarteItem.Erro & vbNewLine
    txtRetorno.Text = txtRetorno.Text & "ErroClasse: " & DescarteItem.ErroClasse & vbNewLine
  Next i
End Sub

Private Sub cmdEnviarEmail_Click()
Dim retorno As BoletoX.spdRetEnvioEmail
  
  txtTx2.Text = "INCLUIREMAIL" & vbNewLine
  txtTx2.Text = txtTx2.Text & vbNewLine
  txtTx2.Text = txtTx2.Text & "IdIntegracao= " & txtIdIntegracao & vbNewLine
  txtTx2.Text = txtTx2.Text & "EmailNomeRemetente=Nome do Remetente" & vbNewLine
  txtTx2.Text = txtTx2.Text & "EmailRemetente=naoresponda@minhaempresa.com.br" & vbNewLine
  txtTx2.Text = txtTx2.Text & "EmailAssunto=Boleto para pagamento" & vbNewLine
  txtTx2.Text = txtTx2.Text & "EmailMensagem=Prezado cliente, segue link para visualização e pagamento do boleto:|${linkBoleto}|Considere não imprimir este email." & vbNewLine
  txtTx2.Text = txtTx2.Text & "EmailDestinatario=pedro.souza@tecnospeed.com.br" & vbNewLine
  txtTx2.Text = txtTx2.Text & vbNewLine
  txtTx2.Text = txtTx2.Text & "SALVAREMAIL" & vbNewLine
  
  
  Set retorno = FBoletoX.EnviarEmail(txtTx2.Text)
  
  txtRetorno.Text = ".: E-MAIL BOLETO ::."
  txtRetorno.Text = txtRetorno.Text & vbNewLine & "Mensagem : " & retorno.Mensagem
  txtRetorno.Text = txtRetorno.Text & vbNewLine & "Status : " & retorno.Status
  txtRetorno.Text = txtRetorno.Text & vbNewLine
End Sub

Private Sub cmdGerarBaixa_Click()
Dim GerarResposta As spdRetGerarRemessaBaixa

Set GerarResposta = FBoletoX.GerarRemessaBaixa(txtIdIntegracao.Text)


If GerarResposta.Protocolo <> Empty Then
    edtProtocoloEmailLote.Text = GerarResposta.Protocolo

  txtRetorno.Text = ".:: GERAR BAIXA ::."
  txtRetorno.Text = txtRetorno.Text & vbNewLine & " Mensagem : " & GerarResposta.Mensagem & vbNewLine
  txtRetorno.Text = txtRetorno.Text & vbNewLine & " Status : " & GerarResposta.Status & vbNewLine
  txtRetorno.Text = txtRetorno.Text & vbNewLine & " Protocolo : " & GerarResposta.Protocolo & vbNewLine
End If

If StrComp(GerarResposta.Status, "ERRO") Then
    txtRetorno.Text = txtRetorno.Text & " ErroClasse: " & GerarResposta.ErroClasse & vbNewLine

End If

txtProtocoloRemessaBaixada.Text = GerarResposta.Protocolo


End Sub

Private Sub cmdGerarRemessa_Click()
Dim retornoLista As BoletoX.spdRetGerarRemessaLista
  Dim retornoItem  As BoletoX.spdRetGerarRemessaItem
  'Dim Titulos As BoletoX.spdGerarRemessaTitulos

  Set retornoLista = FBoletoX.GerarRemessa(txtIdIntegracao.Text)
 
  txtRetorno.Text = ".:: GERAR REMESSA ::."
  txtRetorno.Text = txtRetorno.Text & vbNewLine & "Mensagem : " & retornoLista.Mensagem
  txtRetorno.Text = txtRetorno.Text & vbNewLine & "Status : " & retornoLista.Status
  txtRetorno.Text = txtRetorno.Text & vbNewLine
  
  
  For i = 0 To retornoLista.Count - 1
    Set retornoItem = retornoLista.Item(i)
    'Set Titulos = retornoItem.Titulos
    txtRetorno.Text = txtRetorno.Text & "Item : " & CStr(i + 1) & vbNewLine
    txtRetorno.Text = txtRetorno.Text & "Remessa : " & retornoItem.Remessa & vbNewLine
    txtRetorno.Text = txtRetorno.Text & "Banco : " & retornoItem.Banco & vbNewLine
    txtRetorno.Text = txtRetorno.Text & "Conta : " & retornoItem.Conta & vbNewLine
    txtRetorno.Text = txtRetorno.Text & "Erro : " & retornoItem.Erro & vbNewLine
    
    For j = 0 To retornoItem.Titulos.Count - 1
      txtRetorno.Text = txtRetorno.Text & "Id Integração : " & CStr(j + 1) & " - " & retornoItem.Titulos.Item(j) & vbNewLine
    Next j
  
  Next i
  
''' Salvar a remessa em UTF-8(SEM BOM)
   Set objStream = CreateObject("ADODB.Stream")
   Set objStreamNoBOM = CreateObject("ADODB.Stream")

   With objStream
      .Open
      .Charset = "UTF-8"
      .WriteText retornoItem.Remessa
      .Position = 0
   End With

   With objStreamNoBOM
      .Charset = "Windows-1252"
      .Open
      .Type = 2
      .WriteText objStream.ReadText
      .SaveToFile "c:\Temp\TesteRemessa.txt", 2
      .Close
   End With

   objStream.Close
   
End Sub

Private Sub cmdGerarRemessaAlteracao_Click()
Dim GerarResposta As BoletoX.spdRetGerarRemessaAlteracao

If cbbGerarRemessaAlteracao.ListIndex = 0 Then
    Set GerarResposta = FBoletoX.GerarRemessaAlteracao("0", txtTx2.Text)   ' Alteração de Vencimento'
ElseIf cbbGerarRemessaAlteracao.ListIndex = 1 Then
    Set GerarResposta = FBoletoX.GerarRemessaAlteracao("1", txtTx2.Text)    ' Alteração de Valor '
End If
  
  txtRetorno.Text = ".:: Gerar Alteração::."
  txtRetorno.Text = txtRetorno.Text & vbNewLine & "Mensagem : " & GerarResposta.Mensagem
  txtRetorno.Text = txtRetorno.Text & vbNewLine & "Status : " & GerarResposta.Status
  txtRetorno.Text = txtRetorno.Text & vbNewLine & "Protocolo: " & GerarResposta.Protocolo
    
  If (GerarResposta.Status = "ERRO") Then
    txtRetorno.Text = txtRetorno.Text & "ErroClasse: " & GerarResposta.ErroClasse
  End If
  
  txtProtocoloRetornoRemessaAlteracao.Text = GerarResposta.Protocolo
  
End Sub

Private Sub cmdImprimir_Click()
Dim retorno As BoletoX.spdRetImprimir

  Set retorno = FBoletoX.Imprimir(txtIntegraoImpressao.Text, "")
 
  txtRetorno.Text = "### IMPRIMIR BOLETO ###"
  txtRetorno.Text = txtRetorno.Text & vbNewLine & "Mensagem : " & retorno.Mensagem
  txtRetorno.Text = txtRetorno.Text & vbNewLine & "Status : " & retorno.Status
  txtRetorno.Text = txtRetorno.Text & vbNewLine
End Sub

Private Sub cmdImprimirLote_Click()
Dim Impressao As spdRetConsultarLoteImpressao
  
  txtRetorno.Text = ""
  txtTx2.Text = ""
  
  Set Impressao = FBoletoX.ConsultarLoteImpressao(txtProtocoloRetornoImpressaoLote.Text, "")
  
  txtRetorno.Text = ".:: Impressão em Lote::."
  txtRetorno.Text = txtRetorno.Text & vbNewLine & "Mensagem : " & Impressao.Mensagem
  txtRetorno.Text = txtRetorno.Text & vbNewLine & "Status : " & Impressao.Status
  
  If (Impressao.Status = "ERRO") Then
    txtRetorno.Text = txtRetorno.Text & "ErroClasse: " & Impressao.ErroClasse
  End If
  
  txtRetorno.Text = txtRetorno.Text & vbNewLine
End Sub

Private Sub cmdIncluir_Click()
  Dim retorno As BoletoX.spdRetIncluirLista
  Set retorno = FBoletoX.Incluir(txtTx2.Text)
  Dim listaIdsIntegracao As String
  
  txtRetorno.Text = ".:: INCLUIR BOLETO ::."
  txtRetorno.Text = txtRetorno.Text & vbNewLine & "Mensagem : " & retorno.Mensagem
  txtRetorno.Text = txtRetorno.Text & vbNewLine & "Status : " & retorno.Status
  txtRetorno.Text = txtRetorno.Text & vbNewLine
  
  For i = 0 To retorno.Count - 1
    txtRetorno.Text = txtRetorno.Text & "Item : " & CStr(i + 1) & vbNewLine
    txtRetorno.Text = txtRetorno.Text & "Número Documento : " & retorno.Item(i).NumeroDocumento & vbNewLine
    txtRetorno.Text = txtRetorno.Text & "Id Integração : " & retorno.Item(i).IdIntegracao & vbNewLine
    txtRetorno.Text = txtRetorno.Text & "Situação : " & retorno.Item(i).Situacao & vbNewLine
    txtRetorno.Text = txtRetorno.Text & "Nosso Número : " & retorno.Item(i).NossoNumero & vbNewLine
    txtRetorno.Text = txtRetorno.Text & "Banco : " & retorno.Item(i).Banco & vbNewLine
    txtRetorno.Text = txtRetorno.Text & "Conta : " & retorno.Item(i).Conta & vbNewLine
    txtRetorno.Text = txtRetorno.Text & "Convênio : " & retorno.Item(i).Convenio & vbNewLine
    txtRetorno.Text = txtRetorno.Text & "Erro : " & retorno.Item(i).Erro & vbNewLine
    
    If i = 0 Then
       listaIdsIntegracao = retorno.Item(i).IdIntegracao
    Else
       listaIdsIntegracao = listaIdsIntegracao & "," & retorno.Item(i).IdIntegracao
    End If
    
    txtIdIntegracao.Text = listaIdsIntegracao
    
  Next i

End Sub


Private Sub btnCarregarConfig_Click()
0 FBoletoX.Config.URL = "http://homologacao.cobrancabancaria.tecnospeed.com.br:8080"
  
  If opHomologacao = True Then
     FBoletoX.Config.URL = "http://homologacao.cobrancabancaria.tecnospeed.com.br:8080"
     txtRetorno.Text = "Selecionado o ambiente de Homologação"
  Else
     FBoletoX.Config.URL = "http://cobrancabancaria.tecnospeed.com.br"
     txtRetorno.Text = "Selecionado o ambiente de Produção"
  End If
  
  FBoletoX.ConfigurarSoftwareHouse txtCNPJSoftwareHouse.Text, txtTokenSoftwareHouse.Text
  FBoletoX.Config.CedenteCpfCnpj = txtCnpjCedente.Text
End Sub

Private Sub cmdSalvarPDF_Click()
Dim salvarPDF As BoletoX.spdRetSalvarPDF
  Set salvarPDF = FBoletoX.salvarPDF(txtIntegraoImpressao.Text, "C:\testeVB.pdf")
 
  txtRetorno.Text = "### SALVAR PDF ###"
  txtRetorno.Text = txtRetorno.Text & vbNewLine & "Mensagem : " & salvarPDF.Mensagem
  txtRetorno.Text = txtRetorno.Text & vbNewLine & "Status : " & salvarPDF.Status
  txtRetorno.Text = txtRetorno.Text & vbNewLine
End Sub

Private Sub cmdSalvarPDFLote_Click()
Dim SalvarPDFLote As spdRetSalvarLoteImpressaoPDF
  
  txtRetorno.Text = ""
  txtTx2.Text = ""
  
  Set SalvarPDFLote = FBoletoX.SalvarLoteImpressaoPDF(txtProtocoloRetornoImpressaoLote.Text, "C:\Temp\teste.pdf")
  
  txtRetorno.Text = ".:: Consultar Protocolo Lote Impressão::."
  txtRetorno.Text = txtRetorno.Text & vbNewLine & "Mensagem : " & SalvarPDFLote.Mensagem
  txtRetorno.Text = txtRetorno.Text & vbNewLine & "Status : " & SalvarPDFLote.Status
  
  If (SalvarPDFLote.Status = "ERRO") Then
    txtRetorno.Text = txtRetorno.Text & "ErroClasse: " & SalvarPDFLote.ErroClasse
  End If
  
  txtRetorno.Text = txtRetorno.Text & vbNewLine

End Sub

Private Sub cmdSolicitarImpressaoLote_Click()
Dim ImprimirLoteList As spdRetImprimirLote
  Dim TipoImpressao As String
  
  If cbbTipoImpressao.ListIndex = 0 Then
    TipoImpressao = "0"    'Impressão modo Normal
  ElseIf cbbTipoImpressao.ListIndex = 1 Then
    TipoImpressao = "1"    ' Impressão em modo Carne Duplo Paisagem
  ElseIf cbbTipoImpressao.ListIndex = 2 Then
    TipoImpressao = "2"    ' Impressão em modo Carne triplo
  ElseIf cbbTipoImpressao.ListIndex = 3 Then
    TipoImpressao = "3"    ' Impressão em modo Carne Duplo Retrato
  ElseIf cbbTipoImpressao.ListIndex = 4 Then
    TipoImpressao = "99"   ' Impressão Personalizada
  End If
  
  Set ImprimirLoteList = FBoletoX.ImprimirLote(txtIdIntegracao.Text, TipoImpressao)
  
  If (ImprimirLoteList.Protocolo <> "") Then
    txtProtocoloRetornoImpressaoLote.Text = ImprimirLoteList.Protocolo
  End If
  
  txtRetorno.Text = ""
  txtTx2.Text = ""
  
  txtRetorno.Text = ".:: Impressão em Lote::."
  txtRetorno.Text = txtRetorno.Text & vbNewLine & "Mensagem : " & ImprimirLoteList.Mensagem
  txtRetorno.Text = txtRetorno.Text & vbNewLine & "Status : " & ImprimirLoteList.Status
  txtRetorno.Text = txtRetorno.Text & vbNewLine & "Protocolo : " & ImprimirLoteList.Status
  
  
  If (ImprimirLoteList.Status = "ERRO") Then
    txtRetorno.Text = txtRetorno.Text & vbNewLine & "ErroClasse : " & ImprimirLoteList.ErroClasse
  End If
  
  txtProtocoloRetornoImpressaoLote.Text = ImprimirLoteList.Protocolo
  
End Sub

Private Sub cmdUploadRet_Click()
Dim ProcessarRetornoList As BoletoX.spdRetProcessarRetorno
  
  cmdAbrirArqRet.ShowOpen
  If cmdAbrirArqRet.FileName <> "" Then
     txtTx2.Text = ReadUTF8File(cmdAbrirArqRet.FileName)
  End If
    
  Set ProcessarRetornoList = FBoletoX.ProcessarRetorno(txtTx2.Text)  'Envia o retorno

  txtRetorno.Text = "### UPLOAD RETORNO ###" & vbNewLine
  txtRetorno.Text = txtRetorno.Text & "Mensagem: " + ProcessarRetornoList.Mensagem & vbNewLine
  txtRetorno.Text = txtRetorno.Text & "Status: " + ProcessarRetornoList.Status & vbNewLine
  txtRetorno.Text = txtRetorno.Text & "Protocolo: " + ProcessarRetornoList.Protocolo & vbNewLine

  txtProtocolo.Text = ProcessarRetornoList.Protocolo


End Sub

Private Sub Form_Initialize()
  Set FBoletoX = New BoletoX.spdBoletoX
  opHomologacao = True
  opProducao = False
 
  
End Sub

Private Sub Text10_Change()

End Sub

Private Sub TabStrip1_Click()

End Sub

Private Sub Label6_Click()

End Sub

