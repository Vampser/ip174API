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
using News.drugoe;
using System.Net;
using System.IO;
using System.Collections;
using HtmlAgilityPack;

namespace News
{
    public partial class Form1 : Form
    {
        private int M = 0;
        public Form1()
        {
            InitializeComponent();
            
        }


        private async void button1_Click(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var responce = await client.GetAsync(new Uri($"https://api.reliefweb.int/v1/reports?appname=apidoc&profile=full&limit=50"));
            var jsonResult = await responce.Content.ReadAsStringAsync();
            var newsInfo = JsonConvert.DeserializeObject<NewsInfo>(jsonResult);
            //textBox3.Text = $"\t Краткое содержание:" + Environment.NewLine +$"{newsInfo.Results[0].SummaryShort}";
            label1.Text = $"{newsInfo.Data[M].AllIsNews.Theme[0].Name}";
            textBox1.Text = $"{newsInfo.Data[M].AllIsNews.Body}";
            label2.Text = Convert.ToString(M);

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            M += 1;
            label2.Text = Convert.ToString(M);
            var client = new HttpClient();
            var responce = await client.GetAsync(new Uri($"https://api.reliefweb.int/v1/reports?appname=apidoc&profile=full&limit=50"));
            var jsonResult = await responce.Content.ReadAsStringAsync();
            var newsInfo = JsonConvert.DeserializeObject<NewsInfo>(jsonResult);
            //textBox3.Text = $"\t Краткое содержание:" + Environment.NewLine +$"{newsInfo.Results[0].SummaryShort}";
            label1.Text = $"{newsInfo.Data[M].AllIsNews.Theme[0].Name}";
            textBox1.Text = $"{newsInfo.Data[M].AllIsNews.Body}";
        }
    }
}
