using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using Погода.wthr;

namespace Погода
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private const string AppKey = "f79b0c1515e4eb94fe77560458dd279d";

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            var sity = Convert.ToString(listBox1.SelectedItem);
            var client = new HttpClient();
            var responce = client.GetAsync(new Uri($"http://api.openweathermap.org/data/2.5/weather?q={sity}&appid={AppKey}&units=metric&lang=ru")).GetAwaiter().GetResult();
            var jsonResult = responce.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var wthrInfo = JsonConvert.DeserializeObject<WeatherInfo>(jsonResult);
            textBox1.Text = $"Город:{wthrInfo.Name},температура: { wthrInfo.Main.Temp}" + Environment.NewLine +$"Минимальная темп:{wthrInfo.Main.TempMin}, Максимальная темп: {wthrInfo.Main.TempMax}" + Environment.NewLine +
                $"Ощущается как:{wthrInfo.Main.FeelsLike}";

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
