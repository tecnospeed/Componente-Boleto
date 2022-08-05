unit Unit1;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls, Vcl.ExtCtrls, Vcl.Mask,
  Vcl.OleCtrls, IniFiles,Vcl.Printers, DateUtils, BoletoX_TLB, ShellApi,
  Vcl.ComCtrls, Vcl.OleCtnrs, Data.DB;

type
  TfrmExemploBoletoX = class(TForm)
    btnIncluir: TButton;
    btnConsultar: TButton;
    edtIdIntegracao: TEdit;
    lblImpressora: TLabel;
    cbbImpressora: TComboBox;
    lblTX2: TLabel;
    mmoTX2: TMemo;
    lblRetorno: TLabel;
    lblTempoDeResposta: TLabel;
    dlgOpenArqRet: TOpenDialog;
    dlgSalvarPDF: TSaveDialog;
    btnCarregarTx2: TButton;
    dlgOpenTx2: TOpenDialog;
    GroupBox1: TGroupBox;
    Label3: TLabel;
    grpImpressao: TGroupBox;
    btnGerarTx2: TButton;
    mmoResposta: TMemo;
    GroupBox2: TGroupBox;
    btnGerarRemessa: TButton;
    btnUploadRetorno: TButton;
    btnConsultarRetornoProcessamento: TButton;
    edtProtocoloRetornoProcessamento: TEdit;
    btnConsultarMovimentacao: TButton;
    lblDataInicial: TLabel;
    medtDataInicial: TMaskEdit;
    lblDataFinal: TLabel;
    medtDataFinal: TMaskEdit;
    mmoMensagens: TMemo;
    lblMensagens: TLabel;
    cbbTipoImpressao: TComboBox;
    btnSolicitarImpressaoLote: TButton;
    edtProtocoloRetornoImpressaoLote: TEdit;
    btnImprimirLote: TButton;
    btnSalvarPDFLote: TButton;
    Label6: TLabel;
    GroupBox4: TGroupBox;
    btnConsultarProtocoloRemessaAlteracao: TButton;
    edtProtocoloRetornoRemessaAlteracao: TEdit;
    btnGerarBaixa: TButton;
    btnConsultarRemessaBaixada: TButton;
    edtProcotoloRemessaBaixada: TEdit;
    btnDescartarBoletos: TButton;
    Shape1: TShape;
    btnGerarRemessaAlteracao: TButton;
    cbbTipoRemessaAlteracao: TComboBox;
    lblLeiaMe: TLabel;
    GroupBox5: TGroupBox;
    btnEnviarEmailLote: TButton;
    edtProtocoloEmailLote: TEdit;
    Button1: TButton;
    PageControlConfiguracoes: TPageControl;
    TabSheetConfiguracoes: TTabSheet;
    TabSheetCadCedente: TTabSheet;
    rgAmbiente: TRadioGroup;
    Label8: TLabel;
    edtServerTestes: TEdit;
    lbl3: TLabel;
    edtCNPJSoftwareHouse: TEdit;
    Label1: TLabel;
    Label2: TLabel;
    edtCNPJCedente: TEdit;
    btnCarregarConfig: TButton;
    btnCadastrarCedente: TButton;
    btnCadastrarConta: TButton;
    btnCadastrarConvenio: TButton;
    AbrirPDFGravado: TOleContainer;
    AbrirPDF: TButton;
    edtTokenSoftwareHouse: TMaskEdit;
    edtIDCedente: TEdit;
    btnAlterarCedente: TButton;
    edtIDConta: TEdit;
    edtIDConvenio: TEdit;
    btnAlterarConta: TButton;
    btnAlterarConvenio: TButton;
    DataSource1: TDataSource;
    function ConverteErroClasse(aErroClasse: TErroClasse): string;
    procedure btnIncluirClick(Sender: TObject);
    procedure btnConsultarClick(Sender: TObject);
    procedure btnImprimirClick(Sender: TObject);
    procedure btnSalvarPDFClick(Sender: TObject);
    procedure btnGerarRemessaClick(Sender: TObject);
    procedure btnUploadRetornoClick(Sender: TObject);
    procedure btnConsultarMovimentacaoClick(Sender: TObject);
    procedure btnCarregarTx2Click(Sender: TObject);
    procedure btnCarregarConfigClick(Sender: TObject);
    procedure btnConsultarRetornoProcessamentoClick(Sender: TObject);
    procedure btnEnviarEmailClick(Sender: TObject);
    procedure btnGerarTx2Click(Sender: TObject);
    procedure btnSolicitarImpressaoLoteClick(Sender: TObject);
    procedure btnImprimirLoteClick(Sender: TObject);
    procedure btnSalvarPDFLoteClick(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure btnGerarRemessaAlteracaoVencimentoClick(Sender: TObject);
    procedure btnConsultarProtocoloRemessaAlteracaoClick(Sender: TObject);
    procedure btnGerarBaixaClick(Sender: TObject);
    procedure btnConsultarRemessaBaixadaClick(Sender: TObject);
    procedure btnDescartarBoletosClick(Sender: TObject);
    procedure btnGerarRemessaAlteracaoClick(Sender: TObject);
    procedure mmoTX2KeyDown(Sender: TObject; var Key: Word; Shift: TShiftState);
    procedure mmoRespostaKeyDown(Sender: TObject; var Key: Word;
      Shift: TShiftState);
    procedure lblLeiaMeClick(Sender: TObject);
    procedure btnEnviarEmailLoteClick(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure btnCadastrarCedenteClick(Sender: TObject);
    procedure btnCadastrarContaClick(Sender: TObject);
    procedure btnCadastrarConvenioClick(Sender: TObject);
    procedure AbrirPDFClick(Sender: TObject);
    procedure btnAlterarCedenteClick(Sender: TObject);
    procedure btnAlterarContaClick(Sender: TObject);
    procedure btnAlterarConvenioClick(Sender: TObject);
  private
    { Private declarations }
    procedure InicioTempoResposta;
    procedure FimTempoResposta;
  public
    FBoletoX: TspdBoletoX;
    FInicioReq : TDateTime;

    { Public declarations }
    procedure DoOnBoletoException(ASender: TObject; const aExceptionMessage: WideString);
    procedure DoOnBoletoProgress(ASender: TObject; const aProgressMessage: WideString);

  end;

var
  frmExemploBoletoX: TfrmExemploBoletoX;

implementation

{$R *.dfm}

function TfrmExemploBoletoX.ConverteErroClasse(aErroClasse: TErroClasse): string;
begin
  case aErroClasse of
    ecValidacao: Result := 'VALIDACAO';
    ecAutenticacao: Result := 'AUTENTICACAO';
    ecNaoEncontrado: Result := 'NAOENCONTRADO';
    ecInterno: Result := 'INTERNO';
    ecParametroTamanhoExcedido: Result := 'PARAMETROTAMANHOEXCEDIDO';
    ecServidorIndisponivel: Result := 'SERVIDORINDISPONIVEL';
    ecNaoTratado: Result := 'NAOTRATADO';
    ecAcessoNegado: Result := 'ACESSONEGADO';
    ecNenhum: Result := 'NENHUM';
  end;
end;


procedure TfrmExemploBoletoX.btnCarregarTx2Click(Sender: TObject);
var
   arq: string;
begin
  mmoTX2.Clear;
  dlgOpenTx2.InitialDir := ExtractFilePath(ParamStr(0)+ 'INCLUIRBOLETO.tx2');

  if dlgOpenTx2.Execute then
  begin
    mmoTX2.Lines.LoadFromFile(dlgOpenTx2.FileName);
    arq:= dlgOpenTx2.FileName
  end;

end;


procedure TfrmExemploBoletoX.btnConsultarClick(Sender: TObject);
var
  _ConsultarList: IspdRetConsultarLista;
  _ConsultarItem: IspdRetConsultarTituloItem;
  i, j,k ,l : Integer;
begin
  mmoResposta.Lines.Clear;
  mmoResposta.Refresh;
  mmoResposta.Lines.BeginUpdate;

  try
    InicioTempoResposta;
    _ConsultarList := FBoletoX.Consultar(edtIdIntegracao.Text);
    FimTempoResposta;

    mmoResposta.Lines.Add('.:: Consultar T�tulo ::.');
    mmoResposta.Lines.Add('Mensagem: ' + _ConsultarList.Mensagem);
    mmoResposta.Lines.Add('Status: ' + _ConsultarList.Status);

    if _ConsultarList.ErroConexao <> '' then
      mmoResposta.Lines.Add('Erro Conex�o: ' + _ConsultarList.ErroConexao);

    mmoResposta.Lines.Add('');

    while _ConsultarList.Count <> 0 do
    begin
      for i := 0 to pred(_ConsultarList.Count) do    //o conte�do de pred � equivalente a (_ConsultarList.Count - 1)
      begin
        _ConsultarItem := _ConsultarList.Item[i];
        mmoResposta.Lines.Add('ITEM: ' + IntToStr(i+1));
        mmoResposta.Lines.Add('  IdIntegracao: ' + _ConsultarItem.IdIntegracao);
        mmoResposta.Lines.Add('  Situacao: ' + _ConsultarItem.Situacao);
        mmoResposta.Lines.Add('  Motivo: ' + _ConsultarItem.Motivo);
        mmoResposta.Lines.Add('');
        mmoResposta.Lines.Add('CEDENTE:');
        mmoResposta.Lines.Add('  Agencia: ' + _ConsultarItem.CedenteAgencia);
        mmoResposta.Lines.Add('  AgenciaDV: ' + _ConsultarItem.CedenteAgenciaDV);
        mmoResposta.Lines.Add('  C�digo Banco: ' + _ConsultarItem.CedenteCodigoBanco);
        mmoResposta.Lines.Add('  Carteira: ' + _ConsultarItem.CedenteCarteira);
        mmoResposta.Lines.Add('  Conta: ' + _ConsultarItem.CedenteConta);
        mmoResposta.Lines.Add('  DV da conta: ' + _ConsultarItem.CedenteContaNumeroDV);
        mmoResposta.Lines.Add('  Numero Conv�nio: ' + _ConsultarItem.CedenteNumeroConvenio);
        mmoResposta.Lines.Add('');
        mmoResposta.Lines.Add('SACADO:');
        mmoResposta.Lines.Add('  CPFCNPJ: ' + _ConsultarItem.SacadoCPFCNPJ);
        mmoResposta.Lines.Add('  Nome: ' + _ConsultarItem.SacadoNome);
        mmoResposta.Lines.Add('  Telefone: ' + _ConsultarItem.SacadoTelefone);
        mmoResposta.Lines.Add('  Celular: ' + _ConsultarItem.SacadoCelular);
        mmoResposta.Lines.Add('  Email: ' + _ConsultarItem.SacadoEmail);
        mmoResposta.Lines.Add('  Endere�o N�mero: ' + _ConsultarItem.SacadoEnderecoNumero);
        mmoResposta.Lines.Add('  Endere�o Bairro: ' + _ConsultarItem.SacadoEnderecoBairro);
        mmoResposta.Lines.Add('  Endere�o CEP: ' + _ConsultarItem.SacadoEnderecoCEP);
        mmoResposta.Lines.Add('  Endere�o Cidade: ' + _ConsultarItem.SacadoEnderecoCidade);
        mmoResposta.Lines.Add('  Endere�o Complemento: ' + _ConsultarItem.SacadoEnderecoComplemento);
        mmoResposta.Lines.Add('  Endere�o Logradouro: ' + _ConsultarItem.SacadoEnderecoLogradouro);
        mmoResposta.Lines.Add('  Endere�o Pa�s: ' + _ConsultarItem.SacadoEnderecoPais);
        mmoResposta.Lines.Add('  Endere�o UF: ' + _ConsultarItem.SacadoEnderecoUF);
        mmoResposta.Lines.Add('  Sacador Avalista: ' + _ConsultarItem.TituloSacadorAvalista);
        mmoResposta.Lines.Add('  Sacador Avalista Inscricao: ' + _ConsultarItem.TituloInscricaoSacadorAvalista);
        mmoResposta.Lines.Add('  Endere�o Sacador Avalista: ' + _ConsultarItem.TituloSacadorAvalistaEndereco);
        mmoResposta.Lines.Add('  Cidade Sacador Avalista: ' + _ConsultarItem.TituloSacadorAvalistaCidade);
        mmoResposta.Lines.Add('  CEP Sacador Avalista: ' + _ConsultarItem.TituloSacadorAvalistaCEP);
        mmoResposta.Lines.Add('  UF Sacador Avalista: ' + _ConsultarItem.TituloSacadorAvalistaUF);
        mmoResposta.Lines.Add('');
        mmoResposta.Lines.Add('T�TULO:');
        mmoResposta.Lines.Add('  Nosso N�mero: ' + _ConsultarItem.TituloNossoNumero);
        mmoResposta.Lines.Add('  N�mero Documento: ' + _ConsultarItem.TituloNumeroDocumento);
        mmoResposta.Lines.Add('  Nosso N�mero Impress�o: ' + _ConsultarItem.TituloNossoNumeroImpressao);
        mmoResposta.Lines.Add('  Origem Documento: ' + _ConsultarItem.TituloOrigemDocumento);
        mmoResposta.Lines.Add('  Linha Digit�vel: ' + _ConsultarItem.TituloLinhaDigitavel);
        mmoResposta.Lines.Add('  C�digo de Barras: ' + _ConsultarItem.TituloCodigoBarras);
        mmoResposta.Lines.Add('  C�digo Emiss�o Bloqueto: ' + _ConsultarItem.TituloCodEmissaoBloqueto);
        mmoResposta.Lines.Add('  Titulo Aceite: ' + _ConsultarItem.TituloAceite);
        mmoResposta.Lines.Add('  Avalista: ' + _ConsultarItem.TituloInscricaoSacadorAvalista);
        mmoResposta.Lines.Add('  Doc Esp�cie: ' + _ConsultarItem.TituloDocEspecie);
        mmoResposta.Lines.Add('  Postagem: ' + _ConsultarItem.TituloPostagemBoleto);

        mmoResposta.Lines.Add('  C�digo para baixa ou devolu��o: ' + _ConsultarItem.TituloCodBaixaDevolucao);
        mmoResposta.Lines.Add('  Prazo para baixa ou devolu��o: ' + _ConsultarItem.TituloPrazoBaixa);
        mmoResposta.Lines.Add('  Data Emiss�o: ' + _ConsultarItem.TituloDataEmissao);
        mmoResposta.Lines.Add('  For�ar Fator Vencimento: ' + BoolToStr(_ConsultarItem.TituloForcarFatorVencimento, True));
        mmoResposta.Lines.Add('  Data Vencimento: ' + _ConsultarItem.TituloDataVencimento);
        mmoResposta.Lines.Add('  C�digo de Desconto: ' + _ConsultarItem.TituloCodDesconto);
        mmoResposta.Lines.Add('  Data Desconto: ' + _ConsultarItem.TituloDataDesconto);
        mmoResposta.Lines.Add('  Valor Desconto: ' + FloatToStr(_ConsultarItem.TituloValorDescontoTaxa));
        mmoResposta.Lines.Add('  C�digo de Desconto2: ' + _ConsultarItem.TituloCodDesconto2);
        mmoResposta.Lines.Add('  Outras Deducoes: ' + _ConsultarItem.TituloOutrasDeducoes);
        mmoResposta.Lines.Add('  Data Desconto: ' + _ConsultarItem.TituloDataDesconto2);
        mmoResposta.Lines.Add('  Valor Desconto: ' + FloatToStr(_ConsultarItem.TituloValorDescontoTaxa2));
        mmoResposta.Lines.Add('  C�digo de Juros: ' + _ConsultarItem.TituloCodigoJuros);
        mmoResposta.Lines.Add('  Data Juros: ' + _ConsultarItem.TituloDataJuros);
        mmoResposta.Lines.Add('  Valor Juros: ' + FloatToStr(_ConsultarItem.TituloValorJuros));
        mmoResposta.Lines.Add('  Prazo Protesto: ' + _ConsultarItem.TituloPrazoProtesto);
        mmoResposta.Lines.Add('  Instrucoes: ' + _ConsultarItem.TituloInstrucoes);
        mmoResposta.Lines.Add('  Mensagem 1: ' + _ConsultarItem.TituloMensagem01);
        mmoResposta.Lines.Add('  Mensagem 2: ' + _ConsultarItem.TituloMensagem02);
        mmoResposta.Lines.Add('  Mensagem 3: ' + _ConsultarItem.TituloMensagem03);
        mmoResposta.Lines.Add('  T�tuloInstrucao 1: ' + _ConsultarItem.TituloInstrucao1);
        mmoResposta.Lines.Add('  T�tuloInstrucao 2: ' + _ConsultarItem.TituloInstrucao2);
        mmoResposta.Lines.Add('  Informacoes Adicionais: ' + _ConsultarItem.TituloInformacoesAdicionais);
        mmoResposta.Lines.Add('  Local Pagamento: ' + _ConsultarItem.TituloLocalPagamento);
        mmoResposta.Lines.Add('  Parcela: ' + _ConsultarItem.TituloParcela);
        mmoResposta.Lines.Add('  Variacao Carteira: ' + _ConsultarItem.TituloVariacaoCarteira);
        mmoResposta.Lines.Add('  Categoria: ' + _ConsultarItem.TituloCategoria);
        mmoResposta.Lines.Add('  Modalidade: ' + _ConsultarItem.TituloModalidade);
        mmoResposta.Lines.Add('  Cip: ' + _ConsultarItem.TituloCip);
        mmoResposta.Lines.Add('  Ios "utilizado apenas pelo Santander": ' + _ConsultarItem.TituloIos);
        mmoResposta.Lines.Add('  Cod Cliente "exclusivo para os bancos HSBC e Safra": ' + _ConsultarItem.TituloCodCliente);
        mmoResposta.Lines.Add('  Valor: ' + FloatToStr(_ConsultarItem.TituloValor));
        mmoResposta.Lines.Add('  Pagamento Minimo: ' + FloatToStr(_ConsultarItem.TituloPagamentoMinimo));
        mmoResposta.Lines.Add('  Data Cr�dito: ' + _ConsultarItem.PagamentoDataCredito);
        mmoResposta.Lines.Add('  Valor Cobrado: ' + FloatToStr(_ConsultarItem.TituloValorCobrado));
        mmoResposta.Lines.Add('  T�tulo Pago: ' + BoolToStr(_ConsultarItem.PagamentoRealizado));
        mmoResposta.Lines.Add('  Valor Cr�dito: ' + FloatToStr(_ConsultarItem.PagamentoValorCredito));
        mmoResposta.Lines.Add('  Valor Outros Acr�scimos: ' + FloatToStr(_ConsultarItem.TituloValorOutrosAcrescimos));
        mmoResposta.Lines.Add('  Valor Pago: ' + FloatToStr(_ConsultarItem.PagamentoValorPago));
        mmoResposta.Lines.Add('  Valor Taxa Cobran�a: ' + FloatToStr(_ConsultarItem.PagamentoValorTaxaCobranca));
        mmoResposta.Lines.Add('  Valor Abatimento: ' + FloatToStr(_ConsultarItem.TituloValorAbatimento));
        mmoResposta.Lines.Add('  Valor Outras Despesas: ' + FloatToStr(_ConsultarItem.PagamentoValorOutrasDespesas));
        mmoResposta.Lines.Add('  Valor IOF: ' + FloatToStr(_ConsultarItem.PagamentoValorIOF));
        mmoResposta.Lines.Add('  C�digo Multa: ' + _ConsultarItem.TituloCodigoMulta);
        mmoResposta.Lines.Add('  Valor Multa: ' + FloatToStr(_ConsultarItem.TituloValorMulta));
        mmoResposta.Lines.Add('  Valor Multa Taxa: ' + FloatToStr(_ConsultarItem.TituloValorMultaTaxa));
        mmoResposta.Lines.Add('  Data Multa: ' + _ConsultarItem.PagamentoData);
        mmoResposta.Lines.Add('  Data Pagamento: ' + _ConsultarItem.PagamentoData);
        mmoResposta.Lines.Add('  Valor Outros Cr�ditos: ' + FloatToStr(_ConsultarItem.PagamentoValorOutrosCreditos));
        mmoResposta.Lines.Add('  Pagamento Valor Desconto: ' + FloatToStr(_ConsultarItem.PagamentoValorDesconto));
        mmoResposta.Lines.Add('  Pagamento Valor Acr�scimos: ' + FloatToStr(_ConsultarItem.PagamentoValorAcrescimos));
        mmoResposta.Lines.Add('  Pagamento Valor Abatimento: ' + FloatToStr(_ConsultarItem.PagamentoValorAbatimento));
        mmoResposta.Lines.Add('  Impress�o Visualizada: ' + BoolToStr(_ConsultarItem.ImpressaoVisualizada, True));   //Converte o retorno para "False" ou "True"
        mmoResposta.Lines.Add('  Impress�o Visualizada Data: ' + (_ConsultarItem.TituloDataImpressaoVisualizada));
        mmoResposta.Lines.Add('');

        { ---> M�todo removido, sendo substitu�do pelo _ConsultarItem.CountTituloMovimentos
               que est� exemplificado logo abaixo do trecho comentado.
        if _ConsultarItem.TituloOcorrencias <> nil then
        begin
          mmoResposta.Lines.Add('  LISTA DE OCORR�NCIAS:');
          for j := 0 to _ConsultarItem.TituloOcorrencias.Count - 1 do
          begin
            mmoResposta.Lines.Add('    C�digo: ' + IntToStr(j+1) + ': ' + _ConsultarItem.TituloOcorrencias.Item[j].Codigo);
            mmoResposta.Lines.Add('    Mensagem: ' + IntToStr(j+1) + ': ' + _ConsultarItem.TituloOcorrencias.Item[j].Mensagem);
          end;
          mmoResposta.Lines.Add('------------');
        end;
        }


        for k := 0 to _ConsultarItem.CountTituloMovimentos -1 do
        begin
           mmoResposta.Lines.Add('  MOVIMENTOS:');
           mmoResposta.Lines.Add('  Movimento C�digo: '  + _ConsultarItem.TituloMovimentos[k].Codigo);
           mmoResposta.Lines.Add('  Movimento Mensagem: '  + _ConsultarItem.TituloMovimentos[k].Mensagem);
           mmoResposta.Lines.Add('  Movimento Data: '  + _ConsultarItem.TituloMovimentos[k].Data);
           mmoResposta.Lines.Add('  Movimento Taxa: '  + FloatToStr(_ConsultarItem.TituloMovimentos[k].Taxa));
           for l := 0 to _ConsultarItem.TituloMovimentos[k].CountOcorrencias -1 do
            begin
              mmoResposta.Lines.Add('  OCORR�NCIAS:');
              mmoResposta.Lines.Add('     Ocorr�ncias C�digo: '  + _ConsultarItem.TituloMovimentos[k].Ocorrencias[l].Codigo);
              mmoResposta.Lines.Add('     Ocorr�ncias Mensagem: '  + _ConsultarItem.TituloMovimentos[k].Ocorrencias[l].Mensagem);
            end;
        mmoResposta.Lines.Add('');
        end;

      end;

      _ConsultarList.PaginaSeguinte;           //Utilize este par�metro quando a consulta for feita com mais de 1000 idIntegracao por vez. O While far� a consulta de 20 em 20 idIntegracao, e o "PaginaSeguinte" repete a consulta enquanto houverem p�ginas a serem consultadas.

    end;

  finally
    mmoResposta.Lines.EndUpdate;
  end;

end;


procedure TfrmExemploBoletoX.btnConsultarMovimentacaoClick(Sender: TObject);
var
  _ConsMovList: IspdRetConsultarMovimentacaoLista;
  _ConsMovItem: IspdRetConsultarItem;

  _DataInicial, _DataFinal: TDateTime;
  i, j: Integer;
begin
  mmoResposta.Lines.Clear;
  mmoResposta.Refresh;
  mmoResposta.Lines.BeginUpdate;
  try
    _DataInicial := StrToDate(medtDataInicial.Text);
    _DataFinal := StrToDate(medtDataFinal.Text);
    InicioTempoResposta;
    _ConsMovList := FBoletoX.ConsultarMovimentacao(_DataInicial, _DataFinal);
    FimTempoResposta;

    mmoResposta.Lines.Clear;
    mmoResposta.Lines.Add('.:: CONSULTAR MOVIMENTA��O ::.');
    mmoResposta.Lines.Add('Mensagem: ' + _ConsMovList.Mensagem);
    mmoResposta.Lines.Add('Status: ' + _ConsMovList.Status);
    mmoResposta.Lines.Add('');

    for i := 0 to _ConsMovList.Count - 1 do
    begin
      _ConsMovItem := _ConsMovList.Item[i];
      mmoResposta.Lines.Add('ITEM: ' + IntToStr(i+1));
      mmoResposta.Lines.Add('IdIntegracao: ' + _ConsMovItem.IdIntegracao);
      mmoResposta.Lines.Add('');
      mmoResposta.Lines.Add('CEDENTE:');
      mmoResposta.Lines.Add('Agencia: ' + _ConsMovItem.CedenteAgencia);
      mmoResposta.Lines.Add('AgenciaDV: ' + _ConsMovItem.CedenteAgenciaDV);
      mmoResposta.Lines.Add('C�digo Banco: ' + _ConsMovItem.CedenteCodigoBanco);
      mmoResposta.Lines.Add('Carteira: ' + _ConsMovItem.CedenteCarteira);
      mmoResposta.Lines.Add('Conta: ' + _ConsMovItem.CedenteConta);
      mmoResposta.Lines.Add('Numero Conv�nio: ' + _ConsMovItem.CedenteNumeroConvenio);
      mmoResposta.Lines.Add('');
      mmoResposta.Lines.Add('T�TULO:');
      mmoResposta.Lines.Add('Nosso Numero: ' + _ConsMovItem.TituloNossoNumero);
      mmoResposta.Lines.Add('NumeroDocumento: ' + _ConsMovItem.TituloNumeroDocumento);
      mmoResposta.Lines.Add('Valor Desconto: ' + FloatToStr(_ConsMovItem.TituloValorDesconto));
      mmoResposta.Lines.Add('Valor Outros Acrescimos: ' + FloatToStr(_ConsMovItem.TituloValorOutrosAcrescimos));
      mmoResposta.Lines.Add('Valor Abatimento: ' + FloatToStr(_ConsMovItem.TituloValorAbatimento));
      mmoResposta.Lines.Add('');

      if _ConsMovItem.TituloOcorrencias <> nil then
      begin
        mmoResposta.Lines.Add('  OCORR�NCIAS:');
        for j := 0 to _ConsMovItem.TituloOcorrencias.Count - 1 do
        begin
          mmoResposta.Lines.Add('C�digo: ' + IntToStr(j+1) + ': ' + _ConsMovItem.TituloOcorrencias.Item[j].Codigo);
          mmoResposta.Lines.Add('Mensagem: ' + IntToStr(j+1) + ': ' + _ConsMovItem.TituloOcorrencias.Item[j].Mensagem);
        end;
        mmoResposta.Lines.Add('');
      end;

      mmoResposta.Lines.Add('ERRO:');
      mmoResposta.Lines.Add('Mensagem: ' + _ConsMovItem.Situacao);
      mmoResposta.Lines.Add('');
    end;
  finally
    mmoResposta.Lines.EndUpdate;
  end;
end;


procedure TfrmExemploBoletoX.btnConsultarRemessaBaixadaClick(Sender: TObject);
var
  _RetornoConsultarBaixa: IspdRetConsultarRemessaBaixaLista;
  _RetornoConsultarBaixaItem: IspdRetConsultarRemessaBaixaItem;
  i, j: Integer;
  //_remessa: TStringList;
begin
  mmoResposta.Lines.Clear;
  mmoResposta.Refresh;
  mmoResposta.Lines.BeginUpdate;
  //_remesa := TStringList.Create;
  try
    InicioTempoResposta;
    _RetornoConsultarBaixa := FBoletoX.ConsultarRemessaBaixa(edtProcotoloRemessaBaixada.Text);
    FimTempoResposta;
    mmoResposta.Lines.Clear;
    mmoResposta.Lines.Add('.:: CONSULTA BAIXA ::.');
    mmoResposta.Lines.Add('Mensagem: ' + _RetornoConsultarBaixa.Mensagem);
    mmoResposta.Lines.Add('Status: ' + _RetornoConsultarBaixa.Status);
    mmoResposta.Lines.Add('Situa��o: ' + _RetornoConsultarBaixa.Situacao);
    if AnsiSameText(_RetornoConsultarBaixa.Status, 'ERRO') then
      mmoResposta.Lines.Add('ErroClasse: ' + ConverteErroClasse(_RetornoConsultarBaixa.ErroClasse));
    if _RetornoConsultarBaixa.ErroConexao <> '' then
      mmoResposta.Lines.Add('Erro Conex�o: ' + _RetornoConsultarBaixa.ErroConexao);
    mmoResposta.Lines.Add('');
   for i := 0 to _RetornoConsultarBaixa.Count - 1 do
    begin
      _RetornoConsultarBaixaItem := _RetornoConsultarBaixa.Item[i];
      mmoResposta.Lines.Add('ITEM: ' + IntToStr(i+1));
      mmoResposta.Lines.Add('  Mensagem: ' + _RetornoConsultarBaixaItem.Mensagem);
      mmoResposta.Lines.Add('  Remessa: ' + _RetornoConsultarBaixaItem.Remessa);
      //  _remessa.Text := _RetornoConsultarBaixaItem.Remessa;
      //  _remessa.SaveToFile('c:\remessa.txt');
      mmoResposta.Lines.Add('  Banco: ' + _RetornoConsultarBaixaItem.Banco);
      mmoResposta.Lines.Add('  Conta: ' + _RetornoConsultarBaixaItem.Conta);
      mmoResposta.Lines.Add('  Convenio: ' + _RetornoConsultarBaixaItem.Convenio);
      mmoResposta.Lines.Add('  N�mero Atual da Remessa: ' + IntToStr(_RetornoConsultarBaixaItem.NumeroAtualRemessa));
      mmoResposta.Lines.Add('  Transmiss�o autom�tica?: ' + BoolToStr(_RetornoConsultarBaixaItem.TransmissaoAutomatica));
      mmoResposta.Lines.Add('  Erro: ' + _RetornoConsultarBaixaItem.Erro);
      mmoResposta.Lines.Add('  ErroClasse: ' + ConverteErroClasse(_RetornoConsultarBaixaItem.ErroClasse));
     for j := 0 to _RetornoConsultarBaixaItem.Titulos.Count-1 do
      begin
        mmoResposta.Lines.Add('  IdIntegracao ' + IntToStr(j+1) + ': ' + _RetornoConsultarBaixaItem.Titulos.Item[j]);
      end;
      mmoResposta.Lines.Add('');
    end;
    
  finally
    mmoResposta.Lines.EndUpdate;
  end;

end;


procedure TfrmExemploBoletoX.btnConsultarRetornoProcessamentoClick(Sender: TObject);
var
  _RetornoConsultarProcessamento: IspdRetConsultarRetornoProcessamento;
  _RetornoConsultarProcessamentoItem: IspdRetConsultarRetornoProcessamentoItem;
  _RetornoConsultarProcessamentoItemNaoConciliado : IspdRetConsultarRetornoProcessamentoItemNaoConciliado;
  i, j: Integer;
begin
  mmoResposta.Lines.Clear;
  mmoResposta.Refresh;
  mmoResposta.Lines.BeginUpdate;
  try
    InicioTempoResposta;
    _RetornoConsultarProcessamento := FBoletoX.ConsultaRetornoProcessamento(edtProtocoloRetornoProcessamento.Text);
    FimTempoResposta;

    mmoResposta.Lines.Clear;
    mmoResposta.Lines.Add('.:: CONSULTA RETORNO PROCESSAMENTO ::.');
    mmoResposta.Lines.Add('Mensagem: ' + _RetornoConsultarProcessamento.Mensagem);
    mmoResposta.Lines.Add('Status: ' + _RetornoConsultarProcessamento.Status);
    mmoResposta.Lines.Add('Situa��o: ' + _RetornoConsultarProcessamento.Situacao);

    if _RetornoConsultarProcessamento.ErroConexao <> '' then
      mmoResposta.Lines.Add('Erro Conex�o: ' + _RetornoConsultarProcessamento.ErroConexao);

    if AnsiSameText(_RetornoConsultarProcessamento.Status, 'ERRO') then
      mmoResposta.Lines.Add('ErroClasse: ' + ConverteErroClasse(_RetornoConsultarProcessamento.ErroClasse));

    mmoResposta.Lines.Add('');

    for i := 0 to _RetornoConsultarProcessamento.Count - 1 do
    begin
      _RetornoConsultarProcessamentoItem := _RetornoConsultarProcessamento.Titulos[i];
      mmoResposta.Lines.Add('TITULO: ' + IntToStr(i+1));
      mmoResposta.Lines.Add('  idIntegracao: ' + _RetornoConsultarProcessamentoItem.IdIntegracao);
      mmoResposta.Lines.Add('');
    end;

    for i := 0 to _RetornoConsultarProcessamento.CountTitulosNaoConciliados - 1 do
    begin
      _RetornoConsultarProcessamentoItemNaoConciliado := _RetornoConsultarProcessamento.TitulosNaoConciliados[i];
      mmoResposta.Lines.Add('TITULO N�O CONCILIADO: ' + IntToStr(i+1));
      mmoResposta.Lines.Add('  Codigo Movimento: ' + _RetornoConsultarProcessamentoItemNaoConciliado.CodigoMovimento);
      mmoResposta.Lines.Add('  Nosso Numero: ' + _RetornoConsultarProcessamentoItemNaoConciliado.TituloNossoNumero);
      mmoResposta.Lines.Add('  Nosso Numero Original: ' + _RetornoConsultarProcessamentoItemNaoConciliado.TituloNossoNumeroOriginal);
      mmoResposta.Lines.Add('  N�mero do Documento: ' + _RetornoConsultarProcessamentoItemNaoConciliado.TituloNumeroDocumento);
      mmoResposta.Lines.Add('  Data Vencimeto: ' + _RetornoConsultarProcessamentoItemNaoConciliado.TituloDataVencimento);
      mmoResposta.Lines.Add('  Valor Pago: ' + FloatToStr(_RetornoConsultarProcessamentoItemNaoConciliado.PagamentoValorPago));
      mmoResposta.Lines.Add('  Valor Cr�dito: ' + FloatToStr(_RetornoConsultarProcessamentoItemNaoConciliado.PagamentoValorCredito));
      mmoResposta.Lines.Add('  Valor Taxa Cobran�a: ' + FloatToStr(_RetornoConsultarProcessamentoItemNaoConciliado.PagamentoValorTaxaCobranca));
      mmoResposta.Lines.Add('  Valor Acr�scimos: ' + FloatToStr(_RetornoConsultarProcessamentoItemNaoConciliado.PagamentoValorAcrescimos));
      mmoResposta.Lines.Add('  Data Pagamento: ' + _RetornoConsultarProcessamentoItemNaoConciliado.PagamentoData);
      mmoResposta.Lines.Add('  Data Credito: ' + _RetornoConsultarProcessamentoItemNaoConciliado.PagamentoDataCredito);
      mmoResposta.Lines.Add('  T�tulo Pago: ' + BoolToStr(_RetornoConsultarProcessamentoItemNaoConciliado.PagamentoRealizado));
      mmoResposta.Lines.Add('');

      for j := 0 to _RetornoConsultarProcessamentoItemNaoConciliado.CountOcorrencias - 1 do
        mmoResposta.Lines.Add('Ocorr�ncia ' + IntToStr(j+1) + ': ' + _RetornoConsultarProcessamentoItemNaoConciliado.Ocorrencias[j]);

      mmoResposta.Lines.Add('');

      for j := 0 to _RetornoConsultarProcessamentoItemNaoConciliado.CountCodigosOcorrencias - 1 do
        mmoResposta.Lines.Add('C�digo Ocorr�ncia ' + IntToStr(j+1) + ': ' + _RetornoConsultarProcessamentoItemNaoConciliado.CodigosOcorrencias[j]);

      mmoResposta.Lines.Add('');
    end;

  finally
    mmoResposta.Lines.EndUpdate;
  end;
end;


procedure TfrmExemploBoletoX.btnDescartarBoletosClick(Sender: TObject);
var
  _DescarteList: IspdretDescartarLista;
  _DescarteItem: IspdRetDescartarTituloItem;
  i: Integer;
begin
  mmoResposta.Lines.Clear;
  mmoResposta.Refresh;
  mmoResposta.Lines.BeginUpdate;
  try
    InicioTempoResposta;
    _DescarteList := FBoletoX.Descartar(edtIdIntegracao.Text);
    FimTempoResposta;

    mmoResposta.Lines.Clear;
    mmoResposta.Lines.Add('.:: DESCARTAR ::.');
    mmoResposta.Lines.Add('Mensagem: ' + _DescarteList.Mensagem);
    mmoResposta.Lines.Add('Status: ' + _DescarteList.Status);
    if AnsiSameText(_DescarteList.Status, 'ERRO') then
      mmoResposta.Lines.Add('ErroClasse: ' + ConverteErroClasse(_DescarteList.ErroClasse));

    mmoResposta.Lines.Add('');

    for i := 0 to _DescarteList.Count - 1 do
    begin
      _DescarteItem := _DescarteList.Item[i];
      mmoResposta.Lines.Add('ITEM: ' + IntToStr(i+1));
      mmoResposta.Lines.Add('  IdIntegracao: ' + _DescarteItem.IdIntegracao);
      mmoResposta.Lines.Add('  Erro: ' + _DescarteItem.Erro);
      mmoResposta.Lines.Add('  ErroClasse: ' + ConverteErroClasse(_DescarteItem.ErroClasse));

      mmoResposta.Lines.Add('');
    end;
    
  finally
    mmoResposta.Lines.EndUpdate;
  end;

end;


procedure TfrmExemploBoletoX.btnEnviarEmailClick(Sender: TObject);
var
  _BoletoList: IspdRetEnvioEmail;
begin
  mmoResposta.Lines.Clear;
  mmoResposta.Refresh;
  mmoResposta.Lines.BeginUpdate;
  
  try
    InicioTempoResposta;
    _BoletoList := FBoletoX.EnviarEmail(mmoTX2.Text);
    FimTempoResposta;

    mmoResposta.Lines.Clear;
    mmoResposta.Lines.Add('.:: E-Mail Boleto ::.');
    mmoResposta.Lines.Add('');
    mmoResposta.Lines.Add('Mensagem: ' + _BoletoList.Mensagem);
    mmoResposta.Lines.Add('Status: ' + _BoletoList.Status);
    
    if AnsiSameText(_BoletoList.Status, 'ERRO') then
      mmoResposta.Lines.Add('ErroClasse: ' + ConverteErroClasse(_BoletoList.ErroClasse));
      
    mmoResposta.Lines.Add('');

    mmoResposta.SelStart := 1;
    mmoResposta.SelLength := 1;

  finally
    mmoResposta.Lines.EndUpdate;
  end;
end;


procedure TfrmExemploBoletoX.btnEnviarEmailLoteClick(Sender: TObject);
var
  _EnviarEmailLoteResposta: IspdRetEnvioEmailLote;
begin
  mmoResposta.Lines.Clear;
  mmoResposta.Refresh;
  mmoResposta.Lines.BeginUpdate;

  try
    _EnviarEmailLoteResposta := FBoletoX.EnviarEmailLote(mmoTX2.Text);


    mmoResposta.Lines.Clear;
    mmoResposta.Lines.Add('.:: Enviar Email Lote ::.');
    mmoResposta.Lines.Add('Mensagem: ' + _EnviarEmailLoteResposta.Mensagem);
    mmoResposta.Lines.Add('Status: ' + _EnviarEmailLoteResposta.Status);
    mmoResposta.Lines.Add('Protocolo: ' + _EnviarEmailLoteResposta.Protocolo);

    edtProtocoloEmailLote.Text :=  _EnviarEmailLoteResposta.Protocolo;

    if AnsiSameText(_EnviarEmailLoteResposta.Status, 'ERRO') then
      mmoResposta.Lines.Add('ErroClasse: ' + ConverteErroClasse(_EnviarEmailLoteResposta.ErroClasse));

    if _EnviarEmailLoteResposta.ErroConexao <> '' then
      mmoResposta.Lines.Add('Erro Conex�o: ' + _EnviarEmailLoteResposta.ErroConexao);

    mmoResposta.Lines.Add('');

    mmoResposta.SelStart := 1;
    mmoResposta.SelLength := 1;


  finally
    mmoResposta.Lines.EndUpdate;
  end;
end;



procedure TfrmExemploBoletoX.btnGerarRemessaClick(Sender: TObject);
var
  _RemessaList: IspdRetGerarRemessaLista;
  _RemessaItem: IspdRetGerarRemessaItem;
  i, j: Integer;
  conteudoRemessa: TStringList;
begin
  mmoResposta.Lines.Clear;
  mmoResposta.Refresh;
  mmoResposta.Lines.BeginUpdate;
  
  try
    InicioTempoResposta;
    _RemessaList := FBoletoX.GerarRemessa(edtIdIntegracao.Text);
    FimTempoResposta;

    mmoResposta.Lines.Clear;
    mmoResposta.Lines.Add('.:: GERAR REMESSA ::.');
    mmoResposta.Lines.Add('Mensagem: ' + _RemessaList.Mensagem);
    mmoResposta.Lines.Add('Status: ' + _RemessaList.Status);
    mmoResposta.Lines.Add('');

    for i := 0 to _RemessaList.Count - 1 do
    begin
      _RemessaItem := _RemessaList.Item[i];
      mmoResposta.Lines.Add('ITEM: ' + IntToStr(i+1));
      mmoResposta.Lines.Add('  Mensagem: ' + _RemessaItem.Mensagem);
      mmoResposta.Lines.Add('  Remessa: ' + _RemessaItem.Remessa);
      mmoResposta.Lines.Add('  Banco: ' + _RemessaItem.Banco);
      mmoResposta.Lines.Add('  Conta: ' + _RemessaItem.Conta);
      mmoResposta.Lines.Add('  N�mero Atual da Remessa: ' + IntToStr(_RemessaItem.NumeroAtualRemessa));
      mmoResposta.Lines.Add('  Transmiss�o autom�tica?: ' + BoolToStr(_RemessaItem.TransmissaoAutomatica));
      mmoResposta.Lines.Add('  Erro: ' + _RemessaItem.Erro);

      conteudoRemessa := TStringList.Create;                           // ---
      conteudoRemessa.Text := UTF8Encode(_RemessaItem.Remessa);               //    |--> Salva o conte�do da remessa em um arquivo texto
      conteudoRemessa.SaveToFile('C:\Temp\conteudoRemessaUTF8.txt');   // ---

      for j := 0 to _RemessaItem.Titulos.Count-1 do
      begin
        mmoResposta.Lines.Add('  IdIntegracao ' + IntToStr(j+1) + ': ' + _RemessaItem.Titulos.Item[j]);
      end;

      mmoResposta.Lines.Add('');

      conteudoRemessa.Free;

    end;
    
  finally
    mmoResposta.Lines.EndUpdate;

  end;
end;


procedure TfrmExemploBoletoX.btnGerarTx2Click(Sender: TObject);
var
   ControleNossoNumero: TStringList;
   NossoNumeroAtual: integer;
   aux,dataAtual : string;
   dataFutura,dataDesconto : TDateTime;

begin
  //mmoTX2.Clear;
  ControleNossoNumero := TStringList.Create;
  ControleNossoNumero.LoadFromFile(ExtractFilePath(ParamStr(0)) + '\ControleNossoNumero.txt');  //captura o conte�do do arquivo de contole do NossoNumero
  aux := Trim(ControleNossoNumero.Text);
  NossoNumeroAtual := StrToInt(aux);        //Converte para inteiro o NossoNumero que veio do arquivo

  dataAtual := FormatDateTime('dd/mm/yyyy',now);

  dataFutura := IncDay(Now,15);      //incrementa a nota em 15 dias


  dataDesconto := incDay (Now,5);  //incrementa a nota em 5 dias

  //In�cio do preenchimento do tx2
  mmoTx2.Lines.Add('INCLUIRBOLETO');
  mmoTx2.Lines.Add('CedenteContaNumero=12345');
  mmoTx2.Lines.Add('CedenteContaNumeroDV=6');
  mmoTx2.Lines.Add('CedenteConvenioNumero=1234123456');
  mmoTx2.Lines.Add('CedenteContaCodigoBanco=341');
  mmoTx2.Lines.Add('TituloDocEspecie=06');
  mmoTx2.Lines.Add('');
  mmoTx2.Lines.Add('SacadoEmail=sacado@teste.com.br');
  mmoTx2.Lines.Add('SacadoNome=Sacado Teste');
  mmoTx2.Lines.Add('SacadoCPFCNPJ=01001001000113');
  mmoTx2.Lines.Add('SacadoEnderecoCEP=87020025');
  mmoTx2.Lines.Add('SacadoCelular=440000000');
  mmoTx2.Lines.Add('SacadoEnderecoNumero=716');
  mmoTx2.Lines.Add('SacadoEnderecoBairro=Jd Washington');
  mmoTx2.Lines.Add('SacadoEnderecoCidade=Maringa');
  mmoTx2.Lines.Add('SacadoEnderecoLogradouro=AV. BRASIL');
  mmoTx2.Lines.Add('SacadoEnderecoPais=BRASIL');
  mmoTx2.Lines.Add('SacadoEnderecoUF=PR');
  mmoTx2.Lines.Add('SacadoTelefone=4433333333');
  mmoTx2.Lines.Add('');
  mmoTx2.Lines.Add('TituloNossoNumero=' + IntToStr(NossoNumeroAtual));
  mmoTx2.Lines.Add('TituloNumeroDocumento=00015');
  mmoTx2.Lines.Add('TituloDataVencimento=' + DateToStr(dataFutura));
  mmoTx2.Lines.Add('TituloDataEmissao=' + dataAtual);
  mmoTx2.Lines.Add('TituloValor=1,01');
  mmoTx2.Lines.Add('');
  mmoTx2.Lines.Add('TituloMensagem01=Mensagem linha 1');
  mmoTx2.Lines.Add('TituloMensagem02=Mensagem linha 2');
  mmoTx2.Lines.Add('TituloMensagem03=Mensagem linha 3');
  mmoTx2.Lines.Add('');
  mmoTx2.Lines.Add('TituloInformacoesAdicionais=Teste inf.Adcionais: Numero NF: 0');
  mmoTx2.Lines.Add('TituloInstrucoes=Teste Instrucoes: Desconto de 5% ate '+ DateToStr(dataDesconto));
  mmoTx2.Lines.Add('');
  mmoTx2.Lines.Add('SALVARBOLETO');

  NossoNumeroAtual := NossoNumeroAtual + 1;
  ControleNossoNumero.Text := IntToStr(NossoNumeroAtual);
  ControleNossoNumero.SaveToFile(ExtractFilePath(ParamStr(0)) + '\ControleNossoNumero.txt');
end;


procedure TfrmExemploBoletoX.btnImprimirClick(Sender: TObject);
var
  _Impressao: IspdRetImprimir;

begin
  mmoResposta.Lines.Clear;
  mmoResposta.Refresh;
  mmoResposta.Lines.BeginUpdate;

  try
    InicioTempoResposta;
    _Impressao := FBoletoX.Imprimir(edtIdIntegracao.Text, cbbImpressora.Text);
    FimTempoResposta;

    mmoResposta.Lines.Clear;
    mmoResposta.Lines.Add('.:: IMPRIMIR BOLETO ::.');
    mmoResposta.Lines.Add('Mensagem: ' + _Impressao.Mensagem);
    mmoResposta.Lines.Add('Status: ' + _Impressao.Status);
    if _Impressao.ErroConexao <> '' then
      mmoResposta.Lines.Add('Erro Conex�o: ' + _Impressao.ErroConexao);
    mmoResposta.Lines.Add('');
    
  finally
    mmoResposta.Lines.EndUpdate;
  end;

end;


procedure TfrmExemploBoletoX.btnImprimirLoteClick(Sender: TObject);
var
  _Impressao: IspdRetConsultarLoteImpressao;
begin
  mmoResposta.Lines.Clear;
  mmoResposta.Refresh;
  mmoResposta.Lines.BeginUpdate;
  
  try
    InicioTempoResposta;
    _Impressao := FBoletoX.ConsultarLoteImpressao(edtProtocoloRetornoImpressaoLote.Text, cbbImpressora.Text);
    FimTempoResposta;
    mmoResposta.Lines.Clear;
    mmoResposta.Lines.Add('.:: CONSULTAR PROTOCOLO LOTE IMPRESS�O ::.');
    mmoResposta.Lines.Add('Situacao: ' + _Impressao.Situacao);    //'PROCESSANDO': impress�o em processamento  // 'PROCESSADA': impress�o processada com sucesso  //  'FALHA': erro ao gerar a impress�o. (O erro estar� preenchido na propriedade Mensagem)  //  'CANCELADA': impress�o abortada
    mmoResposta.Lines.Add('Mensagem: ' + _Impressao.Mensagem);
    mmoResposta.Lines.Add('Status: ' + _Impressao.Status);
    if _Impressao.ErroConexao <> '' then
      mmoResposta.Lines.Add('Erro Conex�o: ' + _Impressao.ErroConexao);
    if AnsiSameText(_Impressao.Status, 'ERRO') then
      mmoResposta.Lines.Add('ErroClasse: ' + ConverteErroClasse(_Impressao.ErroClasse));
      
    mmoResposta.Lines.Add('');
    
  finally
    mmoResposta.Lines.EndUpdate;
  end;
end;


procedure TfrmExemploBoletoX.btnIncluirClick(Sender: TObject);
var
  _BoletoList: IspdRetIncluirLista;
  i: Integer;
  listaIdsIntegracao: string;
begin
  mmoResposta.Lines.Clear;
  mmoResposta.Refresh;
  mmoResposta.Lines.BeginUpdate;
  
  try
    InicioTempoResposta;
    _BoletoList := FBoletoX.Incluir(mmoTX2.Lines.Text);
    FimTempoResposta;

    mmoResposta.Lines.Clear;
    mmoResposta.Lines.Add('.:: Incluir Boleto ::.');
    mmoResposta.Lines.Add('Mensgem: ' + _BoletoList.Mensagem);
    mmoResposta.Lines.Add('Status: ' + _BoletoList.Status);
    mmoResposta.Lines.Add('');

    for i := 0 to _BoletoList.Count -1 do
    begin
      mmoResposta.Lines.Add('Item: ' + IntToStr(i+1));
      mmoResposta.Lines.Add('  NumeroDocumento: ' + _BoletoList[i].NumeroDocumento);
      mmoResposta.Lines.Add('  IdIntegracao: ' + _BoletoList[i].IdIntegracao);
      mmoResposta.Lines.Add('  Situacao: ' + _BoletoList[i].Situacao);
      mmoResposta.Lines.Add('  NossoNumero: ' + _BoletoList[i].NossoNumero);
      mmoResposta.Lines.Add('  Banco: ' + _BoletoList[i].Banco);
      mmoResposta.Lines.Add('  Conta: ' + _BoletoList[i].Conta);
      mmoResposta.Lines.Add('  Convenio: ' + _BoletoList[i].Convenio);
      mmoResposta.Lines.Add('  Erro: ' + _BoletoList[i].Erro);
      mmoResposta.Lines.Add('  ErroClasse: ' + ConverteErroClasse(_BoletoList[i].ErroClasse));
      mmoResposta.Lines.Add('');

      if i = 0 then                                       //este if identifica se foi feito o envio de 1 boleto por tx2 ou de um lote de boletos, para alimentar os campos que recebem os idIntegracao
      listaIdsIntegracao := _BoletoList[i].IdIntegracao
      else
      listaIdsIntegracao := _BoletoList[i].IdIntegracao + ',' + listaIdsIntegracao;

      edtIdIntegracao.Text  := listaIdsIntegracao;

    end;

    mmoResposta.SelStart  := 1;
    mmoResposta.SelLength := 1;
    
  finally
    mmoResposta.Lines.EndUpdate;
    //mmoTX2.Lines.Clear;
  end;
end;


procedure TfrmExemploBoletoX.btnGerarRemessaAlteracaoClick(Sender: TObject);
var
  _GerarResposta: IspdRetGerarRemessaAlteracao;
begin

  mmoResposta.Lines.Clear;
  mmoResposta.Refresh;
  mmoResposta.Lines.BeginUpdate;
  
  try
    if cbbTipoRemessaAlteracao.ItemIndex = 0 then
    begin
      _GerarResposta := FBoletoX.GerarRemessaAlteracao('0', mmoTX2.Text); //Tipo "0" indica a altera��o de vencimento
      mmoResposta.Lines.Add('.:: Gerar altera��o de Vencimento ::.');
    end
    else
    begin
      _GerarResposta := FBoletoX.GerarRemessaAlteracao('1', mmoTX2.Text);  //Tipo "1" indica a altera��o de valor
      mmoResposta.Lines.Add('.:: Gerar altera��o de Valor ::.')
    end ;    

    if _GerarResposta.Protocolo <> EmptyStr then
      edtProtocoloRetornoRemessaAlteracao.Text := _GerarResposta.Protocolo;

    mmoResposta.Lines.Add('Mensagem: ' + _GerarResposta.Mensagem);
    mmoResposta.Lines.Add('Status: ' + _GerarResposta.Status);
    mmoResposta.Lines.Add('Protocolo: ' + _GerarResposta.Protocolo);
    
    if AnsiSameText(_GerarResposta.Status, 'ERRO') then
      mmoResposta.Lines.Add('ErroClasse: ' + ConverteErroClasse(_GerarResposta.ErroClasse));
      
    mmoResposta.Lines.Add('');
    
  finally
    mmoResposta.Lines.EndUpdate;
  end;
end;


procedure TfrmExemploBoletoX.AbrirPDFClick(Sender: TObject);
begin
  //Este n�o � um m�todo do componente. Apenas um m�todo do Delphi implementado para facilitar a visualiza��o do PDF gerado nos m�todos de impress�o/PDF
  AbrirPDFGravado.Visible := True;   //Ativa o componente OleContainer  no form

  if FileExists(dlgSalvarPDF.FileName) then
      begin
         AbrirPDFGravado.AutoActivate:= aaGetFocus;
         AbrirPDFGravado.CreateLinkToFile(dlgSalvarPDF.FileName,TRUE);
         AbrirPDFGravado.SetFocus;
      end
   else
      MessageDlg('Arquivo n�o encontrado!!!' , mtInformation,[mbOk], 0);


  AbrirPDFGravado.Visible := False;   //Desativa o componente OleContainer  no form
end;

procedure TfrmExemploBoletoX.btnAlterarCedenteClick(Sender: TObject);
var
  _AlterarCedente: IspdRetAlterarCedente;
  _Id: WideString;
begin
  mmoResposta.Lines.Clear;
  mmoResposta.Refresh;
  mmoResposta.Lines.BeginUpdate;
  try
    InicioTempoResposta;
    _Id := edtIDCedente.Text;
    _AlterarCedente := FBoletoX.AlterarCedente(_Id, mmoTX2.Lines.Text);
    FimTempoResposta;
    mmoResposta.Lines.Clear;
    mmoResposta.Lines.Add('.:: Alterar Cedente ::.');
    mmoResposta.Lines.Add('Mensgem: ' + _AlterarCedente.Mensagem);
    mmoResposta.Lines.Add('Status: '  + _AlterarCedente.Status);
    mmoResposta.Lines.Add('');

    if _AlterarCedente.Status = 'SUCESSO' then
    begin
      mmoResposta.Lines.Add('  Id Cedente: '     + _AlterarCedente.IdCedente);
      mmoResposta.Lines.Add('  Situacao: '       + _AlterarCedente.Situacao);
      mmoResposta.Lines.Add('  Token: '          + _AlterarCedente.Token);
      mmoResposta.Lines.Add('  CPF / CNPJ: '     + _AlterarCedente.CpfCnpj);
      mmoResposta.Lines.Add('  Razao Social: '   + _AlterarCedente.RazaoSocial);
      mmoResposta.Lines.Add('  Nome Fantasia: '  + _AlterarCedente.NomeFantasia);
      mmoResposta.Lines.Add('');
    end;

    mmoResposta.SelStart  := 1;
    mmoResposta.SelLength := 1;
  finally
    mmoResposta.Lines.EndUpdate;
    mmoTX2.Lines.Clear;
  end;
end;

procedure TfrmExemploBoletoX.btnAlterarContaClick(Sender: TObject);
var
  _AlterarConta: IspdRetAlterarConta;
  _Id: WideString;
begin
  mmoResposta.Lines.Clear;
  mmoResposta.Refresh;
  mmoResposta.Lines.BeginUpdate;

  try
    _Id := edtIDConta.Text;
    InicioTempoResposta;
    _AlterarConta := FBoletoX.AlterarConta(_Id, mmoTX2.Lines.Text);
    FimTempoResposta;
    mmoResposta.Lines.Clear;
    mmoResposta.Lines.Add('.:: Alterar Conta ::.');
    mmoResposta.Lines.Add('Mensagem: ' + _AlterarConta.Mensagem);
    mmoResposta.Lines.Add('Status: '   + _AlterarConta.Status);
    mmoResposta.Lines.Add('Erro de conex�o: ' + _AlterarConta.ErroConexao);
    mmoResposta.Lines.Add('');


    if _AlterarConta.Status = 'SUCESSO' then
    begin
      mmoResposta.Lines.Add('  Id Conta: '            + _AlterarConta.IdConta);
      mmoResposta.Lines.Add('  C�digo Banco: '        + _AlterarConta.CodigoBanco);
      mmoResposta.Lines.Add('  Ag�ncia: '             + _AlterarConta.Agencia);
      mmoResposta.Lines.Add('  Ag�nciaDV: '           + _AlterarConta.AgenciaDV);
      mmoResposta.Lines.Add('  Conta: '               + _AlterarConta.Conta);
      mmoResposta.Lines.Add('  Conta DV: '            + _AlterarConta.ContaDV);
      mmoResposta.Lines.Add('  Tipo Conta: '          + _AlterarConta.TipoConta);
      mmoResposta.Lines.Add('  C�digo Benefic�rio: '  + _AlterarConta.CodigoBeneficiario);
      mmoResposta.Lines.Add('  C�digo Empresa: '      + _AlterarConta.CodigoEmpresa);
      mmoResposta.Lines.Add('');
    end;

      mmoResposta.SelStart  := 1;
      mmoResposta.SelLength := 1;
    finally
        mmoResposta.Lines.EndUpdate;
        mmoTX2.Lines.Clear;
    end;
end;



procedure TfrmExemploBoletoX.btnAlterarConvenioClick(Sender: TObject);
var
  _AlterarConvenio: IspdRetAlterarConvenio;
  _Id: WideString;
begin
  mmoResposta.Lines.Clear;
  mmoResposta.Refresh;
  mmoResposta.Lines.BeginUpdate;

  try
    InicioTempoResposta;
    _Id := edtIDConvenio.Text;

    _AlterarConvenio := FBoletoX.AlterarConvenio(_Id, mmoTX2.Lines.Text);
    FimTempoResposta;
    mmoResposta.Lines.Clear;
    mmoResposta.Lines.Add('.:: Atualizar Cedente ::.');
    mmoResposta.Lines.Add('Mensagem: ' + _AlterarConvenio.Mensagem);
    mmoResposta.Lines.Add('Status: '   + _AlterarConvenio.Status);
    mmoResposta.Lines.Add('');

    if _AlterarConvenio.Status = 'SUCESSO' then
    begin
      mmoResposta.Lines.Add('  Id Conv�nio: '              + _AlterarConvenio.IdConvenio);
      mmoResposta.Lines.Add('  N�mero Conv�nio: '          + _AlterarConvenio.NumeroConvenio);
      mmoResposta.Lines.Add('  Descri��o: '                + _AlterarConvenio.DescricaoConvenio);
      mmoResposta.Lines.Add('  Carteira: '                 + _AlterarConvenio.Carteira);
      mmoResposta.Lines.Add('  Esp�cie: '                  + _AlterarConvenio.Especie);
      mmoResposta.Lines.Add('  Padr�o CNAB: '              + _AlterarConvenio.PadraoCNAB);
      mmoResposta.Lines.Add('  Utiliza VAN: '              + BoolToStr(_AlterarConvenio.UtilizaVan));
      mmoResposta.Lines.Add('  N�mero Remessa: '           + _AlterarConvenio.NumeroRemessa);
      mmoResposta.Lines.Add('  Reiniciar N�mero Remessa: ' + BoolToStr(_AlterarConvenio.ReiniciarDiariamente));
      mmoResposta.Lines.Add('');
    end;
    mmoResposta.SelStart  := 1;
    mmoResposta.SelLength := 1;

  finally
    mmoResposta.Lines.EndUpdate;
    mmoTX2.Lines.Clear;
  end;
end;

procedure TfrmExemploBoletoX.btnCadastrarCedenteClick(Sender: TObject);
var
  _Cedente: IspdRetCadastrarCedente;
begin
  mmoResposta.Lines.Clear;
  mmoResposta.Refresh;
  mmoResposta.Lines.BeginUpdate;
  try
    InicioTempoResposta;
    _Cedente := FBoletoX.CadastrarCedente (mmoTX2.Lines.Text);
    FimTempoResposta;

    mmoResposta.Lines.Clear;
    mmoResposta.Lines.Add('.:: Cadastrar Cedente ::.');
    mmoResposta.Lines.Add('Mensgem: '          + _Cedente.Mensagem);
    mmoResposta.Lines.Add('Status: '           + _Cedente.Status);
    mmoResposta.Lines.Add('Erro de conex�o: '  + _Cedente.ErroConexao);
    mmoResposta.Lines.Add('');

    if _Cedente.Status = 'SUCESSO' then
    begin
      mmoResposta.Lines.Add('  Id Cedente: '     + _Cedente.IdCedente);
      mmoResposta.Lines.Add('  Situacao: '       + _Cedente.Situacao);
      mmoResposta.Lines.Add('  Token: '          + _Cedente.Token);
      mmoResposta.Lines.Add('  CPF / CNPJ: '     + _Cedente.CpfCnpj);
      mmoResposta.Lines.Add('  Razao Social: '   + _Cedente.RazaoSocial);
      mmoResposta.Lines.Add('  Nome Fantasia: '  + _Cedente.NomeFantasia);
      mmoResposta.Lines.Add('');
    end;

    mmoResposta.SelStart  := 1;
    mmoResposta.SelLength := 1;

    edtIDCedente.Text := _Cedente.IdCedente;

  finally
    mmoResposta.Lines.EndUpdate;
    mmoTX2.Lines.Clear;
  end;
end;

procedure TfrmExemploBoletoX.btnCadastrarContaClick(Sender: TObject);
var
  _Conta: IspdRetCadastrarConta;
begin
  mmoResposta.Lines.Clear;
  mmoResposta.Refresh;
  mmoResposta.Lines.BeginUpdate;
  try
    InicioTempoResposta;
    _Conta := FBoletoX.CadastrarConta(mmoTX2.Lines.Text);
    FimTempoResposta;

    mmoResposta.Lines.Clear;
    mmoResposta.Lines.Add('.:: Cadastrar Conta ::.');
    mmoResposta.Lines.Add('Mensgem: '          + _Conta.Mensagem);
    mmoResposta.Lines.Add('Status: '           + _Conta.Status);
    mmoResposta.Lines.Add('Erro de conex�o: '  + _Conta.ErroConexao);
    mmoResposta.Lines.Add('');

    if _Conta.Status = 'SUCESSO' then
    begin
      mmoResposta.Lines.Add('  Id Conta: '            + _Conta.IdConta);
      mmoResposta.Lines.Add('  C�digo Banco: '        + _Conta.CodigoBanco);
      mmoResposta.Lines.Add('  Ag�ncia: '             + _Conta.Agencia);
      mmoResposta.Lines.Add('  Ag�nciaDV: '           + _Conta.AgenciaDV);
      mmoResposta.Lines.Add('  Conta: '               + _Conta.Conta);
      mmoResposta.Lines.Add('  Conta DV: '            + _Conta.ContaDV);
      mmoResposta.Lines.Add('  Tipo Conta: '          + _Conta.TipoConta);
      mmoResposta.Lines.Add('  C�digo Benefic�rio: '  + _Conta.CodigoBeneficiario);
      mmoResposta.Lines.Add('  C�digo Empresa: '      + _Conta.CodigoEmpresa);
      mmoResposta.Lines.Add('');
    end;

    edtIDConta.Text := _Conta.IdConta;

    mmoResposta.SelStart  := 1;
    mmoResposta.SelLength := 1;
  finally
    mmoResposta.Lines.EndUpdate;
    mmoTX2.Lines.Clear;
  end;
end;

procedure TfrmExemploBoletoX.btnCadastrarConvenioClick(Sender: TObject);
var
  _Convenio: IspdRetCadastrarConvenio;
begin
  mmoResposta.Lines.Clear;
  mmoResposta.Refresh;
  mmoResposta.Lines.BeginUpdate;
  try
    InicioTempoResposta;
    _Convenio := FBoletoX.CadastrarConvenio(mmoTX2.Lines.Text);
    FimTempoResposta;

    mmoResposta.Lines.Clear;
    mmoResposta.Lines.Add('.:: Cadastrar Conv�nio ::.');
    mmoResposta.Lines.Add('Mensgem: '         + _Convenio.Mensagem);
    mmoResposta.Lines.Add('Status: '          + _Convenio.Status);
    mmoResposta.Lines.Add('Erro de conex�o: ' + _Convenio.ErroConexao);
    mmoResposta.Lines.Add('');

    if _Convenio.Status = 'SUCESSO' then
    begin
      mmoResposta.Lines.Add('  Id Conv�nio: '               + _Convenio.IdConvenio);
      mmoResposta.Lines.Add('  N�mero Conv�nio: '           + _Convenio.NumeroConvenio);
      mmoResposta.Lines.Add('  Descri��o: '                 + _Convenio.DescricaoConvenio);
      mmoResposta.Lines.Add('  Carteira: '                  + _Convenio.Carteira);
      mmoResposta.Lines.Add('  Esp�cie: '                   + _Convenio.Especie);
      mmoResposta.Lines.Add('  Padr�o CNAB: '               + _Convenio.PadraoCNAB);
      mmoResposta.Lines.Add('  Utiliza VAN: '               + BoolToStr(_Convenio.UtilizaVan));
      mmoResposta.Lines.Add('  N�mero Remessa: '            + _Convenio.NumeroRemessa);
      mmoResposta.Lines.Add('  Reiniciar N�mero Remessa: '  + BoolToStr(_Convenio.ReiniciarDiariamente));
      mmoResposta.Lines.Add('');
    end;

    edtIDConvenio.Text := _Convenio.IdConvenio;

    mmoResposta.SelStart  := 1;
    mmoResposta.SelLength := 1;
  finally
    mmoResposta.Lines.EndUpdate;
    mmoTX2.Lines.Clear;
  end;
end;

procedure TfrmExemploBoletoX.btnCarregarConfigClick(Sender: TObject);
var
   CNPJSofwareHouse, TokenSofwareHouse, CNPJCedente : string;
begin
  mmoResposta.Clear;
  mmoTX2.Clear;

  if rgAmbiente.ItemIndex = 0 then
  begin
     FBoletoX.Config.URL := 'http://cobrancabancaria.tecnospeed.com.br';
     mmoResposta.Text := (FBoletoX.Config.URL);
  end
  else
  begin
    FBoletoX.Config.URL := 'http://homologacao.cobrancabancaria.tecnospeed.com.br';
    mmoResposta.Text := 'Servidor: ' + FBoletoX.Config.URL;
  end;

  if Length(edtServerTestes.Text) > 10 then
  begin
    FBoletoX.Config.URL := edtServerTestes.Text;    //Esta configura��o � usada apenas para testes internos, em m�quinas de valida��o. Portanto, voc� n�o precisa implementar este IF
    mmoResposta.Text := 'Servidor: ' + FBoletoX.Config.URL
  end;

  CNPJSofwareHouse := edtCNPJSoftwareHouse.Text;
  TokenSofwareHouse := edtTokenSoftwareHouse.Text;
  CNPJCedente := edtCNPJCedente.Text;

  FBoletoX.ConfigurarSoftwareHouse(CNPJSofwareHouse, TokenSofwareHouse);
  FBoletoX.Config.CedenteCpfCnpj := CNPJCedente;
  FBoletoX.OnException := DoOnBoletoException;
  FBoletoX.OnProgress := DoOnBoletoProgress;
  FBoletoX.Config.SalvarLogs := true;                  //Salva os logs na pasta em que se encontra o exe do projeto
end;


procedure TfrmExemploBoletoX.btnSalvarPDFClick(Sender: TObject);
var
  _SalvarPDF: IspdRetSalvarPDF;
begin
  if dlgSalvarPDF.Execute then
  begin
    mmoResposta.Lines.Clear;
    mmoResposta.Refresh;
    mmoResposta.Lines.BeginUpdate;
    
    try
      InicioTempoResposta;
      _SalvarPDF := FBoletoX.SalvarPDF(edtIdIntegracao.Text, dlgSalvarPDF.FileName);
      FimTempoResposta;

      mmoResposta.Lines.Clear;
      mmoResposta.Lines.Add('.:: SALVANDO PDF ::.');
      mmoResposta.Lines.Add('Mensagem: ' + _SalvarPDF.Mensagem);
      mmoResposta.Lines.Add('Status: ' + _SalvarPDF.Status);
          if _SalvarPDF.ErroConexao <> '' then
      mmoResposta.Lines.Add('Erro Conex�o: ' + _SalvarPDF.ErroConexao);

      mmoResposta.Lines.Add('');
      
    finally
      mmoResposta.Lines.EndUpdate;
    end;
  end;
end;


procedure TfrmExemploBoletoX.btnSalvarPDFLoteClick(Sender: TObject);
var
  _SalvarPDFLote: IspdRetSalvarLoteImpressaoPDF;
  numeroConsultas: Integer;

begin
  mmoResposta.Lines.Clear;
  mmoResposta.Refresh;
  mmoResposta.Lines.BeginUpdate;
  numeroConsultas := 1;

 if dlgSalvarPDF.Execute then
  begin
    try
      InicioTempoResposta;

      repeat           // Repete at� que a nossa API tenha terminado de tratar o pedido de impress�o
      begin
        _SalvarPDFLote := FBoletoX.SalvarLoteImpressaoPDF(edtProtocoloRetornoImpressaoLote.Text, dlgSalvarPDF.FileName);

        mmoResposta.Lines.Add('.:: CONSULTAR PROTOCOLO LOTE IMPRESS�O - Tentativa ' + IntToStr(numeroConsultas) + ' ::.');
        mmoResposta.Lines.Add('Situacao: ' + _SalvarPDFLote.Situacao);    //'PROCESSANDO': impress�o em processamento  // 'PROCESSADA': impress�o processada com sucesso  //  'FALHA': erro ao gerar a impress�o. (O erro estar� preenchido na propriedade Mensagem)  //  'CANCELADA': impress�o abortada
        mmoResposta.Lines.Add('Mensagem: ' + _SalvarPDFLote.Mensagem);
        mmoResposta.Lines.Add('Status: '   + _SalvarPDFLote.Status);

        if _SalvarPDFLote.ErroConexao <> '' then
          mmoResposta.Lines.Add('Erro Conex�o: ' + _SalvarPDFLote.ErroConexao);

        if AnsiSameText(_SalvarPDFLote.Status, 'ERRO') then
          mmoResposta.Lines.Add('ErroClasse: ' + ConverteErroClasse(_SalvarPDFLote.ErroClasse));

        if  _SalvarPDFLote.Situacao = 'PROCESSANDO' then
          Sleep(2000);    //'Se o processamento da API ainda n�o terminou, guarda 2 segundos.

        numeroConsultas := numeroConsultas + 1;
        mmoResposta.Lines.Add ('');
      end;

      until (_SalvarPDFLote.Situacao = 'PROCESSADA') and (numeroConsultas < 40);


      FimTempoResposta;

    finally
      mmoResposta.Lines.EndUpdate;
    end;
  end;

end;


procedure TfrmExemploBoletoX.btnSolicitarImpressaoLoteClick(Sender: TObject);
var
  _ImprimirLoteList: IspdRetImprimirLote;
  tipoImpressao : string;
begin
    mmoResposta.Lines.Clear;
    mmoResposta.Refresh;
    mmoResposta.Lines.BeginUpdate;
    try
      if cbbTipoImpressao.ItemIndex = 0 then        // impress�o normal
        tipoImpressao := '0'
      else if cbbTipoImpressao.ItemIndex = 1 then   // impress�o em modo carne duplo (paisagem)
        tipoImpressao := '1'
      else if cbbTipoImpressao.ItemIndex = 2 then   // impress�o em modo carne triplo (retrato)
        tipoImpressao := '2'
      else if cbbTipoImpressao.ItemIndex = 3 then   // impress�o dupla (retrato)
        tipoImpressao := '3'
      else if cbbTipoImpressao.ItemIndex = 4 then   // impress�o com marca d'�gua
        tipoImpressao := '4'
      else tipoImpressao := '99';                   // impress�o em modo personalizado


      InicioTempoResposta;
      _ImprimirLoteList := FBoletoX.ImprimirLote(edtIdIntegracao.Text, tipoImpressao);
      FimTempoResposta;

      if _ImprimirLoteList.Protocolo <> EmptyStr then
        edtProtocoloRetornoImpressaoLote.Text := _ImprimirLoteList.Protocolo;

      mmoResposta.Lines.Clear;
      mmoResposta.Lines.Add('.:: IMPRESS�O EM LOTE ::.');
      mmoResposta.Lines.Add('Mensagem: ' + _ImprimirLoteList.Mensagem);
      mmoResposta.Lines.Add('Status: ' + _ImprimirLoteList.Status);
      mmoResposta.Lines.Add('Protocolo: ' + _ImprimirLoteList.Protocolo);
      
      if AnsiSameText(_ImprimirLoteList.Status, 'ERRO') then
      begin
        mmoResposta.Lines.Add('ErroClasse: ' + ConverteErroClasse(_ImprimirLoteList.ErroClasse));
      end;
      
      mmoResposta.Lines.Add('');
      
    finally
      mmoResposta.Lines.EndUpdate;
    end;
end;


procedure TfrmExemploBoletoX.btnUploadRetornoClick(Sender: TObject);
var
  _UploadRetornoList: IspdRetProcessarRetorno;
  _ConteudoArqRet: WideString;
  _ss: TStringStream;
begin
  if dlgOpenArqRet.Execute then
  begin
    _ss := TStringStream.Create;
    try
      _ss.LoadFromFile(dlgOpenArqRet.FileName);
      _ConteudoArqRet := _ss.DataString;
    finally
      _ss.Free;
    end;

    mmoResposta.Lines.Clear;
    mmoResposta.Refresh;
    mmoResposta.Lines.BeginUpdate;
    
    try
      InicioTempoResposta;
      _UploadRetornoList := FBoletoX.ProcessarRetorno(_ConteudoArqRet); //Passar sempre o conte�do do arquivo, e n�o apenas o caminho
      FimTempoResposta;

      mmoResposta.Lines.Clear;
      mmoResposta.Lines.Add('.:: UPLOAD RETORNO ::.');
      mmoResposta.Lines.Add('Mensagem: ' + _UploadRetornoList.Mensagem);
      mmoResposta.Lines.Add('Status: ' + _UploadRetornoList.Status);
      mmoResposta.Lines.Add('Protocolo: ' + _UploadRetornoList.Protocolo);

      edtProtocoloRetornoProcessamento.Text := _UploadRetornoList.Protocolo;
      if AnsiSameText(_UploadRetornoList.Status, 'ERRO') then
        mmoResposta.Lines.Add('ErroClasse: ' + ConverteErroClasse(_UploadRetornoList.ErroClasse));
        
      mmoResposta.Lines.Add('');
      
    finally
      mmoResposta.Lines.EndUpdate;
    end;
  end;
end;


procedure TfrmExemploBoletoX.Button1Click(Sender: TObject);
var
  _RespostaEmailLote: IspdRetConsultarEmailLote;

begin
  _RespostaEmailLote := FBoletoX.ConsultarEmailLote(edtProtocoloEmailLote.Text);

  mmoResposta.Lines.Clear;
  mmoResposta.Lines.Add('.:: Consulta de emails em Lote ::.');
  mmoResposta.Lines.Add('');
  mmoResposta.Lines.Add('Mensagem: ' + _RespostaEmailLote.Mensagem);
  mmoResposta.Lines.Add('Status: ' + _RespostaEmailLote.Status);
  mmoResposta.Lines.Add('Situa��o: ' + _RespostaEmailLote.Situacao);

  if _RespostaEmailLote.ErroConexao <> '' then
    mmoResposta.Lines.Add('Erro Conex�o: ' + _RespostaEmailLote.ErroConexao);

end;

procedure TfrmExemploBoletoX.btnGerarBaixaClick(Sender: TObject);
var
  _GerarResposta: IspdRetGerarRemessaBaixa;
begin
  mmoResposta.Lines.Clear;
  mmoResposta.Refresh;
  mmoResposta.Lines.BeginUpdate;
  
  try
    InicioTempoResposta;
    _GerarResposta := FBoletoX.GerarRemessaBaixa(edtIdIntegracao.Text);
    FimTempoResposta;
    if _GerarResposta.Protocolo <> EmptyStr then
      edtProcotoloRemessaBaixada.Text := _GerarResposta.Protocolo;
    mmoResposta.Lines.Clear;
    mmoResposta.Lines.Add('.:: GERAR BAIXA ::.');
    mmoResposta.Lines.Add('Mensagem: ' + _GerarResposta.Mensagem);
    mmoResposta.Lines.Add('Status: ' + _GerarResposta.Status);
    mmoResposta.Lines.Add('Protocolo: ' + _GerarResposta.Protocolo);
    
    if AnsiSameText(_GerarResposta.Status, 'ERRO') then
      mmoResposta.Lines.Add('ErroClasse: ' + ConverteErroClasse(_GerarResposta.ErroClasse));
      
    mmoResposta.Lines.Add('');
    
  finally
    mmoResposta.Lines.EndUpdate;
  end;           
end;


procedure TfrmExemploBoletoX.btnGerarRemessaAlteracaoVencimentoClick(Sender: TObject);
var
  _GerarResposta: IspdRetGerarRemessaAlteracao;
begin
  mmoResposta.Lines.Clear;
  mmoResposta.Refresh;
  mmoResposta.Lines.BeginUpdate;
  
  try
    InicioTempoResposta;
    _GerarResposta := FBoletoX.GerarRemessaAlteracao('0', mmoTX2.Text);   //Tipo "0" indica a altera��o de vencimento
    FimTempoResposta;
    if _GerarResposta.Protocolo <> EmptyStr then
      edtProtocoloRetornoRemessaAlteracao.Text := _GerarResposta.Protocolo;
    mmoResposta.Lines.Clear;
    mmoResposta.Lines.Add('.:: Gerar altera��o de vencimento ::.');
    mmoResposta.Lines.Add('Mensagem: ' + _GerarResposta.Mensagem);
    mmoResposta.Lines.Add('Status: ' + _GerarResposta.Status);
    mmoResposta.Lines.Add('Protocolo: ' + _GerarResposta.Protocolo);
    
    if AnsiSameText(_GerarResposta.Status, 'ERRO') then
      mmoResposta.Lines.Add('ErroClasse: ' + ConverteErroClasse(_GerarResposta.ErroClasse));
      
    mmoResposta.Lines.Add('');
    
  finally
    mmoResposta.Lines.EndUpdate;
  end;
end;


procedure TfrmExemploBoletoX.btnConsultarProtocoloRemessaAlteracaoClick(Sender: TObject);
var
  _RetornoConsultarAlteracao: IspdRetConsultarRemessaAlteracaoLista;
  _RetornoConsultarAlteracaoItem: IspdRetConsultarRemessaAlteracaoItem;
  i, j: Integer;
 // _remessa: TStringList;
begin
  mmoResposta.Lines.Clear;
  mmoResposta.Refresh;
  mmoResposta.Lines.BeginUpdate;
  //_remessa := TStringList.Create;
  try
    InicioTempoResposta;
    _RetornoConsultarAlteracao := FBoletoX.ConsultarRemessaAlteracao(edtProtocoloRetornoRemessaAlteracao.Text);
    FimTempoResposta;
    mmoResposta.Lines.Clear;
    mmoResposta.Lines.Add('.:: CONSULTA ALTERACAO ::.');
    mmoResposta.Lines.Add('Mensagem: ' + _RetornoConsultarAlteracao.Mensagem);
    mmoResposta.Lines.Add('Status: ' + _RetornoConsultarAlteracao.Status);
    mmoResposta.Lines.Add('Situa��o: ' + _RetornoConsultarAlteracao.Situacao);
    if _RetornoConsultarAlteracao.ErroConexao <> '' then
      mmoResposta.Lines.Add('Erro Conex�o: ' + _RetornoConsultarAlteracao.ErroConexao);
    
    if AnsiSameText(_RetornoConsultarAlteracao.Status, 'ERRO') then
      mmoResposta.Lines.Add('ErroClasse: ' + ConverteErroClasse(_RetornoConsultarAlteracao.ErroClasse));
      
    mmoResposta.Lines.Add('');
   for i := 0 to _RetornoConsultarAlteracao.Count - 1 do
    begin
      _RetornoConsultarAlteracaoItem := _RetornoConsultarAlteracao.Item[i];
      mmoResposta.Lines.Add('ITEM: ' + IntToStr(i+1));
      mmoResposta.Lines.Add('  Mensagem: ' + _RetornoConsultarAlteracaoItem.Mensagem);
      mmoResposta.Lines.Add('  Remessa: ' + _RetornoConsultarAlteracaoItem.Remessa);
    //  _remessa.Text := _RetornoConsultarAlteracaoItem.Remessa;
    //  _remessa.SaveToFile('c:\remessa.txt');
      mmoResposta.Lines.Add('  Banco: ' + _RetornoConsultarAlteracaoItem.Banco);
      mmoResposta.Lines.Add('  Conta: ' + _RetornoConsultarAlteracaoItem.Conta);
      mmoResposta.Lines.Add('  Convenio: ' + _RetornoConsultarAlteracaoItem.Convenio);
      mmoResposta.Lines.Add('  N�mero Atual da Remessa: ' + IntToStr(_RetornoConsultarAlteracaoItem.NumeroAtualRemessa));
      mmoResposta.Lines.Add('  Transmiss�o autom�tica?: ' + BoolToStr(_RetornoConsultarAlteracaoItem.TransmissaoAutomatica));
      mmoResposta.Lines.Add('  Erro: ' + _RetornoConsultarAlteracaoItem.Erro);
      mmoResposta.Lines.Add('  ErroClasse: ' + ConverteErroClasse(_RetornoConsultarAlteracaoItem.ErroClasse));
     for j := 0 to _RetornoConsultarAlteracaoItem.Titulos.Count-1 do
      begin
        mmoResposta.Lines.Add('  IdIntegracao ' + IntToStr(j+1) + ': ' + _RetornoConsultarAlteracaoItem.Titulos.Item[j]);
      end;
     mmoResposta.Lines.Add('');
    end;
  finally
    mmoResposta.Lines.EndUpdate;
  end;                         
end;


procedure TfrmExemploBoletoX.DoOnBoletoException(ASender: TObject;
  const aExceptionMessage: WideString);
begin
  MessageBox(0, PChar(aExceptionMessage), 'Exce��o do BoletoX', MB_ICONERROR or MB_OK);
end;


procedure TfrmExemploBoletoX.DoOnBoletoProgress(ASender: TObject;
  const aProgressMessage: WideString);
begin
  mmoMensagens.Lines.Add(aProgressMessage);
end;



procedure TfrmExemploBoletoX.InicioTempoResposta;
begin
  lblTempoDeResposta.Caption := '';
  FInicioReq := Now;
end;


procedure TfrmExemploBoletoX.lblLeiaMeClick(Sender: TObject);
begin
  ShellExecute(Handle, 'open', 'http://docs.tecnospeed.com.br/boleto/', '', '', 1);
end;

procedure TfrmExemploBoletoX.FimTempoResposta;
begin
  lblTempoDeResposta.Caption := 'Tempo de Resposta: ' +
  FormatDateTime('nn:ss.zzz', Now - FInicioReq);
end;


procedure TfrmExemploBoletoX.FormCreate(Sender: TObject);
begin
  FBoletoX := TspdBoletoX.Create(nil);

  cbbImpressora.Items.Assign(Printer.Printers);
  cbbImpressora.ItemIndex := 0;
  cbbTipoImpressao.ItemIndex := 0;

  frmExemploBoletoX.Text := 'Exemplo Componente Boleto - Tecnospeed TI: ' + FBoletoX.Versao;

  Application.HintHidePause:=10000;
  AbrirPDFGravado.Visible := False;

  PageControlConfiguracoes.TabIndex := 0

end;


procedure TfrmExemploBoletoX.mmoRespostaKeyDown(Sender: TObject; var Key: Word;    //Habilitar o Control+A no memo
  Shift: TShiftState);
begin
  if (Key = Ord('A')) and (ssCtrl in Shift) then
  begin
    TMemo(Sender).SelectAll;
    Key := 0;
  end;
end;


procedure TfrmExemploBoletoX.mmoTX2KeyDown(Sender: TObject; var Key: Word;         //Habilitar o Control+A no memo
  Shift: TShiftState);
begin
  if (Key = Ord('A')) and (ssCtrl in Shift) then
  begin
    TMemo(Sender).SelectAll;
    Key := 0;
  end;
end;
end.