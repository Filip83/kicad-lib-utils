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
using System.IO;
using System.Diagnostics;


namespace KicadUtils
{
    public partial class CmpProperties : Form
    {
        public KicadLibComponent Component { get; set; }
        private bool isWeb = false;
        private bool isFile = false;
        public CmpProperties()
        {
            InitializeComponent();
            
        }

        private void CmpProperties_Load(object sender, EventArgs e)
        {
            cmpName.Text = Component.Definition.Name;
            cmpDeisg.Text = Component.Definition.Reference;
            if(Component.Documentation == null)
            {
                docuDesc.Text = "";
                docuKeyWord.Text = "";
                docuFile.Text = "";
            }
            else
            {
                docuDesc.Text = Component.Documentation.Destription;
                docuKeyWord.Text = Component.Documentation.Keyword;
                docuFile.Text = Component.Documentation.DataSheet.Trim();
            }
            
            if(Component.FootPrints != null)
            {
                foreach(String fp in Component.FootPrints)
                {
                    FootPrints.Text += fp + "\r\n";
                }
            }
            isWeb = Uri.IsWellFormedUriString(docuFile.Text, UriKind.Absolute);
            if(!isWeb)
            {
                if (File.Exists(docuFile.Text))
                    isFile = true;
            }

            openBtn.Visible = isWeb | isFile;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Component.Definition.Name = cmpName.Text;
            Component.Definition.Reference = cmpDeisg.Text;
            if (Component.Documentation == null)
                Component.Documentation = new KicadLibDocu();

            Component.Documentation.CmpName = cmpName.Text;
            Component.Documentation.Destription = docuDesc.Text;
            Component.Documentation.Keyword = docuKeyWord.Text;
            Component.Documentation.DataSheet = docuFile.Text;

            Component.Documentation.CmpName = Component.Documentation.CmpName.Replace("\r\n", " ");
            Component.Documentation.Destription = Component.Documentation.Destription.Replace("\r\n", " ");
            Component.Documentation.Keyword = Component.Documentation.Keyword.Replace("\r\n", " ");
            Component.Documentation.DataSheet = Component.Documentation.DataSheet.Replace("\r\n", "");

            Component.Documentation.CmpName = Component.Documentation.CmpName.Replace("\n", " ");
            Component.Documentation.Destription = Component.Documentation.Destription.Replace("\n", " ");
            Component.Documentation.Keyword = Component.Documentation.Keyword.Replace("\n", " ");
            Component.Documentation.DataSheet = Component.Documentation.DataSheet.Replace("\n", "");

            String[] charSeparators = new String[] { " ", "\n", "\r\n"};
            String[] items = FootPrints.Text.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
            Component.FootPrints.Clear();
            foreach (String str in items)
            {
                Component.FootPrints.Add(str);
            }

            Close();
        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(docuFile.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
