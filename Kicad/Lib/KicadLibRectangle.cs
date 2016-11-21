using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Kicad.Lib
{
    public class KicadLibRectangle
    {
        public const int Items = 9;
        public double X1 { get; set; }
        public double Y1 { get; set; }
        public double X2 { get; set; }
        public double Y2 { get; set; }
        public int Part { get; set; }
        public int Dmg { get; set; }
        public int Pen { get; set; }
        public KicadLibFill Fill { get; set; }

        public KicadLibRectangle()
        {
            Fill = new KicadLibFill(0);
        }
        public void Parse(String line)
        {
            char[] charSeparators = new char[] { ' ' };
            String[] items = line.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
            if (items.Length == Items)
            {
                if (items[0] != "S")
                    throw new Exception("LibPolygon public class parse error. Another object.");

                X1 = System.Convert.ToInt32(items[1]);
                Y1 = System.Convert.ToInt32(items[2]);
                X2 = System.Convert.ToInt32(items[3]);
                Y2 = System.Convert.ToInt32(items[4]);
                Part = System.Convert.ToInt32(items[5]);
                Dmg = System.Convert.ToInt32(items[6]);
                Pen = System.Convert.ToInt32(items[7]);
                Fill.Parse(items[8]);


            }
            else
                throw new Exception("LibPolygon public class parse error. Unexpected number of items.");
        }

        public void Parse(String[] items)
        {
            if (items.Length == Items)
            {
                if (items[0] != "S")
                    throw new Exception("LibPolygon public class parse error. Another object.");

                X1 = System.Convert.ToInt32(items[1]);
                Y1 = System.Convert.ToInt32(items[2]);
                X2 = System.Convert.ToInt32(items[3]);
                Y2 = System.Convert.ToInt32(items[4]);
                Part = System.Convert.ToInt32(items[5]);
                Dmg = System.Convert.ToInt32(items[6]);
                Pen = System.Convert.ToInt32(items[7]);
                Fill.Parse(items[8]);


            }
            else
                throw new Exception("LibPolygon public class parse error. Unexpected number of items.");
        }
        public override String ToString()
        {
            StringBuilder outstr = new StringBuilder();
            outstr.AppendFormat(CultureInfo.InstalledUICulture, "S {0} {1} {2} {3} {4} {5} {6} {7}",
                X1, Y1, X2, Y2, Part, Dmg, Pen, Fill);

            return outstr.ToString();
        }
    }
}
