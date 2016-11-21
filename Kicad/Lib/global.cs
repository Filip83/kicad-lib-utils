using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Kicad.Lib
{
    public static class KicadUnitConvert
    {
        public static int From_mm(double mm)
        {
            return (int)System.Math.Round(mm * 39.37007874);
        }

        public static int From_degs(double mm)
        {
            return (int)System.Math.Round(mm * 0.1);
        }
    }

    public class KicadLibItalic
    {
        public bool IsItalic { get; set; }
        public KicadLibItalic(bool italic)
        {
            IsItalic = italic;
        }
        public KicadLibItalic(String italic)
        {
            Parse(italic);
        }

        public void Parse(String italic)
        {
            if (italic == "Italic")
                IsItalic = true;
            else
                IsItalic = false;
        }

        public override string ToString()
        {
            if (IsItalic)
                return "Italic";
            return "Normal";
        }
    }

    public class KicadLibHTextJustify
    {
        public enum HTextJustify
        {
            Left = 0, Right, Centre
        };

        public HTextJustify Value {get; set;}
        public void Parse(String txt)
        {
            switch(txt)
            {
                case "L":
                    Value = HTextJustify.Left;
                    break;
                case "R":
                    Value = HTextJustify.Right;
                    break;
                case "C":
                    Value = HTextJustify.Centre;
                    break;
                default:
                    throw new Exception("KicadHTextJustify parse error.");
                    break;
            }
        }
        public KicadLibHTextJustify(HTextJustify justyfy)
        {
            Value = justyfy;
        }
        public KicadLibHTextJustify(String txt)
        {
            Parse(txt);
        }

        public override string ToString()
        {
            switch(Value)
            {
                case HTextJustify.Left:
                    return "L";
                    break;
                case HTextJustify.Right:
                    return "R";
                    break;
                default:
                    return "C";
                    break;
            }
        }
    }

    public class KicadLibVTextJustify
    {
        public enum VTextJustify
        {
            Top, Bottom, Centre
        };

        public VTextJustify Value { get; set; }
        public void Parse(String txt)
        {
            switch (txt)
            {
                case "T":
                    Value = VTextJustify.Top;
                    break;
                case "B":
                    Value = VTextJustify.Bottom;
                    break;
                case "C":
                    Value = VTextJustify.Centre;
                    break;
                case "TNN":
                    Value = VTextJustify.Top;
                    break;
				case "BIN":
				case "BNB":
				case "BIB":
                case "BNN":
                    Value = VTextJustify.Bottom;
                    break;
				case "CIN":
				case "CNB":
				case "CIB":
                case "CNN":
                    Value = VTextJustify.Centre;
                    break;
                default:
                    throw new Exception("KicadHTextJustify parse error.");
                    break;
            }
        }
        public KicadLibVTextJustify(VTextJustify justyfy)
        {
            Value = justyfy;
        }
        public KicadLibVTextJustify(String txt)
        {
            Parse(txt);
        }

        public override string ToString()
        {
            switch (Value)
            {
                case VTextJustify.Top:
                    return "TNN";
                    break;
                case VTextJustify.Bottom:
                    return "BNN";
                    break;
                default:
                    return "CNN";
                    break;
            }
        }
    }
    
    public class KicadLibTextOrientation
    {
        public enum TextOrient
        {
            Vertical, Horizontal, Center
        };

        public TextOrient Value { get; set; }
        public void Parse(String txt)
        {
            switch(txt)
            {
                case "V":
                    Value = TextOrient.Vertical;
                    break;
                case "H":
                    Value = TextOrient.Horizontal;
                    break;
                case "I":
                    Value = TextOrient.Center;
                    break;
                default:
                    throw new Exception("kicadTextOrientation parse error.");
                    break;
            }
        }
        public KicadLibTextOrientation(TextOrient value)
        {
            Value = value;
        }
        public KicadLibTextOrientation(String txt)
        {
            Parse(txt);
        }
        public override string ToString()
        {
            switch(Value)
            {
                case TextOrient.Horizontal:
                    return "H";
                    break;
                case TextOrient.Center:
                    return "I";
                    break;
                default:
                    return "V";
                    break;
            }
        }
    }
    

    public class KicadLibFill
    {
        public enum Fill
        {
            FillInBackgColor, FillInPenColor, NotFill
        };

        public Fill Value { get; set; }
        public KicadLibFill(Fill fill)
        {
            Value = fill;
        }
        public void Parse(String txt)
        {
            switch(txt)
            {
                case "f":
                    Value = Fill.FillInBackgColor;
                    break;
                case "F":
                    Value = Fill.FillInPenColor;
                    break;
                case "N":
                    Value = Fill.NotFill;
                    break;
                default:
                    throw new Exception("KicadFill parse error.");
            }
        }
        public KicadLibFill(String txt)
        {
            Parse(txt);
        }
        public override string ToString()
        {
            switch(Value)
            {
                case Fill.FillInBackgColor:
                    return "f";
                    break;
                case Fill.FillInPenColor:
                    return "F";
                    break;
                default:
                    return "N";
                    break;
            }
        }
    }

    public class KicadLibPinOrientation
    {
        private static String[] _strValues = { "Up", "Down", "Left", "Right" };
        public static String[] StringValues { get { return _strValues; } }
        public enum PinOrentation
        {
            Up = 0, Down, Left, Right
        };
        public PinOrentation Value { get; set; }

        public KicadLibPinOrientation(PinOrentation fill)
        {
            Value = fill;
        }
        public void Parse(String txt)
        {
            switch(txt)
            {
                case "U":
                case "Up":
                    Value = PinOrentation.Up;
                    break;
                case "Down":
                case "D":
                    Value = PinOrentation.Down;
                    break;
                case "Left":
                case "L":
                    Value = PinOrentation.Left;
                    break;
                case "Right":
                case "R":
                    Value = PinOrentation.Right;
                    break;
                default:
                    throw new Exception("KicadPinOrientation parse error.");
            }
        }
        public KicadLibPinOrientation(String txt)
        {
            Parse(txt);
        }
        public override string ToString()
        {
            switch(Value)
            {
                case PinOrentation.Up:
                    return "U";
                    break;
                case PinOrentation.Down:
                    return "D";
                    break;
                case PinOrentation.Left:
                    return "L";
                    break;
                default:
                    return "R";
                    break;
            }
        }
    }



    public class KicadLibPinType
    {
        private static String[] _strPinType = {"Input", "Output", "Bidirectional",
                                      "Tristate", "Passsive", "OpenCollector",
            "OpenEmitter", "NonConnected", "Unspecified", "PowerInput", "PowerOutput" };
        public static String[] StringValues { get { return _strPinType; } }
        public enum PinType
        {
            Input = 0, Output, Bidirectional, Tristate, Passsive, OpenCollector,
            OpenEmitter, NonConnected, Unspecified, PowerInput, PowerOutput
        };
        public PinType Value { get; set; }

        public KicadLibPinType(PinType fill)
        {
            Value = fill;
        }
        public void Parse(String txt)
        {
            switch (txt)
            {
                case "Input":
                case "I":
                    Value = PinType.Input;
                    break;
                case "Output":
                case "O":
                    Value = PinType.Output;
                    break;
                case "Bidirectional":
                case "B":
                    Value = PinType.Bidirectional;
                    break;
                case "Tristate":
                case "T":
                    Value = PinType.Tristate;
                    break;
                case "Passsive":
                case "P":
                    Value = PinType.Passsive;
                    break;
                case "OpenCollector":
                case "C":
                    Value = PinType.OpenCollector;
                    break;
                case "OpenEmitter":
                case "E":
                    Value = PinType.OpenEmitter;
                    break;
                case "NonConnected":
                case "N":
                    Value = PinType.NonConnected;
                    break;
                case "Unspecified":
                case "U":
                    Value = PinType.Unspecified;
                    break;
                case "PowerInput":
                case "W":
                    Value = PinType.PowerInput;
                    break;
                case "PowerOutput":
                case "w":
                    Value = PinType.PowerOutput;
                    break;
                default:
                    throw new Exception("KicadPinType parse error.");
            }
        }
        public KicadLibPinType(String txt)
        {
            Parse(txt);
        }
        public override string ToString()
        {
            switch (Value)
            {
                case PinType.Input:
                    return "I";
                    break;
                case PinType.Output:
                    return "O";
                    break;
                case PinType.Bidirectional:
                    return "B";
                    break;
                case PinType.Tristate:
                    return "T";
                    break;
                case PinType.Passsive:
                    return "P";
                    break;
                case PinType.OpenCollector:
                    return "C";
                    break;
                case PinType.OpenEmitter:
                    return "E";
                    break;
                case PinType.NonConnected:
                    return "N";
                    break;
                case PinType.Unspecified:
                    return "U";
                    break;
                case PinType.PowerInput:
                    return "W";
                    break;
                default:
                case PinType.PowerOutput:
                    return "w";
                    break;
            }
        }
    }

    public class KicadLibPinShape
    {
        private static String[] _strValue = {"Line", "Inverted", "Clock", "InvertedClock",
                                             "InputLow", "ClockLow", "OutputLow", "FallingEdge", "NonLogic"};
        public static String[] StringValues { get { return _strValue; } }
        public enum PinShape
        {
            Line = 0, Inverted, Clock, InvertedClock,
            InputLow, ClockLow, OutputLow, FallingEdge, NonLogic
        }
        public PinShape Value { get; set; }
        public KicadLibPinShape(PinShape fill)
        {
            Value = fill;
        }
        public void Parse(String txt)
        {
            switch(txt)
            {
                case "~":
                    break;
                case "NonLogic":
                case "N":
                    Value = PinShape.NonLogic;
                    break;
                case "Inverted":
                case "I":
                    Value = PinShape.Inverted;
                    break;
                case "Clock":
                case "C":
                    Value = PinShape.Clock;
                    break;
                case "InvertedClock":
                case "IC":
                    Value = PinShape.InvertedClock;
                    break;
                case "InputLow":
                case "L":
                    Value = PinShape.InputLow;
                    break;
                case "ClockLow":
                case "CL":
                    Value = PinShape.ClockLow;
                    break;
                case "OutputLow":
                case "V":
                    Value = PinShape.OutputLow;
                    break;
                case "FallingEdge":
                case "F":
                    Value = PinShape.FallingEdge;
                    break;
                case "Line":
                case "":
                    Value = PinShape.Line;
                    break;
                default:
                    throw new Exception("KicadPinShape parse error.");
            }
        }
        public KicadLibPinShape(String txt)
        {
            Parse(txt);
        }
        public override string ToString()
        {
            switch(Value)
            {
                case PinShape.NonLogic:
                    return "N";
                    break;
                case PinShape.Inverted:
                    return "I";
                    break;
                case PinShape.Clock:
                    return "C";
                    break;
                case PinShape.InvertedClock:
                    return "IC";
                    break;
                case PinShape.InputLow:
                    return "L";
                    break;
                case PinShape.ClockLow:
                    return "CL";
                    break;
                case PinShape.OutputLow:
                    return "V";
                    break;
                case PinShape.FallingEdge:
                    return "F";
                    break;
                default:
                case PinShape.Line:
                    return "";
                    break;
            }
        }
    }
    
    public class KicadLibVisible
    {
        public bool IsVisible {get; set;}
        public KicadLibVisible(bool visible)
        {
            IsVisible = visible;
        }

        public void Parse(String txt)
        {
            if (txt == "V")
                IsVisible = true;
            else if (txt == "I")
                IsVisible = false;
            else
                throw new Exception("KicadLibVisible parse error.");
        }

        public override string ToString()
        {
            if (IsVisible)
                return "V";
            return "I";
        }
    }

    public class KicadLibYesNo
    {
        public bool Value { get; set; }
        public KicadLibYesNo(bool visible)
        {
            Value = visible;
        }

        public KicadLibYesNo(String txt)
        {
            Parse(txt);
        }
        public void Parse(String txt)
        {
            if (txt == "Y")
                Value = true;
            else if (txt == "N")
                Value = false;
            else
                throw new Exception("KicadLibYesNo parse error.");
        }
        public override string ToString()
        {
            if (Value)
                return "Y";
            return "N";
        }
    }

    public class KicadLibUnitLocked
    {
        public bool Value { get; set; }
        public KicadLibUnitLocked(bool visible)
        {
            Value = visible;
        }

        public KicadLibUnitLocked(String txt)
        {
            Parse(txt);
        }
        public void Parse(String txt)
        {
            if (txt == "L")
                Value = true;
            else if (txt == "F")
                Value = false;
            else
                throw new Exception("KicadLibUnitLocked parse error.");
        }
        public override string ToString()
        {
            if (Value)
                return "L";
            return "F";
        }
    }

    public class KicadLibOptionFlag
    {
        public enum OptionFlag
        {
            Normal, Power
        };
        public OptionFlag Value { get; set; }
        public KicadLibOptionFlag(OptionFlag val)
        {
            Value = val;
        }

        public KicadLibOptionFlag(String txt)
        {
            Parse(txt);
        }
        public void Parse(String txt)
        {
            if (txt == "N")
                Value = OptionFlag.Normal;
            else if (txt == "F")
                Value = OptionFlag.Power;
            else
                throw new Exception("KicadLibOptionFlag parse error.");
        }
        public override string ToString()
        {
            if (Value == OptionFlag.Normal)
                return "N";
            return "F";
        }
    }
    public class KicadLibPoint
    {
        public KicadLibPoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public override string ToString()
        {
            return X.ToString(CultureInfo.InstalledUICulture) + " " + Y.ToString(CultureInfo.InstalledUICulture);
        }
    }
}
