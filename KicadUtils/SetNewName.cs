using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kicad.Lib;

namespace KicadUtils
{
    public partial class SetNewName : Form
    {
        private KicadLibLibrary _lib;
        public SetNewName()
        {
            InitializeComponent();
        }

        public String ComponentName { get { return NewName.Text; } set { NewName.Text = value; } }
        public KicadLibLibrary Lib { set { _lib = value; } }

        private void OK_Click(object sender, EventArgs e)
        {
            foreach(KicadLibComponent cmp in _lib.Components)
            {
                if(ComponentName == cmp.Definition.Name)
                {
                    MessageBox.Show("No walid component name.");
                    return;
                }
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}
