namespace APISoftwareHouse
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
            this.components = new System.ComponentModel.Container();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdProducao = new System.Windows.Forms.RadioButton();
            this.rdHomologacao = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tBoxCNPJCedente = new System.Windows.Forms.TextBox();
            this.tBoxTokenSoftwareHouse = new System.Windows.Forms.TextBox();
            this.tBoxCNPJSoftwareHouse = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rtRetorno = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.cbbTipoRemessaAlteracao = new System.Windows.Forms.ComboBox();
            this.btnSolicitarRemessaAlteracao = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtProtocoloRemessaAlteracao = new System.Windows.Forms.TextBox();
            this.btnConsultaProtRemAlteracao = new System.Windows.Forms.Button();
            this.btnUploadRetorno = new System.Windows.Forms.Button();
            this.tbProtocoloUploadRetorno = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnConsultaProtRetorno = new System.Windows.Forms.Button();
            this.btnGerarRemessa = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSolicitarImpressao = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cbbTipoImpressao = new System.Windows.Forms.ComboBox();
            this.txtProtocoloImpressao = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.txtIdIntegracao = new System.Windows.Forms.TextBox();
            this.IdIntegracao = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnConsultarProtBaixa = new System.Windows.Forms.Button();
            this.txtProtocoloBaixa = new System.Windows.Forms.TextBox();
            this.btnSolicitarBaixa = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnEmail = new System.Windows.Forms.Button();
            this.btnDescartar = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdProducao);
            this.groupBox2.Controls.Add(this.rdHomologacao);
            this.groupBox2.Location = new System.Drawing.Point(6, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(300, 46);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Ambiente do Envio ";
            // 
            // rdProducao
            // 
            this.rdProducao.AutoSize = true;
            this.rdProducao.Checked = true;
            this.rdProducao.Location = new System.Drawing.Point(223, 18);
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
            this.rdHomologacao.Location = new System.Drawing.Point(6, 19);
            this.rdHomologacao.Name = "rdHomologacao";
            this.rdHomologacao.Size = new System.Drawing.Size(128, 17);
            this.rdHomologacao.TabIndex = 0;
            this.rdHomologacao.TabStop = true;
            this.rdHomologacao.Text = "Homologação (testes)";
            this.rdHomologacao.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tBoxCNPJCedente);
            this.groupBox5.Controls.Add(this.tBoxTokenSoftwareHouse);
            this.groupBox5.Controls.Add(this.tBoxCNPJSoftwareHouse);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Location = new System.Drawing.Point(6, 67);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(300, 116);
            this.groupBox5.TabIndex = 39;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = " Configurações ";
            // 
            // tBoxCNPJCedente
            // 
            this.tBoxCNPJCedente.Location = new System.Drawing.Point(6, 34);
            this.tBoxCNPJCedente.Name = "tBoxCNPJCedente";
            this.tBoxCNPJCedente.Size = new System.Drawing.Size(137, 20);
            this.tBoxCNPJCedente.TabIndex = 13;
            this.tBoxCNPJCedente.Text = "01001001000113";
            // 
            // tBoxTokenSoftwareHouse
            // 
            this.tBoxTokenSoftwareHouse.Location = new System.Drawing.Point(6, 83);
            this.tBoxTokenSoftwareHouse.Name = "tBoxTokenSoftwareHouse";
            this.tBoxTokenSoftwareHouse.Size = new System.Drawing.Size(288, 20);
            this.tBoxTokenSoftwareHouse.TabIndex = 12;
            this.tBoxTokenSoftwareHouse.Text = "f22b97c0c9a3d41ac0a3875aba69e5aa";
            // 
            // tBoxCNPJSoftwareHouse
            // 
            this.tBoxCNPJSoftwareHouse.Location = new System.Drawing.Point(157, 34);
            this.tBoxCNPJSoftwareHouse.Name = "tBoxCNPJSoftwareHouse";
            this.tBoxCNPJSoftwareHouse.Size = new System.Drawing.Size(137, 20);
            this.tBoxCNPJSoftwareHouse.TabIndex = 11;
            this.tBoxCNPJSoftwareHouse.Text = "01001001000113";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "CNPJ do Cedente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Token Software House";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(154, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "CNPJ Software House";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 451);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Retorno:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // rtRetorno
            // 
            this.rtRetorno.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtRetorno.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.rtRetorno.Location = new System.Drawing.Point(6, 467);
            this.rtRetorno.Name = "rtRetorno";
            this.rtRetorno.Size = new System.Drawing.Size(959, 283);
            this.rtRetorno.TabIndex = 37;
            this.rtRetorno.Text = "";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 13);
            this.label7.TabIndex = 53;
            this.label7.Text = "Tipo da Alteração:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // cbbTipoRemessaAlteracao
            // 
            this.cbbTipoRemessaAlteracao.FormattingEnabled = true;
            this.cbbTipoRemessaAlteracao.Items.AddRange(new object[] {
            "0 - Vencimento",
            "1 - Valor"});
            this.cbbTipoRemessaAlteracao.Location = new System.Drawing.Point(6, 118);
            this.cbbTipoRemessaAlteracao.Name = "cbbTipoRemessaAlteracao";
            this.cbbTipoRemessaAlteracao.Size = new System.Drawing.Size(137, 21);
            this.cbbTipoRemessaAlteracao.TabIndex = 54;
            // 
            // btnSolicitarRemessaAlteracao
            // 
            this.btnSolicitarRemessaAlteracao.Location = new System.Drawing.Point(157, 118);
            this.btnSolicitarRemessaAlteracao.Name = "btnSolicitarRemessaAlteracao";
            this.btnSolicitarRemessaAlteracao.Size = new System.Drawing.Size(137, 23);
            this.btnSolicitarRemessaAlteracao.TabIndex = 55;
            this.btnSolicitarRemessaAlteracao.Text = "8 - Solicitar Alteração";
            this.btnSolicitarRemessaAlteracao.UseVisualStyleBackColor = true;
            this.btnSolicitarRemessaAlteracao.Click += new System.EventHandler(this.btnSolicitarRemessaAlteracao_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 152);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 13);
            this.label8.TabIndex = 56;
            this.label8.Text = "Protocolo da Alteração:";
            // 
            // txtProtocoloRemessaAlteracao
            // 
            this.txtProtocoloRemessaAlteracao.Location = new System.Drawing.Point(6, 168);
            this.txtProtocoloRemessaAlteracao.Name = "txtProtocoloRemessaAlteracao";
            this.txtProtocoloRemessaAlteracao.Size = new System.Drawing.Size(137, 20);
            this.txtProtocoloRemessaAlteracao.TabIndex = 57;
            // 
            // btnConsultaProtRemAlteracao
            // 
            this.btnConsultaProtRemAlteracao.Location = new System.Drawing.Point(157, 155);
            this.btnConsultaProtRemAlteracao.Name = "btnConsultaProtRemAlteracao";
            this.btnConsultaProtRemAlteracao.Size = new System.Drawing.Size(137, 42);
            this.btnConsultaProtRemAlteracao.TabIndex = 58;
            this.btnConsultaProtRemAlteracao.Text = "8.1 - Consultar Protocolo Alteração";
            this.btnConsultaProtRemAlteracao.UseVisualStyleBackColor = true;
            this.btnConsultaProtRemAlteracao.Click += new System.EventHandler(this.btnConsultaProtRemAlteracao_Click);
            // 
            // btnUploadRetorno
            // 
            this.btnUploadRetorno.Location = new System.Drawing.Point(6, 32);
            this.btnUploadRetorno.Name = "btnUploadRetorno";
            this.btnUploadRetorno.Size = new System.Drawing.Size(137, 23);
            this.btnUploadRetorno.TabIndex = 49;
            this.btnUploadRetorno.Text = "6 - Upload do Retorno";
            this.btnUploadRetorno.UseVisualStyleBackColor = true;
            this.btnUploadRetorno.Click += new System.EventHandler(this.button3_Click);
            // 
            // tbProtocoloUploadRetorno
            // 
            this.tbProtocoloUploadRetorno.Location = new System.Drawing.Point(156, 35);
            this.tbProtocoloUploadRetorno.Name = "tbProtocoloUploadRetorno";
            this.tbProtocoloUploadRetorno.Size = new System.Drawing.Size(137, 20);
            this.tbProtocoloUploadRetorno.TabIndex = 50;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(153, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 13);
            this.label6.TabIndex = 51;
            this.label6.Text = "Protocolo Retorno:";
            // 
            // btnConsultaProtRetorno
            // 
            this.btnConsultaProtRetorno.Location = new System.Drawing.Point(6, 60);
            this.btnConsultaProtRetorno.Name = "btnConsultaProtRetorno";
            this.btnConsultaProtRetorno.Size = new System.Drawing.Size(137, 23);
            this.btnConsultaProtRetorno.TabIndex = 52;
            this.btnConsultaProtRetorno.Text = "7 - Consulta Prot. Retorno";
            this.btnConsultaProtRetorno.UseVisualStyleBackColor = true;
            this.btnConsultaProtRetorno.Click += new System.EventHandler(this.btnConsultaProtRetorno_Click);
            // 
            // btnGerarRemessa
            // 
            this.btnGerarRemessa.Location = new System.Drawing.Point(6, 32);
            this.btnGerarRemessa.Name = "btnGerarRemessa";
            this.btnGerarRemessa.Size = new System.Drawing.Size(137, 23);
            this.btnGerarRemessa.TabIndex = 48;
            this.btnGerarRemessa.Text = "5 - Gerar Remessa";
            this.btnGerarRemessa.UseVisualStyleBackColor = true;
            this.btnGerarRemessa.Click += new System.EventHandler(this.btnGerarRemessa_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 13);
            this.label5.TabIndex = 47;
            this.label5.Text = "Protocolo de Impressão";
            // 
            // btnSolicitarImpressao
            // 
            this.btnSolicitarImpressao.Location = new System.Drawing.Point(157, 32);
            this.btnSolicitarImpressao.Name = "btnSolicitarImpressao";
            this.btnSolicitarImpressao.Size = new System.Drawing.Size(137, 23);
            this.btnSolicitarImpressao.TabIndex = 41;
            this.btnSolicitarImpressao.Text = "3 - Solicitar Impressão";
            this.btnSolicitarImpressao.UseVisualStyleBackColor = true;
            this.btnSolicitarImpressao.Click += new System.EventHandler(this.btnSolicitarImpressao_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 13);
            this.label9.TabIndex = 42;
            this.label9.Text = "Tipo de Impressão";
            // 
            // cbbTipoImpressao
            // 
            this.cbbTipoImpressao.FormattingEnabled = true;
            this.cbbTipoImpressao.Items.AddRange(new object[] {
            "Normal",
            "Carnê",
            "Carnê Triplo",
            "Personalizada"});
            this.cbbTipoImpressao.Location = new System.Drawing.Point(9, 32);
            this.cbbTipoImpressao.Name = "cbbTipoImpressao";
            this.cbbTipoImpressao.Size = new System.Drawing.Size(134, 21);
            this.cbbTipoImpressao.TabIndex = 43;
            this.cbbTipoImpressao.SelectedIndexChanged += new System.EventHandler(this.cbbTipoImpressao_SelectedIndexChanged);
            // 
            // txtProtocoloImpressao
            // 
            this.txtProtocoloImpressao.Location = new System.Drawing.Point(9, 87);
            this.txtProtocoloImpressao.Name = "txtProtocoloImpressao";
            this.txtProtocoloImpressao.Size = new System.Drawing.Size(134, 20);
            this.txtProtocoloImpressao.TabIndex = 45;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(157, 87);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(137, 23);
            this.button2.TabIndex = 46;
            this.button2.Text = "4 - Consultar Protocolo";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(6, 23);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(137, 23);
            this.btnEnviar.TabIndex = 34;
            this.btnEnviar.Text = "1 - Enviar Boleto";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // txtIdIntegracao
            // 
            this.txtIdIntegracao.Location = new System.Drawing.Point(157, 26);
            this.txtIdIntegracao.Name = "txtIdIntegracao";
            this.txtIdIntegracao.Size = new System.Drawing.Size(137, 20);
            this.txtIdIntegracao.TabIndex = 35;
            // 
            // IdIntegracao
            // 
            this.IdIntegracao.AutoSize = true;
            this.IdIntegracao.Location = new System.Drawing.Point(154, 10);
            this.IdIntegracao.Name = "IdIntegracao";
            this.IdIntegracao.Size = new System.Drawing.Size(67, 13);
            this.IdIntegracao.TabIndex = 36;
            this.IdIntegracao.Text = "IdIntegracao";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 62);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 23);
            this.button1.TabIndex = 40;
            this.button1.Text = "2 - Consultar idIntegracao";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEnviar);
            this.groupBox1.Controls.Add(this.IdIntegracao);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtIdIntegracao);
            this.groupBox1.Location = new System.Drawing.Point(6, 199);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 95);
            this.groupBox1.TabIndex = 59;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Inclusão e Consulta";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.cbbTipoImpressao);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtProtocoloImpressao);
            this.groupBox3.Controls.Add(this.btnSolicitarImpressao);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Location = new System.Drawing.Point(6, 306);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(300, 121);
            this.groupBox3.TabIndex = 60;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = " Impressão:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnConsultarProtBaixa);
            this.groupBox4.Controls.Add(this.txtProtocoloBaixa);
            this.groupBox4.Controls.Add(this.btnSolicitarBaixa);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.btnGerarRemessa);
            this.groupBox4.Controls.Add(this.cbbTipoRemessaAlteracao);
            this.groupBox4.Controls.Add(this.btnConsultaProtRemAlteracao);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.txtProtocoloRemessaAlteracao);
            this.groupBox4.Controls.Add(this.btnSolicitarRemessaAlteracao);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Location = new System.Drawing.Point(335, 67);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(300, 360);
            this.groupBox4.TabIndex = 61;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Remessa: Normal, Alteração e Baixa";
            // 
            // btnConsultarProtBaixa
            // 
            this.btnConsultarProtBaixa.Location = new System.Drawing.Point(6, 310);
            this.btnConsultarProtBaixa.Name = "btnConsultarProtBaixa";
            this.btnConsultarProtBaixa.Size = new System.Drawing.Size(137, 23);
            this.btnConsultarProtBaixa.TabIndex = 62;
            this.btnConsultarProtBaixa.Text = "Cons. Prot. Baixa";
            this.btnConsultarProtBaixa.UseVisualStyleBackColor = true;
            this.btnConsultarProtBaixa.Click += new System.EventHandler(this.btnConsultarProtBaixa_Click);
            // 
            // txtProtocoloBaixa
            // 
            this.txtProtocoloBaixa.Location = new System.Drawing.Point(159, 272);
            this.txtProtocoloBaixa.Name = "txtProtocoloBaixa";
            this.txtProtocoloBaixa.Size = new System.Drawing.Size(135, 20);
            this.txtProtocoloBaixa.TabIndex = 61;
            // 
            // btnSolicitarBaixa
            // 
            this.btnSolicitarBaixa.Location = new System.Drawing.Point(6, 271);
            this.btnSolicitarBaixa.Name = "btnSolicitarBaixa";
            this.btnSolicitarBaixa.Size = new System.Drawing.Size(137, 23);
            this.btnSolicitarBaixa.TabIndex = 60;
            this.btnSolicitarBaixa.Text = "Solicitar Baixa";
            this.btnSolicitarBaixa.UseVisualStyleBackColor = true;
            this.btnSolicitarBaixa.Click += new System.EventHandler(this.btnSolicitarBaixa_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 255);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 13);
            this.label12.TabIndex = 59;
            this.label12.Text = "Remessa de Baixa:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 83);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(117, 13);
            this.label11.TabIndex = 50;
            this.label11.Text = "Remessa de Alteração:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 13);
            this.label10.TabIndex = 49;
            this.label10.Text = "Remessa Normal:";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnUploadRetorno);
            this.groupBox6.Controls.Add(this.tbProtocoloUploadRetorno);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.btnConsultaProtRetorno);
            this.groupBox6.Location = new System.Drawing.Point(666, 67);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(299, 190);
            this.groupBox6.TabIndex = 62;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Upload do Retorno";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btnEmail);
            this.groupBox7.Controls.Add(this.btnDescartar);
            this.groupBox7.Location = new System.Drawing.Point(666, 267);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(298, 159);
            this.groupBox7.TabIndex = 63;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Métodos Adicionais:";
            // 
            // btnEmail
            // 
            this.btnEmail.Location = new System.Drawing.Point(156, 19);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(137, 23);
            this.btnEmail.TabIndex = 1;
            this.btnEmail.Text = "Email";
            this.btnEmail.UseVisualStyleBackColor = true;
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            // 
            // btnDescartar
            // 
            this.btnDescartar.Location = new System.Drawing.Point(6, 19);
            this.btnDescartar.Name = "btnDescartar";
            this.btnDescartar.Size = new System.Drawing.Size(137, 23);
            this.btnDescartar.TabIndex = 0;
            this.btnDescartar.Text = "Descarte";
            this.btnDescartar.UseVisualStyleBackColor = true;
            this.btnDescartar.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 762);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtRetorno);
            this.Name = "Form1";
            this.Text = "API Software House";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdProducao;
        private System.Windows.Forms.RadioButton rdHomologacao;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox tBoxCNPJCedente;
        private System.Windows.Forms.TextBox tBoxTokenSoftwareHouse;
        private System.Windows.Forms.TextBox tBoxCNPJSoftwareHouse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtRetorno;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbbTipoRemessaAlteracao;
        private System.Windows.Forms.Button btnSolicitarRemessaAlteracao;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtProtocoloRemessaAlteracao;
        private System.Windows.Forms.Button btnConsultaProtRemAlteracao;
        private System.Windows.Forms.Button btnUploadRetorno;
        private System.Windows.Forms.TextBox tbProtocoloUploadRetorno;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnConsultaProtRetorno;
        private System.Windows.Forms.Button btnGerarRemessa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSolicitarImpressao;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbbTipoImpressao;
        private System.Windows.Forms.TextBox txtProtocoloImpressao;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.TextBox txtIdIntegracao;
        private System.Windows.Forms.Label IdIntegracao;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnConsultarProtBaixa;
        private System.Windows.Forms.TextBox txtProtocoloBaixa;
        private System.Windows.Forms.Button btnSolicitarBaixa;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btnEmail;
        private System.Windows.Forms.Button btnDescartar;
    }
}

