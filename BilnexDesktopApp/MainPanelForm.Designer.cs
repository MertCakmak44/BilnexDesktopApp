namespace BilnexDesktopApp
{
    partial class MainPanelForm
    {
        private System.ComponentModel.IContainer components = null;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(50, 40);
            button1.Name = "button1";
            button1.Size = new Size(120, 40);
            button1.TabIndex = 0;
            button1.Text = "Customer";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(200, 40);
            button2.Name = "button2";
            button2.Size = new Size(120, 40);
            button2.TabIndex = 1;
            button2.Text = "Stock";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(50, 100);
            button3.Name = "button3";
            button3.Size = new Size(120, 40);
            button3.TabIndex = 2;
            button3.Text = "Sales";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(200, 100);
            button4.Name = "button4";
            button4.Size = new Size(120, 40);
            button4.TabIndex = 3;
            button4.Text = "Admin Panel";
            button4.UseVisualStyleBackColor = true;
            // 
            // MainPanelForm
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 201);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(button3);
            Controls.Add(button4);
            Name = "MainPanelForm";
            Text = "Bilnex Ana Panel";
            this.Load += new System.EventHandler(this.MainPanelForm_Load);
            ResumeLayout(false);
        }
    }
}
