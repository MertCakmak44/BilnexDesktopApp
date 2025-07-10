using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Windows.Forms;

namespace BilnexDesktopApp
{
    public partial class SalesListForm : Form
    {
        private readonly string _token;
        private List<SaleDto> _sales = new();

        public SalesListForm(string token)
        {
            InitializeComponent();
            _token = token;
        }

        private async void SalesListForm_Load(object sender, EventArgs e)
        {
            try
            {
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
                var response = await client.GetAsync("https://localhost:7146/api/sales");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                _sales = JsonSerializer.Deserialize<List<SaleDto>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                dataGridViewSales.DataSource = _sales;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Satışlar yüklenemedi: " + ex.Message);
            }
        }

        private void dataGridViewSales_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < _sales.Count)
            {
                var selectedSale = _sales[e.RowIndex];
                var editForm = new SalesEditForm(selectedSale, _token);
                editForm.ShowDialog();
                SalesListForm_Load(this, EventArgs.Empty); // Yeniden yükle
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewSales.SelectedRows.Count == 0)
                return;

            var selected = (SaleDto)dataGridViewSales.SelectedRows[0].DataBoundItem;

            var confirm = MessageBox.Show("Bu satışı silmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

            try
            {
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
                var response = await client.DeleteAsync($"https://localhost:7146/api/sales/{selected.Id}");
                response.EnsureSuccessStatusCode();
                MessageBox.Show("Silindi.");
                SalesListForm_Load(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme işlemi başarısız: " + ex.Message);
            }
        }
    }

    public class SaleDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string StockName { get; set; }
        public int Amount { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime SaleDate { get; set; }
    }
}
