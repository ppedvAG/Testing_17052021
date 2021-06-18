using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;

namespace BooksClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var url = $"https://www.googleapis.com/books/v1/volumes?q={textBox1.Text}";

            var http = new HttpClient();
            var response = await http.GetStringAsync(url);

            textBox2.Text = response;

            var books = JsonConvert.DeserializeObject<Books>(response);

            dataGridView1.DataSource = books.items.Select(x => x.volumeInfo).ToList();

        }
    }
}
