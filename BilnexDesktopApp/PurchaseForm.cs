using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BilnexDesktopApp
{
    public partial class PurchaseForm : Form
    {
        private readonly string _token;

        public PurchaseForm(string token)
        {
            InitializeComponent();
            _token = token;
        }

        private async void PurchaseForm_Load(object sender, EventArgs e)
        {
            await LoadStocksAsync();
        }

        private async Task LoadStocksAsync()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7146/");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            try
            {
                var response = await client.GetAsync("api/stock");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var stocks = JsonSerializer.Deserialize<List<StockDto>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    dgvStockList.DataSource = stocks;
                }
                else
                {
                    MessageBox.Show("Stoklar alınamadı.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private async void btnPurchase_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtStockId.Text, out int stockId) || !int.TryParse(txtAmount.Text, out int amount))
            {
                MessageBox.Show("Lütfen geçerli bir ID ve miktar girin.");
                return;
            }

            var purchase = new
            {
                StockId = stockId,
                Amount = amount
            };

            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7146/");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var json = JsonSerializer.Serialize(purchase);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/purchases", content);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Satın alma başarılı.");

                await LoadStocksAsync();

                var selectedStock = ((List<StockDto>)dgvStockList.DataSource).Find(s => s.ID == stockId);
                dgvHistory.Rows.Add(selectedStock.ID, selectedStock.Name, selectedStock.Price, amount, selectedStock.Price * amount);
            }
            else
            {
                MessageBox.Show("Satın alma başarısız.");
            }
        }

        public class StockDto
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int Price { get; set; }
            public int Amount { get; set; }
        }
    }
}
