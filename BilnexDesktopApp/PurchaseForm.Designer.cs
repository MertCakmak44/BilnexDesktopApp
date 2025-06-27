namespace BilnexDesktopApp
{
    partial class PurchaseForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbStock;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Button btnPurchase;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label lblQuantity;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            cmbStock = new System.Windows.Forms.ComboBox();
            numQuantity = new System.Windows.Forms.NumericUpDown();
            btnPurchase = new System.Windows.Forms.Button();
            lblStock = new System.Windows.Forms.Label();
            lblQuantity = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            SuspendLayout();
            // 
            // cmbStock
            // 
            cmbStock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbStock.FormattingEnabled = true;
            cmbStock.Location = new System.Drawing.Point(120, 30);
            cmbStock.Name = "cmbStock";
            cmbStock.Size = new System.Drawing.Size(180, 23);
            cmbStock.TabIndex = 0;
            // 
            // numQuantity
            // 
            numQuantity.Location = new System.Drawing.Point(120, 70);
            numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQuantity.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new System.Drawing.Size(80, 23);
            numQuantity.TabIndex = 1;
            numQuantity.Value = 1;
            // 
            // btnPurchase
            // 
            btnPurchase.Location = new System.Drawing.Point(120, 110);
            btnPurchase.Name = "btnPurchase";
            btnPurchase.Size = new System.Drawing.Size(120, 35);
            btnPurchase.TabIndex = 2;
            btnPurchase.Text = "Satın Al";
            btnPurchase.UseVisualStyleBackColor = true;
            btnPurchase.Click += new System.EventHandler(this.btnPurchase_Click);
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Location = new System.Drawing.Point(30, 33);
            lblStock.Name = "lblStock";
            lblStock.Size = new System.Drawing.Size(66, 15);
            lblStock.TabIndex = 3;
            lblStock.Text = "Ürün Seçin:";
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new System.Drawing.Point(30, 72);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new System.Drawing.Size(45, 15);
            lblQuantity.TabIndex = 4;
            lblQuantity.Text = "Miktar:";
            // 
            // PurchaseForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(350, 180);
            Controls.Add(lblQuantity);
            Controls.Add(lblStock);
            Controls.Add(btnPurchase);
            Controls.Add(numQuantity);
            Controls.Add(cmbStock);
            Name = "PurchaseForm";
            Text = "Satın Alma Paneli";
            Load += new System.EventHandler(this.PurchaseForm_Load);
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
