namespace ProjetoPDVUI
{
    partial class frmInformaPagamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInformaPagamento));
            this.label2 = new System.Windows.Forms.Label();
            this.radVisa = new System.Windows.Forms.RadioButton();
            this.radMastercard = new System.Windows.Forms.RadioButton();
            this.radIfood = new System.Windows.Forms.RadioButton();
            this.radOutros = new System.Windows.Forms.RadioButton();
            this.pnlBandeiras = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNumAutorizacao = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.pnlTeclado = new System.Windows.Forms.Panel();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlCedulas = new System.Windows.Forms.Panel();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.btnLimparValor = new System.Windows.Forms.Button();
            this.btnValorFaltando = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblSalvar = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblCancelar = new System.Windows.Forms.Label();
            this.radPix = new System.Windows.Forms.RadioButton();
            this.pnlBandeiras.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.pnlTeclado.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlCedulas.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(234, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 16);
            this.label2.TabIndex = 22;
            this.label2.Text = "Selecione a Bandeira:";
            // 
            // radVisa
            // 
            this.radVisa.AutoSize = true;
            this.radVisa.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radVisa.ForeColor = System.Drawing.Color.White;
            this.radVisa.Image = ((System.Drawing.Image)(resources.GetObject("radVisa.Image")));
            this.radVisa.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.radVisa.Location = new System.Drawing.Point(119, 40);
            this.radVisa.Name = "radVisa";
            this.radVisa.Size = new System.Drawing.Size(138, 50);
            this.radVisa.TabIndex = 23;
            this.radVisa.TabStop = true;
            this.radVisa.Tag = "VISA";
            this.radVisa.Text = "  [V] VISA";
            this.radVisa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radVisa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radVisa.UseVisualStyleBackColor = true;
            // 
            // radMastercard
            // 
            this.radMastercard.AutoSize = true;
            this.radMastercard.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radMastercard.ForeColor = System.Drawing.Color.White;
            this.radMastercard.Image = ((System.Drawing.Image)(resources.GetObject("radMastercard.Image")));
            this.radMastercard.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.radMastercard.Location = new System.Drawing.Point(391, 40);
            this.radMastercard.Name = "radMastercard";
            this.radMastercard.Size = new System.Drawing.Size(190, 50);
            this.radMastercard.TabIndex = 24;
            this.radMastercard.TabStop = true;
            this.radMastercard.Tag = "MASTERCARD";
            this.radMastercard.Text = " [M] MASTERCARD";
            this.radMastercard.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radMastercard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radMastercard.UseVisualStyleBackColor = true;
            // 
            // radIfood
            // 
            this.radIfood.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radIfood.ForeColor = System.Drawing.Color.White;
            this.radIfood.Image = ((System.Drawing.Image)(resources.GetObject("radIfood.Image")));
            this.radIfood.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.radIfood.Location = new System.Drawing.Point(119, 105);
            this.radIfood.Name = "radIfood";
            this.radIfood.Size = new System.Drawing.Size(143, 35);
            this.radIfood.TabIndex = 25;
            this.radIfood.TabStop = true;
            this.radIfood.Tag = "IFOOD";
            this.radIfood.Text = "  [X] iFood";
            this.radIfood.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radIfood.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radIfood.UseVisualStyleBackColor = true;
            // 
            // radOutros
            // 
            this.radOutros.AutoSize = true;
            this.radOutros.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radOutros.ForeColor = System.Drawing.Color.White;
            this.radOutros.Image = ((System.Drawing.Image)(resources.GetObject("radOutros.Image")));
            this.radOutros.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.radOutros.Location = new System.Drawing.Point(391, 96);
            this.radOutros.Name = "radOutros";
            this.radOutros.Size = new System.Drawing.Size(158, 50);
            this.radOutros.TabIndex = 26;
            this.radOutros.TabStop = true;
            this.radOutros.Tag = "OUTROS";
            this.radOutros.Text = "  [S] OUTROS";
            this.radOutros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radOutros.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radOutros.UseVisualStyleBackColor = true;
            this.radOutros.CheckedChanged += new System.EventHandler(this.radOutros_CheckedChanged);
            // 
            // pnlBandeiras
            // 
            this.pnlBandeiras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBandeiras.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBandeiras.Controls.Add(this.radPix);
            this.pnlBandeiras.Controls.Add(this.label5);
            this.pnlBandeiras.Controls.Add(this.txtNumAutorizacao);
            this.pnlBandeiras.Controls.Add(this.radOutros);
            this.pnlBandeiras.Controls.Add(this.radIfood);
            this.pnlBandeiras.Controls.Add(this.radMastercard);
            this.pnlBandeiras.Controls.Add(this.radVisa);
            this.pnlBandeiras.Controls.Add(this.label2);
            this.pnlBandeiras.Location = new System.Drawing.Point(1, 211);
            this.pnlBandeiras.Name = "pnlBandeiras";
            this.pnlBandeiras.Size = new System.Drawing.Size(628, 222);
            this.pnlBandeiras.TabIndex = 34;
            this.pnlBandeiras.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBandeiras_Paint);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(13, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 16);
            this.label5.TabIndex = 38;
            this.label5.Text = "N° Autorização:";
            // 
            // txtNumAutorizacao
            // 
            this.txtNumAutorizacao.BackColor = System.Drawing.Color.DimGray;
            this.txtNumAutorizacao.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNumAutorizacao.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumAutorizacao.ForeColor = System.Drawing.Color.White;
            this.txtNumAutorizacao.Location = new System.Drawing.Point(129, 179);
            this.txtNumAutorizacao.Name = "txtNumAutorizacao";
            this.txtNumAutorizacao.Size = new System.Drawing.Size(195, 26);
            this.txtNumAutorizacao.TabIndex = 37;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.pictureBox3);
            this.panel3.Controls.Add(this.btnLimpar);
            this.panel3.Controls.Add(this.pnlTeclado);
            this.panel3.Location = new System.Drawing.Point(627, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(343, 482);
            this.panel3.TabIndex = 174;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.ImageLocation = "";
            this.pictureBox3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox3.Location = new System.Drawing.Point(232, 374);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(96, 88);
            this.pictureBox3.TabIndex = 176;
            this.pictureBox3.TabStop = false;
            // 
            // btnLimpar
            // 
            this.btnLimpar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimpar.BackColor = System.Drawing.Color.Gainsboro;
            this.btnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLimpar.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpar.Location = new System.Drawing.Point(239, 241);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(89, 68);
            this.btnLimpar.TabIndex = 175;
            this.btnLimpar.Text = "←";
            this.btnLimpar.UseVisualStyleBackColor = false;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // pnlTeclado
            // 
            this.pnlTeclado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTeclado.Controls.Add(this.button11);
            this.pnlTeclado.Controls.Add(this.button10);
            this.pnlTeclado.Controls.Add(this.button9);
            this.pnlTeclado.Controls.Add(this.button8);
            this.pnlTeclado.Controls.Add(this.button12);
            this.pnlTeclado.Controls.Add(this.button13);
            this.pnlTeclado.Controls.Add(this.button14);
            this.pnlTeclado.Controls.Add(this.button15);
            this.pnlTeclado.Controls.Add(this.button16);
            this.pnlTeclado.Controls.Add(this.button17);
            this.pnlTeclado.Controls.Add(this.button18);
            this.pnlTeclado.Location = new System.Drawing.Point(46, 12);
            this.pnlTeclado.Name = "pnlTeclado";
            this.pnlTeclado.Size = new System.Drawing.Size(290, 300);
            this.pnlTeclado.TabIndex = 174;
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.Gainsboro;
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button11.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.Location = new System.Drawing.Point(98, 228);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(89, 69);
            this.button11.TabIndex = 11;
            this.button11.Tag = "c";
            this.button11.Text = "0";
            this.button11.UseVisualStyleBackColor = false;
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.Gainsboro;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button10.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.Location = new System.Drawing.Point(3, 78);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(89, 69);
            this.button10.TabIndex = 10;
            this.button10.Tag = "4";
            this.button10.Text = "4";
            this.button10.UseVisualStyleBackColor = false;
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.Gainsboro;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button9.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.Location = new System.Drawing.Point(193, 3);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(89, 69);
            this.button9.TabIndex = 9;
            this.button9.Tag = "9";
            this.button9.Text = "9";
            this.button9.UseVisualStyleBackColor = false;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Gainsboro;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button8.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Location = new System.Drawing.Point(98, 78);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(89, 69);
            this.button8.TabIndex = 8;
            this.button8.Tag = "5";
            this.button8.Text = "5";
            this.button8.UseVisualStyleBackColor = false;
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.Gainsboro;
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button12.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button12.Location = new System.Drawing.Point(193, 78);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(89, 69);
            this.button12.TabIndex = 7;
            this.button12.Tag = "6";
            this.button12.Text = "6";
            this.button12.UseVisualStyleBackColor = false;
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.Gainsboro;
            this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button13.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button13.Location = new System.Drawing.Point(3, 153);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(89, 69);
            this.button13.TabIndex = 6;
            this.button13.Tag = "1";
            this.button13.Text = "1";
            this.button13.UseVisualStyleBackColor = false;
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.Color.Gainsboro;
            this.button14.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button14.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button14.Location = new System.Drawing.Point(98, 153);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(89, 69);
            this.button14.TabIndex = 5;
            this.button14.Tag = "2";
            this.button14.Text = "2";
            this.button14.UseVisualStyleBackColor = false;
            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.Color.Gainsboro;
            this.button15.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button15.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button15.Location = new System.Drawing.Point(3, 228);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(89, 69);
            this.button15.TabIndex = 4;
            this.button15.Text = "C";
            this.button15.UseVisualStyleBackColor = false;
            // 
            // button16
            // 
            this.button16.BackColor = System.Drawing.Color.Gainsboro;
            this.button16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button16.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button16.Location = new System.Drawing.Point(193, 153);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(89, 69);
            this.button16.TabIndex = 3;
            this.button16.Tag = "3";
            this.button16.Text = "3";
            this.button16.UseVisualStyleBackColor = false;
            // 
            // button17
            // 
            this.button17.BackColor = System.Drawing.Color.Gainsboro;
            this.button17.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button17.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button17.Location = new System.Drawing.Point(98, 3);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(89, 69);
            this.button17.TabIndex = 2;
            this.button17.Tag = "8";
            this.button17.Text = "8";
            this.button17.UseVisualStyleBackColor = false;
            // 
            // button18
            // 
            this.button18.BackColor = System.Drawing.Color.Gainsboro;
            this.button18.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button18.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button18.Location = new System.Drawing.Point(3, 3);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(89, 69);
            this.button18.TabIndex = 1;
            this.button18.Tag = "7";
            this.button18.Text = "7";
            this.button18.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.pnlCedulas);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtObservacao);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.btnLimparValor);
            this.panel2.Controls.Add(this.btnValorFaltando);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(1, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(627, 222);
            this.panel2.TabIndex = 177;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Silver;
            this.label6.Location = new System.Drawing.Point(108, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(474, 26);
            this.label6.TabIndex = 185;
            this.label6.Text = "Selecione para preencher automaticamente. Segure a tecla SHIFT para somar ao\r\ncli" +
    "car nos números.";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlCedulas
            // 
            this.pnlCedulas.Controls.Add(this.button7);
            this.pnlCedulas.Controls.Add(this.button6);
            this.pnlCedulas.Controls.Add(this.button5);
            this.pnlCedulas.Controls.Add(this.button3);
            this.pnlCedulas.Controls.Add(this.button4);
            this.pnlCedulas.Location = new System.Drawing.Point(86, 69);
            this.pnlCedulas.Name = "pnlCedulas";
            this.pnlCedulas.Size = new System.Drawing.Size(516, 49);
            this.pnlCedulas.TabIndex = 184;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(111, 4);
            this.button7.Margin = new System.Windows.Forms.Padding(0);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(95, 40);
            this.button7.TabIndex = 176;
            this.button7.Tag = "5";
            this.button7.Text = "5,00";
            this.button7.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(211, 4);
            this.button6.Margin = new System.Windows.Forms.Padding(0);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(95, 40);
            this.button6.TabIndex = 175;
            this.button6.Tag = "10";
            this.button6.Text = "10,00";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(312, 4);
            this.button5.Margin = new System.Windows.Forms.Padding(0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(95, 40);
            this.button5.TabIndex = 174;
            this.button5.Tag = "20";
            this.button5.Text = "20,00";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(412, 4);
            this.button3.Margin = new System.Windows.Forms.Padding(0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(95, 40);
            this.button3.TabIndex = 173;
            this.button3.Tag = "50";
            this.button3.Text = "50,00";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(10, 4);
            this.button4.Margin = new System.Windows.Forms.Padding(0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(95, 40);
            this.button4.TabIndex = 172;
            this.button4.Tag = "2";
            this.button4.Text = "2,00";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Silver;
            this.label4.Location = new System.Drawing.Point(441, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 183;
            this.label4.Text = "(opcional)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(124, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 16);
            this.label3.TabIndex = 182;
            this.label3.Text = "Observação:";
            // 
            // txtObservacao
            // 
            this.txtObservacao.BackColor = System.Drawing.Color.DimGray;
            this.txtObservacao.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtObservacao.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservacao.ForeColor = System.Drawing.Color.White;
            this.txtObservacao.Location = new System.Drawing.Point(219, 168);
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.Size = new System.Drawing.Size(208, 26);
            this.txtObservacao.TabIndex = 181;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.txtValor);
            this.panel1.Location = new System.Drawing.Point(76, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(199, 39);
            this.panel1.TabIndex = 180;
            // 
            // txtValor
            // 
            this.txtValor.BackColor = System.Drawing.Color.DimGray;
            this.txtValor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtValor.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValor.ForeColor = System.Drawing.Color.White;
            this.txtValor.Location = new System.Drawing.Point(24, 7);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(156, 26);
            this.txtValor.TabIndex = 0;
            this.txtValor.Text = "0,00";
            this.txtValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnLimparValor
            // 
            this.btnLimparValor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(158)))), ((int)(((byte)(165)))));
            this.btnLimparValor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLimparValor.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimparValor.ForeColor = System.Drawing.Color.White;
            this.btnLimparValor.Location = new System.Drawing.Point(494, 24);
            this.btnLimparValor.Margin = new System.Windows.Forms.Padding(0);
            this.btnLimparValor.Name = "btnLimparValor";
            this.btnLimparValor.Size = new System.Drawing.Size(119, 39);
            this.btnLimparValor.TabIndex = 179;
            this.btnLimparValor.Text = "Limpar";
            this.btnLimparValor.UseVisualStyleBackColor = false;
            // 
            // btnValorFaltando
            // 
            this.btnValorFaltando.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnValorFaltando.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnValorFaltando.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValorFaltando.ForeColor = System.Drawing.Color.White;
            this.btnValorFaltando.Location = new System.Drawing.Point(282, 24);
            this.btnValorFaltando.Margin = new System.Windows.Forms.Padding(0);
            this.btnValorFaltando.Name = "btnValorFaltando";
            this.btnValorFaltando.Size = new System.Drawing.Size(207, 39);
            this.btnValorFaltando.TabIndex = 178;
            this.btnValorFaltando.Text = "0,00  (Faltando)";
            this.btnValorFaltando.UseVisualStyleBackColor = false;
            this.btnValorFaltando.Click += new System.EventHandler(this.btnValorFaltando_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 23);
            this.label1.TabIndex = 177;
            this.label1.Text = "Valor:";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.pictureBox2);
            this.panel4.Controls.Add(this.lblSalvar);
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Controls.Add(this.lblCancelar);
            this.panel4.Location = new System.Drawing.Point(1, 432);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(627, 51);
            this.panel4.TabIndex = 178;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(198, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(56, 38);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 171;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // lblSalvar
            // 
            this.lblSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSalvar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSalvar.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalvar.ForeColor = System.Drawing.Color.White;
            this.lblSalvar.Location = new System.Drawing.Point(202, 10);
            this.lblSalvar.Name = "lblSalvar";
            this.lblSalvar.Size = new System.Drawing.Size(179, 28);
            this.lblSalvar.TabIndex = 170;
            this.lblSalvar.Text = "Salvar  [ENTER]";
            this.lblSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSalvar.Click += new System.EventHandler(this.lblSalvar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(425, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(56, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 169;
            this.pictureBox1.TabStop = false;
            // 
            // lblCancelar
            // 
            this.lblCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCancelar.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCancelar.ForeColor = System.Drawing.Color.White;
            this.lblCancelar.Location = new System.Drawing.Point(438, 9);
            this.lblCancelar.Name = "lblCancelar";
            this.lblCancelar.Size = new System.Drawing.Size(170, 32);
            this.lblCancelar.TabIndex = 168;
            this.lblCancelar.Text = "Cancelar  [ESC]";
            this.lblCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCancelar.Click += new System.EventHandler(this.lblCancelar_Click);
            // 
            // radPix
            // 
            this.radPix.AutoSize = true;
            this.radPix.Enabled = false;
            this.radPix.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radPix.ForeColor = System.Drawing.Color.White;
            this.radPix.Image = ((System.Drawing.Image)(resources.GetObject("radPix.Image")));
            this.radPix.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.radPix.Location = new System.Drawing.Point(391, 155);
            this.radPix.Name = "radPix";
            this.radPix.Size = new System.Drawing.Size(129, 50);
            this.radPix.TabIndex = 39;
            this.radPix.TabStop = true;
            this.radPix.Tag = "PIX";
            this.radPix.Text = "  [P] PIX";
            this.radPix.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radPix.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radPix.UseVisualStyleBackColor = true;
            // 
            // frmInformaPagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(970, 484);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pnlBandeiras);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmInformaPagamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmInformaPagamento";
            this.Load += new System.EventHandler(this.frmInformaPagamento_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmInformaPagamento_KeyDown);
            this.pnlBandeiras.ResumeLayout(false);
            this.pnlBandeiras.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.pnlTeclado.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlCedulas.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radVisa;
        private System.Windows.Forms.RadioButton radMastercard;
        private System.Windows.Forms.RadioButton radIfood;
        private System.Windows.Forms.RadioButton radOutros;
        private System.Windows.Forms.Panel pnlBandeiras;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNumAutorizacao;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Panel pnlTeclado;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button18;
        public System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnlCedulas;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Button btnLimparValor;
        private System.Windows.Forms.Button btnValorFaltando;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblSalvar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblCancelar;
        private System.Windows.Forms.RadioButton radPix;
    }
}