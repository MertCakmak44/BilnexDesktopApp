namespace BilnexDesktopApp
{
    partial class SalesEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button btnSave;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // txtId
            this.txtId.Location = new System.Drawing.Point(30, 20);
            this.txtId.ReadOnly = true;
            this.txtId.PlaceholderText = "ID";
            this.txtId.Size = new System.Drawing.Size(100, 23);

            // txtCustomer
            this.txtCustomer.Location = new System.Drawing.Point(30, 60);
            this.txtCustomer.ReadOnly = true;
            this.txtCustomer.PlaceholderText = "Müşteri";
            this.txtCustomer.Size = new System.Drawing.Size(200, 23);

            // txtStock
            this.txtStock.Location = new System.Drawing.Point(30, 100);
            this.txtStock.ReadOnly = true;
            this.txtStock.PlaceholderText = "Ürün";
            this.txtStock.Size = new System.Drawing.Size(200, 23);

            // txtAmount
            this.txtAmount.Location = new System.Drawing.Point(30, 140);
            this.txtAmount.PlaceholderText = "Adet";
            this.txtAmount.Size = new System.Drawing.Size(100, 23);

            // txtPrice
            this.txtPrice.Location = new System.Drawing.Point(30, 180);
            this.txtPrice.PlaceholderText = "Toplam Fiyat";
            this.txtPrice.Size = new System.Drawing.Size(100, 23);

            // dtpDate
            this.dtpDate.Location = new System.Drawing.Point(30, 220);
            this.dtpDate.Size = new System.Drawing.Size(200, 23);

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(30, 260);
            this.btnSave.Text = "Kaydet";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // SalesEditForm
            this.ClientSize = new System.Drawing.Size(300, 320);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.btnSave);
            this.Name = "SalesEditForm";
            this.Text = "Satış Güncelle";
            this.Load += new System.EventHandler(this.SalesEditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
