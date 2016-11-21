using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Globalization;

namespace Kicad.Lib
{
    public class KicadLibPolygon
    {
        public const int Items = 8;
        public int Count { get; set; }
        public int Part { get; set; }
        public int Dmg { get; set; }
        public int Pen { get; set; }
        public KicadLibPoint[] Points { get; set; }
        public KicadLibFill Fill { get; set; }

        public KicadLibPolygon()
        {
            Fill = new KicadLibFill(0);
        }
        public void Parse(String line)
        {
            char[] charSeparators = new char[] { ' ' };
            String[] items = line.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);

            if (items[0] != "P")
                throw new Exception("LibPolygon public class parse error. Another object.");

            Count = System.Convert.ToInt32(items[1]);
            Part  = System.Convert.ToInt32(items[2]);
            Dmg   = System.Convert.ToInt32(items[3]);
            Pen   = System.Convert.ToInt32(items[4]);

            Points = new KicadLibPoint[Count];
            for (int i = 0; i < Count;i++ )
            {
                Points[i] = new KicadLibPoint(System.Convert.ToInt32(items[5 + 2 * i + 0]),
                                              System.Convert.ToInt32(items[5 + 2 * i + 1]));
            }

            Fill.Parse(items[5 + 2 * Count]);
        }

        public void Parse(String[] items)
        {
            if (items[0] != "P")
                throw new Exception("LibPolygon public class parse error. Another object.");

            try
            {
                Count = System.Convert.ToInt32(items[1]);
                Part = System.Convert.ToInt32(items[2]);
                Dmg = System.Convert.ToInt32(items[3]);
                Pen = System.Convert.ToInt32(items[4]);

                Points = new KicadLibPoint[Count];
                for (int i = 0; i < Count; i++)
                {
                    Points[i] = new KicadLibPoint(System.Convert.ToInt32(items[5 + 2 * i + 0]),
                                                  System.Convert.ToInt32(items[5 + 2 * i + 1]));
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            Fill.Parse(items[5 + 2 * Count]);
        }
        public override String ToString()
        {
            StringBuilder outstr = new StringBuilder();
            outstr.AppendFormat(CultureInfo.InstalledUICulture, "P {0} {1} {2} {3} ",
                Count, Part, Dmg, Pen);

            for (int i = 0; i < Count; i++ )
            {
                outstr.AppendFormat(CultureInfo.InstalledUICulture, "{0} {1} ", Points[i].X, Points[i].Y);
            }
            outstr.AppendFormat(CultureInfo.InstalledUICulture, "{0}", Fill);
            return outstr.ToString();
        }
    }
}
