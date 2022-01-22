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
    public partial class GAMonitor<S> : UserControl
    {
        GenericGASolver<S> theGASolver;

        /// <summary>
        /// The monitor of the GA solver.
        /// </summary>
        /// <param name="theGASolver"> A GA solver. </param>
        public GAMonitor(GenericGASolver<S> theGASolver)
        {
            this.theGASolver = theGASolver;
            InitializeComponent();
            btn_runOneIter.Enabled = btn_runToEnd.Enabled = false;
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            theGASolver.Reset();
            btn_runOneIter.Enabled = btn_runToEnd.Enabled = true;
            btn_reset.BackColor = SystemColors.Control;
            btn_runOneIter.BackColor = btn_runToEnd.BackColor = Color.Cornsilk;
        }

        private void btn_runOneIter_Click(object sender, EventArgs e)
        {
            theGASolver.RunOneIteration();
        }

        private void btn_runToEnd_Click(object sender, EventArgs e)
        {
            theGASolver.RunToEnd();
            btn_runOneIter.Enabled = btn_runToEnd.Enabled = false;
            btn_reset.BackColor = Color.Cornsilk;
            btn_runOneIter.BackColor = btn_runToEnd.BackColor = SystemColors.Control;
        }
    }
}
