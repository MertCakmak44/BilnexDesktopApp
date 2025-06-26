namespace BilnexDesktopApp
{
    partial class StockUpdateForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Button btnUpdate;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblId = new Label();
            lblName = new Label();
            lblPrice = new Label();
            lblAmount = new Label();
            txtId = new TextBox();
            txtName = new TextBox();
            txtPrice = new TextBox();
            txtAmount = new TextBox();
            btnUpdate = new Button();
            SuspendLayout();
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(30, 30);
            lblId.Name = "lblId";
            lblId.Size = new Size(18, 15);
            lblId.TabIndex = 0;
            lblId.Text = "ID";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(30, 70);
            lblName.Name = "lblName";
            lblName.Size = new Size(39, 15);
            lblName.TabIndex = 2;
            lblName.Text = "Name";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(30, 110);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(33, 15);
            lblPrice.TabIndex = 4;
            lblPrice.Text = "Price";
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Location = new Point(30, 150);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(51, 15);
            lblAmount.TabIndex = 6;
            lblAmount.Text = "Amount";
            // 
            // txtId
            // 
            txtId.Location = new Point(100, 27);
            txtId.Name = "txtId";
            txtId.ReadOnly = false;
            txtId.Size = new Size(150, 23);
            txtId.TabIndex = 1;
            // 
            // txtName
            // 
            txtName.Location = new Point(100, 67);
            txtName.Name = "txtName";
            txtName.Size = new Size(150, 23);
            txtName.TabIndex = 3;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(100, 107);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(150, 23);
            txtPrice.TabIndex = 5;
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(100, 147);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(150, 23);
            txtAmount.TabIndex = 7;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(100, 190);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(150, 40);
            btnUpdate.TabIndex = 8;
            btnUpdate.Text = "Güncelle";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // StockUpdateForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(300, 260);
            Controls.Add(lblId);
            Controls.Add(txtId);
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(lblPrice);
            Controls.Add(txtPrice);
            Controls.Add(lblAmount);
            Controls.Add(txtAmount);
            Controls.Add(btnUpdate);
            Name = "StockUpdateForm";
            Text = "Stok Güncelle";
            Load += StockUpdateForm_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
