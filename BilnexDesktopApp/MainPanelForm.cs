using System;
using System.Windows.Forms;

namespace BilnexDesktopApp
{
    public partial class MainPanelForm : Form
    {
        private readonly string _token;
        private readonly string _role;

        public MainPanelForm(string token, string role)
        {
            InitializeComponent();
            _token = token;
            _role = role;
        }

        private void MainPanelForm_Load(object sender, EventArgs e)
        {
            // Admin değilse Admin Panel butonunu gizle
            if (!string.Equals(_role?.Trim(), "Admin", StringComparison.OrdinalIgnoreCase))
            {
                button4.Visible = false;
            }


            // Olay bağlamaları
            button1.Click += (s, e) =>
            {
                CustomerForm form = new CustomerForm(_token);
                form.Show();
            };

            button2.Click += (s, e) =>
            {
                MessageBox.Show("StockForm açılacak");
            };

            button3.Click += (s, e) =>
            {
                MessageBox.Show("SalesForm açılacak");
            };

            button4.Click += (s, e) =>
            {
                MessageBox.Show("AdminPanelForm açılacak");
            };
        }
    }
}
