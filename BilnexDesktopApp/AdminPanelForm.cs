using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BilnexDesktopApp
{
    public partial class AdminPanelForm : Form
    {
        private readonly string _token;
        private readonly HttpClient _httpClient = new HttpClient();

        public AdminPanelForm(string token)
        {
            InitializeComponent();
            _token = token;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
        }

        private async void btnSales_Click(object sender, EventArgs e)
        {
            var salesListForm = new SalesListForm(_token);
            salesListForm.ShowDialog();
        }

        private async void btnPurchases_Click(object sender, EventArgs e)
        {
            try
            {
                var response = await _httpClient.GetAsync("https://localhost:7146/api/purchases");
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                var purchases = JsonSerializer.Deserialize<dynamic>(content);
                dataGridView.DataSource = purchases;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Alışlar yüklenemedi: " + ex.Message);
            }
        }

        private async void btnDeleteAll_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Tüm verileri silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

            try
            {
                var response = await _httpClient.DeleteAsync("https://localhost:7146/api/admin/delete-all-data");
                response.EnsureSuccessStatusCode();
                MessageBox.Show("Tüm veriler başarıyla silindi.");
                dataGridView.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme işlemi başarısız: " + ex.Message);
            }
        }

        private void AdminPanelForm_Load(object sender, EventArgs e)
        {

        }
    }
}
