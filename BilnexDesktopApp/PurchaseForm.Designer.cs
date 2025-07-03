namespace BilnexDesktopApp
{
    partial class PurchaseForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbStock;
        private System.Windows.Forms.NumericUpDown numAmount;
        private System.Windows.Forms.Button btnPurchase;
        private System.Windows.Forms.DataGridView dgvPurchases;
        private System.Windows.Forms.TextBox txtTotal;
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
            cmbStock = new ComboBox();
            numAmount = new NumericUpDown();
            btnPurchase = new Button();
            dgvPurchases = new DataGridView();
            txtTotal = new TextBox();
            lblStock = new Label();
            lblAmount = new Label();
            lblTotal = new Label();

            ((System.ComponentModel.ISupportInitialize)numAmount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPurchases).BeginInit();
            SuspendLayout();
            // 
            // cmbStock
            // 
            cmbStock.Location = new Point(100, 20);
            cmbStock.Size = new Size(150, 23);
            cmbStock.SelectedIndexChanged += cmbStock_SelectedIndexChanged;
            // 
            // numAmount
            // 
            numAmount.Location = new Point(100, 60);
            numAmount.Minimum = 1;
            numAmount.Maximum = 10000;
            numAmount.Value = 1;
            numAmount.ValueChanged += numAmount_ValueChanged;
            // 
            // btnPurchase
            // 
            btnPurchase.Location = new Point(270, 40);
            btnPurchase.Size = new Size(100, 30);
            btnPurchase.Text = "Satın Al";
            btnPurchase.Click += btnPurchase_Click;
            // 
            // dgvPurchases
            // 
            dgvPurchases.Location = new Point(20, 120);
            dgvPurchases.Size = new Size(500, 200);
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(420, 340);
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(100, 23);
            // 
            // lblStock
            // 
            lblStock.Text = "Ürün:";
            lblStock.Location = new Point(20, 20);
            // 
            // lblAmount
            // 
            lblAmount.Text = "Adet:";
            lblAmount.Location = new Point(20, 60);
            // 
            // lblTotal
            // 
            lblTotal.Text = "Toplam:";
            lblTotal.Location = new Point(360, 340);
            // 
            // PurchaseForm
            // 
            ClientSize = new Size(560, 400);
            Controls.Add(cmbStock);
            Controls.Add(numAmount);
            Controls.Add(btnPurchase);
            Controls.Add(dgvPurchases);
            Controls.Add(txtTotal);
            Controls.Add(lblStock);
            Controls.Add(lblAmount);
            Controls.Add(lblTotal);
            Text = "Satın Alma Paneli";
            Load += PurchaseForm_Load;
            ((System.ComponentModel.ISupportInitialize)numAmount).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPurchases).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
