namespace BilnexDesktopApp
{
    partial class StockAddForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtId;
        private Button btnSave;
        private Label lblId;
        private Label lblName;
        private Label lblPrice;
        private Label lblAmount;
        private TextBox txtName;
        private TextBox txtPrice;
        private TextBox txtAmount;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtId = new TextBox();
            btnSave = new Button();
            lblId = new Label();
            lblName = new Label();
            lblPrice = new Label();
            lblAmount = new Label();
            txtName = new TextBox();
            txtPrice = new TextBox();
            txtAmount = new TextBox();
            SuspendLayout();

            // txtId
            txtId.Location = new Point(100, 30);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 1;

            // btnSave
            btnSave.Location = new Point(100, 200);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 30);
            btnSave.TabIndex = 8;
            btnSave.Text = "Kaydet";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += new EventHandler(btnSave_Click);

            // lblId
            lblId.Location = new Point(30, 30);
            lblId.Name = "lblId";
            lblId.Size = new Size(100, 23);
            lblId.TabIndex = 0;
            lblId.Text = "ID";

            // lblName
            lblName.Location = new Point(30, 70);
            lblName.Name = "lblName";
            lblName.Size = new Size(100, 23);
            lblName.TabIndex = 2;
            lblName.Text = "Ürün Adı";

            // lblPrice
            lblPrice.Location = new Point(30, 110);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(100, 23);
            lblPrice.TabIndex = 4;
            lblPrice.Text = "Fiyat";

            // lblAmount
            lblAmount.Location = new Point(30, 150);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(100, 23);
            lblAmount.TabIndex = 6;
            lblAmount.Text = "Adet";

            // txtName
            txtName.Location = new Point(126, 70);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 9;

            // txtPrice
            txtPrice.Location = new Point(126, 107);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(100, 23);
            txtPrice.TabIndex = 10;

            // txtAmount
            txtAmount.Location = new Point(126, 147);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(100, 23);
            txtAmount.TabIndex = 11;

            // StockAddForm
            ClientSize = new Size(289, 280);
            Controls.Add(txtAmount);
            Controls.Add(txtPrice);
            Controls.Add(txtName);
            Controls.Add(lblId);
            Controls.Add(txtId);
            Controls.Add(lblName);
            Controls.Add(lblPrice);
            Controls.Add(lblAmount);
            Controls.Add(btnSave);
            Name = "StockAddForm";
            Text = "Yeni Stok Ekle";
            Load += new EventHandler(StockAddForm_Load);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
