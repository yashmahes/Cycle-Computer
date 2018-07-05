using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace CycleComputer
{
    public partial class SuitableGUIDisplay : Form
    {
        string startTime = "";
        string date = "";

        
        List<int> speed = new List<int>();
        List<int> cadence = new List<int>();
        List<int> altitude = new List<int>();
        List<int> heartRate = new List<int>();
        List<int> powerInWatts = new List<int>();

        public SuitableGUIDisplay()
        {
            InitializeComponent();
        }

        private void SuitableGUIDisplay_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            int counter = 0;
            string line;

            // Read the file   
            System.IO.StreamReader file =
                new System.IO.StreamReader(@Form1.filename);

            while ((line = file.ReadLine()) != null)
            {

                if (line.Contains("Date"))
                {
                    date = line;
                }

                if (line.Contains("StartTime"))
                {
                    startTime = line;
                }

                if (line.Contains("HRData"))
                    break;

            }


            while ((line = file.ReadLine()) != null)
            {
                line = line.Trim();
                if (line.Equals(""))
                    continue;


                try
                {
                    counter++;
                    char[] splitchar = new char[] { ' ', '\t' };
                    string[] arr = line.Split();
                   
                    arr[0] = arr[0].Trim();
                    arr[1] = arr[1].Trim();
                    arr[2] = arr[2].Trim();
                    arr[3] = arr[3].Trim();
                    arr[4] = arr[4].Trim();

                    speed.Add(Convert.ToInt32(arr[0]));
                    cadence.Add(Convert.ToInt32(arr[1]));
                    altitude.Add(Convert.ToInt32(arr[2]));
                    heartRate.Add(Convert.ToInt32(arr[3]));
                    powerInWatts.Add(Convert.ToInt32(arr[4]));

                }
                catch(Exception excep)
                {
                    continue;
                }

            }



            file.Close();

            displayData();
            plotSpeed();
            plotCadence();
            plotAltitude();
            plotHeartRate();
            plotPower();

        }

        private void displayData()
        {
            richTextBox1.Text = "";
            richTextBox1.Text += "\n\n";
            richTextBox1.Text +=  date;
            richTextBox1.Text += "\n\n";
            richTextBox1.Text +=  startTime;

            richTextBox1.Text += "\n\n";
            richTextBox1.Text += "Speed(kph)  Cadence(rpm)  Altitude(mi)  Heart rate(bpm)  Power in watts(W)";

            for (int i = 0; i < speed.Count; i++) 
            {

                richTextBox1.Text += "\n\n";
                richTextBox1.Text += speed[i] + "                 " + cadence[i] + "                  " + altitude[i] + "                   " + heartRate[i] + "                        " + powerInWatts[i];

            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox1.Text += "\n\n";
            richTextBox1.Text += date;
            richTextBox1.Text += "\n\n";
            richTextBox1.Text += startTime;

            richTextBox1.Text += "\n\n";
            richTextBox1.Text += "Speed(mph)  Cadence(rpm)  Altitude(mi)  Heart rate(bpm)  Power in watts(W)";

            for (int i = 0; i < speed.Count; i++)
            {

                richTextBox1.Text += "\n\n";
                richTextBox1.Text += (speed[i]* 0.621371) + "                 " + cadence[i] + "                  " + altitude[i] + "                   " + heartRate[i] + "                        " + powerInWatts[i];

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox1.Text += "\n\n";
            richTextBox1.Text += date;
            richTextBox1.Text += "\n\n";
            richTextBox1.Text += startTime;

            richTextBox1.Text += "\n\n";
            richTextBox1.Text += "Speed(kph)  Cadence(rpm)  Altitude(mi)  Heart rate(bpm)  Power in watts(W)";

            for (int i = 0; i < speed.Count; i++)
            {

                richTextBox1.Text += "\n\n";
                richTextBox1.Text += speed[i] + "                 " + cadence[i] + "                  " + altitude[i] + "                   " + heartRate[i] + "                        " + powerInWatts[i];

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int maxHeartRate = Convert.ToInt32(textBox1.Text);

                richTextBox1.Text = "";
                richTextBox1.Text += "\n\n";
                richTextBox1.Text += date;
                richTextBox1.Text += "\n\n";
                richTextBox1.Text += startTime;

                richTextBox1.Text += "\n\n";
                richTextBox1.Text += "Speed(kph)  Cadence(rpm)  Altitude(mi)  Heart rate(bpm)  Power in watts(W)";

                for (int i = 0; i < speed.Count; i++)
                {
                    if (heartRate[i] <= maxHeartRate)
                    {
                        richTextBox1.Text += "\n\n";
                        richTextBox1.Text += speed[i] + "                 " + cadence[i] + "                  " + altitude[i] + "                   " + heartRate[i] + "                        " + powerInWatts[i];
                    }
                }


            }
            catch(Exception excep)
            {
                MessageBox.Show("Please enter maximum heart rate as Integer or number");
            }


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            try
            {
                int maxPower = Convert.ToInt32(textBox2.Text);

                richTextBox1.Text = "";
                richTextBox1.Text += "\n\n";
                richTextBox1.Text += date;
                richTextBox1.Text += "\n\n";
                richTextBox1.Text += startTime;

                richTextBox1.Text += "\n\n";
                richTextBox1.Text += "Speed(kph)  Cadence(rpm)  Altitude(mi)  Heart rate(bpm)  Power in watts(W)";

                for (int i = 0; i < speed.Count; i++)
                {
                    if (powerInWatts[i] <= maxPower)
                    {
                        richTextBox1.Text += "\n\n";
                        richTextBox1.Text += speed[i] + "                 " + cadence[i] + "                  " + altitude[i] + "                   " + heartRate[i] + "                        " + powerInWatts[i];
                    }
                }


            }
            catch (Exception excep)
            {
                MessageBox.Show("Please enter Functional Threshold Power as Integer or number");
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = "Summary";
            richTextBox2.Text += "\n\n";

            richTextBox2.Text += "Total distance covered : " + cadence.Sum() + " mi";
            richTextBox2.Text += "\n\n";

            richTextBox2.Text += "Average speed : " + speed.Average() + " kph";
            richTextBox2.Text += "\n\n";

            richTextBox2.Text += "Maximum speed : " + speed.Max() + " kph";
            richTextBox2.Text += "\n\n";

            richTextBox2.Text += "Average Heart rate : " + heartRate.Average() + " bpm";
            richTextBox2.Text += "\n\n";

            richTextBox2.Text += "Maximum Heart rate : " + heartRate.Max() + " bpm";
            richTextBox2.Text += "\n\n";

            richTextBox2.Text += "Minimum Heart rate : " + heartRate.Min() + " bpm";
            richTextBox2.Text += "\n\n";

            richTextBox2.Text += "Average Power : " + powerInWatts.Average() + " W";
            richTextBox2.Text += "\n\n";

            richTextBox2.Text += "Maximum Power : " + powerInWatts.Max() + " W";
            richTextBox2.Text += "\n\n";

            richTextBox2.Text += "Average Altitude : " + altitude.Average() + " mi";
            richTextBox2.Text += "\n\n";

        }



        private void plotSpeed()
        {
            GraphPane myPane = zedGraphControl1.GraphPane;

            // Set the Titles
            myPane.Title = "Speed";
            myPane.XAxis.Title = "count";
            myPane.YAxis.Title = "Speed";
            

            PointPairList teamAPairList = new PointPairList();
            
            int[] teamAData = speed.ToArray();
            
            for (int i = 0; i < teamAData.Length; i++)
            {
                teamAPairList.Add(i, teamAData[i]);
               
            }

            LineItem teamACurve = myPane.AddCurve("Speed",
                   teamAPairList, Color.Red, SymbolType.Diamond);

            

            zedGraphControl1.AxisChange();
        }


        private void plotCadence()
        {
            GraphPane myPane = zedGraphControl2.GraphPane;

            // Set the Titles
            myPane.Title = "Cadence";
            myPane.XAxis.Title = "count";
            myPane.YAxis.Title = "Cadence";


            PointPairList teamAPairList = new PointPairList();

            int[] teamAData = cadence.ToArray();

            for (int i = 0; i < teamAData.Length; i++)
            {
                teamAPairList.Add(i, teamAData[i]);

            }

            LineItem teamACurve = myPane.AddCurve("Cadence",
                   teamAPairList, Color.Red, SymbolType.Diamond);



            zedGraphControl2.AxisChange();
        }


        private void plotAltitude()
        {
            GraphPane myPane = zedGraphControl3.GraphPane;

            // Set the Titles
            myPane.Title = "Altitude";
            myPane.XAxis.Title = "count";
            myPane.YAxis.Title = "Altitude";


            PointPairList teamAPairList = new PointPairList();

            int[] teamAData = altitude.ToArray();

            for (int i = 0; i < teamAData.Length; i++)
            {
                teamAPairList.Add(i, teamAData[i]);

            }

            LineItem teamACurve = myPane.AddCurve("Altitude",
                   teamAPairList, Color.Red, SymbolType.Diamond);



            zedGraphControl3.AxisChange();
        }


        private void plotHeartRate()
        {
            GraphPane myPane = zedGraphControl4.GraphPane;

            // Set the Titles
            myPane.Title = "Heart Rate";
            myPane.XAxis.Title = "count";
            myPane.YAxis.Title = "Heart Rate";


            PointPairList teamAPairList = new PointPairList();

            int[] teamAData = heartRate.ToArray();

            for (int i = 0; i < teamAData.Length; i++)
            {
                teamAPairList.Add(i, teamAData[i]);

            }

            LineItem teamACurve = myPane.AddCurve("Heart Rate",
                   teamAPairList, Color.Red, SymbolType.Diamond);



            zedGraphControl4.AxisChange();
        }



        private void plotPower()
        {
            GraphPane myPane = zedGraphControl5.GraphPane;

            // Set the Titles
            myPane.Title = "Power in Watts";
            myPane.XAxis.Title = "count";
            myPane.YAxis.Title = "Power in Watts";


            PointPairList teamAPairList = new PointPairList();

            int[] teamAData = powerInWatts.ToArray();

            for (int i = 0; i < teamAData.Length; i++)
            {
                teamAPairList.Add(i, teamAData[i]);

            }

            LineItem teamACurve = myPane.AddCurve("Power in Watts",
                   teamAPairList, Color.Red, SymbolType.Diamond);



            zedGraphControl5.AxisChange();
        }





        private void zedGraphControl1_Load(object sender, EventArgs e)
        {
            

        }
    }
}
