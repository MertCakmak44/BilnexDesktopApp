using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace BilnexDesktopApp
{
    public partial class SalesEditForm : Form
    {
        private readonly SaleDto _sale;
        private readonly string _token;

        public SalesEditForm(SaleDto sale, string token)
        {
            InitializeComponent();
            _sale = sale;
            _token = token;
        }

        private void SalesEditForm_Load(object sender, EventArgs e)
        {
            txtId.Text = _sale.Id.ToString();
            txtCustomer.Text = _sale.CustomerName;
            txtStock.Text = _sale.StockName;
            txtAmount.Text = _sale.Amount.ToString();
            txtPrice.Text = _sale.TotalPrice.ToString();
            dtpDate.Value = _sale.SaleDate;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var updatedSale = new
                {
                    Id = _sale.Id,
                    Amount = int.Parse(txtAmount.Text),
                    TotalPrice = decimal.Parse(txtPrice.Text),
                    SaleDate = dtpDate.Value
                };

                var json = JsonSerializer.Serialize(updatedSale);
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PutAsync($"https://localhost:7146/api/sales/{_sale.Id}", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Satış başarıyla güncellendi.");
                    this.Close();
                }
                else
                {
                    var err = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Güncelleme hatası: " + err);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }
    }
}
