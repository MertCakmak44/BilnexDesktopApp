namespace BilnexDesktopApp
{
    partial class StockForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvStocks;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnRefresh;

        /// <summary>
        /// Temizleme işlemi
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvStocks = new DataGridView();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnRefresh = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvStocks).BeginInit();
            SuspendLayout();

            // 
            // dgvStocks
            // 
            dgvStocks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStocks.Location = new Point(12, 54);
            dgvStocks.Name = "dgvStocks";
            dgvStocks.Size = new Size(640, 338);
            dgvStocks.TabIndex = 0;
            dgvStocks.CellDoubleClick += new DataGridViewCellEventHandler(this.dgvStocks_CellDoubleClick);

            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(28, 12);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(82, 36);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Ekle";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += new EventHandler(this.Add_Click);

            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(184, 12);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(91, 36);
            btnUpdate.TabIndex = 2;
            btnUpdate.Text = "Güncelle";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += new EventHandler(this.Update_Click);

            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(379, 12);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(90, 36);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Sil";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += new EventHandler(this.Delete_Click);

            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(546, 12);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(84, 36);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Yenile";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += new EventHandler(this.Refresh_Click);

            // 
            // StockForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(664, 404);
            Controls.Add(btnRefresh);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(dgvStocks);
            Name = "StockForm";
            Text = "Stoklar";
            Load += new EventHandler(this.StockForm_Load);
            ((System.ComponentModel.ISupportInitialize)dgvStocks).EndInit();
            ResumeLayout(false);
        }
    }
}
