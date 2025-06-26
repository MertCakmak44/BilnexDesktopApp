using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace BilnexDesktopApp
{
    public partial class StockUpdateForm : Form
    {
        private readonly string _token;

        public StockUpdateForm(string token)
        {
            InitializeComponent();
            _token = token;
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id) ||
                !int.TryParse(txtPrice.Text, out int price) ||
                !int.TryParse(txtAmount.Text, out int amount))
            {
                MessageBox.Show("Geçerli değerler giriniz.");
                return;
            }

            var updatedStock = new
            {
                ID = id,
                Name = txtName.Text,
                Price = price,
                Amount = amount
            };

            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7146/");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var json = JsonSerializer.Serialize(updatedStock);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"api/stock/{id}", content);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Stok başarıyla güncellendi.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                MessageBox.Show("Güncelleme başarısız:\n" + error);
            }
        }

        private void StockUpdateForm_Load(object sender, EventArgs e)
        {
            // Form yüklenince yapılacak bir işlem yok
        }

        public void FillStock(StockDto stock)
        {
            txtId.Text = stock.ID.ToString();
            txtName.Text = stock.Name;
            txtPrice.Text = stock.Price.ToString();
            txtAmount.Text = stock.Amount.ToString();
        }

        private void StockUpdateForm_Load_1(object sender, EventArgs e)
        {

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
