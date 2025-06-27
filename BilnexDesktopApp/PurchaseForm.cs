using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyAppCore.Dtos; // StockDto burada tanımlı olmalı

namespace BilnexDesktopApp
{
    public partial class PurchaseForm : Form
    {
        private readonly string _token;
        private List<StockDto> _stockList;

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
                    _stockList = JsonSerializer.Deserialize<List<StockDto>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    cmbStock.DataSource = _stockList;
                    cmbStock.DisplayMember = "Name";
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
            if (cmbStock.SelectedItem is not StockDto selectedStock)
            {
                MessageBox.Show("Lütfen geçerli bir ürün seçin.");
                return;
            }

            int quantity = (int)numQuantity.Value;

            var purchase = new
            {
                stockId = selectedStock.ID,
                amount = quantity
            };

            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7146/");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var json = JsonSerializer.Serialize(purchase);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync("api/purchase", content);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Satın alma başarılı!");
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Satın alma başarısız:\n" + error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("İşlem sırasında hata oluştu:\n" + ex.Message);
            }
        }
    }
}
