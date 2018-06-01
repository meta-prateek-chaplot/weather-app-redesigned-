using System;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace Weather
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Program.dataGrabber.SetJson(JObject.Parse(Program.jaipurJson));
        }
    }
}
