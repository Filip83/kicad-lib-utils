using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Kicad.Lib
{

    public class KicadLibArc
    {
        public const int Items = 14;
        public KicadLibPoint Position { get; set; }
        public int Radius { get; set; }
        public int StartAngle { get; set; }
        public int EndAngle { get; set; }
        public int Part { get; set; }
        public int Dmg { get; set; }
        public int Pen { get; set; }
        public KicadLibFill  Fill { get; set; }
        public KicadLibPoint Start { get; set; }
        public KicadLibPoint End { get; set; }

        public KicadLibArc()
        {
            Position = new KicadLibPoint(0,0);
            Fill = new KicadLibFill(0);
            Start = new KicadLibPoint(0,0);
            End = new KicadLibPoint(0, 0);
        }

        public void Parse(String line)
        {
            char[] charSeparators = new char[] { ' ' };
            String[] items = line.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
            if (items.Length == Items)
            {
                if (items[0] != "A")
                    throw new Exception("LibArc public class parse error. Another object.");

                Position.X = System.Convert.ToInt32(items[1]);
                Position.Y = System.Convert.ToInt32(items[2]);
                Radius     = System.Convert.ToInt32(items[3]);
                StartAngle = System.Convert.ToInt32(items[4]);
                EndAngle   = System.Convert.ToInt32(items[5]);
                Part       = System.Convert.ToInt32(items[6]);
                Dmg        = System.Convert.ToInt32(items[7]);
                Pen        = System.Convert.ToInt32(items[8]);

                Fill.Parse(items[9]);

                Start.X = System.Convert.ToInt32(items[10]);
                Start.Y = System.Convert.ToInt32(items[11]);
                End.X   = System.Convert.ToInt32(items[12]);
                End.Y   = System.Convert.ToInt32(items[13]);
            }
            else
                throw new Exception("LibArc public class parse error. Unexpected number of items.");
        }

        public void Parse(String[] items)
        {
            if (items.Length == Items)
            {
                if (items[0] != "A")
                    throw new Exception("LibArc public class parse error. Another object.");

                Position.X = System.Convert.ToInt32(items[1]);
                Position.Y = System.Convert.ToInt32(items[2]);
                Radius = System.Convert.ToInt32(items[3]);
                StartAngle = System.Convert.ToInt32(items[4]);
                EndAngle = System.Convert.ToInt32(items[5]);
                Part = System.Convert.ToInt32(items[6]);
                Dmg = System.Convert.ToInt32(items[7]);
                Pen = System.Convert.ToInt32(items[8]);

                Fill.Parse(items[9]);

                Start.X = System.Convert.ToInt32(items[10]);
                Start.Y = System.Convert.ToInt32(items[11]);
                End.X = System.Convert.ToInt32(items[12]);
                End.Y = System.Convert.ToInt32(items[13]);
            }
            else
                throw new Exception("LibArc public class parse error. Unexpected number of items.");
        }
        public override String ToString()
        {
            StringBuilder outstr = new StringBuilder();
            outstr.AppendFormat(CultureInfo.InstalledUICulture,"A {0} {1} {2} {3} {4} {5} {6} {7} {8} {9}",
                Position, Radius, StartAngle, EndAngle, Part, Dmg, Pen, Fill, Start, End);
            return outstr.ToString();
        }
    }
}
