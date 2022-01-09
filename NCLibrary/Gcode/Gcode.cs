using System.Collections.Generic;
using System.Linq;


namespace NcLibrary
{
    public class Gcode
    {
        private List<Cadr> cadres { get; set; }

        public Gcode()
        {
            cadres = new List<Cadr>();
        }

        public void SetCadres(List<string> listStringCadres)
        {
            cadres.Clear();
            foreach (string item in listStringCadres)
            {
                Cadr cadr = new Cadr();

                cadr = cadr.StringToCadr(item);

                if (cadr!= null)
                {
                    cadres.Add(cadr);
                }
                else continue;
            }
        }

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

        public List<string> GetCadres()
        {
            List<string> list = new List<string>();
            foreach (Cadr item in cadres)
            {
                if (item!=null) list.Add(item.CadrToString(item));
            }
            return list;
        }

        public int GetCadresCount()
        {
            return cadres.Count();
        }

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
