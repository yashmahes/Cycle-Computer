using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CycleComputer
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// filename is used to store the path of data file
        /// </summary>
        public static string filename;
        public static string filename2;

        public Form1()
        {
            InitializeComponent();

            //OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //openFileDialog1.ShowDialog();
            //openFileDialog1.RestoreDirectory = true;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.Hide();
            button4.Hide();
            button5.Hide();
        }


        /// <summary>
        /// When user browse the computer to select the data file. This method is used to browse and select the data file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)

        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();



            openFileDialog1.InitialDirectory = @"C:\";

            openFileDialog1.Title = "Browse Text Files";



            openFileDialog1.CheckFileExists = true;

            openFileDialog1.CheckPathExists = true;



            openFileDialog1.DefaultExt = "txt";

            openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            openFileDialog1.FilterIndex = 2;

            openFileDialog1.RestoreDirectory = true;



            openFileDialog1.ReadOnlyChecked = true;

            openFileDialog1.ShowReadOnly = true;



            if (openFileDialog1.ShowDialog() == DialogResult.OK)

            {

                textBox1.Text = openFileDialog1.FileName;
                filename = openFileDialog1.FileName;

            }

        }

        /// <summary>
        /// This method is used to fetch data and display it on new form : Data_Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            
            Data_Form data_Form = new Data_Form(filename);
            data_Form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Show();
            button4.Show();
            button5.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();



            openFileDialog1.InitialDirectory = @"C:\";

            openFileDialog1.Title = "Browse Text Files";



            openFileDialog1.CheckFileExists = true;

            openFileDialog1.CheckPathExists = true;



            openFileDialog1.DefaultExt = "txt";

            openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            openFileDialog1.FilterIndex = 2;

            openFileDialog1.RestoreDirectory = true;



            openFileDialog1.ReadOnlyChecked = true;

            openFileDialog1.ShowReadOnly = true;



            if (openFileDialog1.ShowDialog() == DialogResult.OK)

            {

                textBox2.Text = openFileDialog1.FileName;
                filename2 = openFileDialog1.FileName;

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Data_Form data_Form = new Data_Form(filename2);
            data_Form.Show();
        }
    }
}
