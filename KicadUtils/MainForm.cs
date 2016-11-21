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
using System.Text.RegularExpressions;

namespace KicadUtils
{
    public partial class MainForm : Form
    {
        public KicadLibLibrary primaryLIb = new KicadLibLibrary();
        public KicadLibLibrary secondaryLIb = new KicadLibLibrary();
        public bool newLib = false;
        public MainForm()
        {
            InitializeComponent();
        }

        private void RefreshPrimaryList()
        {
            PrimaryLibList.Items.Clear();
            foreach (KicadLibComponent cmp in primaryLIb.Components)
            {
                PrimaryLibList.Items.Add(cmp.Definition.Name);
            }
        }
        private void RadPrim_Click(object sender, EventArgs e)
        {
            if (libOpenDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
				try
				{
	                primaryLIb.ReadFile(libOpenDlg.FileName);
	                PrimaryLibList.Items.Clear();

	                foreach (KicadLibComponent cmp in primaryLIb.Components)
	                {
	                    PrimaryLibList.Items.Add(cmp.Definition.Name);
	                }

                    NewComponent.Enabled = 
                    DelBtn.Enabled = 
                    OpenBtn.Enabled = 
                    PropBtn.Enabled = 
                    SaveAsBtn.Enabled = true;

                    if (secondaryLIb.Components.Count != 0)
                        AddBtn.Enabled = true;

                }
				catch(Exception ee)
				{
					MessageBox.Show(ee.ToString());

                    NewComponent.Enabled =
                    AddBtn.Enabled =
                    DelBtn.Enabled =
                    OpenBtn.Enabled =
                    PropBtn.Enabled =
                    SaveBtn.Enabled =
                    SaveAsBtn.Enabled = false;
                }
            }
        }

