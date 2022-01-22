using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TEChangGALibrary
{
    public partial class BFMonitor : UserControl
    {
        BrutalForceMethod brutalForceMethod;
        ProgressBar pb;
        /// <summary>
        /// The monitor of brutal force method.
        /// </summary>
        /// <param name="brutalForceMethod"> A brutal force method </param>
        public BFMonitor(BrutalForceMethod brutalForceMethod)
        {
            InitializeComponent();
            this.brutalForceMethod = brutalForceMethod;
            pb = new ProgressBar();
            if(brutalForceMethod.NumberOfJobs <= 8)
            {
                btn_brutalForce.BackColor = Color.Cornsilk;
            }
        }

        private void btn_brutalForce_Click(object sender, EventArgs e)
        {
            if(brutalForceMethod.NumberOfJobs >= 8)
            {
                DialogResult dialogResult = MessageBox.Show("It might cost A LOT OF TIME for the brutal force method to solve the problem when number of jobs is large, are you sure to execute?",
                                                            "Warning Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    pb.Value = 0;
                    brutalForceMethod.ShowAllCombinations();
                    btn_brutalForce.BackColor = SystemColors.Control;
                }
            }
            else
            {
                brutalForceMethod.ShowAllCombinations();
                btn_brutalForce.BackColor = SystemColors.Control;
            }
        }
    }
}
