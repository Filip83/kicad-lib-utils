using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kicad.Lib
{
    public class KicadLibDocu
    {
        private String _CmpName { get; set; }
        private String _Destription { get; set; }
        private String _Keyword { get; set; }
        private String _DataSheet { get; set; }

        public String CmpName { get { return _CmpName; } set { _CmpName = value.Trim(); } }
        public String Destription { get { return _Destription; } set { _Destription = value.Trim(); } }
        public String Keyword { get { return _Keyword; } set { _Keyword = value.Trim(); } }
        public String DataSheet { get { return _DataSheet; } set { _DataSheet = value.Trim(); } }

        public KicadLibDocu()
        {
            CmpName = "";
            Destription = "";
            Keyword = "";
            DataSheet = "";
        }

        public bool Parse(StreamReader reader)
        {
            do
            {
                String line = reader.ReadLine();
                if (reader.EndOfStream == true)
                    return false;
                if (line.StartsWith("#"))
                    continue;
                char[] charSeparators = new char[] { ' ' };
                String[] items = line.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
                switch (items[0])
                {
                    case "$CMP":
                        CmpName = items[1];
                        break;
                    case "D":
                        Destription = line.TrimStart('D');
                        break;
                    case "K":
                        Keyword = line.TrimStart('K');
                        break;
                    case "F":
                        DataSheet = line.TrimStart('F');
                        break;
                    case "$ENDCMP":
                        return true;
                        break;
                    default:
                        throw new Exception("KicadLibDocu parse error. Unexpected value of items.");
                        break;
                }
            } while (true);
        }

        public override String ToString()
        {
            StringBuilder outstr = new StringBuilder();
            outstr.AppendFormat("$CMP {0}\n", CmpName);
            outstr.AppendFormat("D {0}\n", Destription);
            outstr.AppendFormat("K {0}\n", Keyword);
            outstr.AppendFormat("F {0}\n", DataSheet);
            outstr.AppendFormat("$ENDCMP\n# \n");
            return outstr.ToString();
        }
    }
}
