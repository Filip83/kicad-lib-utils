using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Kicad.Lib
{
    public class KicadLibCircle
    {
        public const int Items = 8;
        public KicadLibPoint Position { get; set; }
        public double Radius { get; set; }
        public int Part { get; set; }
        public int Dmg { get; set; }
        public int Pen { get; set; }
        public KicadLibFill Fill { get; set; }

        public KicadLibCircle()
        {
            Position = new KicadLibPoint(0, 0);
            Fill = new KicadLibFill(0);
        }
        public void Parse(String line)
        {
            char[] charSeparators = new char[] { ' ' };
            String[] items = line.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
            if (items.Length == Items)
            {
                if (items[0] != "C")
                    throw new Exception("LibCirc public class parse error. Another object.");

                Position.X = System.Convert.ToInt32(items[1]);
                Position.Y = System.Convert.ToInt32(items[2]);
                Radius = System.Convert.ToInt32(items[3]);
                Part = System.Convert.ToInt32(items[4]);
                Dmg = System.Convert.ToInt32(items[5]);
                Pen = System.Convert.ToInt32(items[6]);
                Fill.Parse(items[7]);

            }
            else
                throw new Exception("LibArc public class parse error. Unexpected number of items.");
        }

        public void Parse(String[] items)
        {
            if (items.Length == Items)
            {
                if (items[0] != "C")
                    throw new Exception("LibCirc public class parse error. Another object.");

                Position.X = System.Convert.ToInt32(items[1]);
                Position.Y = System.Convert.ToInt32(items[2]);
                Radius = System.Convert.ToInt32(items[3]);
                Part = System.Convert.ToInt32(items[4]);
                Dmg = System.Convert.ToInt32(items[5]);
                Pen = System.Convert.ToInt32(items[6]);
                Fill.Parse(items[7]);

            }
            else
                throw new Exception("LibArc public class parse error. Unexpected number of items.");
        }
        public override String ToString()
        {
            StringBuilder outstr = new StringBuilder();
            outstr.AppendFormat(CultureInfo.InstalledUICulture,"A {0} {1} {2} {3} {4} {5} {6}",
                Position, Radius, Part, Dmg, Pen, Fill);
            return outstr.ToString();
        }
    }
}
