using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace BilnexDesktopApp
{
    public partial class CustomerUpdateForm : Form
    {
        private readonly string _token;

        public CustomerUpdateForm(string token)
        {
            InitializeComponent();
            _token = token;
        }
        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Lütfen geçerli bir ID girin.");
                return;
            }

            var updatedCustomer = new
            {
                Name = txtName.Text,
                Sname = txtSname.Text
            };

            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7146/");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var json = JsonSerializer.Serialize(updatedCustomer);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"api/customer/{id}", content); 

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Müşteri başarıyla güncellendi.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                MessageBox.Show("Güncelleme başarısız:\n" + error);
            }
        }

        private Label lblId;
        private Label lblName;
        private Label lblSname;
        private TextBox txtId;
        private TextBox txtName;
        private TextBox txtSname;
        private Button btnUpdate;

        private void InitializeComponent()
        {
            lblId = new Label();
            lblName = new Label();
            lblSname = new Label();
            txtId = new TextBox();
            txtName = new TextBox();
            txtSname = new TextBox();
            btnUpdate = new Button();
            SuspendLayout();
            // 
            // lblId
            // 
            lblId.Location = new Point(20, 30);
            lblId.Name = "lblId";
            lblId.Size = new Size(100, 23);
            lblId.TabIndex = 0;
            lblId.Text = "ID";
            // 
            // lblName
            // 
            lblName.Location = new Point(20, 70);
            lblName.Name = "lblName";
            lblName.Size = new Size(100, 23);
            lblName.TabIndex = 2;
            lblName.Text = "İsim";
            // 
            // lblSname
            // 
            lblSname.Location = new Point(20, 110);
            lblSname.Name = "lblSname";
            lblSname.Size = new Size(100, 23);
            lblSname.TabIndex = 4;
            lblSname.Text = "Soyisim";
            // 
            // txtId
            // 
            txtId.Location = new Point(120, 30);
            txtId.Name = "txtId";
            txtId.Size = new Size(150, 23);
            txtId.TabIndex = 1;
            // 
            // txtName
            // 
            txtName.Location = new Point(120, 70);
            txtName.Name = "txtName";
            txtName.Size = new Size(150, 23);
            txtName.TabIndex = 3;
            // 
            // txtSname
            // 
            txtSname.Location = new Point(120, 110);
            txtSname.Name = "txtSname";
            txtSname.Size = new Size(150, 23);
            txtSname.TabIndex = 5;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(120, 160);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(150, 40);
            btnUpdate.TabIndex = 6;
            btnUpdate.Text = "Güncelle";
            btnUpdate.Click += btnUpdate_Click;
            // 
            // CustomerUpdateForm
            // 
            ClientSize = new Size(409, 267);
            Controls.Add(lblId);
            Controls.Add(txtId);
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(lblSname);
            Controls.Add(txtSname);
            Controls.Add(btnUpdate);
            Name = "CustomerUpdateForm";
            Text = "Müşteri Güncelle";
            Load += CustomerUpdateForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void CustomerUpdateForm_Load(object sender, EventArgs e)
        {

        }
    }
}
