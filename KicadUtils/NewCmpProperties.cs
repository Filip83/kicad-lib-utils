using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KicadUtils
{
    public partial class NewCmpProperties : Form
    {
        public NewCmpProperties()
        {
            InitializeComponent();
            cmpDeisg.Text = "U";
        }

        public String CompName { get { return cmpName.Text; } }
        public String Designator { get { return cmpDeisg.Text; } }
        public UInt32 PinCount { get { return (UInt32)componentPins.Value; } }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
