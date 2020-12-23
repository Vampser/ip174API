using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using tgBot.tgClass;
using tgBot.weather;
using System.Net.Http;
using System.Net;

namespace tgBot
{
    class Program
    {
        static void Main(string[] args)
        {
            var token = "1436672232:AAFi7Yh8dAd7MgYaCX1jGkzZeq3m9lJL84U";
            var AppKey = "2f8579b26c23fa5a12ef2c67ced3778e";
            var client = new HttpClient();
            var client2 = new HttpClient();
            var sity2 = "";
            while (true)
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                var url = client2.GetAsync(new Uri($"https://api.telegram.org/bot{token}/getUpdates")).GetAwaiter().GetResult();
                var tgJson = url.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                var tgInfo = JsonConvert.DeserializeObject<RootMessage>(tgJson);
                var sity = tgInfo.Result.Last().Message.Text;
                var id = tgInfo.Result.Last().Message.Chat.Id;
                if (sity != sity2)
                {
                    var urlW = client.GetAsync(new Uri($"http://api.openweathermap.org/data/2.5/weather?q={sity}&appid={AppKey}&units=metric&lang=ru")).GetAwaiter().GetResult();
                    var jsonResult = urlW.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    var wthrInfo = JsonConvert.DeserializeObject<weatherInfo>(jsonResult);

                    if (wthrInfo.Name == null)
                    { continue; }
                    else
                    {
                        var pogoda = $"В городе {wthrInfo.Name}: температура: { wthrInfo.Main.Temp}" + Environment.NewLine + $"Минимальная темп:{wthrInfo.Main.TempMin}, Максимальная темп: {wthrInfo.Main.TempMax}" + Environment.NewLine +
                            $"Ощущается как:{wthrInfo.Main.FeelsLike}";
                        Console.WriteLine(pogoda);
                        //sendMessage
                        client2.GetAsync(new Uri($"https://api.telegram.org/bot{token}/sendMessage?chat_id={id}&text={pogoda};")).GetAwaiter().GetResult();
                        sity2 = sity;
                    }
                } 
            }
        }
    }
}
