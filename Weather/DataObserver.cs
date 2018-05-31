using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Weather
{
    // Represents each Observer that is monitoring changes in the subject
    class DataObserver : IObserver
    {
        private static JObject jaipurJson;

        // Will hold reference to the StockGrabber object
        private ISubject dataSubject;

        public DataObserver(ISubject dataSubject)
        {
            // Store the reference to the dataSubject object so
            // I can make call to its methods
            this.dataSubject = dataSubject;

            // Add the observer to the Subjects ArrayList
            dataSubject.Register(this);
        }

        public void Update(JObject newJaipurJson)
        {
            jaipurJson = newJaipurJson;

            AsyncPush();
        }

        async static void AsyncPush()
        {
            Program.form.chart1.Series["Temp"].Points.Clear();
            Program.form.chart1.Series["Pressure"].Points.Clear();
            Program.form.chart1.Series["Humidity"].Points.Clear();

            Program.form.chart1.Series["Temp"].Points.AddXY("Jaipur", (int)jaipurJson["main"]["temp"]);
            Program.form.chart1.Series["Pressure"].Points.AddXY("Jaipur", (int)jaipurJson["main"]["pressure"] / 100);
            Program.form.chart1.Series["Humidity"].Points.AddXY("Jaipur", (int)jaipurJson["main"]["humidity"]);
        }
    }
}
