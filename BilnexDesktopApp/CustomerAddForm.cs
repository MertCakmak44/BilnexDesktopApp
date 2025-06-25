using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace BilnexDesktopApp
{
    public partial class CustomerAddForm : Form
    {
        private readonly string _token;

        public CustomerAddForm(string token)
        {
            InitializeComponent();
            _token = token;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var customer = new
            {
                Name = txtName.Text,
                Sname = txtSname.Text
            };

            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7146/");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var json = JsonSerializer.Serialize(customer);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/customer", content);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Müşteri başarıyla eklendi.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                MessageBox.Show("Ekleme başarısız:\n" + error);
            }
        }

        private Label lblName;
        private Label lblSname;
        private Button btnSave;
        private TextBox txtSname;
        private TextBox txtName;

        private void InitializeComponent()
        {
            lblName = new Label();
            lblSname = new Label();
            btnSave = new Button();
            txtSname = new TextBox();
            txtName = new TextBox();
            SuspendLayout();

            // lblName
            lblName.AutoSize = true;
            lblName.Location = new Point(12, 40);
            lblName.Name = "lblName";
            lblName.Size = new Size(29, 15);
            lblName.Text = "İsim";

            // txtName
            txtName.Location = new Point(100, 37);
            txtName.Name = "txtName";
            txtName.Size = new Size(200, 23);

            // lblSname
            lblSname.AutoSize = true;
            lblSname.Location = new Point(12, 80);
            lblSname.Name = "lblSname";
            lblSname.Size = new Size(48, 15);
            lblSname.Text = "Soyisim";

            // txtSname
            txtSname.Location = new Point(100, 77);
            txtSname.Name = "txtSname";
            txtSname.Size = new Size(200, 23);

            // btnSave
            btnSave.Location = new Point(100, 120);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 40);
            btnSave.Text = "Kaydet";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;

            // CustomerAddForm
            ClientSize = new Size(350, 200);
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(lblSname);
            Controls.Add(txtSname);
            Controls.Add(btnSave);
            Name = "CustomerAddForm";
            Text = "Yeni Müşteri Ekle";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
