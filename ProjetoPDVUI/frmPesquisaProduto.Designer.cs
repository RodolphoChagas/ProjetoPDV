namespace ProjetoPDVUI
{
    partial class frmPesquisaProduto
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboLocalizar = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnRetornar = new System.Windows.Forms.Button();
            this.cboLoja = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstvwProduto = new System.Windows.Forms.ListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelCategoria = new System.Windows.Forms.Panel();
            this.tableCategoria = new System.Windows.Forms.TableLayoutPanel();
            this.panel1.SuspendLayout();
            this.panelCategoria.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panelCategoria);
            this.panel1.Controls.Add(this.cboLocalizar);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnSair);
            this.panel1.Controls.Add(this.btnRetornar);
            this.panel1.Controls.Add(this.cboLoja);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lstvwProduto);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(982, 571);
            this.panel1.TabIndex = 176;
            // 
            // cboLocalizar
            // 
            this.cboLocalizar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocalizar.FormattingEnabled = true;
            this.cboLocalizar.Items.AddRange(new object[] {
            "Descrição",
            "ISBN/EAN"});
            this.cboLocalizar.Location = new System.Drawing.Point(9, 21);
            this.cboLocalizar.Name = "cboLocalizar";
            this.cboLocalizar.Size = new System.Drawing.Size(108, 21);
            this.cboLocalizar.TabIndex = 182;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 14);
            this.label5.TabIndex = 181;
            this.label5.Text = "Localizar por";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(631, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 16);
            this.label3.TabIndex = 180;
            this.label3.Text = "X";
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.LightGray;
            this.btnSair.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSair.Location = new System.Drawing.Point(568, 335);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(75, 23);
            this.btnSair.TabIndex = 179;
            this.btnSair.Text = "&Sair";
            this.btnSair.UseVisualStyleBackColor = false;
            // 
            // btnRetornar
            // 
            this.btnRetornar.BackColor = System.Drawing.Color.LightGray;
            this.btnRetornar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRetornar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRetornar.Location = new System.Drawing.Point(445, 335);
            this.btnRetornar.Name = "btnRetornar";
            this.btnRetornar.Size = new System.Drawing.Size(117, 23);
            this.btnRetornar.TabIndex = 176;
            this.btnRetornar.Text = "&Retornar produto";
            this.btnRetornar.UseVisualStyleBackColor = false;
            // 
            // cboLoja
            // 
            this.cboLoja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoja.FormattingEnabled = true;
            this.cboLoja.Items.AddRange(new object[] {
            "Livraria",
            "Cafeteria"});
            this.cboLoja.Location = new System.Drawing.Point(9, 66);
            this.cboLoja.Name = "cboLoja";
            this.cboLoja.Size = new System.Drawing.Size(108, 21);
            this.cboLoja.TabIndex = 178;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 14);
            this.label1.TabIndex = 177;
            this.label1.Text = "Loja";
            // 
            // lstvwProduto
            // 
            this.lstvwProduto.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader3,
            this.ColumnHeader4,
            this.ColumnHeader5,
            this.columnHeader7});
            this.lstvwProduto.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstvwProduto.FullRowSelect = true;
            this.lstvwProduto.GridLines = true;
            this.lstvwProduto.HideSelection = false;
            this.lstvwProduto.Location = new System.Drawing.Point(3, 104);
            this.lstvwProduto.MultiSelect = false;
            this.lstvwProduto.Name = "lstvwProduto";
            this.lstvwProduto.Size = new System.Drawing.Size(642, 223);
            this.lstvwProduto.TabIndex = 175;
            this.lstvwProduto.UseCompatibleStateImageBehavior = false;
            this.lstvwProduto.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "CodPro";
            // 
            // ColumnHeader3
            // 
            this.ColumnHeader3.Text = "Descrição";
            this.ColumnHeader3.Width = 340;
            // 
            // ColumnHeader4
            // 
            this.ColumnHeader4.Text = "Grupo";
            this.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ColumnHeader4.Width = 100;
            // 
            // ColumnHeader5
            // 
            this.ColumnHeader5.Text = "Estoque";
            this.ColumnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Valor";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panelCategoria
            // 
            this.panelCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCategoria.AutoScroll = true;
            this.panelCategoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCategoria.Controls.Add(this.tableCategoria);
            this.panelCategoria.Location = new System.Drawing.Point(60, 364);
            this.panelCategoria.Name = "panelCategoria";
            this.panelCategoria.Size = new System.Drawing.Size(829, 181);
            this.panelCategoria.TabIndex = 183;
            // 
            // tableCategoria
            // 
            this.tableCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableCategoria.AutoSize = true;
            this.tableCategoria.ColumnCount = 2;
            this.tableCategoria.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableCategoria.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableCategoria.Location = new System.Drawing.Point(3, 2);
            this.tableCategoria.Name = "tableCategoria";
            this.tableCategoria.RowCount = 1;
            this.tableCategoria.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableCategoria.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableCategoria.Size = new System.Drawing.Size(817, 174);
            this.tableCategoria.TabIndex = 1;
            // 
            // frmPesquisaProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(985, 574);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPesquisaProduto";
            this.Text = "frmPesquisaProduto";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelCategoria.ResumeLayout(false);
            this.panelCategoria.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboLocalizar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnRetornar;
        private System.Windows.Forms.ComboBox cboLoja;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lstvwProduto;
        internal System.Windows.Forms.ColumnHeader ColumnHeader1;
        internal System.Windows.Forms.ColumnHeader ColumnHeader3;
        internal System.Windows.Forms.ColumnHeader ColumnHeader4;
        internal System.Windows.Forms.ColumnHeader ColumnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Panel panelCategoria;
        private System.Windows.Forms.TableLayoutPanel tableCategoria;
    }
}