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
    public partial class CompSpreadSheet : Form
    {
        private bool modified = false;
        private bool newComponent = false;
        private List<KicadLibPin> _Pins;
        public KicadLibComponent Component { get; set; }
        public CompSpreadSheet()
        {
            InitializeComponent();
            Component = new KicadLibComponent();
            //KicadLibPinOrientation.StringValues
            DataGridViewComboBoxColumn cmbColumn = (DataGridViewComboBoxColumn)spreadSheet.Columns[2];
            foreach (String str in KicadLibPinOrientation.StringValues)
                cmbColumn.Items.Add(str);

            cmbColumn = (DataGridViewComboBoxColumn)spreadSheet.Columns[3];
            foreach (String str in KicadLibPinType.StringValues)
                cmbColumn.Items.Add(str);

            cmbColumn = (DataGridViewComboBoxColumn)spreadSheet.Columns[4];
            foreach (String str in KicadLibPinShape.StringValues)
                cmbColumn.Items.Add(str);
            
        }

        public DialogResult ShowMyDalog(int id)
        {
            if (id == 0)
            {
                NewCmpProperties properties = new NewCmpProperties();
                if (properties.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    return System.Windows.Forms.DialogResult.Cancel;
                }
                else
                {
                    Component.Definition.Name = properties.CompName;
                    Component.Definition.Reference = properties.Designator;
                    KicadLibFX F0 = new KicadLibFX(0);
                    KicadLibFX F1 = new KicadLibFX(1);
                    KicadLibFX F2 = new KicadLibFX(2);
                    KicadLibFX F3 = new KicadLibFX(3);

                    F0.Reference = properties.Designator;
                    F1.Reference = properties.CompName;
                    Component.Parameters.Add(F0);
                    Component.Parameters.Add(F1);
                    Component.Parameters.Add(F2);
                    Component.Parameters.Add(F3);

                    _Pins = new List<KicadLibPin>();
                    for (int i = 0; i < properties.PinCount; i++)
                    {
                        KicadLibPin curpin = new KicadLibPin();
                        spreadSheet.Rows.Add();
                        curpin.Pin = (i + 1).ToString();
                        curpin.Orientation.Value = KicadLibPinOrientation.PinOrentation.Left;
                        curpin.Type.Value = KicadLibPinType.PinType.Input;
                        curpin.Shape.Value = KicadLibPinShape.PinShape.Line;
                        curpin.Sizenum = curpin.Sizename = KicadUnitConvert.From_mm(1.270);
                        curpin.Length = 3.810;
                        _Pins.Add(curpin);

                        spreadSheet.Rows[i].Cells[1].Value = (i + 1).ToString();
                        spreadSheet.Rows[i].Cells[2].Value = "Left";
                        spreadSheet.Rows[i].Cells[3].Value = "Input";
                        spreadSheet.Rows[i].Cells[4].Value = "Line";

                        spreadSheet.Rows[i].Cells[5].Value = 50;
                        spreadSheet.Rows[i].Cells[6].Value = 50;
                        spreadSheet.Rows[i].Cells[7].Value = 200;
                        //spreadSheet.Rows[i].Cells[8].Value = true;
                    }
                    newComponent = true;
                }
                
            }
            else if (id == 1)
            {
                _Pins = new List<KicadLibPin>();
                foreach (Object obj in Component.DrawObjects)
                {
                    if(obj.GetType() == typeof(KicadLibPin))
                    {
                        KicadLibPin curpin = (KicadLibPin)obj;
                        _Pins.Add(curpin);
                        spreadSheet.Rows.Add(
                        curpin.Name,
                        curpin.Pin,
                        KicadLibPinOrientation.StringValues[(int)curpin.Orientation.Value],
                        KicadLibPinType.StringValues[(int)curpin.Type.Value],
                        KicadLibPinShape.StringValues[(int)curpin.Shape.Value],
                        curpin.Sizename,
                        curpin.Sizenum,
                        curpin.Length/*,
                        true*/);
                    }
                }
                newComponent = false;
            }
            else
                return System.Windows.Forms.DialogResult.Abort;

            return base.ShowDialog();
        }

        private void spreadSheet_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double dvalue;
            String strValue = spreadSheet.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            if(String.IsNullOrWhiteSpace(strValue ))
                return;
            switch(e.ColumnIndex)
            {
                /*case 1:
                    if (!int.TryParse(strValue, out value))
                    {
                        spreadSheet.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                    }
                    break;*/
                case 5:
                case 6:
                    if (!double.TryParse(strValue, out dvalue))
                    {
                        double tmp = KicadUnitConvert.From_mm(1.270);
                        spreadSheet.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = tmp.ToString();
                    }
                    break;
                case 7:
                    if (!double.TryParse(strValue, out dvalue))
                    {
                        double tmp = KicadUnitConvert.From_mm(3.810);
                        spreadSheet.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = tmp.ToString();
                    }
                    break;

            }
        }

        private void CompSpreadSheet_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (modified)
                this.DialogResult = DialogResult.OK;
            else
                this.DialogResult = DialogResult.Cancel;
        }

        private void Prop_Click(object sender, EventArgs e)
        {
            CmpProperties prop = new CmpProperties();
            prop.Component = Component;
            if (prop.ShowDialog() == DialogResult.OK)
                modified = true;
        }

        private void readUCF_Click(object sender, EventArgs e)
        {
            /*if(UCFOpen.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                UCFPins ucfPins = new UCFPins();
                ucfPins.ReadFile(UCFOpen.FileName);
            }*/
        }

        private void Compare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Index == 0 || e.Column.Index == 1)
            {
                e.Handled = true;
                String x = e.CellValue1.ToString();
                String y = e.CellValue2.ToString();

                string s1 = x as string;
                if (s1 == null)
                {
                    return;
                }
                string s2 = y as string;
                if (s2 == null)
                {
                    return;
                }

                int len1 = s1.Length;
                int len2 = s2.Length;
                int marker1 = 0;
                int marker2 = 0;

                // Walk through two the strings with two markers.
                while (marker1 < len1 && marker2 < len2)
                {
                    char ch1 = s1[marker1];
                    char ch2 = s2[marker2];

                    // Some buffers we can build up characters in for each chunk.
                    char[] space1 = new char[len1];
                    int loc1 = 0;
                    char[] space2 = new char[len2];
                    int loc2 = 0;

                    // Walk through all following characters that are digits or
                    // characters in BOTH strings starting at the appropriate marker.
                    // Collect char arrays.
                    do
                    {
                        space1[loc1++] = ch1;
                        marker1++;

                        if (marker1 < len1)
                        {
                            ch1 = s1[marker1];
                        }
                        else
                        {
                            break;
                        }
                    } while (char.IsDigit(ch1) == char.IsDigit(space1[0]));

                    do
                    {
                        space2[loc2++] = ch2;
                        marker2++;

                        if (marker2 < len2)
                        {
                            ch2 = s2[marker2];
                        }
                        else
                        {
                            break;
                        }
                    } while (char.IsDigit(ch2) == char.IsDigit(space2[0]));

                    // If we have collected numbers, compare them numerically.
                    // Otherwise, if we have strings, compare them alphabetically.
                    string str1 = new string(space1);
                    string str2 = new string(space2);

                    int result;

                    if (char.IsDigit(space1[0]) && char.IsDigit(space2[0]))
                    {
                        int thisNumericChunk = int.Parse(str1);
                        int thatNumericChunk = int.Parse(str2);
                        result = thisNumericChunk.CompareTo(thatNumericChunk);
                    }
                    else
                    {
                        result = str1.CompareTo(str2);
                    }

                    if (result != 0)
                    {
                        e.SortResult = result;
                        return;
                    }
                }
                e.SortResult =  len1 - len2;
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (_Pins != null)
            {
                Component.RemovePins();
                int length = _Pins.Count / 4;
                int xstart = -(length / 2)*200;
                int ystart = (length / 2)*200;
                for (int i = 0; i < _Pins.Count; i++)
                {
                    KicadLibPin curpin = _Pins[i];

                    curpin.Name = spreadSheet.Rows[i].Cells[0].Value.ToString();
                    curpin.Pin = spreadSheet.Rows[i].Cells[1].Value.ToString(); //(i + 1).ToString();
                    //curpin.Orientation = new KicadLibPinOrientation(spreadSheet.Rows[i].Cells[2].Value.ToString());
                    curpin.Type = new KicadLibPinType(spreadSheet.Rows[i].Cells[3].Value.ToString());
                    curpin.Shape = new KicadLibPinShape(spreadSheet.Rows[i].Cells[4].Value.ToString());
                    curpin.Sizename = (System.Convert.ToDouble(spreadSheet.Rows[i].Cells[5].Value.ToString()));
                    curpin.Sizenum = (System.Convert.ToDouble(spreadSheet.Rows[i].Cells[6].Value.ToString()));
                    curpin.Length = (System.Convert.ToDouble(spreadSheet.Rows[i].Cells[7].Value.ToString()));
                  
                    if (newComponent)
                    {
                        curpin.Length = 200;
                        curpin.Part = curpin.Dmg = 1;

                        if (i < length)
                        {
                            curpin.Position.Y = ystart + 400;
                            curpin.Position.X = xstart + i * 200;
                            curpin.Orientation.Value = KicadLibPinOrientation.PinOrentation.Down;
                        }
                        else if( i < 2*length)
                        {
                            curpin.Position.X = xstart*(-1) + 400;
                            curpin.Position.Y = ystart - (i - length) * 200;
                            curpin.Orientation.Value = KicadLibPinOrientation.PinOrentation.Left;
                        }
                        else if(i < 3*length)
                        {
                            curpin.Position.Y = ystart*(-1) - 400;
                            curpin.Position.X = xstart*(-1) - (i - 2*length) * 200;
                            curpin.Orientation.Value = KicadLibPinOrientation.PinOrentation.Up;
                        }
                        else
                        {
                            curpin.Position.X = xstart - 400;
                            curpin.Position.Y = ystart*(-1) + (i - 3*length) * 200;
                            curpin.Orientation.Value = KicadLibPinOrientation.PinOrentation.Right;
                        }  
                    }

                    Component.DrawObjects.Add(curpin);
                }

                modified = true;
            }
        }
    }
}