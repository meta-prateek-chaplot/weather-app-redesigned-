using System;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace Weather
{
    class DataObserver : IObserver
    {
        private static JObject jaipurJson;

        private ISubject dataSubject;

        public DataObserver(ISubject dataSubject)
        {
            this.dataSubject = dataSubject;

            dataSubject.Register(this);
        }

        public void Update(JObject newJaipurJson)
        {
            try
            {
                jaipurJson = newJaipurJson;
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("Exception Caught: {0}", e);
            }

            UpdateChartPoints();
        }

        static void UpdateChartPoints()
        {
            Program.form.Invoke((MethodInvoker)delegate
            {
                try
                {
                    Program.form.chart1.Series["Temp"].Points.Clear();
                    Program.form.chart1.Series["Pressure"].Points.Clear();
                    Program.form.chart1.Series["Humidity"].Points.Clear();

                    Program.form.chart1.Series["Temp"].Points.AddXY("Jaipur", (int)jaipurJson["main"]["temp"]);
                    Program.form.chart1.Series["Pressure"].Points.AddXY("Jaipur", (int)jaipurJson["main"]["pressure"] / 100);
                    Program.form.chart1.Series["Humidity"].Points.AddXY("Jaipur", (int)jaipurJson["main"]["humidity"]);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("Exception Caught: {0}", e);
                }
            });
        }
    }
}
