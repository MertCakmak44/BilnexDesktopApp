using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BilnexDesktopApp
{
    public partial class StockAddForm : Form
    {
        private readonly string _token;

        public StockAddForm(string token)
        {
            InitializeComponent();
            _token = token;
        }

        private async void StockAddForm_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;

            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7146/");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await client.GetAsync("api/stock");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var stockList = JsonSerializer.Deserialize<List<StockDto>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                int nextId = 1;
                if (stockList != null && stockList.Count > 0)
                    nextId = stockList.Max(s => s.ID) + 1;

                txtId.Text = nextId.ToString();
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var stock = new
            {
                Id = int.Parse(txtId.Text),
                Name = txtName.Text,
                Price = int.Parse(txtPrice.Text),
                Amount = int.Parse(txtAmount.Text)
            };

            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7146/");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var json = JsonSerializer.Serialize(stock);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/stock", content);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Stok başarıyla eklendi.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Ekleme başarısız.");
            }
        }

        private class StockDto
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int Price { get; set; }
            public int Amount { get; set; }
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
