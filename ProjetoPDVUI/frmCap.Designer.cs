namespace ProjetoPDVUI
{
    partial class frmCap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCap));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstVwCategorias = new System.Windows.Forms.ListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnExpandirCategoria = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.cboFornecedores = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ckCategoriaPrincipal = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblSalvar = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblVoltar = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lstVwCategorias);
            this.groupBox1.Controls.Add(this.btnExpandirCategoria);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtDescricao);
            this.groupBox1.Controls.Add(this.cboFornecedores);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(661, 140);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados Principais";
            // 
            // lstVwCategorias
            // 
            this.lstVwCategorias.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.lstVwCategorias.BackColor = System.Drawing.Color.White;
            this.lstVwCategorias.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader3});
            this.lstVwCategorias.Cursor = System.Windows.Forms.Cursors.Default;
            this.lstVwCategorias.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstVwCategorias.FullRowSelect = true;
            this.lstVwCategorias.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstVwCategorias.HideSelection = false;
            this.lstVwCategorias.Location = new System.Drawing.Point(101, 29);
            this.lstVwCategorias.MultiSelect = false;
            this.lstVwCategorias.Name = "lstVwCategorias";
            this.lstVwCategorias.Size = new System.Drawing.Size(272, 23);
            this.lstVwCategorias.TabIndex = 169;
            this.lstVwCategorias.UseCompatibleStateImageBehavior = false;
            this.lstVwCategorias.View = System.Windows.Forms.View.Details;
            this.lstVwCategorias.SelectedIndexChanged += new System.EventHandler(this.lstVwCategorias_SelectedIndexChanged);
            this.lstVwCategorias.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstVwCategorias_MouseDoubleClick);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "id";
            this.ColumnHeader1.Width = 20;
            // 
            // ColumnHeader3
            // 
            this.ColumnHeader3.Text = "Produto";
            this.ColumnHeader3.Width = 200;
            // 
            // btnExpandirCategoria
            // 
            this.btnExpandirCategoria.Location = new System.Drawing.Point(380, 29);
            this.btnExpandirCategoria.Name = "btnExpandirCategoria";
            this.btnExpandirCategoria.Size = new System.Drawing.Size(45, 23);
            this.btnExpandirCategoria.TabIndex = 27;
            this.btnExpandirCategoria.Text = "button1";
            this.btnExpandirCategoria.UseVisualStyleBackColor = true;
            this.btnExpandirCategoria.Click += new System.EventHandler(this.btnExpandirCategoria_Click);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Location = new System.Drawing.Point(540, 29);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(100, 22);
            this.dateTimePicker2.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(104, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(325, 15);
            this.label6.TabIndex = 25;
            this.label6.Text = "Exemplo: Conta de água Jar/2018; NF Compra 10001; etc.";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(540, 57);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 24;
            this.textBox1.Text = "0,00";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(491, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 15);
            this.label5.TabIndex = 23;
            this.label5.Text = "Valor:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(454, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 15);
            this.label4.TabIndex = 22;
            this.label4.Text = "Vencimento:";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(101, 86);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(327, 22);
            this.txtDescricao.TabIndex = 21;
            // 
            // cboFornecedores
            // 
            this.cboFornecedores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFornecedores.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboFornecedores.FormattingEnabled = true;
            this.cboFornecedores.Location = new System.Drawing.Point(101, 57);
            this.cboFornecedores.Name = "cboFornecedores";
            this.cboFornecedores.Size = new System.Drawing.Size(327, 24);
            this.cboFornecedores.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 15);
            this.label3.TabIndex = 19;
            this.label3.Text = "Descrição:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 15);
            this.label2.TabIndex = 17;
            this.label2.Text = "Fornecedor:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 16;
            this.label1.Text = "Categoria:";
            // 
            // ckCategoriaPrincipal
            // 
            this.ckCategoriaPrincipal.AutoSize = true;
            this.ckCategoriaPrincipal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckCategoriaPrincipal.Location = new System.Drawing.Point(12, 173);
            this.ckCategoriaPrincipal.Name = "ckCategoriaPrincipal";
            this.ckCategoriaPrincipal.Size = new System.Drawing.Size(108, 20);
            this.ckCategoriaPrincipal.TabIndex = 15;
            this.ckCategoriaPrincipal.Text = "Conta Paga";
            this.ckCategoriaPrincipal.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(12, 193);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(661, 56);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(576, 21);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(64, 20);
            this.textBox4.TabIndex = 31;
            this.textBox4.Text = "0,00";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(489, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 15);
            this.label10.TabIndex = 30;
            this.label10.Text = "(=) Valor Pago:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(425, 22);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(64, 20);
            this.textBox3.TabIndex = 29;
            this.textBox3.Text = "0,00";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(333, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 15);
            this.label9.TabIndex = 28;
            this.label9.Text = "(+) Juros/Multa:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(265, 21);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(64, 20);
            this.textBox2.TabIndex = 27;
            this.textBox2.Text = "0,00";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(181, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 15);
            this.label8.TabIndex = 26;
            this.label8.Text = "(-) Descontos:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(80, 21);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(95, 20);
            this.dateTimePicker1.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 15);
            this.label7.TabIndex = 24;
            this.label7.Text = "Pago em:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 283);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(53, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 223;
            this.pictureBox1.TabStop = false;
            // 
            // lblSalvar
            // 
            this.lblSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSalvar.BackColor = System.Drawing.Color.Gainsboro;
            this.lblSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSalvar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalvar.ForeColor = System.Drawing.Color.Black;
            this.lblSalvar.Location = new System.Drawing.Point(24, 288);
            this.lblSalvar.Name = "lblSalvar";
            this.lblSalvar.Size = new System.Drawing.Size(96, 28);
            this.lblSalvar.TabIndex = 222;
            this.lblSalvar.Text = "Salvar";
            this.lblSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSalvar.Click += new System.EventHandler(this.lblSalvar_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox3.BackColor = System.Drawing.Color.Gainsboro;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(566, 288);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(53, 36);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 221;
            this.pictureBox3.TabStop = false;
            // 
            // lblVoltar
            // 
            this.lblVoltar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVoltar.BackColor = System.Drawing.Color.Gainsboro;
            this.lblVoltar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblVoltar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVoltar.ForeColor = System.Drawing.Color.Black;
            this.lblVoltar.Location = new System.Drawing.Point(590, 293);
            this.lblVoltar.Name = "lblVoltar";
            this.lblVoltar.Size = new System.Drawing.Size(80, 28);
            this.lblVoltar.TabIndex = 220;
            this.lblVoltar.Text = "Voltar";
            this.lblVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmCap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(682, 325);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblSalvar);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.lblVoltar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ckCategoriaPrincipal);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmCap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conta a Pagar";
            this.Load += new System.EventHandler(this.frmCap_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboFornecedores;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox ckCategoriaPrincipal;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblSalvar;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblVoltar;
        private System.Windows.Forms.Button btnExpandirCategoria;
        private System.Windows.Forms.ListView lstVwCategorias;
        internal System.Windows.Forms.ColumnHeader ColumnHeader1;
        internal System.Windows.Forms.ColumnHeader ColumnHeader3;
    }
}