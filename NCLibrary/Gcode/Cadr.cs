using System;
using System.Globalization;
using System.Text;


namespace NcLibrary
{
    public class Cadr
    {
        public string type { get; set; }
        public int S { get; set; }
        public int F { get; set; }
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public bool xEnable { get; set; }
        public bool yEnable { get; set; }
        public string CadrToString(Cadr cadr)
        {
            IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };
            StringBuilder cadrString = new StringBuilder();
            switch (cadr.type)
            {
                case "M5":
                    cadrString.Append("M5");
                    break;
                case "M3":
                    cadrString.Append("M3");
                    cadrString.Append("S");
                    cadrString.Append(cadr.S.ToString());
                    break;
                case "M4":
                    cadrString.Append("M4");
                    cadrString.Append("S");
                    cadrString.Append(cadr.S.ToString());
                    break;
                case "G0":
                    cadrString.Append("G0");
                    if (cadr.xEnable != false)
                    {
                        cadrString.Append("X");
                        cadrString.Append(cadr.X.ToString(formatter));
                    }
                    if (cadr.yEnable != false)
                    {
                        cadrString.Append("Y");
                        cadrString.Append(cadr.Y.ToString(formatter));
                    }
                    break;
                case "G1":
                    cadrString.Append("G1");
                    if (cadr.xEnable != false)
                    {
                        cadrString.Append("X");
                        cadrString.Append(cadr.X.ToString(formatter));
                    }
                    if (cadr.yEnable != false)
                    {
                        cadrString.Append("Y");
                        cadrString.Append(cadr.Y.ToString(formatter));
                    }
                    cadrString.Append("F");
                    cadrString.Append(cadr.F.ToString());
                    break;
                case "XY":
                    cadrString.Append("X");
                    cadrString.Append(cadr.X.ToString(formatter));
                    cadrString.Append("Y");
                    cadrString.Append(cadr.Y.ToString(formatter));
                    break;
                case "XX":
                    cadrString.Append("X");
                    cadrString.Append(cadr.X.ToString(formatter));
                    break;
                case "YY":
                    cadrString.Append("Y");
                    cadrString.Append(cadr.Y.ToString(formatter));
                    break;
                default:
                    cadrString.Append("NO");
                    break;
            }
            return cadrString.ToString();
        }
        public Cadr StringToCadr(string cadrString)
        {
            Cadr cadr = new Cadr();

            if (cadrString.ToUpper().Contains("M5"))
            {
                return parseM5();
            }
            if (cadrString.ToUpper().Contains("M4"))
            {
                return parseM4(cadrString);
            }
            if (cadrString.ToUpper().Contains("M3"))
            {
                return parseM3(cadrString);
            }
            if (cadrString.ToUpper().Contains("G0"))
            {
                return parseG0(cadrString);
            }
            if (cadrString.ToUpper().Contains("G1"))
            {
                return parseG1(cadrString);
            }
            if (cadrString.ToUpper().Contains("X")&& cadrString.ToUpper().Contains("Y"))
            {
                return parseXY(cadrString);
            }
            if (cadrString.ToUpper().Contains("X"))
            {
                return parseX(cadrString);
            }
            if (cadrString.ToUpper().Contains("Y"))
            {
                return parseY(cadrString);
            }

            return parseNO();
        }

        private Cadr parseNO()
        {
            Cadr cadr = new Cadr();
            cadr.type = "NO";
            return cadr;
        }

        private Cadr parseM5()
        {
            Cadr cadr = new Cadr();
            cadr.type = "M5";
            return cadr;
        }

        private Cadr parseM4(string cadrString)
        {
            Cadr cadr = new Cadr();
            cadr.type = "M4";
            int powerPosition = cadrString.ToUpper().IndexOf("S");
            string power = cadr.ParseNumberInt(cadrString, "S");
            cadr.S = Convert.ToInt32(power);
            return cadr;
        }

        private Cadr parseM3(string cadrString)
        {
            Cadr cadr = new Cadr();
            cadr.type = "M3";
            int powerPosition = cadrString.ToUpper().IndexOf("S");
            string power = cadr.ParseNumberInt(cadrString, "S");
            cadr.S = Convert.ToInt32(power);
            return cadr;
        }

        private Cadr parseG0(string cadrString)
        {
            IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };
            Cadr cadr = new Cadr();
            int xPos, yPos;

            cadr.type = "G0";
            xPos = cadrString.ToUpper().IndexOf("X");
            yPos = cadrString.ToUpper().IndexOf("Y");
            if (xPos==-1 && yPos==-1) return cadr;
            if (xPos!=-1 && yPos != -1)
            {
                cadr.X = decimal.Parse(cadr.ParseNumberDecimal(cadrString,"X"), formatter);
                cadr.Y = decimal.Parse(cadr.ParseNumberDecimal(cadrString, "Y"), formatter);
                cadr.xEnable = true;
                cadr.yEnable = true;
                return cadr;
            }

