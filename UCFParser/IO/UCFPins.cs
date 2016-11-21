using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UCFParser.IO
{
   public class UCFPins
    {
       public List<UCFPin> Pins { get; set; }
       public UCFPins()
       {
           Pins = new List<UCFPin>();
       }

       private String GetLine(StreamReader reader)
       {
           String output = "";
           int toRead = 0;
           do
           {
               toRead = reader.Read();
               output += (char)toRead;
           } while (toRead != ';' && toRead > 0);

           output = output.Replace('\n', ' ');
           return output.Replace("\r", "");
       }

       public void ReadFile(String fileName)
       {
           StreamReader ucfFile = new StreamReader(fileName);
           Pins.Clear();
           do
           {
               UCFPin component = new UCFPin();
               String line = GetLine(ucfFile);
               if (line.StartsWith("#"))
                   continue;
               if (!String.IsNullOrWhiteSpace(line))
               {
                   component.Parse(line);
                   Pins.Add(component);
               }
               else
                   break;
           } while (!ucfFile.EndOfStream);
           ucfFile.Close();
       }
    }
}
