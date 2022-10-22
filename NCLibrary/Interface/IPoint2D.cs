using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcLibrary
{
    interface IPoint2D
    {
        decimal x { get; set; }
        decimal y { get; set; }
        void Set(decimal newX, decimal newY);
    }
}
