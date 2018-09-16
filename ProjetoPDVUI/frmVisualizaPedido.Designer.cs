namespace ProjetoPDVUI
{
    partial class frmVisualizaPedido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVisualizaPedido));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblPedido = new System.Windows.Forms.Label();
            this.lblStatusCaixa = new System.Windows.Forms.Label();
            this.lstVwProdutos = new System.Windows.Forms.ListView();
            this.produtoId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.produto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.qtd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.valorUnitario = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.total = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTroco = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblOutros = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblCartaoCredito = new System.Windows.Forms.Label();
            this.lblCartaoDebito = new System.Windows.Forms.Label();
            this.lblDinheiro = new System.Windows.Forms.Label();
            this.lblDinheiros = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblSair = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.lblPedido);
            this.panel1.Controls.Add(this.lblStatusCaixa);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(227, 466);
            this.panel1.TabIndex = 1;
            // 
            // lblPedido
            // 
            this.lblPedido.AutoSize = true;
            this.lblPedido.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPedido.ForeColor = System.Drawing.Color.White;
            this.lblPedido.Location = new System.Drawing.Point(11, 112);
            this.lblPedido.Name = "lblPedido";
            this.lblPedido.Size = new System.Drawing.Size(69, 13);
            this.lblPedido.TabIndex = 1;
            this.lblPedido.Text = "Pedido 000";
            // 
            // lblStatusCaixa
            // 
            this.lblStatusCaixa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatusCaixa.BackColor = System.Drawing.Color.IndianRed;
            this.lblStatusCaixa.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusCaixa.ForeColor = System.Drawing.Color.White;
            this.lblStatusCaixa.Location = new System.Drawing.Point(-3, 0);
            this.lblStatusCaixa.Name = "lblStatusCaixa";
            this.lblStatusCaixa.Size = new System.Drawing.Size(230, 51);
            this.lblStatusCaixa.TabIndex = 0;
            this.lblStatusCaixa.Text = "Pedido Fechado";
            this.lblStatusCaixa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstVwProdutos
            // 
            this.lstVwProdutos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.produtoId,
            this.produto,
            this.qtd,
            this.valorUnitario,
            this.total});
            this.lstVwProdutos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstVwProdutos.FullRowSelect = true;
            this.lstVwProdutos.GridLines = true;
            this.lstVwProdutos.HideSelection = false;
            this.lstVwProdutos.Location = new System.Drawing.Point(229, 2);
            this.lstVwProdutos.MultiSelect = false;
            this.lstVwProdutos.Name = "lstVwProdutos";
            this.lstVwProdutos.Size = new System.Drawing.Size(432, 403);
            this.lstVwProdutos.TabIndex = 217;
            this.lstVwProdutos.UseCompatibleStateImageBehavior = false;
            this.lstVwProdutos.View = System.Windows.Forms.View.Details;
            // 
            // produtoId
            // 
            this.produtoId.Text = "Código";
            this.produtoId.Width = 0;
            // 
            // produto
            // 
            this.produto.Text = "Descrição";
            this.produto.Width = 178;
            // 
            // qtd
            // 
            this.qtd.Text = "Quantidade";
            this.qtd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.qtd.Width = 68;
            // 
            // valorUnitario
            // 
            this.valorUnitario.Text = "Valor Unitário";
            this.valorUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.valorUnitario.Width = 88;
            // 
            // total
            // 
            this.total.Text = "Valor Total";
            this.total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.total.Width = 87;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.PapayaWhip;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.lblTotal);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.lblTroco);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.lblOutros);
            this.panel4.Controls.Add(this.label21);
            this.panel4.Controls.Add(this.lblCartaoCredito);
            this.panel4.Controls.Add(this.lblCartaoDebito);
            this.panel4.Controls.Add(this.lblDinheiro);
            this.panel4.Controls.Add(this.lblDinheiros);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.label10);
            this.panel4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel4.Location = new System.Drawing.Point(667, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(220, 403);
            this.panel4.TabIndex = 218;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(138, 197);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(71, 13);
            this.lblTotal.TabIndex = 27;
            this.lblTotal.Text = "0,00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(3, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 14);
            this.label2.TabIndex = 26;
            this.label2.Text = "Total do Pedido";
            // 
            // lblTroco
            // 
            this.lblTroco.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTroco.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTroco.ForeColor = System.Drawing.Color.Black;
            this.lblTroco.Location = new System.Drawing.Point(135, 171);
            this.lblTroco.Name = "lblTroco";
            this.lblTroco.Size = new System.Drawing.Size(74, 13);
            this.lblTroco.TabIndex = 25;
            this.lblTroco.Text = "0,00";
            this.lblTroco.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(3, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 14);
            this.label1.TabIndex = 24;
            this.label1.Text = "Troco";
            // 
            // lblOutros
            // 
            this.lblOutros.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutros.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblOutros.Location = new System.Drawing.Point(123, 94);
            this.lblOutros.Name = "lblOutros";
            this.lblOutros.Size = new System.Drawing.Size(86, 13);
            this.lblOutros.TabIndex = 23;
            this.lblOutros.Text = "0,00";
            this.lblOutros.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(1, 94);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(40, 13);
            this.label21.TabIndex = 22;
            this.label21.Text = "Outros";
            // 
            // lblCartaoCredito
            // 
            this.lblCartaoCredito.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCartaoCredito.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblCartaoCredito.Location = new System.Drawing.Point(123, 77);
            this.lblCartaoCredito.Name = "lblCartaoCredito";
            this.lblCartaoCredito.Size = new System.Drawing.Size(86, 13);
            this.lblCartaoCredito.TabIndex = 16;
            this.lblCartaoCredito.Text = "0,00";
            this.lblCartaoCredito.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCartaoDebito
            // 
            this.lblCartaoDebito.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCartaoDebito.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblCartaoDebito.Location = new System.Drawing.Point(123, 58);
            this.lblCartaoDebito.Name = "lblCartaoDebito";
            this.lblCartaoDebito.Size = new System.Drawing.Size(86, 13);
            this.lblCartaoDebito.TabIndex = 15;
            this.lblCartaoDebito.Text = "0,00";
            this.lblCartaoDebito.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDinheiro
            // 
            this.lblDinheiro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDinheiro.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblDinheiro.Location = new System.Drawing.Point(123, 39);
            this.lblDinheiro.Name = "lblDinheiro";
            this.lblDinheiro.Size = new System.Drawing.Size(86, 13);
            this.lblDinheiro.TabIndex = 14;
            this.lblDinheiro.Text = "0,00";
            this.lblDinheiro.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDinheiros
            // 
            this.lblDinheiros.AutoSize = true;
            this.lblDinheiros.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDinheiros.ForeColor = System.Drawing.Color.Black;
            this.lblDinheiros.Location = new System.Drawing.Point(1, 39);
            this.lblDinheiros.Name = "lblDinheiros";
            this.lblDinheiros.Size = new System.Drawing.Size(46, 13);
            this.lblDinheiros.TabIndex = 5;
            this.lblDinheiros.Text = "Dinheiro";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(1, 77);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "Cartão de Crédito";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(1, 58);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "Cartão de Débito";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label10.Location = new System.Drawing.Point(14, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "PAGAMENTOS";
            // 
            // lblSair
            // 
            this.lblSair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSair.BackColor = System.Drawing.Color.LightGray;
            this.lblSair.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSair.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSair.ForeColor = System.Drawing.Color.Black;
            this.lblSair.Location = new System.Drawing.Point(800, 431);
            this.lblSair.Name = "lblSair";
            this.lblSair.Size = new System.Drawing.Size(80, 28);
            this.lblSair.TabIndex = 219;
            this.lblSair.Text = "Sair";
            this.lblSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSair.Click += new System.EventHandler(this.lblSair_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.BackColor = System.Drawing.Color.LightGray;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(786, 426);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(53, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 220;
            this.pictureBox1.TabStop = false;
            // 
            // frmVisualizaPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 468);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblSair);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.lstVwProdutos);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "frmVisualizaPedido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmVisualizaPedido";
            this.Load += new System.EventHandler(this.frmVisualizaPedido_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmVisualizaPedido_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblPedido;
        private System.Windows.Forms.Label lblStatusCaixa;
        private System.Windows.Forms.ListView lstVwProdutos;
        internal System.Windows.Forms.ColumnHeader produtoId;
        internal System.Windows.Forms.ColumnHeader produto;
        internal System.Windows.Forms.ColumnHeader qtd;
        internal System.Windows.Forms.ColumnHeader valorUnitario;
        private System.Windows.Forms.ColumnHeader total;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblOutros;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblCartaoCredito;
        private System.Windows.Forms.Label lblCartaoDebito;
        private System.Windows.Forms.Label lblDinheiro;
        private System.Windows.Forms.Label lblDinheiros;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblSair;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTroco;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label2;
    }
}