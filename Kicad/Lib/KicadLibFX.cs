using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Kicad.Lib
{
    /// <summary>
    /// F0 oject hold information about position and
    /// properties of ICs reference designator
    /// </summary>
    ///

    public class KicadLibFX
    {
        public const int Items = 9;
        public int                      FType { get; set; }
        public String                   Reference { get; set; }
        public KicadLibPoint            Position { get; set; }
        public int                      TextSize { get; set; }
        public KicadLibTextOrientation  Oreintation { get; set; }
        public KicadLibVisible          Visible { get; set; }
        public KicadLibHTextJustify     HJustify { get; set; }
        public KicadLibVTextJustify     VJustify { get; set; }
        public String                   Name { get; set; }

        public KicadLibFX(int type = 0)
        {
            Position = new KicadLibPoint(0, 0);
            Oreintation = new KicadLibTextOrientation(KicadLibTextOrientation.TextOrient.Horizontal);
            Visible = new KicadLibVisible(true);
            HJustify = new KicadLibHTextJustify(0);
            VJustify = new KicadLibVTextJustify(0);
            FType = type;
            TextSize = 50;
        }
        public void Parse(String line)
        {
            char[] charSeparators = new char[] { ' ' };
            String[] items = line.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
            if (items.Length == Items)
            {
                bool CheckName = false;
                if ((items[0])[0] != 'F')
                    throw new Exception("FX public class parse error. Another object.");

                String toNum = items[0].Replace("F", "");
                FType = System.Convert.ToInt32(toNum);
                if (FType > 3)
                    CheckName = true;

                Reference = items[1].Trim('"');
                Position.X  = System.Convert.ToInt32(items[2]);
                Position.Y = System.Convert.ToInt32(items[3]);
                TextSize = System.Convert.ToInt32(items[4]);
                Oreintation.Parse(items[5]);
                Visible.Parse(items[6]);
                HJustify.Parse(items[7]);
                VJustify.Parse(items[8]);
                if (CheckName)
                {
                    if (items.Length == Items + 1)
                        Name = items[9].Remove('"');
                    else
                        Name = "";
                }        
            }
            else
                throw new Exception("FX public class parse error. Unexpected number of items.");
        }

        public void Parse(String[] items)
        {
            if (items.Length == Items)
            {
                bool CheckName = false;
                if ((items[0])[0] != 'F')
                    throw new Exception("FX public class parse error. Another object.");
                String toNum = items[0].Replace("F","");
                FType = System.Convert.ToInt32(toNum);
                if (FType > 3)
                    CheckName = true;

                Reference = items[1].Trim('"');
                Position.X = System.Convert.ToInt32(items[2]);
                Position.Y = System.Convert.ToInt32(items[3]);
                TextSize = System.Convert.ToInt32(items[4]);
                Oreintation.Parse(items[5]);
                Visible.Parse(items[6]);
                HJustify.Parse(items[7]);
                VJustify.Parse(items[8]);
                if (CheckName)
                {
                    if (items.Length == Items + 1)
                        Name = items[9].Remove('"');
                    else
                        Name = "";
                }
            }
            else
                throw new Exception("FX public class parse error. Unexpected number of items.");
        }
        public override String ToString()
        {
            StringBuilder outstr = new StringBuilder();
            outstr.AppendFormat(CultureInfo.InstalledUICulture, "F{0} \"{1}\" {2} {3} {4} {5} {6} {7}", FType, Reference,
                Position, TextSize, Oreintation, Visible, HJustify,VJustify);
            return outstr.ToString();
        }
    }
}
