using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace CycleComputer
{
    public partial class Visualization_Form : Form
    {
         List<int> speed;
         List<int> cadence;
         List<int> altitude;
         List<int> heartRate;
         List<int> powerInWatts;

        public Visualization_Form(List<int> Speed, List<int> Cadence, List<int> Altitude, List<int> HeartRate, List<int> PowerInWatts)
        {
            
            InitializeComponent();
            speed = Speed;

            cadence = Cadence;

            altitude = Altitude;

            heartRate = HeartRate;

            powerInWatts = PowerInWatts;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            plotSpeed plotSpeed = new plotSpeed(speed, "Speed");
            plotSpeed.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            plotSpeed plotSpeed = new plotSpeed(cadence, "Cadence");
            plotSpeed.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            plotSpeed plotSpeed = new plotSpeed(altitude, "Altitude");
            plotSpeed.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            plotSpeed plotSpeed = new plotSpeed(heartRate, "Heart Rate");
            plotSpeed.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            plotSpeed plotSpeed = new plotSpeed(powerInWatts, "Power in Watts");
            plotSpeed.Show();
        }


        
        
    }
}
