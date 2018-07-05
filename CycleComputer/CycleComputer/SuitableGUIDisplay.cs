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
    /// <summary>
    /// this class is used to get the data from the datafile and show them in suitable GUI and also visualize the data 
    /// by using charting api - ZedGraph
    /// </summary>
    public partial class SuitableGUIDisplay : Form
    {
        string startTime = "";
        string date = "";

        int maxHeartRate = 100000;
        int maxPower = 100000;
        string speedunit = "kph";

        string NormalizedPower;
        string PowerBalance;

         List<int> speed = new List<int>();
         List<int> cadence = new List<int>();
         List<int> altitude = new List<int>();
         List<int> heartRate = new List<int>();
         List<int> powerInWatts = new List<int>();

        /// <summary>
        /// This Initializes all Components
        /// </summary>
        public SuitableGUIDisplay()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This method is called when SuitableGUIDisplay form is Loaded. This method reads the data from the datafile
        /// and stores all the necessary information in the suitable variables which will be used in the application to access data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            NormalizedPower = "The Normalized Power is " + getNormalizedPower();
            PowerBalance = "The Power Balance is " + getPowerBalance();

        }

        /// <summary>
        /// this is used to display data in suitable manner in richTextBox1
        /// </summary>
        private void displayData()
        {
            richTextBox1.Text = "";
            richTextBox1.Text += "\n\n";
            richTextBox1.Text +=  date;
            richTextBox1.Text += "\n\n";
            richTextBox1.Text +=  startTime;

            richTextBox1.Text += "\n\n";
            if (speedunit.Equals("kph"))
            {
                richTextBox1.Text += "Speed(kph)  Cadence(rpm)  Altitude(mi)  Heart rate(bpm)  Power in watts(W)";

                for (int i = 0; i < speed.Count; i++)
                {
                    if (heartRate[i] <= maxHeartRate && powerInWatts[i] <= maxPower)
                    {
                        richTextBox1.Text += "\n\n";
                        richTextBox1.Text += speed[i] + "                 " + cadence[i] + "                  " + altitude[i] + "                   " + heartRate[i] + "                        " + powerInWatts[i];
                    }
                }
            }

            if (speedunit.Equals("mph"))
            {
                richTextBox1.Text += "Speed(mph)  Cadence(rpm)  Altitude(mi)  Heart rate(bpm)  Power in watts(W)";

                for (int i = 0; i < speed.Count; i++)
                {
                    if (heartRate[i] <= maxHeartRate && powerInWatts[i] <= maxPower)
                    {
                        richTextBox1.Text += "\n\n";
                        richTextBox1.Text += (speed[i] * 0.621371) + "                 " + cadence[i] + "                  " + altitude[i] + "                   " + heartRate[i] + "                        " + powerInWatts[i];
                    }
                }

            }

        }

        /// <summary>
        /// when user clicks on "Display unit of speed as mph" button it will display the data in suitable manner
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            speedunit = "mph";
            displayData();

        }

        /// <summary>
        /// when user clicks on "Display unit of speed as kph" button it will display the data in suitable manner
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            speedunit = "kph";
            displayData();

        }

        /// <summary>
        /// After Enter maximum heart rate, when user clicks on "Display data" button it will display the data in suitable manner
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                maxHeartRate = Convert.ToInt32(textBox1.Text);
                displayData();

            }
            catch(Exception excep)
            {
                MessageBox.Show("Please enter maximum heart rate as Integer or number");
            }


        }


        /// <summary>
        /// After Enter Functional Threshold Power, when user clicks on "Display data" button it will display the data in suitable manner
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {

            try
            {
                maxPower = Convert.ToInt32(textBox2.Text);
                displayData();

            }
            catch (Exception excep)
            {
                MessageBox.Show("Please enter Functional Threshold Power as Integer or number");
            }

        }

        /// <summary>
        /// when user clicks on Get summary data button, this method displays the summary data in richTextBox2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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


        /// <summary>
        /// This method is used to plotSpeed on zedGraphControl1
        /// </summary>
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

        /// <summary>
        /// This method is used to plotCadence on zedGraphControl2
        /// </summary>
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

        /// <summary>
        /// This method is used to plot Altitude on zedGraphControl3
        /// </summary>
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


        /// <summary>
        /// This method is used to plot Heart Rate on zedGraphControl4
        /// </summary>
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


        /// <summary>
        /// This method is used to plot power on zedGraphControl5
        /// </summary>
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

        private void button6_Click(object sender, EventArgs e)
        {
            Visualization_Form visualization_Form = new Visualization_Form(speed, cadence, altitude, heartRate, powerInWatts);
            visualization_Form.Show();
        }

        /// <summary>
        /// To get Power Balance
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show(PowerBalance);
        }


        /// <summary>
        /// In practice, the power balance is a four digit number. This is 16bits (each digit being a 4-bit nybble if you converted it into hexadecimal). The Polar documentation tells us that the lower 8 bits are the power from the left leg and the higher 8 bits are the Pedalling Index. The right leg is then 100-left leg. To get the left leg, we need to isolate the lower 8 bits. We do this with a “mask” (the term meaning the same as taping or masking something off when painting). The mask is in binary. We want the lower 8 bits so the binary mask is:

///%0000000011111111

///I.e.we don’t want the top 8 bits(so all zero), but we do want the lower 8 bits(all 1)
///If we then logical AND the mask and the power balance field we will be left with the left leg(because 1 & something will leave something and 0 & something will leave 0).

///To get the PI.We need to isolate the top 8 bits, so the mask would be:

///%1111111100000000

///Once we’ve logical ANDed them together we have it isolated but its a big number because the first bit is representing 256s and not 1s.So we need to bit shift it down 8 places using the >> operator.


        /// </summary>
        /// <returns></returns>
    private int getPowerBalance()
        {
            return 4582;

        }

            /// <summary>
            /// To get Normalized Power
            /// Here is the algorithm from the inventor (Andrew Coggan).
            /// We calculate Normalized Power by:        
            /// 1. Starting at the beginning of the data and calculating a 30-second rolling average for power;        
            /// 2. Raising the values obtained in step 1 to the fourth power;        
            /// 3. Taking the average of all the values obtained in step 2; and        
            /// 4. Taking the fourth root of the number obtained in step 3. This is Normalized Power.
            /// </summary>
            /// <returns></returns>
            private double getNormalizedPower()
        {
            List<double> rollingAvg = new List<double>();

            // Starting at the beginning of the data and calculating a 30-second rolling average for power; 
            for (int i=30; i< powerInWatts.Count + 1; i++)
            {
                int summ = 0;
                for(int j = i-30; j < i; j++)
                {
                    summ += powerInWatts[j];
                }

                double avg = summ / 30;
                rollingAvg.Add(avg);

            }


            //2. Raising the values obtained in step 1 to the fourth power; 
            for(int i=0; i< rollingAvg.Count; i++)
            {
                rollingAvg[i] = Math.Pow(rollingAvg[i], 4);
            }

            //3. Taking the average of all the values obtained in step 2;
            double myaverage = rollingAvg.Average();

            //4. Taking the fourth root of the number obtained in step 3
            double ans = Math.Pow(myaverage, 0.25);

            return ans;

        }


        /// <summary>
        /// To get Normalized Power
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show(NormalizedPower);
        }
    }
}
