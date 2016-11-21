using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Kicad.Lib
{
    public class KicadLibPin
    {
        private String[] strFill = { "f", "F", "N" };
        public const int Items = 12;
        public String Name { get; set; }
        public String    Pin { get; set; } // Pin can be nuber or text
        public KicadLibPoint Position { get; set; }
        public double Length { get; set; }
        public KicadLibPinOrientation Orientation { get; set; }
        public double Sizenum { get; set; }
        public double Sizename { get; set; }
        public int Part { get; set; }
        public int Dmg { get; set; }
        public KicadLibPinType Type { get; set; }
        public KicadLibPinShape Shape { get; set; }

        public KicadLibPin()
        {
            Position = new KicadLibPoint(0, 0);
            Orientation = new KicadLibPinOrientation(0);
            Type = new KicadLibPinType(0);
            Shape = new KicadLibPinShape(0);
        }
        public void Parse(String line)
        {
            char[] charSeparators = new char[] { ' ' };
            String[] items = line.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
            if (items.Length == Items || items.Length == (Items + 1))
            {
                if (items[0] != "X")
                    throw new Exception("LibPin public class parse error. Another object.");

                Name = items[1].Trim('"');
                Pin = items[2];

                Position.X = System.Convert.ToInt32(items[3]);
                Position.Y = System.Convert.ToInt32(items[4]);
                Length = System.Convert.ToInt32(items[5]);
                Orientation.Parse(items[6]);
                Sizenum = System.Convert.ToInt32(items[7]);
                Sizename = System.Convert.ToInt32(items[8]);
                Part = System.Convert.ToInt32(items[9]);
                Dmg = System.Convert.ToInt32(items[10]);
                Type.Parse(items[11]);
                if (items.Length == (Items + 1))
                    Shape.Parse(items[12]);
                else
                    Shape.Value = KicadLibPinShape.PinShape.Line;
            }
            else
                throw new Exception("LibPolygon public class parse error. Unexpected number of items.");
        }

        public void Parse(String[] items)
        {
            if (items.Length == Items || items.Length == (Items + 1))
            {
                if (items[0] != "X")
                    throw new Exception("LibPin public class parse error. Another object.");

                Name = items[1].Trim('"');
                Pin = items[2];

                Position.X = System.Convert.ToInt32(items[3]);
                Position.Y = System.Convert.ToInt32(items[4]);
                Length = System.Convert.ToInt32(items[5]);
                Orientation.Parse(items[6]);
                Sizenum = System.Convert.ToInt32(items[7]);
                Sizename = System.Convert.ToInt32(items[8]);
                Part = System.Convert.ToInt32(items[9]);
                Dmg = System.Convert.ToInt32(items[10]);
                Type.Parse(items[11]);
                if (items.Length == (Items + 1))
                    Shape.Parse(items[12]);
                else
                    Shape.Value = KicadLibPinShape.PinShape.Line;
            }
            else
                throw new Exception("LibPolygon public class parse error. Unexpected number of items.");
        }
        public override String ToString()
        {
            StringBuilder outstr = new StringBuilder();
            if (Shape.Value == KicadLibPinShape.PinShape.Line)
            {
                outstr.AppendFormat(CultureInfo.InstalledUICulture, "X {0} {1} {2} {3} {4} {5} {6} {7} {8} {9}",
                    Name, Pin, Position, Length, Orientation, Sizenum, Sizename,Part,Dmg,Type);
            }
            else
            {
                outstr.AppendFormat(CultureInfo.InstalledUICulture, "X {0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10}",
                    Name, Pin, Position, Length, Orientation, Sizenum, Sizename, Part, Dmg, Type, Shape);
            }

            return outstr.ToString();
        }
    }
}
