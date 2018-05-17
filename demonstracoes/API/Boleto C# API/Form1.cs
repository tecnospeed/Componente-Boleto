using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Net.Http;
using System.Net;
using System.Web;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using RestSharp;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Web.Script.Serialization;  //Add a referencia System.Web.Extensions no projeto
using System.Runtime.Serialization.Json;

namespace APISoftwareHouse
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        public string TrocaVirgulaPorE(string listaIdIntegracao)
        {
            //Metodo implementado apenas para facilitar a informação do idINtegracao na tela. Ele troca a vírgula que separa os idIntegracao pelo "&idintegracao" que será usado na rota
            string auxiliar;
            auxiliar = listaIdIntegracao.Replace(",", "&idintegracao=");
            return auxiliar;
        }


        private void btnEnviar_Click(object sender, EventArgs e)
        {
            //Método que recebe um  json com os dados do boleto e envia  uma requisição POST para nossa API.
            //O retorno desta requisição é um json que trará o idIntegracao do boleto em caso de sucesso, ou a mensagem de erro/validação em caso de falha.

            //Configura os dados de autenticação:
            string cnpjSH = tBoxCNPJSoftwareHouse.Text;
            string tokenSH = tBoxTokenSoftwareHouse.Text;
            string cnpjCedente = tBoxCNPJCedente.Text;
            string url;

            if (tBoxCNPJSoftwareHouse.Text == "" | tBoxTokenSoftwareHouse.Text == "" | tBoxCNPJCedente.Text == "")
            {
                MessageBox.Show("Dados obrigatórios não preenchidos!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            //Verifica qual o ambiente (produção ou homologação) que será usado para montar a requisição
            if (rdHomologacao.Checked)
            {
                url = "http://homologacao.cobrancabancaria.tecnospeed.com.br:8080";
            }
            else url = "https://cobrancabancaria.tecnospeed.com.br";    



            //Criando o json com os campos do tx2:
            var objCamposBoleto = new object[] { new {CedenteContaNumero = "12345",
                                                      CedenteContaNumeroDV = "6",
                                                      CedenteConvenioNumero = "6543231",
                                                      CedenteContaCodigoBanco = "341",
                                                      SacadoCPFCNPJ = "28436161661",
                                                      SacadoEmail = "email@sacado.com",
                                                      SacadoEnderecoNumero = "987",
                                                      SacadoEnderecoBairro = "Centro",
                                                      SacadoEnderecoCEP = "87098765",
                                                      SacadoEnderecoCidade = "Maringá",
                                                      SacadoEnderecoComplemento = "Fundos",
                                                      SacadoEnderecoLogradouro = "Rua teste, 987",
                                                      SacadoEnderecoPais = "Brasil",
                                                      SacadoEnderecoUF = "PR",
                                                      SacadoNome = "Teste de Souza",
                                                      SacadoTelefone = "4499999999",
                                                      SacadoCelular = "44999999999",
                                                      TituloDataDesconto = "05/01/2020",
                                                      TituloValorDesconto = "0,01",
                                                      TituloDataEmissao = "01/01/2020",
                                                      TituloDataVencimento = "01/01/2020",
                                                      TituloValorJuros = "0,01",
                                                      TituloPrazoProtesto = "30",
                                                      TituloMensagem01 = "Juros de 0,01 ao dia",
                                                      TituloMensagem02 = "Nao receber apos 30 dias de atraso",
                                                      TituloMensagem03 = "Titulo sujeito a protesto apos 30 dias",
                                                      TituloNossoNumero ="1254",
                                                      TituloNumeroDocumento = "01012020",
                                                      TituloValor = "0,02",
                                                      TituloLocalPagamento = "Pagável em qualquer banco até o vencimento." }
                                                      //Demais campos disponíveis em: http://docs.tecnospeed.com.br/boleto/Campos/
                                               };
            JavaScriptSerializer js = new JavaScriptSerializer();
            string strJson = js.Serialize(objCamposBoleto);



            //Inicia a configuração da requisicao:
            var client = new RestClient(url + "/api/v1/boletos/lote");
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            request.AddHeader("token-sh", tokenSH);
            request.AddHeader("cnpj-sh", cnpjSH);
            request.AddHeader("cnpj-cedente", cnpjCedente);
            request.AddParameter("application/json", strJson, ParameterType.RequestBody);

            dynamic json = JObject.Parse(client.Execute(request).Content);
            rtRetorno.Text = JsonConvert.SerializeObject(json, Formatting.Indented);
        }



        private void button1_Click(object sender, EventArgs e)
        {
            //Método que recebe um  idIntegracao (ou uma lista) e dispara uma consulta em nossa API para saber o resultado do processamento deste boleto.
            //O retorno desta requisição é um json que trará os campos do boleto em caso de sucesso, ou a mensagem de erro/validação em caso de falha.

            string cnpjSH = tBoxCNPJSoftwareHouse.Text;
            string tokenSH = tBoxTokenSoftwareHouse.Text;
            string cnpjCedente = tBoxCNPJCedente.Text;
            string url;

            if (tBoxCNPJSoftwareHouse.Text == "" | tBoxTokenSoftwareHouse.Text == "" | tBoxCNPJCedente.Text == "")
            {
                MessageBox.Show("Dados obrigatórios não preenchidos!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if (rdHomologacao.Checked)
            {
                url = "http://homologacao.cobrancabancaria.tecnospeed.com.br:8080";
            }
            else url = "https://cobrancabancaria.tecnospeed.com.br";

            var client = new RestClient(url + "/api/v1/boletos?" + "idintegracao=" + TrocaVirgulaPorE(txtIdIntegracao.Text));
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            request.AddHeader("token-sh", tokenSH);
            request.AddHeader("cnpj-sh", cnpjSH);
            request.AddHeader("cnpj-cedente", cnpjCedente);
           
            dynamic json = JObject.Parse(client.Execute(request).Content);
            rtRetorno.Text = JsonConvert.SerializeObject(json, Formatting.Indented);
        }


        private void btnSolicitarImpressao_Click(object sender, EventArgs e)
        {
            //Método que recebe a lista de idIntegracao e dispara o pedido de impressão
            //Existem 4 tipos de impressão: Normal=0 (1 boleto por página); Dupla=1 (2 boletos em folha retrato paisagem); Tripla=2 (3 boletos por página em modo retrato); e Personalizada=99
            //O retorno deste método é  um numero de protocolo, que usamos na rota "/api/v1/boletos/impressao/lote/:protocolo" para obter o PDF do's boleto's.

            string cnpjSH = tBoxCNPJSoftwareHouse.Text;
            string tokenSH = tBoxTokenSoftwareHouse.Text;
            string cnpjCedente = tBoxCNPJCedente.Text;
            string url;

            if (tBoxCNPJSoftwareHouse.Text == "" | tBoxTokenSoftwareHouse.Text == "" | tBoxCNPJCedente.Text == "")
            {
                MessageBox.Show("Dados obrigatórios não preenchidos!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            //Verifica qual o ambiente (produção ou homologação) que será usado para montar a requisição
            if (rdHomologacao.Checked)
            {
                url = "http://homologacao.cobrancabancaria.tecnospeed.com.br:8080";
            }
            else url = "https://cobrancabancaria.tecnospeed.com.br";


            //Cria um array com os idIntegracao (que estão separados por vírgula)
            string[] idIntegracaoArray;
            idIntegracaoArray = txtIdIntegracao.Text.Split(',');


            //Define qual o tipo de impressão a ser usada: 
            string JsonCompletoImpressaoLote = "";
                     
            if (cbbTipoImpressao.SelectedIndex == 0)
            {
                //Começa a montar o JSON:
                string FormatoImpressao = "0";    //Normal
                var jsonImpressaoLote = new
                {
                    tipoImpressao = FormatoImpressao,
                    boletos =  idIntegracaoArray
                };
                JavaScriptSerializer js = new JavaScriptSerializer();
                JsonCompletoImpressaoLote = js.Serialize(jsonImpressaoLote); //Finaliza o JSON

                rtRetorno.Text = JsonCompletoImpressaoLote;
            }
            else if (cbbTipoImpressao.SelectedIndex == 1)
            {
                string FormatoImpressao = "1";    //Carnê duplo
                var jsonImpressaoLote = new
                {
                    tipoImpressao = FormatoImpressao,
                    boletos = idIntegracaoArray
                };
                JavaScriptSerializer js = new JavaScriptSerializer();
                JsonCompletoImpressaoLote = js.Serialize(jsonImpressaoLote);

                rtRetorno.Text = JsonCompletoImpressaoLote;
            }
            else if (cbbTipoImpressao.SelectedIndex == 2)
            {
                string FormatoImpressao = "2";    //Carnê triplo
                var jsonImpressaoLote = new
                {
                    tipoImpressao = FormatoImpressao,
                    boletos = idIntegracaoArray
                };
                JavaScriptSerializer js = new JavaScriptSerializer();
                JsonCompletoImpressaoLote = js.Serialize(jsonImpressaoLote);

                rtRetorno.Text = JsonCompletoImpressaoLote;
            }
            else
            {
                string FormatoImpressao = "99";    //Impressão personalizada
                var jsonImpressaoLote = new
                {
                    tipoImpressao = FormatoImpressao,
                    boletos = idIntegracaoArray
                };
                JavaScriptSerializer js = new JavaScriptSerializer();
                JsonCompletoImpressaoLote = js.Serialize(jsonImpressaoLote);

                rtRetorno.Text = JsonCompletoImpressaoLote;
            }

            //Inicia a configuração da requisicao:
            var client = new RestClient(url + "/api/v1/boletos/impressao/lote");
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            request.AddHeader("token-sh", tokenSH);
            request.AddHeader("cnpj-sh", cnpjSH);
            request.AddHeader("cnpj-cedente", cnpjCedente);
            request.AddParameter("application/json", JsonCompletoImpressaoLote, ParameterType.RequestBody);



            dynamic json = JObject.Parse(client.Execute(request).Content);
            rtRetorno.Text = JsonConvert.SerializeObject(json, Formatting.Indented);
        }


        private void cbbTipoImpressao_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Método que recebe um o número de protocolo gerado no retorno do pedido de envio da impressão
            //O retorno é o PDF do boleto.

            string cnpjSH = tBoxCNPJSoftwareHouse.Text;
            string tokenSH = tBoxTokenSoftwareHouse.Text;
            string cnpjCedente = tBoxCNPJCedente.Text;
            string url;

            if (tBoxCNPJSoftwareHouse.Text == "" | tBoxTokenSoftwareHouse.Text == "" | tBoxCNPJCedente.Text == "")
            {
                MessageBox.Show("Dados obrigatórios não preenchidos!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if (rdHomologacao.Checked)
            {
                url = "http://homologacao.cobrancabancaria.tecnospeed.com.br:8080";
            }
            else url = "https://cobrancabancaria.tecnospeed.com.br";

            var client = new RestClient(url + "/api/v1/boletos/impressao/lote/" + txtProtocoloImpressao.Text);
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/pdf");
            request.AddHeader("token-sh", tokenSH);
            request.AddHeader("cnpj-sh", cnpjSH);
            request.AddHeader("cnpj-cedente", cnpjCedente);
            
            byte[] response = client.DownloadData(request);
            File.WriteAllBytes(@"C:\Temp\TesteImpressao.pdf", response);   //Salva o conteúdo do PDF

            rtRetorno.Text = "PDF salvo em C:\\Temp\\TesteImpressao.pdf !";
        }

        private void btnGerarRemessa_Click(object sender, EventArgs e)
        {
            //Método que recebe uma listagem de idIntegracao e devolve o conteúdo da remessa (em base64)
            string cnpjSH = tBoxCNPJSoftwareHouse.Text;
            string tokenSH = tBoxTokenSoftwareHouse.Text;
            string cnpjCedente = tBoxCNPJCedente.Text;
            string url;

            if (tBoxCNPJSoftwareHouse.Text == "" | tBoxTokenSoftwareHouse.Text == "" | tBoxCNPJCedente.Text == "")
            {
                MessageBox.Show("Dados obrigatórios não preenchidos!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            //Verifica qual o ambiente (produção ou homologação) que será usado para montar a requisição
            if (rdHomologacao.Checked)
            {
                url = "http://homologacao.cobrancabancaria.tecnospeed.com.br:8080";
            }
            else url = "https://cobrancabancaria.tecnospeed.com.br";



            //Cria um array com os idIntegracao (que estão separados por vírgula):
            string[] idIntegracaoArray;
            idIntegracaoArray = txtIdIntegracao.Text.Split(',');

            //Transforma o Array no formato esperado de JSON:
            var objVet = idIntegracaoArray;
            JavaScriptSerializer js = new JavaScriptSerializer();
            string strJsonRemessa = js.Serialize(objVet);

            //Inicia a configuração da requisicao:
            var client = new RestClient(url + "/api/v1/remessas/lote");
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            request.AddHeader("token-sh", tokenSH);
            request.AddHeader("cnpj-sh", cnpjSH);
            request.AddHeader("cnpj-cedente", cnpjCedente);
            request.AddParameter("application/json", strJsonRemessa, ParameterType.RequestBody); 

            dynamic json = JObject.Parse(client.Execute(request).Content);
            rtRetorno.Text = JsonConvert.SerializeObject(json, Formatting.Indented);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Método que recebe o arquivo de retorno gerado pelo Banco, e envia para nossa API, para que os boletos já emitidos sejam atualizados.
            //Requisição assíncrona, que devolve um protocolo que deve ser consultado posteriormente.
            string cnpjSH = tBoxCNPJSoftwareHouse.Text;
            string tokenSH = tBoxTokenSoftwareHouse.Text;
            string cnpjCedente = tBoxCNPJCedente.Text;
            string url;

            if (tBoxCNPJSoftwareHouse.Text == "" | tBoxTokenSoftwareHouse.Text == "" | tBoxCNPJCedente.Text == "")
            {
                MessageBox.Show("Dados obrigatórios não preenchidos!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            //Verifica qual o ambiente (produção ou homologação) que será usado para montar a requisição
            if (rdHomologacao.Checked)
            {
                url = "http://homologacao.cobrancabancaria.tecnospeed.com.br:8080";
            }
            else url = "https://cobrancabancaria.tecnospeed.com.br";

            var RetornoOriginal = System.Text.Encoding.UTF8.GetBytes(rtRetorno.Text);
            var RetornoBase64 = System.Convert.ToBase64String(RetornoOriginal);

            //Inicia a configuração da requisicao:
            var client = new RestClient(url + "/api/v1/retornos");
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            request.AddHeader("token-sh", tokenSH);
            request.AddHeader("cnpj-sh", cnpjSH);
            request.AddHeader("cnpj-cedente", cnpjCedente);
            request.AddParameter("application/x-www-form-urlencoded", "arquivo=" + RetornoBase64, ParameterType.RequestBody);

            dynamic json = JObject.Parse(client.Execute(request).Content);
            rtRetorno.Text = JsonConvert.SerializeObject(json, Formatting.Indented);
        }

        private void btnConsultaProtRetorno_Click(object sender, EventArgs e)
        {
            //Método que faz a consulta do protocolo obtido na requisição de envio do arquivo de retorno.
            //Devolve um json com as informações dos boletos conciliados ou não conciliados pelo arquivo.
            string cnpjSH = tBoxCNPJSoftwareHouse.Text;
            string tokenSH = tBoxTokenSoftwareHouse.Text;
            string cnpjCedente = tBoxCNPJCedente.Text;
            string url;

            if (tBoxCNPJSoftwareHouse.Text == "" | tBoxTokenSoftwareHouse.Text == "" | tBoxCNPJCedente.Text == "")
            {
                MessageBox.Show("Dados obrigatórios não preenchidos!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            //Verifica qual o ambiente (produção ou homologação) que será usado para montar a requisição
            if (rdHomologacao.Checked)
            {
                url = "http://homologacao.cobrancabancaria.tecnospeed.com.br:8080";
            }
            else url = "https://cobrancabancaria.tecnospeed.com.br";

            //Inicia a configuração da requisicao:
            var client = new RestClient(url + "/api/v1/retornos/" + tbProtocoloUploadRetorno.Text); //Passe o protocolo obtido no envio do arquivo de retorno diretamente na URL
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            request.AddHeader("token-sh", tokenSH);
            request.AddHeader("cnpj-sh", cnpjSH);
            request.AddHeader("cnpj-cedente", cnpjCedente);

            dynamic json = JObject.Parse(client.Execute(request).Content);
            rtRetorno.Text = JsonConvert.SerializeObject(json, Formatting.Indented);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnSolicitarRemessaAlteracao_Click(object sender, EventArgs e)
        {        
            string cnpjSH = tBoxCNPJSoftwareHouse.Text;
            string tokenSH = tBoxTokenSoftwareHouse.Text;
            string cnpjCedente = tBoxCNPJCedente.Text;
            string url;

            if (tBoxCNPJSoftwareHouse.Text == "" | tBoxTokenSoftwareHouse.Text == "" | tBoxCNPJCedente.Text == "")
            {
                MessageBox.Show("Dados obrigatórios não preenchidos!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            //Verifica qual o ambiente (produção ou homologação) que será usado para montar a requisição
            if (rdHomologacao.Checked)
            {
                url = "http://homologacao.cobrancabancaria.tecnospeed.com.br:8080";
            }
            else url = "https://cobrancabancaria.tecnospeed.com.br";




            //Define qual o tipo da remessa de alteração
            string JsonCompletoAlteracao = "";

            if (cbbTipoRemessaAlteracao.SelectedIndex == 0)
            {
                string tipoAlteracao = "0";         //Alteração de vencimento

                var jsonRemessaAlteracao = new
                {
                    tipo = tipoAlteracao,
                    boletos = new object[] { new { idintegracao = txtIdIntegracao.Text, TituloDataVencimento = "20/05/2018" } }
                };
                JavaScriptSerializer js = new JavaScriptSerializer();
                JsonCompletoAlteracao = js.Serialize(jsonRemessaAlteracao);

                rtRetorno.Text = JsonCompletoAlteracao;
            }

            else if (cbbTipoRemessaAlteracao.SelectedIndex == 1)
            {
                string tipoAlteracao = "1";         //Alteração de valor

                var jsonRemessaAlteracao = new
                {
                    tipo = tipoAlteracao,
                    boletos = new object[] { new { idintegracao = txtIdIntegracao.Text, TituloValor = "1,50" } }
                };
                JavaScriptSerializer js = new JavaScriptSerializer();
                JsonCompletoAlteracao = js.Serialize(jsonRemessaAlteracao);

                rtRetorno.Text = JsonCompletoAlteracao;
            }

            //Inicia a configuração da requisicao:
            var client = new RestClient(url + "/api/v1/boletos/altera/lote");
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            request.AddHeader("token-sh", tokenSH);
            request.AddHeader("cnpj-sh", cnpjSH);
            request.AddHeader("cnpj-cedente", cnpjCedente);
            request.AddParameter("application/json", (JsonCompletoAlteracao), ParameterType.RequestBody);


            dynamic json = JObject.Parse(client.Execute(request).Content);
            rtRetorno.Text = JsonConvert.SerializeObject(json, Formatting.Indented);
            
        }

        private void btnConsultaProtRemAlteracao_Click(object sender, EventArgs e)
        {
            string cnpjSH = tBoxCNPJSoftwareHouse.Text;
            string tokenSH = tBoxTokenSoftwareHouse.Text;
            string cnpjCedente = tBoxCNPJCedente.Text;
            string url;

            if (tBoxCNPJSoftwareHouse.Text == "" | tBoxTokenSoftwareHouse.Text == "" | tBoxCNPJCedente.Text == "")
            {
                MessageBox.Show("Dados obrigatórios não preenchidos!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if (rdHomologacao.Checked)
            {
                url = "http://homologacao.cobrancabancaria.tecnospeed.com.br:8080";
            }
            else url = "https://cobrancabancaria.tecnospeed.com.br";

            var client = new RestClient(url + "/api/v1/boletos/altera/lote/" + txtProtocoloRemessaAlteracao.Text);
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/pdf");
            request.AddHeader("token-sh", tokenSH);
            request.AddHeader("cnpj-sh", cnpjSH);
            request.AddHeader("cnpj-cedente", cnpjCedente);

            dynamic json = JObject.Parse(client.Execute(request).Content);
            rtRetorno.Text = JsonConvert.SerializeObject(json, Formatting.Indented);
        }


        private void btnSolicitarBaixa_Click(object sender, EventArgs e)
        {
            string cnpjSH = tBoxCNPJSoftwareHouse.Text;
            string tokenSH = tBoxTokenSoftwareHouse.Text;
            string cnpjCedente = tBoxCNPJCedente.Text;
            string url;

            if (tBoxCNPJSoftwareHouse.Text == "" | tBoxTokenSoftwareHouse.Text == "" | tBoxCNPJCedente.Text == "")
            {
                MessageBox.Show("Dados obrigatórios não preenchidos!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            //Verifica qual o ambiente (produção ou homologação) que será usado para montar a requisição
            if (rdHomologacao.Checked)
            {
                url = "http://homologacao.cobrancabancaria.tecnospeed.com.br:8080";
            }
            else url = "https://cobrancabancaria.tecnospeed.com.br";


            //Cria um array com os idIntegracao (que estão separados por vírgula)
            string[] idIntegracaoArray;
            idIntegracaoArray = txtIdIntegracao.Text.Split(',');

            //Transforma o Array no formato esperado de JSON:
            var objVet = idIntegracaoArray;
            JavaScriptSerializer js = new JavaScriptSerializer();
            string strJsonBaixa = js.Serialize(objVet);


            //Inicia a configuração da requisicao:
            var client = new RestClient(url + "/api/v1/boletos/baixa/lote");
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            request.AddHeader("token-sh", tokenSH);
            request.AddHeader("cnpj-sh", cnpjSH);
            request.AddHeader("cnpj-cedente", cnpjCedente);
            request.AddParameter("application/json", (strJsonBaixa), ParameterType.RequestBody);


            dynamic json = JObject.Parse(client.Execute(request).Content);
            rtRetorno.Text = JsonConvert.SerializeObject(json, Formatting.Indented);

        }

        private void btnConsultarProtBaixa_Click(object sender, EventArgs e)
        {
            string cnpjSH = tBoxCNPJSoftwareHouse.Text;
            string tokenSH = tBoxTokenSoftwareHouse.Text;
            string cnpjCedente = tBoxCNPJCedente.Text;
            string url;

            if (tBoxCNPJSoftwareHouse.Text == "" | tBoxTokenSoftwareHouse.Text == "" | tBoxCNPJCedente.Text == "")
            {
                MessageBox.Show("Dados obrigatórios não preenchidos!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if (rdHomologacao.Checked)
            {
                url = "http://homologacao.cobrancabancaria.tecnospeed.com.br:8080";
            }
            else url = "https://cobrancabancaria.tecnospeed.com.br";

            var client = new RestClient(url + "/api/v1/boletos/baixa/lote/" + txtProtocoloBaixa.Text);
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/pdf");
            request.AddHeader("token-sh", tokenSH);
            request.AddHeader("cnpj-sh", cnpjSH);
            request.AddHeader("cnpj-cedente", cnpjCedente);

            dynamic json = JObject.Parse(client.Execute(request).Content);
            rtRetorno.Text = JsonConvert.SerializeObject(json, Formatting.Indented);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string cnpjSH = tBoxCNPJSoftwareHouse.Text;
            string tokenSH = tBoxTokenSoftwareHouse.Text;
            string cnpjCedente = tBoxCNPJCedente.Text;
            string url;

            if (tBoxCNPJSoftwareHouse.Text == "" | tBoxTokenSoftwareHouse.Text == "" | tBoxCNPJCedente.Text == "")
            {
                MessageBox.Show("Dados obrigatórios não preenchidos!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            //Verifica qual o ambiente (produção ou homologação) que será usado para montar a requisição
            if (rdHomologacao.Checked)
            {
                url = "http://homologacao.cobrancabancaria.tecnospeed.com.br:8080";
            }
            else url = "https://cobrancabancaria.tecnospeed.com.br";


            //Cria um array com os idIntegracao (que estão separados por vírgula)
            string[] idIntegracaoArray;
            idIntegracaoArray = txtIdIntegracao.Text.Split(',');


            //Monta o json com o idIntegracao:
            var JsonIDIntegracao = new object[] { idIntegracaoArray };

            JavaScriptSerializer js = new JavaScriptSerializer();
            string strJson = js.Serialize(JsonIDIntegracao);


            //Inicia a configuração da requisicao:
            var client = new RestClient(url + "/api/v1/boletos/descarta/lote/");
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            request.AddHeader("token-sh", tokenSH);
            request.AddHeader("cnpj-sh", cnpjSH);
            request.AddHeader("cnpj-cedente", cnpjCedente);
            request.AddParameter("application/json", (strJson), ParameterType.RequestBody);


            dynamic json = JObject.Parse(client.Execute(request).Content);
            rtRetorno.Text = JsonConvert.SerializeObject(json, Formatting.Indented);

        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            string cnpjSH = tBoxCNPJSoftwareHouse.Text;
            string tokenSH = tBoxTokenSoftwareHouse.Text;
            string cnpjCedente = tBoxCNPJCedente.Text;
            string url;

            if (tBoxCNPJSoftwareHouse.Text == "" | tBoxTokenSoftwareHouse.Text == "" | tBoxCNPJCedente.Text == "")
            {
                MessageBox.Show("Dados obrigatórios não preenchidos!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            //Verifica qual o ambiente (produção ou homologação) que será usado para montar a requisição
            if (rdHomologacao.Checked)
            {
                url = "http://homologacao.cobrancabancaria.tecnospeed.com.br:8080";
            }
            else url = "https://cobrancabancaria.tecnospeed.com.br";


            var objVet =  new { idIntegracao = txtIdIntegracao.Text,
                                EmailNomeRemetente = "Empresa Exemplo",
                                EmailRemetente = "guilherme.ganassin@tecnospeed.com.br",
                                EmailAssunto = "Boleto para pagamento",
                                EmailMensagem = "Segue o link do boleto:| ${linkBoleto}|Considere não imprimir este email.",
                                EmailDestinatario = "guilherme.ganassin@tecnospeed.com.br"
                              };

            JavaScriptSerializer js = new JavaScriptSerializer();
            string srtJson = js.Serialize(objVet);

            rtRetorno.Text = srtJson;
           

            //Inicia a configuração da requisicao:
            var client = new RestClient(url + "/api/v1/email/");
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            request.AddHeader("token-sh", tokenSH);
            request.AddHeader("cnpj-sh", cnpjSH);
            request.AddHeader("cnpj-cedente", cnpjCedente);
            request.AddParameter("application/json", (srtJson), ParameterType.RequestBody);


            dynamic json = JObject.Parse(client.Execute(request).Content);
            rtRetorno.Text = JsonConvert.SerializeObject(json, Formatting.Indented);

        }
    }
}

