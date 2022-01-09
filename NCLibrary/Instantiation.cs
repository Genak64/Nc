using System.Collections.Generic;

namespace NcLibrary
{
    public class Instantiation
    {
        public List<string> CreateCopyXY(List<string> gcodeOriginal, int Xquantity, int Yquantity, decimal offset = 0)
        {
            Gcode gcode = new Gcode();
            List<string> instance = new List<string>();

            if (Xquantity > 1)
            {
                for (int j = 1; j < Xquantity; j++)
                {
                    gcode.AddCadres(CreateCopyOnX(gcodeOriginal, Xquantity, offset));
                }
                instance.AddRange(gcode.GetCadres());
            } else instance.AddRange(gcodeOriginal);

            if (Yquantity > 1)
            {
                gcode.SetCadres(CreateCopyOnY(instance, Yquantity, offset));
                return gcode.GetCadres();
            }
            if (Yquantity==0) return instance;
            if (Yquantity==1) return instance;
            

            return gcode.GetCadres();
        }

        private List<string> CreateCopyOnX(List<string> gcodeOriginal, int quantity, decimal offset = 0)
        {
            Gcode gcode = new Gcode();
           
            gcode.SetCadres(gcodeOriginal);
            decimal Xmax = gcode.GetMaxX();
            decimal Xmin = gcode.GetMinX();
            decimal deltaX = Xmax > Xmin ? Xmax - Xmin : Xmin - Xmax;
            
            for (int i=1; i < quantity; i++)
            {
                gcode.AddCadres(CopyToX(gcodeOriginal, (deltaX+offset) * i));
            }
            return gcode.GetCadres();
        }

        private List<string> CreateCopyOnY(List<string> gcodeOriginal, int quantity, decimal offset = 0)
        {
            Gcode gcode = new Gcode();

            gcode.SetCadres(gcodeOriginal);
            decimal Ymax = gcode.GetMaxY();
            decimal Ymin = gcode.GetMinY();
            decimal deltaY = Ymax > Ymin ? Ymax - Ymin : Ymin - Ymax;

            for (int i = 1; i < quantity; i++)
            {
                gcode.AddCadres(CopyToY(gcodeOriginal, (deltaY+offset) * i));
            }
            return gcode.GetCadres();
        }

        private List<string> CopyToX(List<string> gcodeOriginal, decimal offset)
        {
            Gcode gcode = new Gcode();
            gcode.SetCadres(gcodeOriginal);
            gcode.TranslateX(offset);
            return gcode.GetCadres();
        }

        private List<string> CopyToY(List<string> gcodeOriginal, decimal offset)
        {
            Gcode gcode = new Gcode();
            gcode.SetCadres(gcodeOriginal);
            gcode.TranslateY(offset);
            return gcode.GetCadres();
        }

    }
}
