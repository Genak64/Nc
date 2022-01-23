using System.Collections.Generic;
using System.Linq;


namespace NcLibrary
{
    public class Gcode
    {
        /// <summary>
        /// Program representation in g-code in the instance as data
        /// </summary>
        private List<Cadr> cadres { get; set; }

        public Gcode()
        {
            cadres = new List<Cadr>();
        }

        /// <summary>
        /// Converts the text representation of a program to g-code and stores it as data in the instance
        /// </summary>
        /// <param name="listStringCadres">text representation of a program to g-code (required)</param>
        public void SetCadres(List<string> listStringCadres)
        {
            cadres.Clear();
            foreach (string item in listStringCadres)
            {
                Cadr cadr = new Cadr();

                cadr = cadr.StringToCadr(item);

                if (cadr != null)
                {
                    cadres.Add(cadr);
                }
                else continue;
            }
        }
        /// <summary>
        /// Converts the text representation of the program to g-code and adds to the instance as data
        /// </summary>
        /// <param name="listStringCadres">text representation of a program to g-code (required)</param>
        public void AddCadres(List<string> listStringCadres)
        {
            foreach (string item in listStringCadres)
            {
                Cadr cadr = new Cadr();

                cadr = cadr.StringToCadr(item);

                if (cadr != null)
                {
                    cadres.Add(cadr);
                }
                else continue;
            }
        }

        /// <summary>
        /// Converts the program in the data instance into a text representation of the program in g-code and returns the text representation
        /// </summary>
        /// <returns>Text representation of the program in g-code</returns>
        public List<string> GetCadres()
        {
            List<string> list = new List<string>();
            foreach (Cadr item in cadres)
            {
                if (item!=null) list.Add(item.CadrToString(item));
            }
            return list;
        }
        /// <summary>
        /// Returns the number of program frames contained in the instance as data 
        /// </summary>
        /// <returns>number of program frames(required)</returns>
        public int GetCadresCount()
        {
            return cadres.Count();
        }
        /// <summary>
        /// Returns the maximum value of the X coordinate in the program contained in the instance
        /// </summary>
        /// <returns>maximum value of the X coordinate</returns>
        public decimal GetMaxX()
        {
            decimal Xmax=decimal.MinValue;
            foreach (Cadr item in cadres)
            {
                if (item == null) continue;
                if (item.xEnable)
                {
                    Xmax = Xmax < item.X ? item.X : Xmax;
                }
            }
            return Xmax;
        }
        /// <summary>
        /// Returns the minimum value at the X coordinate in the program contained in the instance
        /// </summary>
        /// <returns>minimum value at the X coordinate</returns>
        public decimal GetMinX()
        {
            decimal Xmin = decimal.MaxValue;
            foreach (Cadr item in cadres)
            {
                if (item == null) continue;
                if (item.xEnable)
                {
                    Xmin = Xmin > item.X ? item.X : Xmin;
                }
            }
            return Xmin;
        }
        /// <summary>
        /// Returns the maximum value of the Y coordinate in the program contained in the instance
        /// </summary>
        /// <returns>maximum value of the Y coordinate</returns>
        public decimal GetMaxY()
        {
            decimal Ymax = decimal.MinValue;
            foreach (Cadr item in cadres)
            {
                if (item == null) continue;
                if (item.yEnable)
                {
                    Ymax = Ymax < item.Y ? item.Y : Ymax;
                }
            }
            return Ymax;
        }

        /// <summary>
        /// Returns the minimum value on the Y coordinate in the program contained in the instance
        /// </summary>
        /// <returns>minimum value on the Y coordinate</returns>        
        public decimal GetMinY()
        {
            decimal Ymin = decimal.MaxValue;
            foreach (Cadr item in cadres)
            {
                if (item == null) continue;
                if (item.xEnable)
                {
                    Ymin = Ymin > item.Y ? item.Y : Ymin;
                }
            }
            return Ymin;
        }
        /// <summary>
        /// Adds the increment to all X values in the program contained in the instance
        /// </summary>
        /// <param name="xTranslate">values(required)</param>
        public void TranslateX(decimal xTranslate)
        {
            for (int i=0; i<cadres.Count();i++)
            {
                if (cadres[i].xEnable)
                {
                    cadres[i].X = cadres[i].X + xTranslate;
                }
            }
        }
        /// <summary>
        /// Adds the increment to all Y values in the program contained in the instance
        /// </summary>
        /// <param name="yTranslate">values(required)</param>
        public void TranslateY(decimal yTranslate)
        {
            for (int i = 0; i < cadres.Count(); i++)
            {
                if (cadres[i].yEnable)
                {
                    cadres[i].Y = cadres[i].Y + yTranslate;
                }
            }
        }
    }
}
