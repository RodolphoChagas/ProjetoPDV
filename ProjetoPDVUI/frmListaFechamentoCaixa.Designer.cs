namespace ProjetoPDVUI
{
    partial class frmListaFechamentoCaixa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListaFechamentoCaixa));
            this.lstVwPedidos = new System.Windows.Forms.ListView();
            this.pedidoId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dataDigitacao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dataNFiscal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.saldoInicial = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.saldoFinal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.usuario = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusCaixa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.observacao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.lblFecharCaixa = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblSair = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lstVwPedidos
            // 
            this.lstVwPedidos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.pedidoId,
            this.dataDigitacao,
            this.dataNFiscal,
            this.saldoInicial,
            this.saldoFinal,
            this.usuario,
            this.statusCaixa,
            this.observacao});
            this.lstVwPedidos.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstVwPedidos.FullRowSelect = true;
            this.lstVwPedidos.GridLines = true;
            this.lstVwPedidos.HideSelection = false;
            this.lstVwPedidos.Location = new System.Drawing.Point(11, 95);
            this.lstVwPedidos.MultiSelect = false;
            this.lstVwPedidos.Name = "lstVwPedidos";
            this.lstVwPedidos.Size = new System.Drawing.Size(1002, 323);
            this.lstVwPedidos.TabIndex = 198;
            this.lstVwPedidos.UseCompatibleStateImageBehavior = false;
            this.lstVwPedidos.View = System.Windows.Forms.View.Details;
            // 
            // pedidoId
            // 
            this.pedidoId.Text = "Cód. Caixa";
            this.pedidoId.Width = 80;
            // 
            // dataDigitacao
            // 
            this.dataDigitacao.Text = "Aberto Em";
            this.dataDigitacao.Width = 150;
            // 
            // dataNFiscal
            // 
            this.dataNFiscal.Text = "Fechado Em";
            this.dataNFiscal.Width = 150;
            // 
            // saldoInicial
            // 
            this.saldoInicial.Text = "Saldo Inicial";
            this.saldoInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.saldoInicial.Width = 100;
            // 
            // saldoFinal
            // 
            this.saldoFinal.Text = "Saldo Final";
            this.saldoFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.saldoFinal.Width = 100;
            // 
            // usuario
            // 
            this.usuario.Text = "Usuário";
            this.usuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.usuario.Width = 130;
            // 
            // statusCaixa
            // 
            this.statusCaixa.Text = "Status Caixa";
            this.statusCaixa.Width = 100;
            // 
            // observacao
            // 
            this.observacao.Text = "Observação";
            this.observacao.Width = 185;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(11, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1002, 84);
            this.groupBox1.TabIndex = 199;
            this.groupBox1.TabStop = false;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(16, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(132, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Exibir os mais recentes";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // lblFecharCaixa
            // 
            this.lblFecharCaixa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFecharCaixa.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblFecharCaixa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFecharCaixa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecharCaixa.ForeColor = System.Drawing.Color.Black;
            this.lblFecharCaixa.Location = new System.Drawing.Point(24, 431);
            this.lblFecharCaixa.Name = "lblFecharCaixa";
            this.lblFecharCaixa.Size = new System.Drawing.Size(136, 28);
            this.lblFecharCaixa.TabIndex = 209;
            this.lblFecharCaixa.Text = "Visualizar [F3]";
            this.lblFecharCaixa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblFecharCaixa.Click += new System.EventHandler(this.lblFecharCaixa_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 426);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(53, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 210;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(888, 429);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(53, 36);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 212;
            this.pictureBox2.TabStop = false;
            // 
            // lblSair
            // 
            this.lblSair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSair.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblSair.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSair.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSair.ForeColor = System.Drawing.Color.Black;
            this.lblSair.Location = new System.Drawing.Point(942, 434);
            this.lblSair.Name = "lblSair";
            this.lblSair.Size = new System.Drawing.Size(69, 28);
            this.lblSair.TabIndex = 211;
            this.lblSair.Text = "Sair [ESC]";
            this.lblSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmListaFechamentoCaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1023, 468);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblSair);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblFecharCaixa);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lstVwPedidos);
            this.Name = "frmListaFechamentoCaixa";
            this.Text = "Relatório de Fechamento de Caixa";
            this.Load += new System.EventHandler(this.frmListaFechamentoCaixa_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstVwPedidos;
        internal System.Windows.Forms.ColumnHeader pedidoId;
        private System.Windows.Forms.ColumnHeader dataDigitacao;
        private System.Windows.Forms.ColumnHeader dataNFiscal;
        private System.Windows.Forms.ColumnHeader saldoInicial;
        private System.Windows.Forms.ColumnHeader saldoFinal;
        private System.Windows.Forms.ColumnHeader usuario;
        private System.Windows.Forms.ColumnHeader statusCaixa;
        private System.Windows.Forms.ColumnHeader observacao;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblFecharCaixa;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblSair;
    }
}