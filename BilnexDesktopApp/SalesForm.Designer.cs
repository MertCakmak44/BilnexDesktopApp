namespace BilnexDesktopApp
{
    partial class SalesForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.ComboBox cmbStock;
        private System.Windows.Forms.NumericUpDown numAmount;
        private System.Windows.Forms.Button btnSale;
        private System.Windows.Forms.DataGridView dgvSales;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblTotal;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            cmbCustomer = new ComboBox();
            cmbStock = new ComboBox();
            numAmount = new NumericUpDown();
            btnSale = new Button();
            dgvSales = new DataGridView();
            txtTotal = new TextBox();
            lblCustomer = new Label();
            lblStock = new Label();
            lblAmount = new Label();
            lblTotal = new Label();
            ((System.ComponentModel.ISupportInitialize)numAmount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSales).BeginInit();
            SuspendLayout();
            // 
            // cmbCustomer
            // 
            cmbCustomer.Location = new Point(100, 20);
            cmbCustomer.Name = "cmbCustomer";
            cmbCustomer.Size = new Size(150, 23);
            cmbCustomer.TabIndex = 0;
            // 
            // cmbStock
            // 
            cmbStock.Location = new Point(100, 60);
            cmbStock.Name = "cmbStock";
            cmbStock.Size = new Size(150, 23);
            cmbStock.TabIndex = 1;
            cmbStock.SelectedIndexChanged += cmbStock_SelectedIndexChanged;
            // 
            // numAmount
            // 
            numAmount.Location = new Point(100, 100);
            numAmount.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numAmount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numAmount.Name = "numAmount";
            numAmount.Size = new Size(119, 23);
            numAmount.TabIndex = 2;
            numAmount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numAmount.ValueChanged += numAmount_ValueChanged;
            // 
            // btnSale
            // 
            btnSale.Location = new Point(270, 60);
            btnSale.Name = "btnSale";
            btnSale.Size = new Size(100, 30);
            btnSale.TabIndex = 3;
            btnSale.Text = "Satış Yap";
            btnSale.Click += btnSale_Click;
            // 
            // dgvSales
            // 
            dgvSales.Location = new Point(20, 150);
            dgvSales.Name = "dgvSales";
            dgvSales.Size = new Size(500, 200);
            dgvSales.TabIndex = 4;
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(420, 370);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(100, 23);
            txtTotal.TabIndex = 5;
            // 
            // lblCustomer
            // 
            lblCustomer.Location = new Point(20, 20);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(100, 23);
            lblCustomer.TabIndex = 6;
            lblCustomer.Text = "Müşteri:";
            // 
            // lblStock
            // 
            lblStock.Location = new Point(20, 60);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(100, 23);
            lblStock.TabIndex = 7;
            lblStock.Text = "Ürün:";
            // 
            // lblAmount
            // 
            lblAmount.Location = new Point(20, 100);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(100, 23);
            lblAmount.TabIndex = 8;
            lblAmount.Text = "Adet:";
            // 
            // lblTotal
            // 
            lblTotal.Location = new Point(360, 370);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(100, 23);
            lblTotal.TabIndex = 9;
            lblTotal.Text = "Toplam:";
            // 
            // SalesForm
            // 
            ClientSize = new Size(550, 420);
            Controls.Add(cmbCustomer);
            Controls.Add(cmbStock);
            Controls.Add(numAmount);
            Controls.Add(btnSale);
            Controls.Add(dgvSales);
            Controls.Add(txtTotal);
            Controls.Add(lblCustomer);
            Controls.Add(lblStock);
            Controls.Add(lblAmount);
            Controls.Add(lblTotal);
            Name = "SalesForm";
            Text = "Satış Paneli";
            Load += SalesForm_Load;
            ((System.ComponentModel.ISupportInitialize)numAmount).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSales).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
