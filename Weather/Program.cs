using System;
using System.Net.Http;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace Weather
{
    static class Program
    {
        public static string jaipurJson;
        public static Form1 form;
        public static DataSubject dataGrabber;

        async static void AsyncPull()
        {
            HttpClient client = new HttpClient();
            jaipurJson = await client.GetStringAsync("http://api.openweathermap.org/data/2.5/weather?id=1269515&units=metric&appid=4d302b00539441446f7736801e1bb1cc");
        }

        [STAThread]
        static void Main()
        {
            dataGrabber = new DataSubject();

            DataObserver jaipurObserver = new DataObserver(dataGrabber);

            var timer = new System.Threading.Timer((e) =>
                { AsyncPull(); }, null, TimeSpan.Zero, TimeSpan.FromSeconds(3));

            System.Threading.Thread.Sleep(3 * 1000);
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            form = new Form1();
            Application.Run(form);
        }
    }
}