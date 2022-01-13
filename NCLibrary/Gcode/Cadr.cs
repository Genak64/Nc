using System;
using System.Globalization;
using System.Text;


namespace NcLibrary
{
    /// <summary>
    /// Represents the data of a single frame of the g-code program and the means to convert it into data or string
    /// </summary>
    public class Cadr
    {
        #region data frame
        /// <summary>
        /// Type of frame, possible options - M5, M3, M4, G0, G1, XY, XX, YY, NO  
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// Laser power 
        /// </summary>
        public int S { get; set; }

        /// <summary>
        /// Feed rate
        /// </summary>
        public int F { get; set; }

        /// <summary>
        /// X coordinate
        /// </summary>
        public decimal X { get; set; }

        /// <summary>
        /// Y coordinate
        /// </summary>
        public decimal Y { get; set; }

        /// <summary>
        /// The presence of the X coordinate value in the frame 
        /// </summary>
        public bool xEnable { get; set; }

        /// <summary>
        /// The presence of the Y coordinate value in the frame 
        /// </summary>
        public bool yEnable { get; set; }
        #endregion

        /// <summary>
        /// Converting a data frame to a string g-code frame representation. 
        /// </summary>
        /// <param name="cadr">data frame(required)</param>
        /// <returns>g-code frame</returns>
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

        /// <summary>
        /// Converting g-code frame string representation to program data frame.
        /// </summary>
        /// <param name="cadrString">g-code frame (required)</param>
        /// <returns>data frame</returns>
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

        #region parsers
        /// <summary>
        /// Parsing the string representation of a frame of type NO
        /// </summary>
        /// <returns>data frame</returns>
        private Cadr parseNO()
        {
            Cadr cadr = new Cadr();
            cadr.type = "NO";
            return cadr;
        }

        /// <summary>
        /// Parsing the string representation of a frame of type M5
        /// </summary>
        /// <returns>data frame</returns>
        private Cadr parseM5()
        {
            Cadr cadr = new Cadr();
            cadr.type = "M5";
            return cadr;
        }

        /// <summary>
        /// Parsing the string representation of a frame of type M4
        /// </summary>
        /// <returns>data frame</returns>
        private Cadr parseM4(string cadrString)
        {
            Cadr cadr = new Cadr();
            cadr.type = "M4";
            int powerPosition = cadrString.ToUpper().IndexOf("S");
            string power = cadr.ParseNumberInt(cadrString, "S");
            cadr.S = Convert.ToInt32(power);
            return cadr;
        }

        /// <summary>
        /// Parsing the string representation of a frame of type M3
        /// </summary>
        /// <returns>data frame</returns>
        private Cadr parseM3(string cadrString)
        {
            Cadr cadr = new Cadr();
            cadr.type = "M3";
            int powerPosition = cadrString.ToUpper().IndexOf("S");
            string power = cadr.ParseNumberInt(cadrString, "S");
            cadr.S = Convert.ToInt32(power);
            return cadr;
        }

        /// <summary>
        /// Parsing the string representation of a frame of type G0
        /// </summary>
        /// <returns>data frame</returns>
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

        /// <summary>
        /// Parsing the string representation of a frame of type G1
        /// </summary>
        /// <returns>data frame</returns>
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

        /// <summary>
        /// Parsing the string representation of a frame of type XY
        /// </summary>
        /// <returns>data frame</returns>
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

        /// <summary>
        /// Parsing the string representation of a frame of type XX
        /// </summary>
        /// <returns>data frame</returns>
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

        /// <summary>
        /// Parsing the string representation of a frame of type YY
        /// </summary>
        /// <returns>data frame</returns>
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

        /// <summary>
        /// Parsing the string representation of the X or Y coordinates represented by a decimal number in the frame
        /// </summary>
        /// <param name="cadr">data frame(required)</param>
        /// <param name="dimension">type coordinates(required)</param>
        /// <returns>valid numder</returns>
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

        /// <summary>
        /// Parsing the string representation of the power S or speed F represented by a number of integer type in the frame
        /// </summary>
        /// <param name="cadr">data frame(required)</param>
        /// <param name="dimension">type power or speed(required)</param>
        /// <returns>valid numder</returns>
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
        #endregion

    }
}
