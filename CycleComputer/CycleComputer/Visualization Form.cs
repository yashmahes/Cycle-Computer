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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Speed"></param>
        /// <param name="Cadence"></param>
        /// <param name="Altitude"></param>
        /// <param name="HeartRate"></param>
        /// <param name="PowerInWatts"></param>
        public Visualization_Form(List<int> Speed, List<int> Cadence, List<int> Altitude, List<int> HeartRate, List<int> PowerInWatts)
        {
            
            InitializeComponent();
            speed = Speed;

            cadence = Cadence;

            altitude = Altitude;

            heartRate = HeartRate;

            powerInWatts = PowerInWatts;
        }

        /// <summary>
        /// When user clicks on plotSpeed button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            plotSpeed plotSpeed = new plotSpeed(speed, "Speed");
            plotSpeed.Show();
        }

        /// <summary>
        /// When user clicks on plotCadence button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            plotSpeed plotSpeed = new plotSpeed(cadence, "Cadence");
            plotSpeed.Show();
        }

        /// <summary>
        /// When user clicks on plotAltitude button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            plotSpeed plotSpeed = new plotSpeed(altitude, "Altitude");
            plotSpeed.Show();
        }

        /// <summary>
        /// When user clicks on plotHeartRate button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            plotSpeed plotSpeed = new plotSpeed(heartRate, "Heart Rate");
            plotSpeed.Show();
        }

        /// <summary>
        /// When user clicks on plotPower button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            plotSpeed plotSpeed = new plotSpeed(powerInWatts, "Power in Watts");
            plotSpeed.Show();
        }


        
        
    }
}
