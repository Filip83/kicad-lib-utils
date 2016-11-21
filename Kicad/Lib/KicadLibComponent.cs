using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace Kicad.Lib
{
    public class KicadLibComponent
    {
        public KicadLibDef Definition {get;set;}
        public List<KicadLibFX> Parameters{get;set;}
        public List<String> FootPrints{get;set;}
        public KicadLibAlias Alias{get;set;}
        public List<Object> DrawObjects{get;set;}
        public KicadLibDocu Documentation { get; set; }
        public KicadLibComponent()
        {
            Definition = new KicadLibDef();
            Parameters = new List<KicadLibFX>();
            FootPrints = new List<string>();
            Alias = new KicadLibAlias();
            DrawObjects = new List<object>();
        }

        public override string ToString()
        {
            StringBuilder outstr = new StringBuilder();
            // Component name in comment
            outstr.AppendFormat(CultureInfo.InstalledUICulture,"#\n# {0}\n#\n", Definition.Name);
            // Compoenent definition
            outstr.AppendFormat(CultureInfo.InstalledUICulture, "{0}\n", Definition);
            // Component parameters
            foreach(KicadLibFX f in Parameters)
                outstr.AppendFormat(CultureInfo.InstalledUICulture, "{0}\n", f);
            // Component alias
            if(Alias.AliasArray != null)
                outstr.AppendFormat(CultureInfo.InstalledUICulture, "{0}\n", Alias);
            // Compoent footprint list
            outstr.AppendFormat(CultureInfo.InstalledUICulture, "$FPLIST\n");
            foreach (String str in FootPrints)
                outstr.AppendFormat(CultureInfo.InstalledUICulture, "{0}\n", str);
            outstr.AppendFormat(CultureInfo.InstalledUICulture, "$ENDFPLIST\n");

            // Draw items
            outstr.AppendFormat(CultureInfo.InstalledUICulture, "DRAW\n");
            foreach (Object f in DrawObjects)
                outstr.AppendFormat(CultureInfo.InstalledUICulture, "{0}\n", f);

            outstr.AppendFormat(CultureInfo.InstalledUICulture, "ENDDRAW\n");
            // component end
            outstr.AppendFormat(CultureInfo.InstalledUICulture, "ENDDEF\n");
            return outstr.ToString();
        }

        public bool Parse(StreamReader reader)
        {
            do
            {
                String line = reader.ReadLine();
                if (reader.EndOfStream == true && line == null)
                    return false;
                if (line.StartsWith("#"))
                    continue;
                char[] charSeparators = new char[] { ' ' };
                String[] items = line.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
                if (items[0][0] == 'F')
                {
                    KicadLibFX nF = new KicadLibFX();
                    nF.Parse(items);
                    Parameters.Add(nF);
                }
                else
                {
                    switch (items[0])
                    {
                        case "DEF":
                            Definition.Parse(items);
                            break;
                        case "ALIAS":
                            Alias.Parse(items);
                            break;
                        case "DRAW":
                            ParseDraw(reader);
                            break;
                        case "ENDDEF":
                            return true;
                        case "$FPLIST":
                            ParseFplist(reader);
                            break;
                        default:
                            throw new Exception("KicadLibComponent parse error. Unknown item.");
                            break;
                    }
                }
                
            } while (true);

        }

        private void ParseDraw(StreamReader reader)
        {
            do
            {
                String line = reader.ReadLine();

                if (line.StartsWith("#"))
                    continue;

                char[] charSeparator = new char[] { ' ' };
                String[] items = line.Split(charSeparator, System.StringSplitOptions.RemoveEmptyEntries);

                switch(items[0])
                {
                    case "ENDDRAW":
                        return;
                    case "C":
                        KicadLibCircle circle = new KicadLibCircle();
                        circle.Parse(items);
                        DrawObjects.Add(circle);
                        break;
                    case "A":
                        KicadLibArc arc = new KicadLibArc();
                        arc.Parse(items);
                        DrawObjects.Add(arc);
                        break;
                    case "P":
                        KicadLibPolygon polygon = new KicadLibPolygon();
                        polygon.Parse(items);
                        DrawObjects.Add(polygon);
                        break;
                    case "S":
                        KicadLibRectangle rect = new KicadLibRectangle();
                        rect.Parse(items);
                        DrawObjects.Add(rect);
                        break;
                    case "T":
                        KicadLibText text = new KicadLibText();
                        text.Parse(items);
                        DrawObjects.Add(text);
                        break;
                    case "B":
                        KicadLibBezier bezier = new KicadLibBezier();
                        bezier.Parse(items);
                        DrawObjects.Add(bezier);
                        break;
                    case "X":
                        KicadLibPin pin = new KicadLibPin();
                        pin.Parse(items);
                        DrawObjects.Add(pin);
                        break;
                    default:
                        throw new Exception("KicadLibComponent parse error. Unknown draw object.");
                }

            } while (true);
        }

        private void ParseFplist(StreamReader reader)
        {
            do
            {
                String line = reader.ReadLine();

                if (line.StartsWith("#"))
                    continue;

                //String[] items = line.Split(' ');

                if (line.Trim() == "$ENDFPLIST")
                    break;

                FootPrints.Add(line);

            } while (true);
        }
    }
}
