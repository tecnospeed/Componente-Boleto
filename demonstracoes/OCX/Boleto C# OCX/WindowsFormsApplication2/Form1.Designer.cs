namespace WindowsFormsApplication2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdProducao = new System.Windows.Forms.RadioButton();
            this.rdHomologacao = new System.Windows.Forms.RadioButton();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.btnLoadConfig = new System.Windows.Forms.Button();
            this.tBoxTokenSoftwareHouse = new System.Windows.Forms.TextBox();
            this.tBoxCNPJCedente = new System.Windows.Forms.TextBox();
            this.tBoxCNPJSoftwareHouse = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tBoxIdIntegracao = new System.Windows.Forms.TextBox();
            this.label5050 = new System.Windows.Forms.Label();
            this.btnDescartarBoletos = new System.Windows.Forms.Button();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.btnIncluir = new System.Windows.Forms.Button();
            this.btnCarregarTx2 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbProtocoloEnvioEmail = new System.Windows.Forms.TextBox();
            this.btnConsultaEmailLote = new System.Windows.Forms.Button();
            this.btnEnviarEmailLote = new System.Windows.Forms.Button();
            this.btnSalvarPDFLote = new System.Windows.Forms.Button();
            this.btnImprimirLote = new System.Windows.Forms.Button();
            this.btnSolicitarImpressaoLote = new System.Windows.Forms.Button();
            this.tbProtocoloRetornoImpressaoLote = new System.Windows.Forms.TextBox();
            this.cbbTipoImpressao = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbbImpressora = new System.Windows.Forms.ComboBox();
            this.Impressora = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tBoxRetProcessamento = new System.Windows.Forms.TextBox();
            this.btnUploadRetorno = new System.Windows.Forms.Button();
            this.btnConsRetProcessamento = new System.Windows.Forms.Button();
            this.btnGerarRemessa = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tBoxProcotoloRemessaBaixada = new System.Windows.Forms.TextBox();
            this.tBoxProtocoloRetornoRemessaAlteracao = new System.Windows.Forms.TextBox();
            this.btnGerarBaixa = new System.Windows.Forms.Button();
            this.btnConsultarRemessaBaixada = new System.Windows.Forms.Button();
            this.btnConsultarProtocoloRemessaAlteracao = new System.Windows.Forms.Button();
            this.btnGerarRemessaAlteracao = new System.Windows.Forms.Button();
            this.cbbTipoRemessaAlteracao = new System.Windows.Forms.ComboBox();
            this.dlgTx2 = new System.Windows.Forms.OpenFileDialog();
            this.savedlgPDF = new System.Windows.Forms.SaveFileDialog();
            this.dlgArqRetorno = new System.Windows.Forms.OpenFileDialog();
            this.rtTx2 = new System.Windows.Forms.RichTextBox();
            this.rtResposta = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnCadastrarCedente = new System.Windows.Forms.Button();
            this.btnCadastrarConta = new System.Windows.Forms.Button();
            this.btnCadastrarConvenio = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdProducao);
            this.groupBox1.Controls.Add(this.rdHomologacao);
            this.groupBox1.Location = new System.Drawing.Point(10, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(361, 45);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ambiente do Envio";
            // 
            // rdProducao
            // 
            this.rdProducao.AutoSize = true;
            this.rdProducao.Location = new System.Drawing.Point(223, 19);
            this.rdProducao.Name = "rdProducao";
            this.rdProducao.Size = new System.Drawing.Size(71, 17);
            this.rdProducao.TabIndex = 1;
            this.rdProducao.TabStop = true;
            this.rdProducao.Text = "Produção";
            this.rdProducao.UseVisualStyleBackColor = true;
            // 
            // rdHomologacao
            // 
            this.rdHomologacao.AutoSize = true;
            this.rdHomologacao.Location = new System.Drawing.Point(9, 19);
            this.rdHomologacao.Name = "rdHomologacao";
            this.rdHomologacao.Size = new System.Drawing.Size(91, 17);
            this.rdHomologacao.TabIndex = 0;
            this.rdHomologacao.TabStop = true;
            this.rdHomologacao.Text = "Homologação";
            this.rdHomologacao.UseVisualStyleBackColor = true;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.btnLoadConfig);
            this.GroupBox2.Controls.Add(this.tBoxTokenSoftwareHouse);
            this.GroupBox2.Controls.Add(this.tBoxCNPJCedente);
            this.GroupBox2.Controls.Add(this.tBoxCNPJSoftwareHouse);
            this.GroupBox2.Controls.Add(this.label3);
            this.GroupBox2.Controls.Add(this.label2);
            this.GroupBox2.Controls.Add(this.label1);
            this.GroupBox2.Location = new System.Drawing.Point(10, 133);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(361, 118);
            this.GroupBox2.TabIndex = 1;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Configurações";
            this.GroupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // btnLoadConfig
            // 
            this.btnLoadConfig.Location = new System.Drawing.Point(158, 86);
            this.btnLoadConfig.Name = "btnLoadConfig";
            this.btnLoadConfig.Size = new System.Drawing.Size(191, 23);
            this.btnLoadConfig.TabIndex = 6;
            this.btnLoadConfig.Text = "Carregar Configurações";
            this.btnLoadConfig.UseVisualStyleBackColor = true;
            this.btnLoadConfig.Click += new System.EventHandler(this.btnLoadConfig_Click);
            // 
            // tBoxTokenSoftwareHouse
            // 
            this.tBoxTokenSoftwareHouse.Location = new System.Drawing.Point(158, 43);
            this.tBoxTokenSoftwareHouse.Name = "tBoxTokenSoftwareHouse";
            this.tBoxTokenSoftwareHouse.Size = new System.Drawing.Size(191, 20);
            this.tBoxTokenSoftwareHouse.TabIndex = 5;
            this.tBoxTokenSoftwareHouse.Text = "f22b97c0c9a3d41ac0a3875aba69e5aa";
            // 
            // tBoxCNPJCedente
            // 
            this.tBoxCNPJCedente.Location = new System.Drawing.Point(9, 88);
            this.tBoxCNPJCedente.Name = "tBoxCNPJCedente";
            this.tBoxCNPJCedente.Size = new System.Drawing.Size(110, 20);
            this.tBoxCNPJCedente.TabIndex = 4;
            this.tBoxCNPJCedente.Text = "01001001000113";
            // 
            // tBoxCNPJSoftwareHouse
            // 
            this.tBoxCNPJSoftwareHouse.Location = new System.Drawing.Point(9, 43);
            this.tBoxCNPJSoftwareHouse.Name = "tBoxCNPJSoftwareHouse";
            this.tBoxCNPJSoftwareHouse.Size = new System.Drawing.Size(110, 20);
            this.tBoxCNPJSoftwareHouse.TabIndex = 3;
            this.tBoxCNPJSoftwareHouse.Text = "01001001000113";
            this.tBoxCNPJSoftwareHouse.TextChanged += new System.EventHandler(this.tBoxCNPJSoftwareHouse_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "CNPJ do Cedente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(155, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Token Software House";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "CNPJ Software House";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tBoxIdIntegracao);
            this.groupBox3.Controls.Add(this.label5050);
            this.groupBox3.Controls.Add(this.btnDescartarBoletos);
            this.groupBox3.Controls.Add(this.btnConsultar);
            this.groupBox3.Controls.Add(this.btnIncluir);
            this.groupBox3.Controls.Add(this.btnCarregarTx2);
            this.groupBox3.Location = new System.Drawing.Point(10, 271);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(361, 133);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Incluir e Consultar Boletos";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // tBoxIdIntegracao
            // 
            this.tBoxIdIntegracao.Location = new System.Drawing.Point(6, 102);
            this.tBoxIdIntegracao.Name = "tBoxIdIntegracao";
            this.tBoxIdIntegracao.Size = new System.Drawing.Size(223, 20);
            this.tBoxIdIntegracao.TabIndex = 6;
            this.tBoxIdIntegracao.TextChanged += new System.EventHandler(this.tBoxIdIntegracao_TextChanged);
            // 
            // label5050
            // 
            this.label5050.AutoSize = true;
            this.label5050.Location = new System.Drawing.Point(3, 86);
            this.label5050.Name = "label5050";
            this.label5050.Size = new System.Drawing.Size(73, 13);
            this.label5050.TabIndex = 5;
            this.label5050.Text = "Id Integração:";
            this.label5050.Click += new System.EventHandler(this.label5050_Click);
            // 
            // btnDescartarBoletos
            // 
            this.btnDescartarBoletos.Location = new System.Drawing.Point(239, 52);
            this.btnDescartarBoletos.Name = "btnDescartarBoletos";
            this.btnDescartarBoletos.Size = new System.Drawing.Size(110, 23);
            this.btnDescartarBoletos.TabIndex = 4;
            this.btnDescartarBoletos.Text = "Descartar Boletos";
            this.btnDescartarBoletos.UseVisualStyleBackColor = true;
            this.btnDescartarBoletos.Click += new System.EventHandler(this.btnDescartarBoletos_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(240, 19);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(109, 23);
            this.btnConsultar.TabIndex = 3;
            this.btnConsultar.Text = "Consultar Boleto";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // btnIncluir
            // 
            this.btnIncluir.Location = new System.Drawing.Point(125, 19);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(110, 23);
            this.btnIncluir.TabIndex = 1;
            this.btnIncluir.Text = "Incluir Boleto";
            this.btnIncluir.UseVisualStyleBackColor = true;
            this.btnIncluir.Click += new System.EventHandler(this.btnIncluir_Click);
            // 
            // btnCarregarTx2
            // 
            this.btnCarregarTx2.Location = new System.Drawing.Point(9, 20);
            this.btnCarregarTx2.Name = "btnCarregarTx2";
            this.btnCarregarTx2.Size = new System.Drawing.Size(110, 23);
            this.btnCarregarTx2.TabIndex = 0;
            this.btnCarregarTx2.Text = "Carregar .tx2";
            this.btnCarregarTx2.UseVisualStyleBackColor = true;
            this.btnCarregarTx2.Click += new System.EventHandler(this.btnCarregarTx2_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnSalvarPDFLote);
            this.groupBox4.Controls.Add(this.btnImprimirLote);
            this.groupBox4.Controls.Add(this.btnSolicitarImpressaoLote);
            this.groupBox4.Controls.Add(this.tbProtocoloRetornoImpressaoLote);
            this.groupBox4.Controls.Add(this.cbbTipoImpressao);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.cbbImpressora);
            this.groupBox4.Controls.Add(this.Impressora);
            this.groupBox4.Location = new System.Drawing.Point(387, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(342, 239);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Impressão";
            // 
            // tbProtocoloEnvioEmail
            // 
            this.tbProtocoloEnvioEmail.Location = new System.Drawing.Point(189, 24);
            this.tbProtocoloEnvioEmail.Multiline = true;
            this.tbProtocoloEnvioEmail.Name = "tbProtocoloEnvioEmail";
            this.tbProtocoloEnvioEmail.Size = new System.Drawing.Size(144, 23);
            this.tbProtocoloEnvioEmail.TabIndex = 18;
            this.tbProtocoloEnvioEmail.Text = "Protocolo E-mail";
            this.tbProtocoloEnvioEmail.TextChanged += new System.EventHandler(this.tbProtocoloEnvioEmail_TextChanged);
            // 
            // btnConsultaEmailLote
            // 
            this.btnConsultaEmailLote.Location = new System.Drawing.Point(9, 86);
            this.btnConsultaEmailLote.Name = "btnConsultaEmailLote";
            this.btnConsultaEmailLote.Size = new System.Drawing.Size(144, 23);
            this.btnConsultaEmailLote.TabIndex = 17;
            this.btnConsultaEmailLote.Text = "Consultar Envio Lote";
            this.btnConsultaEmailLote.UseVisualStyleBackColor = true;
            this.btnConsultaEmailLote.Click += new System.EventHandler(this.btnConsultaEmailLote_Click);
            // 
            // btnEnviarEmailLote
            // 
            this.btnEnviarEmailLote.Location = new System.Drawing.Point(9, 24);
            this.btnEnviarEmailLote.Name = "btnEnviarEmailLote";
            this.btnEnviarEmailLote.Size = new System.Drawing.Size(144, 23);
            this.btnEnviarEmailLote.TabIndex = 16;
            this.btnEnviarEmailLote.Text = "Enviar E-mail Lote";
            this.btnEnviarEmailLote.UseVisualStyleBackColor = true;
            this.btnEnviarEmailLote.Click += new System.EventHandler(this.btnEnviarEmailLote_Click);
            // 
            // btnSalvarPDFLote
            // 
            this.btnSalvarPDFLote.Location = new System.Drawing.Point(189, 205);
            this.btnSalvarPDFLote.Name = "btnSalvarPDFLote";
            this.btnSalvarPDFLote.Size = new System.Drawing.Size(144, 23);
            this.btnSalvarPDFLote.TabIndex = 14;
            this.btnSalvarPDFLote.Text = "Salvar PDF Lote";
            this.btnSalvarPDFLote.UseVisualStyleBackColor = true;
            this.btnSalvarPDFLote.Click += new System.EventHandler(this.btnSalvarPDFLote_Click);
            // 
            // btnImprimirLote
            // 
            this.btnImprimirLote.Location = new System.Drawing.Point(12, 207);
            this.btnImprimirLote.Name = "btnImprimirLote";
            this.btnImprimirLote.Size = new System.Drawing.Size(144, 23);
            this.btnImprimirLote.TabIndex = 13;
            this.btnImprimirLote.Text = "Imprimir Lote";
            this.btnImprimirLote.UseVisualStyleBackColor = true;
            this.btnImprimirLote.Click += new System.EventHandler(this.btnImprimirLote_Click);
            // 
            // btnSolicitarImpressaoLote
            // 
            this.btnSolicitarImpressaoLote.Location = new System.Drawing.Point(189, 154);
            this.btnSolicitarImpressaoLote.Name = "btnSolicitarImpressaoLote";
            this.btnSolicitarImpressaoLote.Size = new System.Drawing.Size(144, 37);
            this.btnSolicitarImpressaoLote.TabIndex = 12;
            this.btnSolicitarImpressaoLote.Text = "Solicitar Impressão em Lote";
            this.btnSolicitarImpressaoLote.UseVisualStyleBackColor = true;
            this.btnSolicitarImpressaoLote.Click += new System.EventHandler(this.btnSolicitarImpressaoLote_Click);
            // 
            // tbProtocoloRetornoImpressaoLote
            // 
            this.tbProtocoloRetornoImpressaoLote.Location = new System.Drawing.Point(15, 164);
            this.tbProtocoloRetornoImpressaoLote.Name = "tbProtocoloRetornoImpressaoLote";
            this.tbProtocoloRetornoImpressaoLote.Size = new System.Drawing.Size(141, 20);
            this.tbProtocoloRetornoImpressaoLote.TabIndex = 11;
            this.tbProtocoloRetornoImpressaoLote.Text = "Protocolo de Impressão";
            this.tbProtocoloRetornoImpressaoLote.TextChanged += new System.EventHandler(this.tbProtocoloRetornoImpressaoLote_TextChanged);
            // 
            // cbbTipoImpressao
            // 
            this.cbbTipoImpressao.FormattingEnabled = true;
            this.cbbTipoImpressao.Items.AddRange(new object[] {
            "0 : Normal",
            "1 : Carnê Duplo",
            "2 : Carnê Triplo",
            "3 : Normal Dupla",
            "99 : Personalizado"});
            this.cbbTipoImpressao.Location = new System.Drawing.Point(12, 94);
            this.cbbTipoImpressao.Name = "cbbTipoImpressao";
            this.cbbTipoImpressao.Size = new System.Drawing.Size(141, 21);
            this.cbbTipoImpressao.TabIndex = 10;
            this.cbbTipoImpressao.SelectedIndexChanged += new System.EventHandler(this.cbbTipoImpressao_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Tipo de Impressão";
            // 
            // cbbImpressora
            // 
            this.cbbImpressora.FormattingEnabled = true;
            this.cbbImpressora.Location = new System.Drawing.Point(9, 35);
            this.cbbImpressora.Name = "cbbImpressora";
            this.cbbImpressora.Size = new System.Drawing.Size(324, 21);
            this.cbbImpressora.TabIndex = 5;
            this.cbbImpressora.SelectedIndexChanged += new System.EventHandler(this.cbbImpressora_SelectedIndexChanged);
            // 
            // Impressora
            // 
            this.Impressora.AutoSize = true;
            this.Impressora.Location = new System.Drawing.Point(6, 16);
            this.Impressora.Name = "Impressora";
            this.Impressora.Size = new System.Drawing.Size(58, 13);
            this.Impressora.TabIndex = 4;
            this.Impressora.Text = "Impressora";
            this.Impressora.Click += new System.EventHandler(this.Impressora_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tBoxRetProcessamento);
            this.groupBox5.Controls.Add(this.btnUploadRetorno);
            this.groupBox5.Controls.Add(this.btnConsRetProcessamento);
            this.groupBox5.Controls.Add(this.btnGerarRemessa);
            this.groupBox5.Location = new System.Drawing.Point(745, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(361, 115);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Remessa e Retorno";
            this.groupBox5.Enter += new System.EventHandler(this.groupBox5_Enter);
            // 
            // tBoxRetProcessamento
            // 
            this.tBoxRetProcessamento.Location = new System.Drawing.Point(20, 65);
            this.tBoxRetProcessamento.Multiline = true;
            this.tBoxRetProcessamento.Name = "tBoxRetProcessamento";
            this.tBoxRetProcessamento.Size = new System.Drawing.Size(138, 21);
            this.tBoxRetProcessamento.TabIndex = 3;
            this.tBoxRetProcessamento.Text = "Protocolo Upload Retorno";
            // 
            // btnUploadRetorno
            // 
            this.btnUploadRetorno.Location = new System.Drawing.Point(192, 22);
            this.btnUploadRetorno.Name = "btnUploadRetorno";
            this.btnUploadRetorno.Size = new System.Drawing.Size(138, 23);
            this.btnUploadRetorno.TabIndex = 2;
            this.btnUploadRetorno.Text = "Upload de Retorno";
            this.btnUploadRetorno.UseVisualStyleBackColor = true;
            this.btnUploadRetorno.Click += new System.EventHandler(this.btnUploadRetorno_Click);
            // 
            // btnConsRetProcessamento
            // 
            this.btnConsRetProcessamento.Location = new System.Drawing.Point(192, 63);
            this.btnConsRetProcessamento.Name = "btnConsRetProcessamento";
            this.btnConsRetProcessamento.Size = new System.Drawing.Size(138, 42);
            this.btnConsRetProcessamento.TabIndex = 1;
            this.btnConsRetProcessamento.Text = "Consultar Retorno Processamento";
            this.btnConsRetProcessamento.UseVisualStyleBackColor = true;
            this.btnConsRetProcessamento.Click += new System.EventHandler(this.btnConsRetProcessamento_Click);
            // 
            // btnGerarRemessa
            // 
            this.btnGerarRemessa.Location = new System.Drawing.Point(20, 22);
            this.btnGerarRemessa.Name = "btnGerarRemessa";
            this.btnGerarRemessa.Size = new System.Drawing.Size(138, 23);
            this.btnGerarRemessa.TabIndex = 0;
            this.btnGerarRemessa.Text = "Gerar Remessa";
            this.btnGerarRemessa.UseVisualStyleBackColor = true;
            this.btnGerarRemessa.Click += new System.EventHandler(this.btnGerarRemessa_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Controls.Add(this.tBoxProcotoloRemessaBaixada);
            this.groupBox6.Controls.Add(this.tBoxProtocoloRetornoRemessaAlteracao);
            this.groupBox6.Controls.Add(this.btnGerarBaixa);
            this.groupBox6.Controls.Add(this.btnConsultarRemessaBaixada);
            this.groupBox6.Controls.Add(this.btnConsultarProtocoloRemessaAlteracao);
            this.groupBox6.Controls.Add(this.btnGerarRemessaAlteracao);
            this.groupBox6.Controls.Add(this.cbbTipoRemessaAlteracao);
            this.groupBox6.Location = new System.Drawing.Point(745, 160);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(361, 244);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = " Remessa de Alteração e Baixa";
            // 
            // tBoxProcotoloRemessaBaixada
            // 
            this.tBoxProcotoloRemessaBaixada.Location = new System.Drawing.Point(199, 138);
            this.tBoxProcotoloRemessaBaixada.Name = "tBoxProcotoloRemessaBaixada";
            this.tBoxProcotoloRemessaBaixada.Size = new System.Drawing.Size(149, 20);
            this.tBoxProcotoloRemessaBaixada.TabIndex = 6;
            this.tBoxProcotoloRemessaBaixada.Text = "Protocolo de Baixa";
            // 
            // tBoxProtocoloRetornoRemessaAlteracao
            // 
            this.tBoxProtocoloRetornoRemessaAlteracao.Location = new System.Drawing.Point(6, 135);
            this.tBoxProtocoloRetornoRemessaAlteracao.Name = "tBoxProtocoloRetornoRemessaAlteracao";
            this.tBoxProtocoloRetornoRemessaAlteracao.Size = new System.Drawing.Size(152, 20);
            this.tBoxProtocoloRetornoRemessaAlteracao.TabIndex = 5;
            this.tBoxProtocoloRetornoRemessaAlteracao.Text = "Protocolo de Alteração";
            this.tBoxProtocoloRetornoRemessaAlteracao.TextChanged += new System.EventHandler(this.tBoxProtocoloRetornoRemessaAlteracao_TextChanged);
            // 
            // btnGerarBaixa
            // 
            this.btnGerarBaixa.Location = new System.Drawing.Point(199, 76);
            this.btnGerarBaixa.Name = "btnGerarBaixa";
            this.btnGerarBaixa.Size = new System.Drawing.Size(151, 23);
            this.btnGerarBaixa.TabIndex = 4;
            this.btnGerarBaixa.Text = "Gerar Baixa";
            this.btnGerarBaixa.UseVisualStyleBackColor = true;
            this.btnGerarBaixa.Click += new System.EventHandler(this.btnGerarBaixa_Click);
            // 
            // btnConsultarRemessaBaixada
            // 
            this.btnConsultarRemessaBaixada.Location = new System.Drawing.Point(199, 197);
            this.btnConsultarRemessaBaixada.Name = "btnConsultarRemessaBaixada";
            this.btnConsultarRemessaBaixada.Size = new System.Drawing.Size(151, 37);
            this.btnConsultarRemessaBaixada.TabIndex = 3;
            this.btnConsultarRemessaBaixada.Text = "Consultar Remessa Baixada";
            this.btnConsultarRemessaBaixada.UseVisualStyleBackColor = true;
            this.btnConsultarRemessaBaixada.Click += new System.EventHandler(this.btnConsultarRemessaBaixada_Click);
            // 
            // btnConsultarProtocoloRemessaAlteracao
            // 
            this.btnConsultarProtocoloRemessaAlteracao.Location = new System.Drawing.Point(6, 196);
            this.btnConsultarProtocoloRemessaAlteracao.Name = "btnConsultarProtocoloRemessaAlteracao";
            this.btnConsultarProtocoloRemessaAlteracao.Size = new System.Drawing.Size(151, 37);
            this.btnConsultarProtocoloRemessaAlteracao.TabIndex = 2;
            this.btnConsultarProtocoloRemessaAlteracao.Text = "Consultar Remessa Alteração";
            this.btnConsultarProtocoloRemessaAlteracao.UseVisualStyleBackColor = true;
            this.btnConsultarProtocoloRemessaAlteracao.Click += new System.EventHandler(this.btnConsultarProtocoloRemessaAlteracao_Click);
            // 
            // btnGerarRemessaAlteracao
            // 
            this.btnGerarRemessaAlteracao.Location = new System.Drawing.Point(7, 76);
            this.btnGerarRemessaAlteracao.Name = "btnGerarRemessaAlteracao";
            this.btnGerarRemessaAlteracao.Size = new System.Drawing.Size(151, 23);
            this.btnGerarRemessaAlteracao.TabIndex = 1;
            this.btnGerarRemessaAlteracao.Text = "Gerar Remessa Ateração";
            this.btnGerarRemessaAlteracao.UseVisualStyleBackColor = true;
            this.btnGerarRemessaAlteracao.Click += new System.EventHandler(this.btnGerarRemessaAlteracao_Click);
            // 
            // cbbTipoRemessaAlteracao
            // 
            this.cbbTipoRemessaAlteracao.FormattingEnabled = true;
            this.cbbTipoRemessaAlteracao.Items.AddRange(new object[] {
            "0 - Alteração de Vencimento",
            "1 - Alteração de Valor"});
            this.cbbTipoRemessaAlteracao.Location = new System.Drawing.Point(5, 37);
            this.cbbTipoRemessaAlteracao.Name = "cbbTipoRemessaAlteracao";
            this.cbbTipoRemessaAlteracao.Size = new System.Drawing.Size(152, 21);
            this.cbbTipoRemessaAlteracao.TabIndex = 0;
            this.cbbTipoRemessaAlteracao.Text = "        Tipo de Remessa";
            this.cbbTipoRemessaAlteracao.SelectedIndexChanged += new System.EventHandler(this.cbbTipoRemessaAlteracao_SelectedIndexChanged);
            // 
            // dlgTx2
            // 
            this.dlgTx2.FileName = "openFileDialog1";
            // 
            // dlgArqRetorno
            // 
            this.dlgArqRetorno.FileName = "openFileDialog1";
            // 
            // rtTx2
            // 
            this.rtTx2.Location = new System.Drawing.Point(7, 430);
            this.rtTx2.Name = "rtTx2";
            this.rtTx2.Size = new System.Drawing.Size(533, 253);
            this.rtTx2.TabIndex = 4;
            this.rtTx2.Text = "";
            // 
            // rtResposta
            // 
            this.rtResposta.Location = new System.Drawing.Point(576, 430);
            this.rtResposta.Name = "rtResposta";
            this.rtResposta.Size = new System.Drawing.Size(530, 254);
            this.rtResposta.TabIndex = 5;
            this.rtResposta.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 415);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Entrada:";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(573, 414);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Resposta: ";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(10, 714);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(1096, 62);
            this.textBox2.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 698);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Mensagens:";
            // 
            // btnCadastrarCedente
            // 
            this.btnCadastrarCedente.Location = new System.Drawing.Point(10, 85);
            this.btnCadastrarCedente.Name = "btnCadastrarCedente";
            this.btnCadastrarCedente.Size = new System.Drawing.Size(116, 23);
            this.btnCadastrarCedente.TabIndex = 10;
            this.btnCadastrarCedente.Text = "Cadastrar Cedente";
            this.btnCadastrarCedente.UseVisualStyleBackColor = true;
            this.btnCadastrarCedente.Click += new System.EventHandler(this.btnCadastrarCedente_Click);
            // 
            // btnCadastrarConta
            // 
            this.btnCadastrarConta.Location = new System.Drawing.Point(132, 85);
            this.btnCadastrarConta.Name = "btnCadastrarConta";
            this.btnCadastrarConta.Size = new System.Drawing.Size(116, 23);
            this.btnCadastrarConta.TabIndex = 11;
            this.btnCadastrarConta.Text = "Cadastrar Conta";
            this.btnCadastrarConta.UseVisualStyleBackColor = true;
            this.btnCadastrarConta.Click += new System.EventHandler(this.btnCadastrarConta_Click);
            // 
            // btnCadastrarConvenio
            // 
            this.btnCadastrarConvenio.Location = new System.Drawing.Point(255, 85);
            this.btnCadastrarConvenio.Name = "btnCadastrarConvenio";
            this.btnCadastrarConvenio.Size = new System.Drawing.Size(116, 23);
            this.btnCadastrarConvenio.TabIndex = 12;
            this.btnCadastrarConvenio.Text = "Cadastrar Convênio";
            this.btnCadastrarConvenio.UseVisualStyleBackColor = true;
            this.btnCadastrarConvenio.Click += new System.EventHandler(this.btnCadastrarConvenio_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 69);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(144, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "Cadastrar Dados do Cedente";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btnEnviarEmailLote);
            this.groupBox7.Controls.Add(this.tbProtocoloEnvioEmail);
            this.groupBox7.Controls.Add(this.btnConsultaEmailLote);
            this.groupBox7.Location = new System.Drawing.Point(387, 271);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(342, 133);
            this.groupBox7.TabIndex = 15;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "E-mail";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(196, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Remessa de Baixa:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1119, 788);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnCadastrarConvenio);
            this.Controls.Add(this.btnCadastrarConta);
            this.Controls.Add(this.btnCadastrarCedente);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.rtResposta);
            this.Controls.Add(this.rtTx2);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox GroupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton rdProducao;
        private System.Windows.Forms.RadioButton rdHomologacao;
        private System.Windows.Forms.Button btnLoadConfig;
        private System.Windows.Forms.TextBox tBoxTokenSoftwareHouse;
        private System.Windows.Forms.TextBox tBoxCNPJCedente;
        private System.Windows.Forms.TextBox tBoxCNPJSoftwareHouse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog dlgTx2;
        private System.Windows.Forms.SaveFileDialog savedlgPDF;
        private System.Windows.Forms.OpenFileDialog dlgArqRetorno;
        private System.Windows.Forms.RichTextBox rtTx2;
        private System.Windows.Forms.RichTextBox rtResposta;
        private System.Windows.Forms.TextBox tBoxIdIntegracao;
        private System.Windows.Forms.Label label5050;
        private System.Windows.Forms.Button btnDescartarBoletos;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Button btnIncluir;
        private System.Windows.Forms.Button btnCarregarTx2;
        private System.Windows.Forms.Label Impressora;
        private System.Windows.Forms.Button btnSalvarPDFLote;
        private System.Windows.Forms.Button btnImprimirLote;
        private System.Windows.Forms.Button btnSolicitarImpressaoLote;
        private System.Windows.Forms.TextBox tbProtocoloRetornoImpressaoLote;
        private System.Windows.Forms.ComboBox cbbTipoImpressao;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbbImpressora;
        private System.Windows.Forms.Button btnUploadRetorno;
        private System.Windows.Forms.Button btnConsRetProcessamento;
        private System.Windows.Forms.Button btnGerarRemessa;
        private System.Windows.Forms.TextBox tBoxRetProcessamento;
        private System.Windows.Forms.TextBox tBoxProcotoloRemessaBaixada;
        private System.Windows.Forms.TextBox tBoxProtocoloRetornoRemessaAlteracao;
        private System.Windows.Forms.Button btnGerarBaixa;
        private System.Windows.Forms.Button btnConsultarRemessaBaixada;
        private System.Windows.Forms.Button btnConsultarProtocoloRemessaAlteracao;
        private System.Windows.Forms.Button btnGerarRemessaAlteracao;
        private System.Windows.Forms.ComboBox cbbTipoRemessaAlteracao;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnEnviarEmailLote;
        private System.Windows.Forms.Button btnConsultaEmailLote;
        private System.Windows.Forms.TextBox tbProtocoloEnvioEmail;
        private System.Windows.Forms.Button btnCadastrarCedente;
        private System.Windows.Forms.Button btnCadastrarConta;
        private System.Windows.Forms.Button btnCadastrarConvenio;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label4;
    }
}

