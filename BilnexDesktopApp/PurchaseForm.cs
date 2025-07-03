using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyAppCore.Dtos;

namespace BilnexDesktopApp
{
    public partial class PurchaseForm : Form
    {
        private readonly string _token;
        private List<StockDto> _stocks;

        public PurchaseForm(string token)
        {
            InitializeComponent();
            _token = token;
        }

        private void InitializeGrid()
        {
            dgvPurchases.Columns.Clear();
            dgvPurchases.Columns.Add("Product", "Ürün");
            dgvPurchases.Columns.Add("Price", "Fiyat");
            dgvPurchases.Columns.Add("Quantity", "Adet");
            dgvPurchases.Columns.Add("Total", "Tutar");
        }

        private async void PurchaseForm_Load(object sender, EventArgs e)
        {
            InitializeGrid();
            await LoadStocksAsync();
            UpdateTotal();
        }

        private async Task LoadStocksAsync()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7146/");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await client.GetAsync("api/stock");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                _stocks = JsonSerializer.Deserialize<List<StockDto>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                cmbStock.DataSource = _stocks;
                cmbStock.DisplayMember = "Name";
                cmbStock.ValueMember = "Id";
            }
        }

        private void cmbStock_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTotal();
        }

        private void numAmount_ValueChanged(object sender, EventArgs e)
        {
            UpdateTotal();
        }

        private void UpdateTotal()
        {
            if (cmbStock.SelectedItem is StockDto stock)
            {
                int quantity = (int)numAmount.Value;
                int total = quantity * stock.Price;
                txtTotal.Text = total.ToString();
            }
        }

        private async void btnPurchase_Click(object sender, EventArgs e)
        {
            if (cmbStock.SelectedItem is not StockDto stock)
            {
                MessageBox.Show("Lütfen bir ürün seçin.");
                return;
            }

            int quantity = (int)numAmount.Value;

            var purchase = new
            {
                StockId = stock.ID, // backend bu ID'ye göre eşleşip stok güncelleyecek
                Amount = quantity
            };

            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7146/");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var json = JsonSerializer.Serialize(purchase);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/purchase", content);
            if (response.IsSuccessStatusCode)
            {
                int total = quantity * stock.Price;
                dgvPurchases.Rows.Add(stock.Name, stock.Price, quantity, total);
                MessageBox.Show("Satın alma başarılı.");
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                MessageBox.Show("Satın alma başarısız:\n" + error);
            }
        }
    }
}
