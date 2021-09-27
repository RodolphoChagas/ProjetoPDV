namespace ProjetoPDVUI
{
    partial class frmSangria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSangria));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panelOperacao = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.rdEntrada = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.rdSaidaSangria = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.rdSaidaDespesa = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblVoltar = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblSalvar = new System.Windows.Forms.Label();
            this.ckImprimir = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panelOperacao.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ckImprimir);
            this.panel1.Controls.Add(this.txtObservacao);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtValor);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.panelOperacao);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(454, 327);
            this.panel1.TabIndex = 0;
            // 
            // txtObservacao
            // 
            this.txtObservacao.Location = new System.Drawing.Point(122, 267);
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.Size = new System.Drawing.Size(307, 41);
            this.txtObservacao.TabIndex = 7;
            this.txtObservacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(42, 274);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Observação:";
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(122, 237);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(102, 20);
            this.txtValor.TabIndex = 5;
            this.txtValor.Text = "0,00";
            this.txtValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtValor_MouseClick);
            this.txtValor.TextChanged += new System.EventHandler(this.txtValor_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(76, 242);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Valor:";
            // 
            // panelOperacao
            // 
            this.panelOperacao.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelOperacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOperacao.Controls.Add(this.label5);
            this.panelOperacao.Controls.Add(this.rdEntrada);
            this.panelOperacao.Controls.Add(this.label4);
            this.panelOperacao.Controls.Add(this.rdSaidaSangria);
            this.panelOperacao.Controls.Add(this.label3);
            this.panelOperacao.Controls.Add(this.rdSaidaDespesa);
            this.panelOperacao.Location = new System.Drawing.Point(123, 50);
            this.panelOperacao.Name = "panelOperacao";
            this.panelOperacao.Size = new System.Drawing.Size(306, 172);
            this.panelOperacao.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label5.Location = new System.Drawing.Point(27, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(220, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Não registra lançamento no contas a receber";
            // 
            // rdEntrada
            // 
            this.rdEntrada.AutoSize = true;
            this.rdEntrada.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rdEntrada.Location = new System.Drawing.Point(14, 115);
            this.rdEntrada.Name = "rdEntrada";
            this.rdEntrada.Size = new System.Drawing.Size(126, 18);
            this.rdEntrada.TabIndex = 6;
            this.rdEntrada.Tag = "4";
            this.rdEntrada.Text = "Entrada - Acréscimo";
            this.rdEntrada.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label4.Location = new System.Drawing.Point(27, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(211, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Não registra lançamento no contas a pagar";
            // 
            // rdSaidaSangria
            // 
            this.rdSaidaSangria.AutoSize = true;
            this.rdSaidaSangria.Checked = true;
            this.rdSaidaSangria.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rdSaidaSangria.Location = new System.Drawing.Point(14, 64);
            this.rdSaidaSangria.Name = "rdSaidaSangria";
            this.rdSaidaSangria.Size = new System.Drawing.Size(105, 18);
            this.rdSaidaSangria.TabIndex = 4;
            this.rdSaidaSangria.TabStop = true;
            this.rdSaidaSangria.Tag = "2";
            this.rdSaidaSangria.Text = "Saída - Sangria";
            this.rdSaidaSangria.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label3.Location = new System.Drawing.Point(27, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(248, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Registra lançamento automático no contas a pagar";
            // 
            // rdSaidaDespesa
            // 
            this.rdSaidaDespesa.AutoSize = true;
            this.rdSaidaDespesa.Enabled = false;
            this.rdSaidaDespesa.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rdSaidaDespesa.Location = new System.Drawing.Point(14, 13);
            this.rdSaidaDespesa.Name = "rdSaidaDespesa";
            this.rdSaidaDespesa.Size = new System.Drawing.Size(188, 18);
            this.rdSaidaDespesa.TabIndex = 1;
            this.rdSaidaDespesa.Text = "Saída - Lançamento de Despesa";
            this.rdSaidaDespesa.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tipo de Operação:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.radioButton1);
            this.panel2.Location = new System.Drawing.Point(123, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(306, 26);
            this.panel2.TabIndex = 1;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton1.Location = new System.Drawing.Point(30, 4);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(70, 18);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Dinheiro";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Forma de Pagto.:";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox3.BackColor = System.Drawing.Color.Gainsboro;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(368, 355);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(53, 36);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 214;
            this.pictureBox3.TabStop = false;
            // 
            // lblVoltar
            // 
            this.lblVoltar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVoltar.BackColor = System.Drawing.Color.Gainsboro;
            this.lblVoltar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblVoltar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVoltar.ForeColor = System.Drawing.Color.Black;
            this.lblVoltar.Location = new System.Drawing.Point(386, 360);
            this.lblVoltar.Name = "lblVoltar";
            this.lblVoltar.Size = new System.Drawing.Size(80, 28);
            this.lblVoltar.TabIndex = 213;
            this.lblVoltar.Text = "Voltar";
            this.lblVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblVoltar.Click += new System.EventHandler(this.lblVoltar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(16, 355);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(53, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 212;
            this.pictureBox1.TabStop = false;
            // 
            // lblSalvar
            // 
            this.lblSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSalvar.BackColor = System.Drawing.Color.Gainsboro;
            this.lblSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSalvar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalvar.ForeColor = System.Drawing.Color.Black;
            this.lblSalvar.Location = new System.Drawing.Point(27, 360);
            this.lblSalvar.Name = "lblSalvar";
            this.lblSalvar.Size = new System.Drawing.Size(88, 28);
            this.lblSalvar.TabIndex = 211;
            this.lblSalvar.Text = "Salvar";
            this.lblSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSalvar.Click += new System.EventHandler(this.lblSalvar_Click);
            // 
            // ckImprimir
            // 
            this.ckImprimir.AutoSize = true;
            this.ckImprimir.Checked = true;
            this.ckImprimir.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckImprimir.Location = new System.Drawing.Point(3, 309);
            this.ckImprimir.Name = "ckImprimir";
            this.ckImprimir.Size = new System.Drawing.Size(109, 17);
            this.ckImprimir.TabIndex = 215;
            this.ckImprimir.Text = "Imprimir ao Salvar";
            this.ckImprimir.UseVisualStyleBackColor = true;
            // 
            // frmSangria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(478, 397);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.lblVoltar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblSalvar);
            this.Controls.Add(this.panel1);
            this.Name = "frmSangria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adicionar Saída / Entrada no Caixa";
            this.Load += new System.EventHandler(this.frmSangria_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelOperacao.ResumeLayout(false);
            this.panelOperacao.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelOperacao;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rdEntrada;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rdSaidaSangria;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdSaidaDespesa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblVoltar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblSalvar;
        private System.Windows.Forms.CheckBox ckImprimir;
    }
}