        private void ReadSec_Click(object sender, EventArgs e)
        {
            if (libOpenDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    secondaryLIb.ReadFile(libOpenDlg.FileName);
                    SecondaryLibList.Items.Clear();

                    foreach (KicadLibComponent cmp in secondaryLIb.Components)
                    {
                        SecondaryLibList.Items.Add(cmp.Definition.Name);
                    }

                    if(primaryLIb.Components.Count != 0)
                        AddBtn.Enabled = true;
                }
                catch(Exception ee)
                {
                    MessageBox.Show(ee.ToString());
                    AddBtn.Enabled = false;
                }
            }
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            int pos = SecondaryLibList.SelectedIndex;
            if (pos != -1)
            {
                KicadLibComponent selectedCmp = FindComponentSecondary(SecondaryLibList.Items[pos].ToString());
                foreach(KicadLibComponent cmp in primaryLIb.Components)
                {
                    if(cmp.Definition.Name == selectedCmp.Definition.Name)
                    {
                        if(MessageBox.Show("Component with same name exist in primary library. Do You wish to rename it?.",
                            "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            SetNewName newName = new SetNewName();
                            
                            newName.ComponentName = selectedCmp.Definition.Name;
                            newName.Lib = primaryLIb;
                            
                            if (newName.ShowDialog() == DialogResult.OK)
                            {
                                KicadLibComponent newcmp = new KicadLibComponent();
                                newcmp = selectedCmp;
                                newcmp.Definition.Name = newName.ComponentName;
                                primaryLIb.Components.Add(newcmp);
                                RefreshPrimaryList();
                                SaveBtn.Enabled = true;
                            }
                        }
                        return;
                    }
                }
                primaryLIb.Components.Add(selectedCmp);
                RefreshPrimaryList();
                SaveBtn.Enabled = true;
            }
            else
            {
                MessageBox.Show("No item to move selected.");
            }
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            int pos = PrimaryLibList.SelectedIndex;
            if (pos != -1)
            {
                KicadLibComponent newComp = FindComponentPrimary(PrimaryLibList.Items[pos].ToString());
                primaryLIb.Components.Remove(newComp);
                RefreshPrimaryList();
                SaveBtn.Enabled = true;
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if(primaryLIb.Components != null)
            {
                if (primaryLIb.Components.Count != 0)
                {
                    SaveBtn.Enabled = false;
                    primaryLIb.Save();
                }
            }
                
        }

        private void NewComponent_Click(object sender, EventArgs e)
        {

            //if (primaryLIb.Components.Count != 0)
            {
                CompSpreadSheet spch = new CompSpreadSheet();
                if (spch.ShowMyDalog(0) == DialogResult.OK)
                {
                    primaryLIb.Components.Add(spch.Component);
                    RefreshPrimaryList();
                    SaveBtn.Enabled = true;
                }
            }
            /*else
            {
                MessageBox.Show("Component can be only added to opened libray.");
            }*/

        }

        private void OpenBtn_Click(object sender, EventArgs e)
        {
            CompSpreadSheet spch = new CompSpreadSheet();
            int pos = PrimaryLibList.SelectedIndex;
            if (pos != -1)
            {
                KicadLibComponent selComp = FindComponentPrimary(PrimaryLibList.Items[pos].ToString());
                spch.Component = selComp;
                if (spch.ShowMyDalog(1) == DialogResult.OK)
                    SaveBtn.Enabled = true;
            }
        }

        private void SaveAsBtn_Click(object sender, EventArgs e)
        {
            if (primaryLIb.Components != null)
            {
                if (primaryLIb.Components.Count != 0)
                {
                    if (saveLibDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        primaryLIb.Save(saveLibDlg.FileName);
                    }
                }

            }
        }

        private void PropBtn_Click(object sender, EventArgs e)
        {
            CmpProperties prop = new CmpProperties();
            int pos = PrimaryLibList.SelectedIndex;
            if (pos != -1)
            {
                KicadLibComponent selComp = FindComponentPrimary(PrimaryLibList.Items[pos].ToString());
                prop.Component = selComp;
                if(prop.ShowDialog() == DialogResult.OK)
                {
                    SaveBtn.Enabled = true;
                }
            }
        }

        private void NewLib_Click(object sender, EventArgs e)
        {
            primaryLIb.Clear();
            NewComponent.Enabled =
            AddBtn.Enabled =
            DelBtn.Enabled =
            OpenBtn.Enabled =
            PropBtn.Enabled =
            SaveAsBtn.Enabled = true;
        }

        private void PrimSearch_Changed(object sender, EventArgs e)
        {
            PrimaryLibList.Items.Clear();
            foreach (KicadLibComponent cmp in primaryLIb.Components)
            {
                if(!String.IsNullOrWhiteSpace(primSearch.Text))
                {
                    try
                    {
                        if (Regex.IsMatch(cmp.Definition.Name, primSearch.Text, RegexOptions.IgnoreCase))
                        {
                            PrimaryLibList.Items.Add(cmp.Definition.Name);
                        }
                    }
                    catch
                    {
                        return;
                    }
                }
                else
                    PrimaryLibList.Items.Add(cmp.Definition.Name);
            }
        }

        private void SecSearch_Changed(object sender, EventArgs e)
        {
            SecondaryLibList.Items.Clear();
            foreach (KicadLibComponent cmp in secondaryLIb.Components)
            {
                if (!String.IsNullOrWhiteSpace(SecSearch.Text))
                {
                    try
                    {
                        if (Regex.IsMatch(cmp.Definition.Name, SecSearch.Text, RegexOptions.IgnoreCase))
                        {
                            SecondaryLibList.Items.Add(cmp.Definition.Name);
                        }
                    }
                    catch
                    {
                        return;
                    }
                }
                else
                    SecondaryLibList.Items.Add(cmp.Definition.Name);
            }
        }

        private KicadLibComponent FindComponentPrimary(String Name)
        {
            foreach(KicadLibComponent cmp in primaryLIb.Components)
            {
                if (cmp.Definition.Name == Name)
                    return cmp;
            }
            return null;
        }

        private KicadLibComponent FindComponentSecondary(String Name)
        {
            foreach (KicadLibComponent cmp in secondaryLIb.Components)
            {
                if (cmp.Definition.Name == Name)
                    return cmp;
            }
            return null;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(SaveBtn.Enabled)
            {
                if (MessageBox.Show("The primary library contains unsaved items. Continue?", "Message",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    e.Cancel = true;
            }
        }
    }
}
