namespace ProjetoSeriesDeTv
{
    partial class frmMinhasSeriesFavoritas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMinhasSeriesFavoritas));
            this.listViewSeries = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBoxSeriesPorCategoria = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnListarSeriesDaquelaCategoria = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // listViewSeries
            // 
            this.listViewSeries.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.listViewSeries.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewSeries.AutoArrange = false;
            this.listViewSeries.BackColor = System.Drawing.SystemColors.Info;
            this.listViewSeries.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewSeries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader7});
            this.listViewSeries.FullRowSelect = true;
            this.listViewSeries.GridLines = true;
            this.listViewSeries.HideSelection = false;
            this.listViewSeries.Location = new System.Drawing.Point(38, 103);
            this.listViewSeries.Name = "listViewSeries";
            this.listViewSeries.Size = new System.Drawing.Size(1094, 364);
            this.listViewSeries.TabIndex = 1;
            this.listViewSeries.UseCompatibleStateImageBehavior = false;
            this.listViewSeries.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Código";
            this.columnHeader1.Width = 65;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Série";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Temporada Atual";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Último Episódio Assistido";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader4.Width = 150;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Total de Temporadas";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader5.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Categoria";
            this.columnHeader7.Width = 120;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 20F);
            this.label8.Image = ((System.Drawing.Image)(resources.GetObject("label8.Image")));
            this.label8.Location = new System.Drawing.Point(472, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(402, 49);
            this.label8.TabIndex = 19;
            this.label8.Text = "Minhas Séries Favoritas";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.ErrorImage")));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(422, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(44, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // comboBoxSeriesPorCategoria
            // 
            this.comboBoxSeriesPorCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSeriesPorCategoria.FormattingEnabled = true;
            this.comboBoxSeriesPorCategoria.Location = new System.Drawing.Point(535, 494);
            this.comboBoxSeriesPorCategoria.Name = "comboBoxSeriesPorCategoria";
            this.comboBoxSeriesPorCategoria.Size = new System.Drawing.Size(278, 28);
            this.comboBoxSeriesPorCategoria.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F);
            this.label6.Image = ((System.Drawing.Image)(resources.GetObject("label6.Image")));
            this.label6.Location = new System.Drawing.Point(47, 493);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(482, 29);
            this.label6.TabIndex = 23;
            this.label6.Text = "Selecione a categoria que você deseja visualizar";
            // 
            // btnListarSeriesDaquelaCategoria
            // 
            this.btnListarSeriesDaquelaCategoria.Location = new System.Drawing.Point(830, 490);
            this.btnListarSeriesDaquelaCategoria.Name = "btnListarSeriesDaquelaCategoria";
            this.btnListarSeriesDaquelaCategoria.Size = new System.Drawing.Size(97, 38);
            this.btnListarSeriesDaquelaCategoria.TabIndex = 25;
            this.btnListarSeriesDaquelaCategoria.Text = "Listar";
            this.btnListarSeriesDaquelaCategoria.UseVisualStyleBackColor = true;
            this.btnListarSeriesDaquelaCategoria.Click += new System.EventHandler(this.BtnListarSeriesDaquelaCategoria_Click);
            // 
            // frmMinhasSeriesFavoritas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1336, 662);
            this.Controls.Add(this.btnListarSeriesDaquelaCategoria);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBoxSeriesPorCategoria);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.listViewSeries);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmMinhasSeriesFavoritas";
            this.Text = "Gerenciamento das Séries";
            this.Load += new System.EventHandler(this.FrmGerenciamentoSeries_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView listViewSeries;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox comboBoxSeriesPorCategoria;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnListarSeriesDaquelaCategoria;
    }
}