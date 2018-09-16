namespace ProjetoPDVUI
{
    partial class frmProdutoGrupoFiscal
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
            this.label8 = new System.Windows.Forms.Label();
            this.txtCodGrupo = new System.Windows.Forms.TextBox();
            this.txtCEST = new System.Windows.Forms.TextBox();
            this.txtNCM = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDescGrupo = new System.Windows.Forms.TextBox();
            this.txtIRPJ = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboICMS = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCSOSN = new System.Windows.Forms.TextBox();
            this.txtCSLL = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtCOFINS = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCOFINSCST = new System.Windows.Forms.TextBox();
            this.lstvwGrupo = new System.Windows.Forms.ListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPIS = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPISCST = new System.Windows.Forms.TextBox();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(419, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(403, 23);
            this.label8.TabIndex = 185;
            this.label8.Text = "Cadastro de Grupos Fiscais";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCodGrupo
            // 
            this.txtCodGrupo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodGrupo.Location = new System.Drawing.Point(15, 20);
            this.txtCodGrupo.Name = "txtCodGrupo";
            this.txtCodGrupo.Size = new System.Drawing.Size(25, 21);
            this.txtCodGrupo.TabIndex = 5;
            this.txtCodGrupo.Text = "0";
            this.txtCodGrupo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodGrupo.Visible = false;
            // 
            // txtCEST
            // 
            this.txtCEST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCEST.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCEST.Location = new System.Drawing.Point(656, 20);
            this.txtCEST.Name = "txtCEST";
            this.txtCEST.Size = new System.Drawing.Size(125, 21);
            this.txtCEST.TabIndex = 4;
            this.txtCEST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCEST.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCEST_KeyPress);
            // 
            // txtNCM
            // 
            this.txtNCM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNCM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNCM.Location = new System.Drawing.Point(479, 20);
            this.txtNCM.Name = "txtNCM";
            this.txtNCM.Size = new System.Drawing.Size(125, 21);
            this.txtNCM.TabIndex = 3;
            this.txtNCM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNCM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNCM_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(610, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "CEST";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(437, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "NCM";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtCodGrupo);
            this.groupBox2.Controls.Add(this.txtCEST);
            this.groupBox2.Controls.Add(this.txtNCM);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtDescGrupo);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(796, 50);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Descrição";
            // 
            // txtDescGrupo
            // 
            this.txtDescGrupo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescGrupo.Location = new System.Drawing.Point(15, 20);
            this.txtDescGrupo.Name = "txtDescGrupo";
            this.txtDescGrupo.Size = new System.Drawing.Size(371, 21);
            this.txtDescGrupo.TabIndex = 0;
            // 
            // txtIRPJ
            // 
            this.txtIRPJ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIRPJ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIRPJ.Location = new System.Drawing.Point(334, 28);
            this.txtIRPJ.Name = "txtIRPJ";
            this.txtIRPJ.Size = new System.Drawing.Size(46, 21);
            this.txtIRPJ.TabIndex = 14;
            this.txtIRPJ.Text = "0";
            this.txtIRPJ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIRPJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIRPJ_KeyPress);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.cboICMS);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtCSOSN);
            this.groupBox3.Controls.Add(this.txtIRPJ);
            this.groupBox3.Controls.Add(this.txtCSLL);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(413, 77);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(395, 99);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ICMS";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(9, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 16);
            this.label9.TabIndex = 18;
            this.label9.Text = "ICMS ST";
            // 
            // cboICMS
            // 
            this.cboICMS.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboICMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboICMS.FormattingEnabled = true;
            this.cboICMS.Items.AddRange(new object[] {
            "Tributado integralmente",
            "Não tributado - Substituição Tributária"});
            this.cboICMS.Location = new System.Drawing.Point(81, 57);
            this.cboICMS.Name = "cboICMS";
            this.cboICMS.Size = new System.Drawing.Size(299, 23);
            this.cboICMS.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(9, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 16);
            this.label7.TabIndex = 16;
            this.label7.Text = "CSOSN";
            // 
            // txtCSOSN
            // 
            this.txtCSOSN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCSOSN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCSOSN.Location = new System.Drawing.Point(81, 26);
            this.txtCSOSN.Name = "txtCSOSN";
            this.txtCSOSN.Size = new System.Drawing.Size(61, 21);
            this.txtCSOSN.TabIndex = 15;
            this.txtCSOSN.Text = "0";
            this.txtCSOSN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCSOSN.TextChanged += new System.EventHandler(this.txtCSOSN_TextChanged);
            // 
            // txtCSLL
            // 
            this.txtCSLL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCSLL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCSLL.Location = new System.Drawing.Point(244, 28);
            this.txtCSLL.Name = "txtCSLL";
            this.txtCSLL.Size = new System.Drawing.Size(46, 21);
            this.txtCSLL.TabIndex = 13;
            this.txtCSLL.Text = "0";
            this.txtCSLL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCSLL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCSLL_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(203, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "CSLL";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(296, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "IRPJ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.lstvwGrupo);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnAplicar);
            this.groupBox1.Controls.Add(this.btnExcluir);
            this.groupBox1.Controls.Add(this.btnNovo);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.groupBox1.Location = new System.Drawing.Point(6, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(818, 383);
            this.groupBox1.TabIndex = 184;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Grupo Fiscal";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtCOFINS);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.txtCOFINSCST);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(413, 243);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(395, 53);
            this.groupBox5.TabIndex = 177;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "COFINS";
            // 
            // txtCOFINS
            // 
            this.txtCOFINS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCOFINS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCOFINS.Location = new System.Drawing.Point(172, 20);
            this.txtCOFINS.Name = "txtCOFINS";
            this.txtCOFINS.Size = new System.Drawing.Size(46, 21);
            this.txtCOFINS.TabIndex = 14;
            this.txtCOFINS.Text = "0";
            this.txtCOFINS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(114, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "COFINS";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(9, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 16);
            this.label11.TabIndex = 12;
            this.label11.Text = "CST";
            // 
            // txtCOFINSCST
            // 
            this.txtCOFINSCST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCOFINSCST.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCOFINSCST.Location = new System.Drawing.Point(50, 21);
            this.txtCOFINSCST.Name = "txtCOFINSCST";
            this.txtCOFINSCST.Size = new System.Drawing.Size(46, 21);
            this.txtCOFINSCST.TabIndex = 11;
            this.txtCOFINSCST.Text = "0";
            this.txtCOFINSCST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lstvwGrupo
            // 
            this.lstvwGrupo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader4});
            this.lstvwGrupo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstvwGrupo.FullRowSelect = true;
            this.lstvwGrupo.GridLines = true;
            this.lstvwGrupo.HideSelection = false;
            this.lstvwGrupo.Location = new System.Drawing.Point(12, 79);
            this.lstvwGrupo.MultiSelect = false;
            this.lstvwGrupo.Name = "lstvwGrupo";
            this.lstvwGrupo.Size = new System.Drawing.Size(386, 266);
            this.lstvwGrupo.TabIndex = 176;
            this.lstvwGrupo.UseCompatibleStateImageBehavior = false;
            this.lstvwGrupo.View = System.Windows.Forms.View.Details;
            this.lstvwGrupo.SelectedIndexChanged += new System.EventHandler(this.lstvwGrupo_SelectedIndexChanged);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Código";
            // 
            // ColumnHeader4
            // 
            this.ColumnHeader4.Text = "Grupo";
            this.ColumnHeader4.Width = 297;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightGray;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(744, 350);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 25);
            this.button1.TabIndex = 7;
            this.button1.Text = "&Sair";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAplicar
            // 
            this.btnAplicar.BackColor = System.Drawing.Color.LightGray;
            this.btnAplicar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAplicar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAplicar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicar.ForeColor = System.Drawing.Color.Black;
            this.btnAplicar.Location = new System.Drawing.Point(628, 350);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(105, 25);
            this.btnAplicar.TabIndex = 6;
            this.btnAplicar.Text = "&Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = false;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.BackColor = System.Drawing.Color.LightGray;
            this.btnExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.ForeColor = System.Drawing.Color.Black;
            this.btnExcluir.Location = new System.Drawing.Point(105, 350);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 25);
            this.btnExcluir.TabIndex = 5;
            this.btnExcluir.Text = "&Excluir";
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.BackColor = System.Drawing.Color.LightGray;
            this.btnNovo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovo.ForeColor = System.Drawing.Color.Black;
            this.btnNovo.Location = new System.Drawing.Point(12, 350);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(75, 25);
            this.btnNovo.TabIndex = 4;
            this.btnNovo.Text = "&Novo";
            this.btnNovo.UseVisualStyleBackColor = false;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.txtPIS);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.txtPISCST);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(413, 184);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(395, 53);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "PIS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(142, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "PIS";
            // 
            // txtPIS
            // 
            this.txtPIS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPIS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPIS.Location = new System.Drawing.Point(172, 20);
            this.txtPIS.Name = "txtPIS";
            this.txtPIS.Size = new System.Drawing.Size(46, 21);
            this.txtPIS.TabIndex = 11;
            this.txtPIS.Text = "0";
            this.txtPIS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(9, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 16);
            this.label10.TabIndex = 10;
            this.label10.Text = "CST";
            // 
            // txtPISCST
            // 
            this.txtPISCST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPISCST.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPISCST.Location = new System.Drawing.Point(50, 21);
            this.txtPISCST.Name = "txtPISCST";
            this.txtPISCST.Size = new System.Drawing.Size(46, 21);
            this.txtPISCST.TabIndex = 9;
            this.txtPISCST.Text = "0";
            this.txtPISCST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rectangleShape1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.rectangleShape1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rectangleShape1.CornerRadius = 1;
            this.rectangleShape1.FillGradientColor = System.Drawing.Color.DimGray;
            this.rectangleShape1.Location = new System.Drawing.Point(0, 0);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(828, 47);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(829, 441);
            this.shapeContainer1.TabIndex = 186;
            this.shapeContainer1.TabStop = false;
            // 
            // frmProdutoGrupoFiscal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(829, 441);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmProdutoGrupoFiscal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmProdutoGrupoFiscal";
            this.Load += new System.EventHandler(this.frmProdutoGrupoFiscal_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCodGrupo;
        private System.Windows.Forms.TextBox txtCEST;
        private System.Windows.Forms.TextBox txtNCM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDescGrupo;
        private System.Windows.Forms.TextBox txtIRPJ;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtCSLL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lstvwGrupo;
        internal System.Windows.Forms.ColumnHeader ColumnHeader1;
        internal System.Windows.Forms.ColumnHeader ColumnHeader4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.GroupBox groupBox4;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboICMS;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCSOSN;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCOFINSCST;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPISCST;
        private System.Windows.Forms.TextBox txtCOFINS;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPIS;
    }
}