using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Kicad.Lib
{
    public class KicadLibDef
    {
        public const int Items = 10;
        public String Name { get; set; }
        public String Reference { get; set; }
        public double TextOffset { get; set; }
        public KicadLibYesNo DrawPinNumber { get; set; }
        public KicadLibYesNo DrawPinName { get; set; }
        public int UnitsCount { get; set; }
        public KicadLibUnitLocked UnitLocked { get; set; }
        public KicadLibOptionFlag Options { get; set; }

        public KicadLibDef()
        {
            DrawPinNumber = new KicadLibYesNo(true);
            DrawPinName = new KicadLibYesNo(true);
            UnitLocked = new KicadLibUnitLocked(false);
            Options = new KicadLibOptionFlag(KicadLibOptionFlag.OptionFlag.Normal);
            UnitsCount = 1;
            Reference = "U";
            TextOffset = 0;
        }
        public void Parse(String line)
        {
            char[] charSeparators = new char[] { ' ' };
            String[] items = line.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);

            if (items[0] != "DEF")
                throw new Exception("KicadLibDef public class parse error. Another object.");

            Name = items[1];
            Reference = items[2];
            if (items[3] == "0")
            {
                TextOffset = System.Convert.ToDouble(items[4]);
                DrawPinNumber.Parse(items[5]);
                DrawPinName.Parse(items[6]);
                UnitsCount = System.Convert.ToInt32(items[7]);
                UnitLocked.Parse(items[8]);
                Options.Parse(items[9]);
            }
            else
                throw new Exception("KicadLibDef public class parse error. Missing signature 0.");
        }

        public void Parse(String[] items)
        {
            if (items[0] != "DEF")
                throw new Exception("KicadLibDef public class parse error. Another object.");

            Name = items[1];
            Reference = items[2];
            if (items[3] == "0")
            {
                TextOffset = System.Convert.ToDouble(items[4]);
                DrawPinNumber.Parse(items[5]);
                DrawPinName.Parse(items[6]);
                UnitsCount = System.Convert.ToInt32(items[7]);
                UnitLocked.Parse(items[8]);
                Options.Parse(items[9]);
            }
            else
                throw new Exception("KicadLibDef public class parse error. Missing signature 0.");
        }
        public override String ToString()
        {
            StringBuilder outstr = new StringBuilder();
            outstr.AppendFormat(CultureInfo.InstalledUICulture, "DEF {0} {1} 1 {2} {3} {4} {5} {6} {7}",
                Name, Reference,TextOffset,DrawPinNumber,DrawPinName,UnitsCount,UnitLocked,Options);

            return outstr.ToString();
        }
    }
}
