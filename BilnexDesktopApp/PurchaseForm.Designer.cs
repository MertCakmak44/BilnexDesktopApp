namespace BilnexDesktopApp
{
    partial class PurchaseForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvStockList;
        private DataGridView dgvHistory;
        private TextBox txtStockId;
        private TextBox txtAmount;
        private Button btnPurchase;
        private Label lblStockId;
        private Label lblAmount;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvStockList = new DataGridView();
            dgvHistory = new DataGridView();
            txtStockId = new TextBox();
            txtAmount = new TextBox();
            btnPurchase = new Button();
            lblStockId = new Label();
            lblAmount = new Label();
            ((System.ComponentModel.ISupportInitialize)(dgvStockList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dgvHistory)).BeginInit();
            SuspendLayout();

            // dgvStockList
            dgvStockList.Location = new System.Drawing.Point(12, 12);
            dgvStockList.Size = new System.Drawing.Size(500, 200);
            dgvStockList.ReadOnly = true;

            // dgvHistory
            dgvHistory.Location = new System.Drawing.Point(12, 300);
            dgvHistory.Size = new System.Drawing.Size(500, 200);
            dgvHistory.Columns.Add("Id", "ID");
            dgvHistory.Columns.Add("Name", "Ürün");
            dgvHistory.Columns.Add("Price", "Fiyat");
            dgvHistory.Columns.Add("Amount", "Adet");
            dgvHistory.Columns.Add("Total", "Toplam");

            // txtStockId
            txtStockId.Location = new System.Drawing.Point(80, 230);
            txtStockId.Size = new System.Drawing.Size(100, 23);

            // txtAmount
            txtAmount.Location = new System.Drawing.Point(250, 230);
            txtAmount.Size = new System.Drawing.Size(100, 23);

            // lblStockId
            lblStockId.Location = new System.Drawing.Point(30, 233);
            lblStockId.Text = "Stok ID:";

            // lblAmount
            lblAmount.Location = new System.Drawing.Point(200, 233);
            lblAmount.Text = "Miktar:";

            // btnPurchase
            btnPurchase.Text = "Satın Al";
            btnPurchase.Location = new System.Drawing.Point(370, 230);
            btnPurchase.Click += new System.EventHandler(this.btnPurchase_Click);

            // PurchaseForm
            ClientSize = new System.Drawing.Size(530, 520);
            Controls.Add(dgvStockList);
            Controls.Add(dgvHistory);
            Controls.Add(txtStockId);
            Controls.Add(txtAmount);
            Controls.Add(btnPurchase);
            Controls.Add(lblStockId);
            Controls.Add(lblAmount);
            Name = "PurchaseForm";
            Text = "Satın Alma";
            Load += new System.EventHandler(this.PurchaseForm_Load);
            ((System.ComponentModel.ISupportInitialize)(dgvStockList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dgvHistory)).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
