using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Kicad.Lib
{
    public class KicadLibText
    {
        public const int Items = 13;
        public double Angle { get; set; }
        public KicadLibPoint Position { get; set; }
        public double Size { get; set; }
        public int Hiden { get; set; }
        public int Part { get; set; }
        public int Dmg { get; set; }
        public String Text { get; set; }
        public KicadLibItalic Italic { get; set; }
        public int Bold { get; set; }
        public KicadLibHTextJustify HAlign { get; set; }
        public KicadLibVTextJustify VAlign { get; set; }

        public KicadLibText()
        {
            Position = new KicadLibPoint(0, 0);
            Italic = new KicadLibItalic(false);
            HAlign = new KicadLibHTextJustify(0);
            VAlign = new KicadLibVTextJustify(0);
        }
        public void Parse(String line)
        {
            char[] charSeparators = new char[] { ' ' };
            String[] items = line.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
            if (items.Length == Items)
            {
                Angle       = System.Convert.ToInt32(items[1]);
                Position.X  = System.Convert.ToInt32(items[2]);
                Position.Y  = System.Convert.ToInt32(items[3]);
                Size        = System.Convert.ToInt32(items[4]);
                Hiden       = System.Convert.ToInt32(items[5]);
                Part        = System.Convert.ToInt32(items[6]);
                Dmg         = System.Convert.ToInt32(items[7]);
                Text        = items[8].Remove('"');
                Italic.Parse(items[9]);

                Bold = System.Convert.ToInt32(items[10]);
                HAlign.Parse(items[11]);
                VAlign.Parse(items[12]);
            }
            else
                throw new Exception("LibPolygon public class parse error. Unexpected number of items.");
        }

        public void Parse(String[] items)
        {
            if (items.Length == Items)
            {
                Angle = System.Convert.ToInt32(items[1]);
                Position.X = System.Convert.ToInt32(items[2]);
                Position.Y = System.Convert.ToInt32(items[3]);
                Size = System.Convert.ToInt32(items[4]);
                Hiden = System.Convert.ToInt32(items[5]);
                Part = System.Convert.ToInt32(items[6]);
                Dmg = System.Convert.ToInt32(items[7]);
                Text = items[8].Trim('"');
                Italic.Parse(items[9]);

                Bold = System.Convert.ToInt32(items[10]);
                HAlign.Parse(items[11]);
                VAlign.Parse(items[12]);
            }
            else
                throw new Exception("LibPolygon public class parse error. Unexpected number of items.");
        }
        public override String ToString()
        {
            StringBuilder outstr = new StringBuilder();
            outstr.AppendFormat(CultureInfo.InstalledUICulture, "T {0} {1} {2} {3} {4} {5} {6} {7} {8} {9}",
                Angle, Position, Size, Hiden, Dmg, Text, Italic, Bold, HAlign, VAlign);

            return outstr.ToString();
        }
    }
}