            if (xPos!=-1)
            {
                cadr.X = decimal.Parse(cadr.ParseNumberDecimal(cadrString, "X"), formatter);
                cadr.xEnable = true;
                return cadr;
            }

            if (yPos != -1)
            {
                cadr.Y = decimal.Parse(cadr.ParseNumberDecimal(cadrString, "Y"), formatter);
                cadr.yEnable = true;
                return cadr;
            }
            return null;
        }

        private Cadr parseG1(string cadrString)
        {
            IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };
            Cadr cadr = new Cadr();
            int xPos, yPos;

            cadr.type = "G1";

            int speedPosition = cadrString.ToUpper().IndexOf("F");
            
            string speed = cadr.ParseNumberInt(cadrString, "F");
            cadr.F = Convert.ToInt32(speed);

            cadrString = cadrString.Substring(0, (cadrString.Length-((cadrString.Length-speedPosition))));

            xPos = cadrString.ToUpper().IndexOf("X");
            yPos = cadrString.ToUpper().IndexOf("Y");
            if (xPos == -1 && yPos == -1) return cadr;
            if (xPos != -1 && yPos != -1)
            {
                cadr.X = decimal.Parse(cadr.ParseNumberDecimal(cadrString, "X"), formatter);
                cadr.Y = decimal.Parse(cadr.ParseNumberDecimal(cadrString, "Y"), formatter);
                cadr.xEnable = true;
                cadr.yEnable = true;
                return cadr;
            }

            if (xPos != -1)
            {
                cadr.X = decimal.Parse(cadr.ParseNumberDecimal(cadrString, "X"), formatter);
                cadr.xEnable = true;
                return cadr;
            }

            if (yPos != -1)
            {
                cadr.Y = decimal.Parse(cadr.ParseNumberDecimal(cadrString, "Y"), formatter);
                cadr.yEnable = true;
                return cadr;
            }
            return null;
        }

        private Cadr parseXY(string cadrString)
        {
            IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };
            Cadr cadr = new Cadr();
            int xPos, yPos;

            cadr.type = "XY";
            xPos = cadrString.ToUpper().IndexOf("X");
            yPos = cadrString.ToUpper().IndexOf("Y");
            if (xPos == -1 && yPos == -1) return cadr;
            if (xPos != -1 && yPos != -1)
            {
                cadr.X = decimal.Parse(cadr.ParseNumberDecimal(cadrString, "X"), formatter);
                cadr.Y = decimal.Parse(cadr.ParseNumberDecimal(cadrString, "Y"), formatter);
                cadr.xEnable = true;
                cadr.yEnable = true;
                return cadr;
            }
            return null;
        }

        private Cadr parseX(string cadrString)
        {
            IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };
            Cadr cadr = new Cadr();
            int xPos;

            cadr.type = "XX";

            xPos = cadrString.ToUpper().IndexOf("X");

            if (xPos != -1)
            {
                cadr.X = decimal.Parse(cadr.ParseNumberDecimal(cadrString, "X"), formatter);
                cadr.xEnable = true;
                return cadr;
            }
            return null;
        }

        private Cadr parseY(string cadrString)
        {
            IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };
            Cadr cadr = new Cadr();
            int yPos;

            cadr.type = "YY";
        
            yPos = cadrString.ToUpper().IndexOf("Y");

            if (yPos != -1)
            {
                cadr.Y = decimal.Parse(cadr.ParseNumberDecimal(cadrString, "Y"), formatter);
                cadr.yEnable = true;
                return cadr;
            }
            return null;
        }

        private string ParseNumberDecimal(string cadr, string dimension)
        {
            cadr = cadr.Replace(" ", "");
            int pos = cadr.IndexOf(dimension);
            string number = "";

            for (int i = pos + 1; i < cadr.Length; i++)
            {
                if (Char.IsDigit(cadr[i]) || cadr[i] == '.')
                {
                    number += cadr[i];
                }
                else
                {
                    break;
                }
            }
            return number;
        }

        private string ParseNumberInt(string cadr, string dimension)
        {
            cadr = cadr.Replace(" ", "");
            int pos = cadr.IndexOf(dimension);
            string number = "";

            for (int i = pos + 1; i < cadr.Length; i++)
            {
                if (Char.IsDigit(cadr[i]))
                {
                    number += cadr[i];
                }
                else
                {
                    break;
                }
            }
            return number;
        }

    }
}
