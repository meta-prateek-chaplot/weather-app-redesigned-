using System;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace Weather
{
    static class Program
    {
        private static string jaipurJson;

        async static void AsyncPull()
        {
            HttpClient client = new HttpClient();
            jaipurJson = await client.GetStringAsync("http://api.openweathermap.org/data/2.5/weather?id=1269515&units=metric&appid=4d302b00539441446f7736801e1bb1cc");
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Create the Subject object
            // It will handle updating all observers
            // as well as deleting and adding them
            DataSubject dataGrabber = new DataSubject();

            // Create an Observer that will be sent updates from Subject
            DataObserver jaipurObserver = new DataObserver(dataGrabber);

            // make a repeated timer thread
            AsyncPull();
            System.Threading.Thread.Sleep(1 * 1000);    //remove
            dataGrabber.SetJson(JObject.Parse(jaipurJson));
            // for the encapsulated method

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
