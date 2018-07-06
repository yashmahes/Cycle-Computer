using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CycleComputer
{
    public partial class Data_Form : Form
    {
        public string filename;
        public Data_Form(string filename)
        {
            this.filename = filename;


            InitializeComponent();
        }

        /// <summary>
        /// This method reads the file and displays all the data store in the filename in richTextBox1 and richTextBox2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Data_Form_Load(object sender, EventArgs e)
        {
            label3.Text = filename;
            richTextBox1.Text = "";
            int counter = 0;
            string line;

            try
            {
                // Read the file.  
                System.IO.StreamReader file =
                    new System.IO.StreamReader(filename);
                while ((line = file.ReadLine()) != null)
                {
                    richTextBox1.Text += "\n\n";
                    richTextBox1.Text += line;
                    counter++;

                    line = line.TrimStart(' ');
                    if (line.Equals(""))
                        break;
                }


                richTextBox2.Text = "";
                while ((line = file.ReadLine()) != null)
                {
                    richTextBox2.Text += "\n\n";
                    richTextBox2.Text += line;
                    counter++;

                    if (counter == 2000)
                        break;

                }



                file.Close();

            }

            catch(Exception excep)
            {
                MessageBox.Show("File not found");
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// This method redirects the user to new window which displays the data in well defined format
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            SuitableGUIDisplay suitableGUIDisplay = new SuitableGUIDisplay(filename);
            suitableGUIDisplay.Show();
        }
    }
}
