using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BoletoX;
using System.IO;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public spdBoletoX boletox = new spdBoletoX();
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void btnLoadConfig_Click(object sender, EventArgs e)
        {
            string CNPJSoftwareHouse;
            string TokenSoftwareHouse;
            string CNPJCedente;
            string ambiente;

            if (rdHomologacao.Checked)
            {
                boletox.Config.URL = "http://homologacao.cobrancabancaria.tecnospeed.com.br:8080";
                ambiente = "Homologação";
            }
            else
            {
                boletox.Config.URL = "http://cobrancabancaria.tecnospeed.com.br";
                MessageBox.Show("Atenção: Selecionado ambiente de Produção", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ambiente = "Produção";
            }

            CNPJSoftwareHouse = tBoxCNPJSoftwareHouse.Text;
            TokenSoftwareHouse = tBoxTokenSoftwareHouse.Text;
            CNPJCedente = tBoxCNPJCedente.Text;

            boletox.ConfigurarSoftwareHouse(CNPJSoftwareHouse, TokenSoftwareHouse);
            boletox.Config.CedenteCpfCnpj = CNPJCedente;

            rtResposta.Text = "Selecionado o ambiente de " + ambiente;
        }

        private void tBoxCNPJSoftwareHouse_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCarregarTx2_Click(object sender, EventArgs e)
        {
            dlgTx2.InitialDirectory = Application.StartupPath;
            if (dlgTx2.ShowDialog() == DialogResult.OK)
            {
                rtTx2.Text = System.IO.File.ReadAllText(dlgTx2.FileName);
            }
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            IspdRetIncluirLista _BoletoList;
            string listaIdsIntegracao = "";

            rtResposta.Clear();

            try
            {
                _BoletoList = boletox.Incluir(rtTx2.Text);

                rtResposta.AppendText(".:: Incluir Boleto ::." + Environment.NewLine);
                rtResposta.AppendText("Mensagem: " + _BoletoList.Mensagem + Environment.NewLine);
                rtResposta.AppendText("Status: " + _BoletoList.Status + Environment.NewLine);
                rtResposta.AppendText(Environment.NewLine);

                for (int i = 0; i <= _BoletoList.Count() - 1; i++)
                {
                    rtResposta.AppendText("Item nº " + Convert.ToString(i + 1) + Environment.NewLine);
                    rtResposta.AppendText(" Número do documento: " + _BoletoList[i].NumeroDocumento + Environment.NewLine);
                    rtResposta.AppendText(" IdIntegracao: " + _BoletoList[i].IdIntegracao + Environment.NewLine);
                    rtResposta.AppendText(" Situação: " + _BoletoList[i].Situacao + Environment.NewLine);
                    rtResposta.AppendText(" Nosso Número: " + _BoletoList[i].NossoNumero + Environment.NewLine);
                    rtResposta.AppendText(" Banco: " + _BoletoList[i].Banco + Environment.NewLine);
                    rtResposta.AppendText(" Conta: " + _BoletoList[i].Conta + Environment.NewLine);
                    rtResposta.AppendText(" Convênio: " + _BoletoList[i].Convenio + Environment.NewLine);
                    rtResposta.AppendText(" Erro: " + _BoletoList[i].Erro + Environment.NewLine);
                    rtResposta.AppendText(" ErroClasse: " + _BoletoList.ErroClasse + Environment.NewLine);
                    rtResposta.AppendText(Environment.NewLine);

                    if (i == 0)
                    {
                        listaIdsIntegracao = _BoletoList[i].IdIntegracao;
                    }
                    else
                    {
                        listaIdsIntegracao += "," + _BoletoList[i].IdIntegracao;
                    }

                    tBoxIdIntegracao.Text = listaIdsIntegracao;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            IspdRetConsultarLista _ConsultarLista;
            rtResposta.Clear();

            _ConsultarLista = boletox.Consultar(tBoxIdIntegracao.Text);

            rtResposta.AppendText(".:: Consultar Título ::." + Environment.NewLine);
            rtResposta.AppendText("Mensagem" + _ConsultarLista.Mensagem + Environment.NewLine);
            rtResposta.AppendText("Status" + _ConsultarLista.Status + Environment.NewLine);

            if (_ConsultarLista.Status == "Erro")
            {
                rtResposta.AppendText("ErroClasse: " + _ConsultarLista.ErroClasse.ToString());
            }

            rtResposta.AppendText(Environment.NewLine);

            for (int i = 0; i <= _ConsultarLista.Count() - 1; i++)
            {
                BoletoX.spdRetConsultarTituloItem _ConsultaItem = _ConsultarLista.Item[i];
                rtResposta.AppendText("ITEM: " + Convert.ToString(i + 1) + Environment.NewLine);
                rtResposta.AppendText("  IdIntegracao: " + _ConsultaItem.IdIntegracao + Environment.NewLine);
                rtResposta.AppendText("  Situacao: " + _ConsultaItem.Situacao + Environment.NewLine);
                rtResposta.AppendText("  Motivo: " + _ConsultaItem.Motivo + Environment.NewLine);
                rtResposta.AppendText(Environment.NewLine);
                rtResposta.AppendText("CEDENTE: " + Environment.NewLine);
                rtResposta.AppendText("  Agencia: " + _ConsultaItem.CedenteAgencia + Environment.NewLine);
                rtResposta.AppendText("  AgenciaDV: " + _ConsultaItem.CedenteAgenciaDV + Environment.NewLine);
                rtResposta.AppendText("  Código Banco: " + _ConsultaItem.CedenteCodigoBanco + Environment.NewLine);
                rtResposta.AppendText("  Carteira: " + _ConsultaItem.CedenteCarteira + Environment.NewLine);
                rtResposta.AppendText("  Conta: " + _ConsultaItem.CedenteConta + Environment.NewLine);
                rtResposta.AppendText("  Numero Convênio: " + _ConsultaItem.CedenteNumeroConvenio + Environment.NewLine);
                rtResposta.AppendText(Environment.NewLine);
                rtResposta.AppendText("SACADO: " + Environment.NewLine);
                rtResposta.AppendText("  CPFCNPJ: " + _ConsultaItem.SacadoCPFCNPJ + Environment.NewLine);
                rtResposta.AppendText("  Nome: " + _ConsultaItem.SacadoNome + Environment.NewLine);
                rtResposta.AppendText("  Telefone: " + _ConsultaItem.SacadoTelefone + Environment.NewLine);
                rtResposta.AppendText("  Email: " + _ConsultaItem.SacadoEmail + Environment.NewLine);
                rtResposta.AppendText("  Endereço Número: " + _ConsultaItem.SacadoEnderecoNumero + Environment.NewLine);
                rtResposta.AppendText("  Endereço Bairro: " + _ConsultaItem.SacadoEnderecoBairro + Environment.NewLine);
                rtResposta.AppendText("  Endereço CEP: " + _ConsultaItem.SacadoEnderecoCEP + Environment.NewLine);
                rtResposta.AppendText("  Endereço Cidade: " + _ConsultaItem.SacadoEnderecoCidade + Environment.NewLine);
                rtResposta.AppendText("  Endereço Complemento: " + _ConsultaItem.SacadoEnderecoComplemento + Environment.NewLine);
                rtResposta.AppendText("  Endereço Logradouro: " + _ConsultaItem.SacadoEnderecoLogradouro + Environment.NewLine);
                rtResposta.AppendText("  Endereço País: " + _ConsultaItem.SacadoEnderecoPais + Environment.NewLine);
                rtResposta.AppendText("  Endereço UF: " + _ConsultaItem.SacadoEnderecoUF + Environment.NewLine);
                rtResposta.AppendText(Environment.NewLine);
                rtResposta.AppendText("TÍTULO: " + Environment.NewLine);
                rtResposta.AppendText("  Número Documento: " + _ConsultaItem.TituloNumeroDocumento + Environment.NewLine);
                rtResposta.AppendText("  Origem Documento: " + _ConsultaItem.TituloOrigemDocumento + Environment.NewLine);
                rtResposta.AppendText("  Nosso Número: " + _ConsultaItem.TituloNossoNumero + Environment.NewLine);
                rtResposta.AppendText("  Data Emissão: " + _ConsultaItem.TituloDataEmissao + Environment.NewLine);
                rtResposta.AppendText("  Data Vencimento: " + _ConsultaItem.TituloDataVencimento + Environment.NewLine);
                rtResposta.AppendText("  Data Desconto: " + _ConsultaItem.TituloDataDesconto + Environment.NewLine);
                rtResposta.AppendText("  Valor Desconto: " + _ConsultaItem.TituloValorDesconto + Environment.NewLine);
                rtResposta.AppendText("  Valor Juros: " + _ConsultaItem.TituloValorJuros + Environment.NewLine);
                rtResposta.AppendText("  Prazo Protesto: " + _ConsultaItem.TituloPrazoProtesto + Environment.NewLine);
                rtResposta.AppendText("  Mensagem 1: " + _ConsultaItem.TituloMensagem01 + Environment.NewLine);
                rtResposta.AppendText("  Mensagem 2: " + _ConsultaItem.TituloMensagem02 + Environment.NewLine);
                rtResposta.AppendText("  Mensagem 3: " + _ConsultaItem.TituloMensagem03 + Environment.NewLine);
                rtResposta.AppendText("  Valor: " + _ConsultaItem.TituloValor + Environment.NewLine);
                rtResposta.AppendText("  Data Crédito: " + _ConsultaItem.PagamentoDataCredito + Environment.NewLine);
                rtResposta.AppendText("  Título Pago: " + _ConsultaItem.PagamentoRealizado + Environment.NewLine);
                rtResposta.AppendText("  Valor Crédito: " + _ConsultaItem.PagamentoValorCredito + Environment.NewLine);
                rtResposta.AppendText("  Valor Outros Acréscimos: " + _ConsultaItem.TituloValorOutrosAcrescimos + Environment.NewLine);
                rtResposta.AppendText("  Valor Pago: " + _ConsultaItem.PagamentoValorPago + Environment.NewLine);
                rtResposta.AppendText("  Valor Taxa Cobrança: " + _ConsultaItem.PagamentoValorTaxaCobranca + Environment.NewLine);
                rtResposta.AppendText("  Valor Abatimento: " + _ConsultaItem.TituloValorAbatimento + Environment.NewLine);
                rtResposta.AppendText("  Valor Outras Despesas: " + _ConsultaItem.PagamentoValorOutrasDespesas + Environment.NewLine);
                rtResposta.AppendText("  Valor IOF: " + _ConsultaItem.PagamentoValorIOF + Environment.NewLine);
                rtResposta.AppendText("  Data Pagamento: " + _ConsultaItem.PagamentoData + Environment.NewLine);
                rtResposta.AppendText("  Valor Outros Créditos: " + _ConsultaItem.PagamentoValorOutrosCreditos + Environment.NewLine);
                rtResposta.AppendText("  Pagamento Valor Desconto: " + _ConsultaItem.PagamentoValorDesconto + Environment.NewLine);
                rtResposta.AppendText("  Pagamento Valor Acréscimos: " + _ConsultaItem.PagamentoValorAcrescimos + Environment.NewLine);
                rtResposta.AppendText("  Pagamento Valor Abatimento: " + _ConsultaItem.PagamentoValorAbatimento + Environment.NewLine);
                rtResposta.AppendText("  Impressão Visualizada: " + _ConsultaItem.ImpressaoVisualizada.ToString() + Environment.NewLine);
                rtResposta.AppendText(Environment.NewLine);

                if (_ConsultaItem.TituloOcorrencias != null)
                {
                    rtResposta.AppendText("OCORRÊNCIAS: " + Environment.NewLine);
                    for (int j = 0; j <= _ConsultaItem.TituloOcorrencias.Count() - 1; j++)
                    {
                        rtResposta.AppendText("Codigo: " + _ConsultaItem.TituloOcorrencias.Item[j].Codigo + Environment.NewLine);
                        rtResposta.AppendText("Mensagem: " + _ConsultaItem.TituloOcorrencias.Item[j].Mensagem + Environment.NewLine);


                    }
                }
            }
        }

        private void btnDescartarBoletos_Click(object sender, EventArgs e)
        {
            IspdRetDescartarLista _DescarteLlist;
            IspdRetDescartarTituloItem _DescarteItem;

            rtResposta.Clear();
            rtTx2.Clear();

            _DescarteLlist = boletox.Descartar(tBoxIdIntegracao.Text);

            rtResposta.AppendText(".:: Descartar Boletos ::." + Environment.NewLine);
            rtResposta.AppendText("Mensagem: " + _DescarteLlist.Mensagem + Environment.NewLine);
            rtResposta.AppendText("Status: " + _DescarteLlist.Status + Environment.NewLine);

            if (_DescarteLlist.Status == "ERRO")
            {
                rtResposta.AppendText("ErroClasse" + _DescarteLlist.ErroClasse);
            }

            rtResposta.AppendText(Environment.NewLine);

            for (int i = 0; i <= _DescarteLlist.Count() - 1; i++)
            {
                _DescarteItem = _DescarteLlist.Item[i];
                rtResposta.AppendText("Item: " + Convert.ToString(i) + Environment.NewLine);
                rtResposta.AppendText("IdIntegracao: " + _DescarteItem.IdIntegracao + Environment.NewLine);
                rtResposta.AppendText("Erro " + _DescarteItem.Erro + Environment.NewLine);
                rtResposta.AppendText("ErroClasse " + _DescarteItem.ErroClasse + Environment.NewLine);
                rtResposta.AppendText(Environment.NewLine);
            }
        }

        

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            BoletoX.spdRetImprimir _Impressao = boletox.Imprimir(tBoxIdIntegracao.Text, cbbImpressora.Text);

            rtResposta.AppendText(".:: IMPRIMIR BOLETO ::." + Environment.NewLine);
            rtResposta.AppendText("Mensagem: " + _Impressao.Mensagem + Environment.NewLine);
            rtResposta.AppendText("Status: " + _Impressao.Status + Environment.NewLine);
            rtResposta.AppendText(Environment.NewLine);


        }

        private void btnGerarPDF_Click(object sender, EventArgs e)
        {
            string CaminhoPDF;
            SaveFileDialog svdlg = new SaveFileDialog();

            if (svdlg.ShowDialog() == DialogResult.OK)
            {
                CaminhoPDF = svdlg.FileName;
            }

            BoletoX.spdRetSalvarPDF retorno = boletox.SalvarPDF(tBoxIdIntegracao.Text, svdlg.FileName);

            rtResposta.AppendText(".:: SALVAR PDF ::. " + Environment.NewLine);
            rtResposta.AppendText("Mensagem: " + retorno.Mensagem + Environment.NewLine);
            rtResposta.AppendText("Status: " + retorno.Status + Environment.NewLine);
        }

        private void tbIdIntegraoImpressao_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSolicitarImpressaoLote_Click(object sender, EventArgs e)
        {
            IspdRetImprimirLote _ImprimirLoteList;

            string TipoImpressao;

            rtResposta.Clear();

            if (cbbTipoImpressao.SelectedIndex == 0)
            {
                TipoImpressao = "0";
            }
            else if (cbbTipoImpressao.SelectedIndex == 1)
            {
                TipoImpressao = "1";
            }
            else if (cbbTipoImpressao.SelectedIndex == 2)
            {
                TipoImpressao = "2";
            }
            else if (cbbTipoImpressao.SelectedIndex == 3)
            {
                TipoImpressao = "3";
            }
            else TipoImpressao = "99";

            _ImprimirLoteList = boletox.ImprimirLote(tBoxIdIntegracao.Text, TipoImpressao);

            if (_ImprimirLoteList.Protocolo != null)
            {
                tbProtocoloRetornoImpressaoLote.Text = _ImprimirLoteList.Protocolo;
            }

            rtResposta.Clear();
            rtResposta.AppendText(".:: Impressão em Lote" + Environment.NewLine);
            rtResposta.AppendText("Mensagem: " + _ImprimirLoteList.Mensagem + Environment.NewLine);
            rtResposta.AppendText("Status: " + _ImprimirLoteList.Status + Environment.NewLine);

            if (_ImprimirLoteList.Status == "ERRO")
            {
                rtResposta.AppendText("ErroClasse: " + _ImprimirLoteList.ErroClasse);
            }

            rtResposta.AppendText(Environment.NewLine);
        }

        private void btnImprimirLote_Click(object sender, EventArgs e)
        {
            IspdRetConsultarLoteImpressao _LoteImpressao;

            rtResposta.Clear();
            rtTx2.Clear();

            _LoteImpressao = boletox.ConsultarLoteImpressao(tbProtocoloRetornoImpressaoLote.Text, cbbImpressora.Text);

            rtResposta.AppendText(".:: Consultar Protocolo Lote Impressão");
        }

        private void btnSalvarPDFLote_Click(object sender, EventArgs e)
        {
            IspdRetSalvarLoteImpressaoPDF _SalvarPDFLote;
            string CaminhoPDF;

            rtResposta.Clear();
            rtTx2.Clear();

            SaveFileDialog svdlg = new SaveFileDialog();
            if (svdlg.ShowDialog() == DialogResult.OK)
            {
                CaminhoPDF = svdlg.FileName;
            }

            _SalvarPDFLote = boletox.SalvarLoteImpressaoPDF(tbProtocoloRetornoImpressaoLote.Text, svdlg.FileName);
            rtResposta.AppendText(".:: SALVAR PDF ::." + Environment.NewLine);
            rtResposta.AppendText("Mensagem: " + _SalvarPDFLote.Mensagem + Environment.NewLine);
            rtResposta.AppendText("Status: " + _SalvarPDFLote.Status + Environment.NewLine);

            if (_SalvarPDFLote.Status == "ERRO")
            {
                rtResposta.AppendText("ErroClasse: " + _SalvarPDFLote.ErroClasse + Environment.NewLine);

            }
        }

        private void btnGerarRemessa_Click(object sender, EventArgs e)
        {
            IspdRetGerarRemessaLista _RemessaList;
            IspdRetGerarRemessaItem _RemessaItem;

            rtResposta.Clear();
            rtTx2.Clear();

            _RemessaList = boletox.GerarRemessa(tBoxIdIntegracao.Text);

            rtResposta.Text += ".:: GERAR REMESSA: ::." + Environment.NewLine;
            rtResposta.Text += "Mensagem: " + _RemessaList.Mensagem + Environment.NewLine;
            rtResposta.Text += "Status: " + _RemessaList.Status + Environment.NewLine;

            for (var i = 0; i < _RemessaList.Count(); i++)
            {
                rtResposta.Text += Environment.NewLine;
                _RemessaItem = _RemessaList.Item[i];
                rtResposta.Text += "Item: " + (i + 1).ToString() + Environment.NewLine;

                Encoding utf8WithoutBom = new UTF8Encoding(false);
                using (FileStream fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + @"\Remessas\" + _RemessaItem.Conta + ".txt", FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                {
                    StreamWriter sw = new StreamWriter(fs, utf8WithoutBom);
                    sw.Write(_RemessaItem.Remessa);
                    sw.Flush();
                    sw.Close();
                    fs.Close();

                }

                rtResposta.Text += "Remessa salva no arquivo " + AppDomain.CurrentDomain.BaseDirectory + @"Remessas\" + _RemessaItem.Convenio + ".txt" + Environment.NewLine + Environment.NewLine;   //Usado para salvar a remessa em um arquivo

                rtResposta.Text += "Remessa: " + _RemessaItem.Remessa + Environment.NewLine;
                rtResposta.Text += "Banco: " + _RemessaItem.Banco + Environment.NewLine;
                rtResposta.Text += "Conta: " + _RemessaItem.Conta + Environment.NewLine;
                rtResposta.Text += "Convenio: " + _RemessaItem.Convenio + Environment.NewLine;
                rtResposta.Text += "Erro: " + _RemessaItem.Erro + Environment.NewLine;


                for (var j = 0; j < _RemessaItem.Titulos.Count(); j++)
                {
                    rtResposta.AppendText("IdIntegracao: " + _RemessaItem.Titulos.Item[j] + Environment.NewLine);
                }

            }
        }

        private void cbbTipoImpressao_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbProtocoloRetornoImpressaoLote_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUploadRetorno_Click(object sender, EventArgs e)
        {
            rtResposta.Clear();
            rtTx2.Clear();

            dlgArqRetorno.InitialDirectory = Application.StartupPath;
            if (dlgArqRetorno.ShowDialog() == DialogResult.OK)
            {
                rtTx2.Text = System.IO.File.ReadAllText(dlgArqRetorno.FileName);
            }
            BoletoX.spdRetProcessarRetorno _ProcessarRetorno = boletox.ProcessarRetorno(rtTx2.Text);

            rtResposta.AppendText(" .:: UPLOAD RETORNO " + Environment.NewLine);
            rtResposta.AppendText("Mensagem: " + _ProcessarRetorno.Mensagem + Environment.NewLine);
            rtResposta.AppendText("Status: " + _ProcessarRetorno.Status + Environment.NewLine);
            rtResposta.AppendText("Protocolo: " + _ProcessarRetorno.Protocolo + Environment.NewLine);

            tBoxRetProcessamento.Text = _ProcessarRetorno.Protocolo;

        }

        private void btnConsRetProcessamento_Click(object sender, EventArgs e)
        {
            IspdRetConsultarRetornoProcessamento _RetornoConsultarProcessamento;
            IspdRetConsultarRetornoProcessamentoItem _RetornoConsultarProcessamentoItem;
            IspdRetConsultarRetornoProcessamentoItemNaoConciliado _RetornoConsultarProcessamentoItemNaoConciliado;

            _RetornoConsultarProcessamento = boletox.ConsultaRetornoProcessamento(tBoxRetProcessamento.Text);

            rtResposta.Clear();
            rtResposta.Text += ".:: CONSULTA RETORNO PROCESSAMENTO ::." + Environment.NewLine;
            rtResposta.Text += "Mensagem: " + _RetornoConsultarProcessamento.Mensagem + Environment.NewLine;
            rtResposta.Text += "Status: " + _RetornoConsultarProcessamento.Status + Environment.NewLine;
            rtResposta.Text += "Situação: " + _RetornoConsultarProcessamento.Situacao + Environment.NewLine;

            rtResposta.Text += Environment.NewLine;

            for (var i= 0; i < _RetornoConsultarProcessamento.Count(); i++)   
            {
                _RetornoConsultarProcessamentoItem = _RetornoConsultarProcessamento.Titulos[i];
                rtResposta.Text += "TÍTULO: " + (i + 1).ToString() + Environment.NewLine;
                rtResposta.Text += "IDintegração: " + _RetornoConsultarProcessamentoItem.IdIntegracao + Environment.NewLine;
                rtResposta.Text += Environment.NewLine;  
            }
            for (var j = 0; j < _RetornoConsultarProcessamento.CountTitulosNaoConciliados(); j++)
            {
                _RetornoConsultarProcessamentoItemNaoConciliado = _RetornoConsultarProcessamento.TitulosNaoConciliados[j];
                rtResposta.Text += "Título Não-Conciliado: " + (j + 1).ToString() + Environment.NewLine;
                rtResposta.Text += "   Código do Movimento: " + _RetornoConsultarProcessamentoItemNaoConciliado.CodigoMovimento + Environment.NewLine;
                rtResposta.Text += "   Nosso Número: " + _RetornoConsultarProcessamentoItemNaoConciliado.TituloNossoNumero + Environment.NewLine;
                rtResposta.Text += "   Nosso Número Original: " + _RetornoConsultarProcessamentoItemNaoConciliado.TituloNossoNumeroOriginal + Environment.NewLine;
                rtResposta.Text += "   Data de Vencimento: " + _RetornoConsultarProcessamentoItemNaoConciliado.TituloDataVencimento + Environment.NewLine;
                rtResposta.Text += "   Valor Pago: " + _RetornoConsultarProcessamentoItemNaoConciliado.PagamentoValorPago + Environment.NewLine;
                rtResposta.Text += "   Valor Crédito: " + _RetornoConsultarProcessamentoItemNaoConciliado.PagamentoValorCredito + Environment.NewLine;
                rtResposta.Text += "   Valor Taxa Cobrança: " + _RetornoConsultarProcessamentoItemNaoConciliado.PagamentoValorTaxaCobranca + Environment.NewLine;
                rtResposta.Text += "   Valor Acréscimos: " + _RetornoConsultarProcessamentoItemNaoConciliado.PagamentoValorAcrescimos + Environment.NewLine;
                rtResposta.Text += "   Data Pagamento: " + _RetornoConsultarProcessamentoItemNaoConciliado.PagamentoData + Environment.NewLine;
                rtResposta.Text += "   Data Credito: " + _RetornoConsultarProcessamentoItemNaoConciliado.PagamentoDataCredito + Environment.NewLine;
                rtResposta.Text += "   Título Pago: " + _RetornoConsultarProcessamentoItemNaoConciliado.PagamentoRealizado + Environment.NewLine;
                rtResposta.Text += Environment.NewLine;

                for (var k = 0; k < _RetornoConsultarProcessamentoItemNaoConciliado.CountOcorrencias(); k++)
                {
                    rtResposta.Text += "   Ocorrência:   " + (k + 1).ToString() + ": " + _RetornoConsultarProcessamentoItemNaoConciliado.Ocorrencias[k] + Environment.NewLine;
                }

                for (var l = 0; l < _RetornoConsultarProcessamentoItemNaoConciliado.CountCodigosOcorrencias(); l++)
                {
                    rtResposta.Text += "   Código Ocorrências: " + (l + 1).ToString() + ": " + _RetornoConsultarProcessamentoItemNaoConciliado.CodigosOcorrencias[l] + Environment.NewLine;
                }

                rtResposta.Text += Environment.NewLine;
            }
        }

        private void btnGerarBaixa_Click(object sender, EventArgs e)
        {
            IspdRetGerarRemessaBaixa _GerarResposta;

            rtResposta.Clear();

            _GerarResposta = boletox.GerarRemessaBaixa(tBoxIdIntegracao.Text);

            if(_GerarResposta.Protocolo != "")
            {
                tBoxProcotoloRemessaBaixada.Text = _GerarResposta.Protocolo;
            }

            rtResposta.AppendText(".:: Gerar Remessa de Alteração ::." + Environment.NewLine);
            rtResposta.AppendText("Mensagem: " + _GerarResposta.Mensagem + Environment.NewLine);
            rtResposta.AppendText("Status: " + _GerarResposta.Status + Environment.NewLine);
            rtResposta.AppendText("Protocolo: " + _GerarResposta.Protocolo + Environment.NewLine);

            if(_GerarResposta.Status == "Erro")
            {
                rtResposta.AppendText("ErroClasse: " + _GerarResposta.ErroClasse);
            }
        }

        private void btnConsultarRemessaBaixada_Click(object sender, EventArgs e)
        {
            IspdRetConsultarRemessaBaixaLista _RetornoConsultarBaixa;
            IspdRetConsultarRemessaBaixaItem _RetornoConsultarBaixaItem;

            rtResposta.Clear();
            rtTx2.Clear();

            _RetornoConsultarBaixa = boletox.ConsultarRemessaBaixa(tBoxProcotoloRemessaBaixada.Text);

            rtResposta.AppendText(" .:: Consulta Remessa de Alteração .::" + Environment.NewLine);
            rtResposta.AppendText("Mensagem: " + _RetornoConsultarBaixa.Mensagem + Environment.NewLine);
            rtResposta.AppendText("Status: " + _RetornoConsultarBaixa.Status + Environment.NewLine);
            rtResposta.AppendText("Situação: " + _RetornoConsultarBaixa.Situacao + Environment.NewLine);

            if (_RetornoConsultarBaixa.Status == "ERRO")
            {
                rtResposta.AppendText("ErroClasse: " + _RetornoConsultarBaixa.ErroClasse);
            }

            for(int i = 0; i <= +_RetornoConsultarBaixa.Count() -1; i++)
            {
                _RetornoConsultarBaixaItem = _RetornoConsultarBaixa.Item[i];
                rtResposta.AppendText("Item: " + Convert.ToString(i) + Environment.NewLine);
                rtResposta.AppendText("  Remessa: " + _RetornoConsultarBaixaItem.Remessa + Environment.NewLine);
                rtResposta.AppendText("  Banco: " + _RetornoConsultarBaixaItem.Banco + Environment.NewLine);
                rtResposta.AppendText("  Conta: " + _RetornoConsultarBaixaItem.Conta + Environment.NewLine);
                rtResposta.AppendText("  Convênio: " + _RetornoConsultarBaixaItem.Convenio + Environment.NewLine);
                rtResposta.AppendText("  Erro: " + _RetornoConsultarBaixaItem.Erro + Environment.NewLine);
                rtResposta.AppendText("  ErroClasse: " + _RetornoConsultarBaixaItem.ErroClasse + Environment.NewLine);

                for (int j = 0; j <= _RetornoConsultarBaixaItem.Titulos.Count() - 1; j++)
                {
                    rtResposta.AppendText(" IdIntegracao: " + Convert.ToString(j + 1) + ": " + _RetornoConsultarBaixaItem.Titulos.Item[j]);
                }

                rtResposta.AppendText(Environment.NewLine);
            }
        }

        private void btnGerarRemessaAlteracao_Click(object sender, EventArgs e)
        {
            IspdRetGerarRemessaAlteracao _GerarResposta;
            _GerarResposta = null;

            rtResposta.Clear();
            while (cbbTipoRemessaAlteracao.SelectedIndex == -1)
            {
                MessageBox.Show("Escolha um tipo de remessa de alteração", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cbbTipoRemessaAlteracao.SelectedIndex == 0)
            {
                _GerarResposta = boletox.GerarRemessaAlteracao("0", rtTx2.Text);                        // Tipo 0 indica a alteração de vencimento
                rtResposta.AppendText(".:: Gerar alteração de Vencimento ::." + Environment.NewLine);
            }
            if (cbbTipoRemessaAlteracao.SelectedIndex == 1)
            {
                _GerarResposta = boletox.GerarRemessaAlteracao("1", rtTx2.Text);                        // Tipo 1 indica a alteração de vencimento
                rtResposta.AppendText(".:: Gerar alteração de Valor ::." + Environment.NewLine);
            }


            if (_GerarResposta.Protocolo != "")
            {
                tBoxProtocoloRetornoRemessaAlteracao.Text = _GerarResposta.Protocolo;
            }

            rtResposta.AppendText("Mensagem: " + _GerarResposta.Mensagem + Environment.NewLine);
            rtResposta.AppendText("Status: " + _GerarResposta.Status + Environment.NewLine);
            rtResposta.AppendText("Protocolo: " + _GerarResposta.Protocolo + Environment.NewLine);

            if (_GerarResposta.Status == "Erro")
            {
                rtResposta.AppendText("ErroClasse: " + _GerarResposta.ErroClasse);
            }

        }

        private void btnConsultarProtocoloRemessaAlteracao_Click(object sender, EventArgs e)
        {
            IspdRetConsultarRemessaAlteracaoLista _RetornoConsultarAlteracao;
            IspdRetConsultarRemessaAlteracaoItem _RetornoConsultarAlteracaoItem;

            rtResposta.Clear();
            rtTx2.Clear();

            _RetornoConsultarAlteracao = boletox.ConsultarRemessaAlteracao(tBoxProtocoloRetornoRemessaAlteracao.Text);

            rtResposta.AppendText(".:: Consulta Remessa de Alteração" + Environment.NewLine);
            rtResposta.AppendText("MEnsagem: " + _RetornoConsultarAlteracao.Mensagem + Environment.NewLine);
            rtResposta.AppendText("Status: " + _RetornoConsultarAlteracao.Status + Environment.NewLine);
            rtResposta.AppendText("Situação: " + _RetornoConsultarAlteracao.Situacao + Environment.NewLine);

            if(_RetornoConsultarAlteracao.Status == "ERRO")
            {
                rtResposta.AppendText("ErroClasse: " + _RetornoConsultarAlteracao.ErroClasse);
            }

            for(int i = 0; i<= _RetornoConsultarAlteracao.Count() -1; i++)
            {
                _RetornoConsultarAlteracaoItem = _RetornoConsultarAlteracao.Item[i];
                rtResposta.AppendText("Item: " + Convert.ToString(i) + Environment.NewLine);
                rtResposta.AppendText("  Remessa: " + _RetornoConsultarAlteracaoItem.Remessa + Environment.NewLine);
                rtResposta.AppendText("  Banco: " + _RetornoConsultarAlteracaoItem.Banco + Environment.NewLine);
                rtResposta.AppendText("  Conta: " + _RetornoConsultarAlteracaoItem.Conta + Environment.NewLine);
                rtResposta.AppendText("  Convênio: " + _RetornoConsultarAlteracaoItem.Convenio + Environment.NewLine);
                rtResposta.AppendText("  Erro: " + _RetornoConsultarAlteracaoItem.Erro + Environment.NewLine);
                rtResposta.AppendText("  ErroClasse: " + _RetornoConsultarAlteracaoItem.ErroClasse + Environment.NewLine);

                for (int j =0; j <= _RetornoConsultarAlteracaoItem.Titulos.Count() -1; j++)
                {
                    rtResposta.AppendText("IdIntegracao: " + Convert.ToString(j + 1) + ": " + _RetornoConsultarAlteracaoItem.Titulos.Item[j]);
                }

                rtResposta.AppendText(Environment.NewLine);

            }
        }

        private void tBoxProtocoloRetornoRemessaAlteracao_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void cbbImpressora_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnEnviarEmailLote_Click(object sender, EventArgs e)
        {
            IspdRetEnvioEmailLote _EnviarEmailLoteResposta;
           
            rtResposta.Clear();

            _EnviarEmailLoteResposta = boletox.EnviarEmailLote(rtTx2.Text);

            

            rtResposta.AppendText("### Enviar Email Lote ###" + Environment.NewLine);
            rtResposta.AppendText("Mensagem: " + _EnviarEmailLoteResposta.Mensagem + Environment.NewLine);
            rtResposta.AppendText("Status: " + _EnviarEmailLoteResposta.Status + Environment.NewLine);
            rtResposta.AppendText("Protocolo: " + _EnviarEmailLoteResposta.Protocolo + Environment.NewLine);
            rtResposta.AppendText(Environment.NewLine);

            tbProtocoloEnvioEmail.Text = _EnviarEmailLoteResposta.Protocolo;

            

        }

        private void btnConsultaEmailLote_Click(object sender, EventArgs e)
        {
            IspdRetConsultarEmailLote _RespostaEmailLote;

            rtResposta.Clear();

            _RespostaEmailLote = boletox.ConsultarEmailLote(tbProtocoloEnvioEmail.Text);


            rtResposta.AppendText("### E-Mail enviado com sucesso" + Environment.NewLine);
            rtResposta.AppendText("Mensagem: " + _RespostaEmailLote.Mensagem + Environment.NewLine);
            rtResposta.AppendText("Status: " + _RespostaEmailLote.Status + Environment.NewLine);
            rtResposta.AppendText("Situação: " + _RespostaEmailLote.Situacao + Environment.NewLine);
            rtResposta.AppendText(Environment.NewLine);
        }

        private void tbProtocoloEnvioEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCadastrarCedente_Click(object sender, EventArgs e)
        {
            IspdRetCadastrarCedente _CadastrarCedente;
            
            rtResposta.Clear();
            
             _CadastrarCedente = boletox.CadastrarCedente(rtTx2.Text);

              rtResposta.AppendText(" .:: CADASTRAR CEDENTE ::. " + Environment.NewLine);
              rtResposta.AppendText("Mensagem: " + _CadastrarCedente.Mensagem + Environment.NewLine);
              rtResposta.AppendText("Status: " + _CadastrarCedente.Status + Environment.NewLine);
              rtResposta.AppendText("Erro de Conexão: " + _CadastrarCedente.ErroConexao + Environment.NewLine);
              rtResposta.AppendText(Environment.NewLine);

            if (_CadastrarCedente.Status == "SUCESSO") 
            {
                rtResposta.AppendText(" Id Cedente: " + _CadastrarCedente.IdCedente + Environment.NewLine);
                rtResposta.AppendText(" Situação: " + _CadastrarCedente.Situacao + Environment.NewLine);
                rtResposta.AppendText(" Token: " + _CadastrarCedente.Token + Environment.NewLine);
                rtResposta.AppendText(" CPF/CNPJ: " + _CadastrarCedente.CpfCnpj + Environment.NewLine);
                rtResposta.AppendText(" Razao Social: " + _CadastrarCedente.RazaoSocial + Environment.NewLine);
                rtResposta.AppendText(" Nome Fantasia: " + _CadastrarCedente.NomeFantasia + Environment.NewLine);
                rtResposta.AppendText(Environment.NewLine);
            }
        }

        private void btnCadastrarConta_Click(object sender, EventArgs e)
        {
            IspdRetCadastrarConta _CadastrarConta;

            rtResposta.Clear();

            _CadastrarConta = boletox.CadastrarConta(rtTx2.Text);

            rtResposta.AppendText(" .:: CADASTRAR CONTA ::. " + Environment.NewLine);
            rtResposta.AppendText("Mensagem: " + _CadastrarConta.Mensagem + Environment.NewLine);
            rtResposta.AppendText("Status: " + _CadastrarConta.Status + Environment.NewLine);
            rtResposta.AppendText("Erro de Conexão: " + _CadastrarConta.ErroConexao + Environment.NewLine);
            rtResposta.AppendText(Environment.NewLine);

            if (_CadastrarConta.Status == "SUCESSO")
            {
                rtResposta.AppendText(" Id Conta: " + _CadastrarConta.IdConta + Environment.NewLine);
                rtResposta.AppendText(" Código Banco: " + _CadastrarConta.CodigoBanco + Environment.NewLine);
                rtResposta.AppendText(" Agência: " + _CadastrarConta.Agencia  + Environment.NewLine);
                rtResposta.AppendText(" AgênciaDV: " + _CadastrarConta.AgenciaDV  + Environment.NewLine);
                rtResposta.AppendText(" Conta: " + _CadastrarConta.Conta  + Environment.NewLine);
                rtResposta.AppendText(" Conta DV: " + _CadastrarConta.ContaDV  + Environment.NewLine);
                rtResposta.AppendText(" Tipo Conta: " + _CadastrarConta.TipoConta  + Environment.NewLine);
                rtResposta.AppendText(" Código Beneficiário: " + _CadastrarConta.CodigoBeneficiario  + Environment.NewLine);
                rtResposta.AppendText(" Código Empresa: " + _CadastrarConta.CodigoEmpresa  + Environment.NewLine);
                rtResposta.AppendText(Environment.NewLine);
            }
        }

        private void btnCadastrarConvenio_Click(object sender, EventArgs e)
        {
            IspdRetCadastrarConvenio _CadastrarConvenio;

            rtResposta.Clear();

            _CadastrarConvenio = boletox.CadastrarConvenio(rtTx2.Text);

            rtResposta.AppendText(" .:: CADASTRAR CONVÊNIO ::. " + Environment.NewLine);
            rtResposta.AppendText("Mensagem: " + _CadastrarConvenio.Mensagem + Environment.NewLine);
            rtResposta.AppendText("Status: " + _CadastrarConvenio.Status + Environment.NewLine);
            rtResposta.AppendText("Erro de Conexão: " + _CadastrarConvenio.ErroConexao + Environment.NewLine);
            rtResposta.AppendText(Environment.NewLine);

            if (_CadastrarConvenio.Status == "SUCESSO")
            {
                rtResposta.AppendText(" Id Convênio: " + _CadastrarConvenio.IdConvenio + Environment.NewLine);
                rtResposta.AppendText(" Número Convênio: " + _CadastrarConvenio.NumeroConvenio  + Environment.NewLine);
                rtResposta.AppendText(" Descrição: " + _CadastrarConvenio.DescricaoConvenio + Environment.NewLine);
                rtResposta.AppendText(" Carteira: " + _CadastrarConvenio.Carteira + Environment.NewLine);
                rtResposta.AppendText(" Espécie: " + _CadastrarConvenio.Especie + Environment.NewLine);
                rtResposta.AppendText(" Padrão CNAB: " + _CadastrarConvenio.PadraoCNAB + Environment.NewLine);
                rtResposta.AppendText(" Utiliza VAN: " + _CadastrarConvenio.UtilizaVan  + Environment.NewLine);
                rtResposta.AppendText(" Número Remessa: " + _CadastrarConvenio.NumeroRemessa + Environment.NewLine);
                rtResposta.AppendText(" Reiniciar Número Remessa: " + _CadastrarConvenio.ReiniciarDiariamente + Environment.NewLine);
                rtResposta.AppendText(Environment.NewLine);
            }
        }

        private void Impressora_Click(object sender, EventArgs e)
        {

        }

        private void label5050_Click(object sender, EventArgs e)
        {

        }

        private void tBoxIdIntegracao_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbbTipoRemessaAlteracao_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
