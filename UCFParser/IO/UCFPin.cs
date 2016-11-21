using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCFParser.IO
{
    public class UCFPin
    {
        public String Name { get; set; }
        public String Number { get; set; }

        private String NetToPinName(String pinName)
        {
            pinName = pinName.Trim('"');
            if (pinName.Contains('<'))
            {
                pinName = pinName.Replace("<", " ");
                pinName = pinName.Remove('>');
                String[] split = pinName.Split(' ');
                return split[0] + split[1];
            }
            return pinName;
        }


        public void Parse(String line)
        {
            line = line.ToLower();
            char[] toSplit = { ' ', '=', '|' };
            String[] items = line.Split(toSplit);
            if(items[0] == "net")
            {
                Name = NetToPinName(items[1]);
                if(items[2] == "loc")
                {
                    if (items[3] == "=")
                        Number = items[4];
                    else
                        Number = items[3];
                }

            }
        }

    }
}
