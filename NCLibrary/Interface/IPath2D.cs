using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcLibrary
{
    interface IPath2D
    {
        void Add(Point2D point);
        int Count();
        Point2D GetPoint(int index);
        void SetLastPointX(decimal x);
        void SetLastPointY(decimal y);

    }
}
