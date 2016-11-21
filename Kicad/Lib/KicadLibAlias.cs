using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kicad.Lib
{
    public class KicadLibAlias
    {
        public String[] AliasArray { get; set; }

        public void Parse(String line)
        {
            char[] charSeparators = new char[] { ' ' };
            String[] items = line.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);

            if (items[0] != "ALIAS")
                throw new Exception("LibCirc public class parse error. Another object.");

            AliasArray = new String[items.Length];
            for (int i = 1; i < items.Length; i++)
                AliasArray[i - 1] = items[i];

        }

        public void Parse(String[] items)
        {
            if (items[0] != "ALIAS")
                throw new Exception("LibCirc public class parse error. Another object.");

            AliasArray = new String[items.Length];
            for (int i = 1; i < items.Length; i++)
                AliasArray[i - 1] = items[i];

        }

        public override String ToString()
        {
            if (AliasArray != null)
            {
                String outstr = "ALIAS ";
                foreach (String str in AliasArray)
                {
                    outstr += " " + str;
                }
                return outstr;
            }
            return null;
        }
    }
}
