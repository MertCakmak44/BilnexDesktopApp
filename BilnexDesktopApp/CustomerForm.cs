using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BilnexDesktopApp
{
    public partial class CustomerForm : Form
    {
        private readonly string _token;

        public CustomerForm(string token)
        {
            InitializeComponent();
            _token = token;
        }

        private async Task LoadCustomersAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7146/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

                try
                {
                    var response = await client.GetAsync("api/customer");
                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();

                        var customers = JsonSerializer.Deserialize<List<CustomerDto>>(json, new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });

                        dgvCustomers.DataSource = customers;
                    }
                    else
                    {
                        MessageBox.Show("Müşteriler alınamadı: " + response.StatusCode);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata oluştu: " + ex.Message);
                }
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadCustomersAsync();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new CustomerAddForm(_token);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                _ = LoadCustomersAsync();
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            var updateForm = new CustomerUpdateForm(_token);
            if (updateForm.ShowDialog() == DialogResult.OK)
            {
                await LoadCustomersAsync(); // listeyi güncelle
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var input = Microsoft.VisualBasic.Interaction.InputBox("Silmek istediğiniz müşteri ID'sini girin:", "Müşteri Sil", "");

            if (!int.TryParse(input, out int id))
            {
                MessageBox.Show("Geçerli bir ID girilmedi.");
                return;
            }

            var confirm = MessageBox.Show($"ID: {id} olan müşteriyi silmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes)
                return;

            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7146/");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await client.DeleteAsync($"api/customer/{id}");
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Müşteri başarıyla silindi.");
                await LoadCustomersAsync(); // listeyi güncelle
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                MessageBox.Show("Silme başarısız:\n" + error);
            }
        }
        private void DgvCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedCustomer = (CustomerDto)dgvCustomers.Rows[e.RowIndex].DataBoundItem;

                var updateForm = new CustomerUpdateForm(_token);
                updateForm.FillCustomer(selectedCustomer);

                if (updateForm.ShowDialog() == DialogResult.OK)
                {
                    _ = LoadCustomersAsync();
                }
            }
        }


        private DataGridView dgvCustomers;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;

        private async void CustomerForm_Load(object sender, EventArgs e)
        {
            await LoadCustomersAsync();
        }

        private void InitializeComponent()
        {
            dgvCustomers = new DataGridView();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            SuspendLayout();
            this.Load += new EventHandler(CustomerForm_Load);
            dgvCustomers.CellDoubleClick += DgvCustomers_CellDoubleClick;
            // 
            // dgvCustomers
            // 
            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomers.Location = new Point(12, 65);
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.Size = new Size(535, 360);
            dgvCustomers.TabIndex = 0;
            // 
            // button5
            // 
            button5.Location = new Point(12, 12);
            button5.Name = "button5";
            button5.Size = new Size(105, 47);
            button5.TabIndex = 1;
            button5.Text = "Ekle";
            button5.UseVisualStyleBackColor = true;
            button5.Click += new EventHandler(btnAdd_Click);
            // 
            // button6
            // 
            button6.Location = new Point(159, 12);
            button6.Name = "button6";
            button6.Size = new Size(105, 47);
            button6.TabIndex = 2;
            button6.Text = "Güncelle";
            button6.UseVisualStyleBackColor = true;
            button6.Click += new EventHandler(btnUpdate_Click);
            // 
            // button7
            // 
            button7.Location = new Point(309, 12);
            button7.Name = "button7";
            button7.Size = new Size(105, 47);
            button7.TabIndex = 3;
            button7.Text = "Sil";
            button7.UseVisualStyleBackColor = true;
            button7.Click += new EventHandler(btnDelete_Click);
            // 
            // button8
            // 
            button8.Location = new Point(442, 12);
            button8.Name = "button8";
            button8.Size = new Size(105, 47);
            button8.TabIndex = 4;
            button8.Text = "Yenile";
            button8.UseVisualStyleBackColor = true;
            button8.Click += new EventHandler(btnRefresh_Click);
            // 
            // CustomerForm
            // 
            ClientSize = new Size(559, 437);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(dgvCustomers);
            Name = "CustomerForm";
            Text = "Müşteri Paneli";
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            ResumeLayout(false);
        }
    }
}
