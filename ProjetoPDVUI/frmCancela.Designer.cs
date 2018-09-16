namespace ProjetoPDVUI
{
    partial class frmCancela
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCancela));
            this.rectangleShape2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cboProcurar = new System.Windows.Forms.ComboBox();
            this.cmdLocalizar = new System.Windows.Forms.Button();
            this.txtNumDoc = new System.Windows.Forms.TextBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.lblCodNat = new System.Windows.Forms.Label();
            this.Label18 = new System.Windows.Forms.Label();
            this.lblValDoc = new System.Windows.Forms.Label();
            this.Label16 = new System.Windows.Forms.Label();
            this.lblDatDoc = new System.Windows.Forms.Label();
            this.Label15 = new System.Windows.Forms.Label();
            this.lblNFiscal = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.lblUF = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.lblCidade = new System.Windows.Forms.Label();
            this.Label11 = new System.Windows.Forms.Label();
            this.lblEndereco = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.lblRazaoSocial = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.cboMotivo = new System.Windows.Forms.ComboBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.TxtNumProtocolo = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.TxtChaveNFe = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.CmdFechar = new System.Windows.Forms.Button();
            this.CmdCancela = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rectangleShape2
            // 
            this.rectangleShape2.BorderColor = System.Drawing.SystemColors.AppWorkspace;
            this.rectangleShape2.Location = new System.Drawing.Point(1, 50);
            this.rectangleShape2.Name = "rectangleShape2";
            this.rectangleShape2.Size = new System.Drawing.Size(471, 433);
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rectangleShape1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.rectangleShape1.BorderColor = System.Drawing.Color.DimGray;
            this.rectangleShape1.CornerRadius = 1;
            this.rectangleShape1.FillGradientColor = System.Drawing.Color.DimGray;
            this.rectangleShape1.Location = new System.Drawing.Point(-1, 0);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(478, 47);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape1,
            this.rectangleShape2});
            this.shapeContainer1.Size = new System.Drawing.Size(477, 486);
            this.shapeContainer1.TabIndex = 0;
            this.shapeContainer1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(228, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 23);
            this.label1.TabIndex = 163;
            this.label1.Text = "Cancelamento da NFC-e";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(4, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(126, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 165;
            this.pictureBox1.TabStop = false;
            // 
            // cboProcurar
            // 
            this.cboProcurar.DisplayMember = "0";
            this.cboProcurar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProcurar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboProcurar.FormattingEnabled = true;
            this.cboProcurar.Items.AddRange(new object[] {
            "N° da Nota Fiscal",
            "N° do Pedido"});
            this.cboProcurar.Location = new System.Drawing.Point(7, 66);
            this.cboProcurar.Name = "cboProcurar";
            this.cboProcurar.Size = new System.Drawing.Size(117, 21);
            this.cboProcurar.TabIndex = 168;
            // 
            // cmdLocalizar
            // 
            this.cmdLocalizar.BackColor = System.Drawing.Color.Gainsboro;
            this.cmdLocalizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdLocalizar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmdLocalizar.Location = new System.Drawing.Point(347, 65);
            this.cmdLocalizar.Name = "cmdLocalizar";
            this.cmdLocalizar.Size = new System.Drawing.Size(120, 24);
            this.cmdLocalizar.TabIndex = 167;
            this.cmdLocalizar.Text = "&Localizar";
            this.cmdLocalizar.UseVisualStyleBackColor = false;
            this.cmdLocalizar.Click += new System.EventHandler(this.cmdLocalizar_Click);
            // 
            // txtNumDoc
            // 
            this.txtNumDoc.BackColor = System.Drawing.Color.White;
            this.txtNumDoc.Location = new System.Drawing.Point(130, 66);
            this.txtNumDoc.MaxLength = 8;
            this.txtNumDoc.Name = "txtNumDoc";
            this.txtNumDoc.Size = new System.Drawing.Size(76, 20);
            this.txtNumDoc.TabIndex = 166;
            this.txtNumDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.lblCodNat);
            this.GroupBox1.Controls.Add(this.Label18);
            this.GroupBox1.Controls.Add(this.lblValDoc);
            this.GroupBox1.Controls.Add(this.Label16);
            this.GroupBox1.Controls.Add(this.lblDatDoc);
            this.GroupBox1.Controls.Add(this.Label15);
            this.GroupBox1.Controls.Add(this.lblNFiscal);
            this.GroupBox1.Controls.Add(this.Label14);
            this.GroupBox1.Controls.Add(this.Label7);
            this.GroupBox1.Controls.Add(this.lblUF);
            this.GroupBox1.Controls.Add(this.Label10);
            this.GroupBox1.Controls.Add(this.lblCidade);
            this.GroupBox1.Controls.Add(this.Label11);
            this.GroupBox1.Controls.Add(this.lblEndereco);
            this.GroupBox1.Controls.Add(this.Label9);
            this.GroupBox1.Controls.Add(this.lblRazaoSocial);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.GroupBox1.Location = new System.Drawing.Point(7, 110);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(460, 132);
            this.GroupBox1.TabIndex = 169;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Dados da NF";
            // 
            // lblCodNat
            // 
            this.lblCodNat.BackColor = System.Drawing.Color.White;
            this.lblCodNat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCodNat.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCodNat.Location = new System.Drawing.Point(288, 20);
            this.lblCodNat.Name = "lblCodNat";
            this.lblCodNat.Size = new System.Drawing.Size(40, 20);
            this.lblCodNat.TabIndex = 107;
            this.lblCodNat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label18
            // 
            this.Label18.AutoSize = true;
            this.Label18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label18.Location = new System.Drawing.Point(240, 24);
            this.Label18.Name = "Label18";
            this.Label18.Size = new System.Drawing.Size(46, 13);
            this.Label18.TabIndex = 106;
            this.Label18.Text = "CodNat:";
            // 
            // lblValDoc
            // 
            this.lblValDoc.BackColor = System.Drawing.Color.White;
            this.lblValDoc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValDoc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblValDoc.Location = new System.Drawing.Point(372, 20);
            this.lblValDoc.Name = "lblValDoc";
            this.lblValDoc.Size = new System.Drawing.Size(80, 20);
            this.lblValDoc.TabIndex = 105;
            this.lblValDoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label16
            // 
            this.Label16.AutoSize = true;
            this.Label16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label16.Location = new System.Drawing.Point(336, 24);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(34, 13);
            this.Label16.TabIndex = 104;
            this.Label16.Text = "Valor:";
            // 
            // lblDatDoc
            // 
            this.lblDatDoc.BackColor = System.Drawing.Color.White;
            this.lblDatDoc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDatDoc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDatDoc.Location = new System.Drawing.Point(156, 20);
            this.lblDatDoc.Name = "lblDatDoc";
            this.lblDatDoc.Size = new System.Drawing.Size(80, 20);
            this.lblDatDoc.TabIndex = 103;
            this.lblDatDoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label15.Location = new System.Drawing.Point(120, 24);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(33, 13);
            this.Label15.TabIndex = 102;
            this.Label15.Text = "Data:";
            // 
            // lblNFiscal
            // 
            this.lblNFiscal.BackColor = System.Drawing.Color.White;
            this.lblNFiscal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNFiscal.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNFiscal.Location = new System.Drawing.Point(52, 20);
            this.lblNFiscal.Name = "lblNFiscal";
            this.lblNFiscal.Size = new System.Drawing.Size(60, 20);
            this.lblNFiscal.TabIndex = 101;
            this.lblNFiscal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label14.Location = new System.Drawing.Point(8, 24);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(45, 13);
            this.Label14.TabIndex = 100;
            this.Label14.Text = "NFiscal:";
            // 
            // Label7
            // 
            this.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label7.Location = new System.Drawing.Point(0, 47);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(460, 2);
            this.Label7.TabIndex = 99;
            // 
            // lblUF
            // 
            this.lblUF.BackColor = System.Drawing.Color.White;
            this.lblUF.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblUF.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblUF.Location = new System.Drawing.Point(416, 104);
            this.lblUF.Name = "lblUF";
            this.lblUF.Size = new System.Drawing.Size(36, 20);
            this.lblUF.TabIndex = 98;
            this.lblUF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label10.Location = new System.Drawing.Point(392, 108);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(24, 13);
            this.Label10.TabIndex = 97;
            this.Label10.Text = "UF:";
            // 
            // lblCidade
            // 
            this.lblCidade.BackColor = System.Drawing.Color.White;
            this.lblCidade.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCidade.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCidade.Location = new System.Drawing.Point(64, 104);
            this.lblCidade.Name = "lblCidade";
            this.lblCidade.Size = new System.Drawing.Size(180, 20);
            this.lblCidade.TabIndex = 96;
            this.lblCidade.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label11.Location = new System.Drawing.Point(8, 108);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(43, 13);
            this.Label11.TabIndex = 95;
            this.Label11.Text = "Cidade:";
            // 
            // lblEndereco
            // 
            this.lblEndereco.BackColor = System.Drawing.Color.White;
            this.lblEndereco.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblEndereco.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblEndereco.Location = new System.Drawing.Point(64, 80);
            this.lblEndereco.Name = "lblEndereco";
            this.lblEndereco.Size = new System.Drawing.Size(388, 20);
            this.lblEndereco.TabIndex = 94;
            this.lblEndereco.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label9.Location = new System.Drawing.Point(8, 84);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(56, 13);
            this.Label9.TabIndex = 93;
            this.Label9.Text = "Endereço:";
            // 
            // lblRazaoSocial
            // 
            this.lblRazaoSocial.BackColor = System.Drawing.Color.White;
            this.lblRazaoSocial.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRazaoSocial.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblRazaoSocial.Location = new System.Drawing.Point(64, 56);
            this.lblRazaoSocial.Name = "lblRazaoSocial";
            this.lblRazaoSocial.Size = new System.Drawing.Size(388, 20);
            this.lblRazaoSocial.TabIndex = 92;
            this.lblRazaoSocial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label2.Location = new System.Drawing.Point(8, 60);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(42, 13);
            this.Label2.TabIndex = 91;
            this.Label2.Text = "Cliente:";
            // 
            // cboMotivo
            // 
            this.cboMotivo.FormattingEnabled = true;
            this.cboMotivo.Items.AddRange(new object[] {
            "CLIENTE DESISTIU DA COMPRA",
            "CLIENTE DESISTIU DA CONSIGNACAO",
            "PEDIDO DIGITADO INDEVIDAMENTE"});
            this.cboMotivo.Location = new System.Drawing.Point(7, 272);
            this.cboMotivo.MaxLength = 100;
            this.cboMotivo.Name = "cboMotivo";
            this.cboMotivo.Size = new System.Drawing.Size(460, 21);
            this.cboMotivo.TabIndex = 175;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label3.Location = new System.Drawing.Point(7, 256);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(312, 13);
            this.Label3.TabIndex = 174;
            this.Label3.Text = "Motivo do Cancelamento:  (Informação a ser enviada ao SEFAZ)";
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label12.Location = new System.Drawing.Point(296, 307);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(107, 13);
            this.Label12.TabIndex = 171;
            this.Label12.Text = "Número do Protocolo";
            // 
            // TxtNumProtocolo
            // 
            this.TxtNumProtocolo.BackColor = System.Drawing.SystemColors.Control;
            this.TxtNumProtocolo.Location = new System.Drawing.Point(299, 323);
            this.TxtNumProtocolo.Name = "TxtNumProtocolo";
            this.TxtNumProtocolo.ReadOnly = true;
            this.TxtNumProtocolo.Size = new System.Drawing.Size(168, 20);
            this.TxtNumProtocolo.TabIndex = 173;
            this.TxtNumProtocolo.TabStop = false;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label8.Location = new System.Drawing.Point(7, 308);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(128, 13);
            this.Label8.TabIndex = 170;
            this.Label8.Text = "Chave de acesso da NFe";
            // 
            // TxtChaveNFe
            // 
            this.TxtChaveNFe.BackColor = System.Drawing.SystemColors.Control;
            this.TxtChaveNFe.Location = new System.Drawing.Point(7, 323);
            this.TxtChaveNFe.Name = "TxtChaveNFe";
            this.TxtChaveNFe.ReadOnly = true;
            this.TxtChaveNFe.Size = new System.Drawing.Size(276, 20);
            this.TxtChaveNFe.TabIndex = 172;
            this.TxtChaveNFe.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtResultado);
            this.groupBox2.Location = new System.Drawing.Point(6, 352);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(462, 90);
            this.groupBox2.TabIndex = 178;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mensagem do sistema";
            // 
            // txtResultado
            // 
            this.txtResultado.AcceptsTab = true;
            this.txtResultado.BackColor = System.Drawing.SystemColors.Control;
            this.txtResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResultado.ForeColor = System.Drawing.Color.Maroon;
            this.txtResultado.Location = new System.Drawing.Point(6, 19);
            this.txtResultado.Multiline = true;
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.ReadOnly = true;
            this.txtResultado.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResultado.Size = new System.Drawing.Size(447, 59);
            this.txtResultado.TabIndex = 133;
            // 
            // CmdFechar
            // 
            this.CmdFechar.BackColor = System.Drawing.Color.Gainsboro;
            this.CmdFechar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CmdFechar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CmdFechar.Location = new System.Drawing.Point(384, 452);
            this.CmdFechar.Name = "CmdFechar";
            this.CmdFechar.Size = new System.Drawing.Size(84, 28);
            this.CmdFechar.TabIndex = 177;
            this.CmdFechar.Text = "&Fechar";
            this.CmdFechar.UseVisualStyleBackColor = false;
            this.CmdFechar.Click += new System.EventHandler(this.CmdFechar_Click);
            // 
            // CmdCancela
            // 
            this.CmdCancela.BackColor = System.Drawing.Color.Gainsboro;
            this.CmdCancela.Enabled = false;
            this.CmdCancela.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CmdCancela.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CmdCancela.Location = new System.Drawing.Point(6, 452);
            this.CmdCancela.Name = "CmdCancela";
            this.CmdCancela.Size = new System.Drawing.Size(125, 28);
            this.CmdCancela.TabIndex = 176;
            this.CmdCancela.Text = "Processar";
            this.CmdCancela.UseVisualStyleBackColor = false;
            // 
            // frmCancela
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(477, 486);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.CmdFechar);
            this.Controls.Add(this.CmdCancela);
            this.Controls.Add(this.cboMotivo);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label12);
            this.Controls.Add(this.TxtNumProtocolo);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.TxtChaveNFe);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.cboProcurar);
            this.Controls.Add(this.cmdLocalizar);
            this.Controls.Add(this.txtNumDoc);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCancela";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCancela";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape2;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.ComboBox cboProcurar;
        private System.Windows.Forms.Button cmdLocalizar;
        private System.Windows.Forms.TextBox txtNumDoc;
        internal System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.Label lblCodNat;
        private System.Windows.Forms.Label Label18;
        private System.Windows.Forms.Label lblValDoc;
        private System.Windows.Forms.Label Label16;
        private System.Windows.Forms.Label lblDatDoc;
        private System.Windows.Forms.Label Label15;
        private System.Windows.Forms.Label lblNFiscal;
        private System.Windows.Forms.Label Label14;
        private System.Windows.Forms.Label Label7;
        private System.Windows.Forms.Label lblUF;
        private System.Windows.Forms.Label Label10;
        private System.Windows.Forms.Label lblCidade;
        private System.Windows.Forms.Label Label11;
        private System.Windows.Forms.Label lblEndereco;
        private System.Windows.Forms.Label Label9;
        private System.Windows.Forms.Label lblRazaoSocial;
        private System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.ComboBox cboMotivo;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Label Label12;
        private System.Windows.Forms.TextBox TxtNumProtocolo;
        private System.Windows.Forms.Label Label8;
        private System.Windows.Forms.TextBox TxtChaveNFe;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtResultado;
        private System.Windows.Forms.Button CmdFechar;
        private System.Windows.Forms.Button CmdCancela;
    }
}