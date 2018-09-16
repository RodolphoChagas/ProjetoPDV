namespace ProjetoPDVUI
{
    partial class frmListaContasAPagar
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
            this.rectangleShape8 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lstvwFornecedores = new System.Windows.Forms.ListView();
            this.forncedor_id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Nome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Email = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // rectangleShape8
            // 
            this.rectangleShape8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rectangleShape8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rectangleShape8.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.rectangleShape8.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rectangleShape8.BorderWidth = 3;
            this.rectangleShape8.CornerRadius = 1;
            this.rectangleShape8.Location = new System.Drawing.Point(252, 1);
            this.rectangleShape8.Name = "rectangleShape8";
            this.rectangleShape8.Size = new System.Drawing.Size(780, 59);
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rectangleShape1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rectangleShape1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.rectangleShape1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rectangleShape1.BorderWidth = 3;
            this.rectangleShape1.CornerRadius = 1;
            this.rectangleShape1.Location = new System.Drawing.Point(253, 421);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(775, 56);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape1,
            this.rectangleShape8});
            this.shapeContainer1.Size = new System.Drawing.Size(1030, 479);
            this.shapeContainer1.TabIndex = 0;
            this.shapeContainer1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(252, 479);
            this.panel1.TabIndex = 1;
            // 
            // lstvwFornecedores
            // 
            this.lstvwFornecedores.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.forncedor_id,
            this.Nome,
            this.columnHeader6,
            this.Email});
            this.lstvwFornecedores.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstvwFornecedores.FullRowSelect = true;
            this.lstvwFornecedores.GridLines = true;
            this.lstvwFornecedores.HideSelection = false;
            this.lstvwFornecedores.Location = new System.Drawing.Point(252, 66);
            this.lstvwFornecedores.MultiSelect = false;
            this.lstvwFornecedores.Name = "lstvwFornecedores";
            this.lstvwFornecedores.Size = new System.Drawing.Size(833, 351);
            this.lstvwFornecedores.TabIndex = 195;
            this.lstvwFornecedores.UseCompatibleStateImageBehavior = false;
            this.lstvwFornecedores.View = System.Windows.Forms.View.Details;
            // 
            // forncedor_id
            // 
            this.forncedor_id.Text = "forncedor_id";
            this.forncedor_id.Width = 0;
            // 
            // Nome
            // 
            this.Nome.Text = "Nome";
            this.Nome.Width = 400;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Telefone Principal";
            this.columnHeader6.Width = 200;
            // 
            // Email
            // 
            this.Email.Text = "Email";
            this.Email.Width = 320;
            // 
            // frmListaContasAPagar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1030, 479);
            this.Controls.Add(this.lstvwFornecedores);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmListaContasAPagar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contas a Pgar";
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape8;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lstvwFornecedores;
        internal System.Windows.Forms.ColumnHeader forncedor_id;
        private System.Windows.Forms.ColumnHeader Nome;
        internal System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader Email;
    }
}