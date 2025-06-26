using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BilnexDesktopApp
{
    public partial class StockForm : Form
    {
        private readonly string _token;

        public StockForm(string token)
        {
            InitializeComponent();
            _token = token;
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

                    dgvStocks.DataSource = stocks;
                }
                else
                {
                    MessageBox.Show("Stoklar alınamadı: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private async void StockForm_Load(object sender, EventArgs e)
        {
            await LoadStocksAsync();
        }
        private void dgvStocks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedStock = (StockDto)dgvStocks.Rows[e.RowIndex].DataBoundItem;
                var updateForm = new StockUpdateForm(_token);
                updateForm.FillStock(selectedStock);

                if (updateForm.ShowDialog() == DialogResult.OK)
                {
                    _ = LoadStocksAsync();
                }
            }
        }
        private void Add_Click(object sender, EventArgs e)
        {
            var addForm = new StockAddForm(_token);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                _ = LoadStocksAsync();
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            var updateForm = new StockUpdateForm(_token);
            if (updateForm.ShowDialog() == DialogResult.OK)
            {
                _ = LoadStocksAsync();
            }
        }

        private async void Delete_Click(object sender, EventArgs e)
        {
            var input = Microsoft.VisualBasic.Interaction.InputBox("Silmek istediğiniz ürünün ID'sini girin:", "Stok Sil", "");

            if (!int.TryParse(input, out int id))
            {
                MessageBox.Show("Geçerli bir ID girilmedi.");
                return;
            }

            var confirm = MessageBox.Show($"ID: {id} olan ürünü silmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes)
                return;

            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7146/");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var response = await client.DeleteAsync($"api/stock/{id}");
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Stok başarıyla silindi.");
                await LoadStocksAsync(); // listeyi yenile
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                MessageBox.Show("Silme başarısız:\n" + error);
            }

        }

        private async void Refresh_Click(object sender, EventArgs e)
        {
            await LoadStocksAsync();
        }
    }
}
