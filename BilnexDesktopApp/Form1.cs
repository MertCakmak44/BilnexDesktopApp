using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace BilnexDesktopApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Kullanıcı modeli
        public class LoginModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        // REGISTER butonu
        private async void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                lblStatus.Text = "⚠️ Boş alan bırakmayın.";
                return;
            }

            var model = new LoginModel
            {
                Username = txtUsername.Text,
                Password = txtPassword.Text
            };

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7146/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = JsonConvert.SerializeObject(model);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    var response = await client.PostAsync("api/Login/register", content);
                    if (response.IsSuccessStatusCode)
                    {
                        lblStatus.Text = "✅ Kayıt başarılı!";
                    }
                    else
                    {
                        string msg = await response.Content.ReadAsStringAsync();
                        lblStatus.Text = $"❌ Kayıt başarısız.\n{msg}";
                    }
                }
                catch (Exception ex)
                {
                    lblStatus.Text = $"⚠️ Sunucuya bağlanılamadı.\n{ex.Message}";
                }
            }
        }

        // LOGIN butonu
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                lblStatus.Text = "⚠️ Kullanıcı adı veya şifre boş olamaz.";
                return;
            }

            var model = new LoginModel
            {
                Username = txtUsername.Text,
                Password = txtPassword.Text
            };

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7146/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = JsonConvert.SerializeObject(model);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    var response = await client.PostAsync("api/Login/login", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseJson = await response.Content.ReadAsStringAsync();
                        dynamic obj = JsonConvert.DeserializeObject(responseJson);
                        string token = obj.token;

                        // Rolü token içinden oku
                        var handler = new JwtSecurityTokenHandler();
                        var jwt = handler.ReadJwtToken(token);
                        string role = jwt.Claims.FirstOrDefault(c => c.Type == "role")?.Value ?? "user";

                        lblStatus.Text = "✅ Giriş başarılı!";
                        MessageBox.Show("Giriş başarılı! Token alınmıştır.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // MainPanelForm'a geçiş
                        MainPanelForm mainForm = new MainPanelForm(token, role);
                        mainForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        lblStatus.Text = "❌ Giriş başarısız. Kullanıcı adı veya şifre hatalı.";
                    }
                }
                catch (Exception ex)
                {
                    lblStatus.Text = $"⚠️ Hata oluştu: {ex.Message}";
                }
            }
        }

        private void label2_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
    }
}
