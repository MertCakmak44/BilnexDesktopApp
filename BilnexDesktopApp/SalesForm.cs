using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyAppCore.Dtos; // DTO'lar buradan gelmeli

namespace BilnexDesktopApp
{
    public partial class SalesForm : Form
    {
        private readonly string _token;
        private List<CustomerDto> _customers;
        private List<StockDto> _stocks;

        public SalesForm(string token)
        {
            InitializeComponent();
            _token = token;
        }

        private void InitializeSalesGrid()
        {
            dgvSales.Columns.Clear();
            dgvSales.Columns.Add("CustomerName", "Müşteri");
            dgvSales.Columns.Add("ProductName", "Ürün");
            dgvSales.Columns.Add("Price", "Fiyat");
            dgvSales.Columns.Add("Quantity", "Adet");
            dgvSales.Columns.Add("Total", "Tutar");
        }

        private async void SalesForm_Load(object sender, EventArgs e)
        {
            InitializeSalesGrid();
            await LoadCustomersAsync();
            await LoadStocksAsync();
            UpdateTotal(); // varsayılan total
        }

        private async Task LoadCustomersAsync()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7146/");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await client.GetAsync("api/customer");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                _customers = JsonSerializer.Deserialize<List<CustomerDto>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                cmbCustomer.DataSource = _customers;
                cmbCustomer.DisplayMember = "Name";
                cmbCustomer.ValueMember = "Id";
            }
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
            if (cmbStock.SelectedItem is StockDto selectedStock)
            {
                int quantity = (int)numAmount.Value;
                int total = quantity * selectedStock.Price;
                txtTotal.Text = total.ToString();
            }
        }

        private async void btnSale_Click(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedItem is not CustomerDto selectedCustomer || cmbStock.SelectedItem is not StockDto selectedStock)
            {
                MessageBox.Show("Lütfen müşteri ve ürün seçin.");
                return;
            }

            int quantity = (int)numAmount.Value;

            var sale = new
            {
                customerId = selectedCustomer.Id,
                stockId = selectedStock.ID,
                amount = quantity
            };

            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7146/");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var json = JsonSerializer.Serialize(sale);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/sales", content);
            if (response.IsSuccessStatusCode)
            {
                int total = quantity * selectedStock.Price;
                dgvSales.Rows.Add(selectedCustomer.Name, selectedStock.Name, selectedStock.Price, quantity, total);

                int currentTotal = int.TryParse(txtTotal.Text, out int oldTotal) ? oldTotal : 0;
                txtTotal.Text = (currentTotal + total).ToString();

                MessageBox.Show("Satış başarılı.");
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                MessageBox.Show("Satış başarısız:\n" + error);
            }
        }
    }
}
