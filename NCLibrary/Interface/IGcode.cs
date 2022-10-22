using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcLibrary
{
    interface IGcode
    {
        void SetCadres(List<string> listStringCadres);
        void AddCadres(List<string> listStringCadres);
        List<string> GetCadres();
        int GetCadresCount();
        decimal GetMaxX();
        decimal GetMinX();
        decimal GetMaxY();
        decimal GetMinY();
        void TranslateX(decimal xTranslate);
        void TranslateY(decimal yTranslate);
        void Rotate(decimal angle, decimal centerPointX, decimal centerPointY);


    }
}
