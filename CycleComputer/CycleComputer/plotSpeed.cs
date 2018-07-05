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
    public partial class plotSpeed : Form
    {
        List<int> data;
        string type;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="str"></param>
        public plotSpeed(List<int> data, string str)
        {
            InitializeComponent();
            this.data = data;
            type = str;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void plotSpeed_Load(object sender, EventArgs e)
        {
            plot();
        }

        /// <summary>
        /// 
        /// </summary>
        private void plot()
        {
            GraphPane myPane = zedGraphControl1.GraphPane;

            // Set the Titles
            
            myPane.XAxis.Title = "count";
            
            myPane.Title = type;
            myPane.YAxis.Title = type;


            PointPairList teamAPairList = new PointPairList();

            int[] teamAData = data.ToArray();

            for (int i = 0; i < teamAData.Length; i++)
            {
                teamAPairList.Add(i, teamAData[i]);

            }

            LineItem teamACurve = myPane.AddCurve(type,
                   teamAPairList, Color.Red, SymbolType.Diamond);



            zedGraphControl1.AxisChange();
        }


    }
}
