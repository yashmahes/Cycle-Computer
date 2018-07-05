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
        public static string filename;

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

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }


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

        private void button2_Click(object sender, EventArgs e)
        {
            
            Data_Form data_Form = new Data_Form();
            data_Form.Show();
        }
    }
}
