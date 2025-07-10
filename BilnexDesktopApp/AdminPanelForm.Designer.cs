namespace BilnexDesktopApp
{
    partial class AdminPanelForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnSales;
        private System.Windows.Forms.Button btnPurchases;
        private System.Windows.Forms.Button btnDeleteAll;
        private System.Windows.Forms.DataGridView dataGridView;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnSales = new Button();
            btnPurchases = new Button();
            btnDeleteAll = new Button();
            dataGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // btnSales
            // 
            btnSales.Location = new Point(12, 12);
            btnSales.Name = "btnSales";
            btnSales.Size = new Size(120, 40);
            btnSales.TabIndex = 0;
            btnSales.Text = "Satışları Listele";
            btnSales.Click += btnSales_Click;
            // 
            // btnPurchases
            // 
            btnPurchases.Location = new Point(150, 12);
            btnPurchases.Name = "btnPurchases";
            btnPurchases.Size = new Size(120, 40);
            btnPurchases.TabIndex = 1;
            btnPurchases.Text = "Alışları Listele";
            btnPurchases.Click += btnPurchases_Click;
            // 
            // btnDeleteAll
            // 
            btnDeleteAll.Location = new Point(290, 12);
            btnDeleteAll.Name = "btnDeleteAll";
            btnDeleteAll.Size = new Size(160, 40);
            btnDeleteAll.TabIndex = 2;
            btnDeleteAll.Text = "Tüm Verileri Sil";
            btnDeleteAll.Click += btnDeleteAll_Click;
            // 
            // dataGridView
            // 
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.Location = new Point(12, 70);
            dataGridView.Name = "dataGridView";
            dataGridView.Size = new Size(600, 300);
            dataGridView.TabIndex = 3;
            // 
            // AdminPanelForm
            // 
            ClientSize = new Size(630, 390);
            Controls.Add(btnSales);
            Controls.Add(btnPurchases);
            Controls.Add(btnDeleteAll);
            Controls.Add(dataGridView);
            Name = "AdminPanelForm";
            Text = "Admin Panel";
            Load += AdminPanelForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }
    }
}
