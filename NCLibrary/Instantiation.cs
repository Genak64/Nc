using System.Collections.Generic;

namespace NcLibrary
{
    public class Instantiation
    {
        /// <summary>
        /// Reproduces the original g-code program in the X and Y directions and returns their text representation
        /// </summary>
        /// <param name="gcodeOriginal">original g-code program(required)</param>
        /// <param name="Xquantity">number of copies in X direction(required)</param>
        /// <param name="Yquantity">number of copies in Y direction(required)</param>
        /// <param name="offset">copy spacing</param>
        /// <returns>general text representation of original and copy programs</returns>
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
        /// <summary>
        /// Reproduces the original g-code program in the X directions and returns their text representation
        /// </summary>
        /// <param name="gcodeOriginal">original g-code program(required)</param>
        /// <param name="quantity">number of copies (required)</param>
        /// <param name="offset">copy spacing</param>
        /// <returns>general text representation of original and copy programs</returns>
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
        /// <summary>
        /// Reproduces the original g-code program in the Y directions and returns their text representation
        /// </summary>
        /// <param name="gcodeOriginal">original g-code program(required)</param>
        /// <param name="quantity">number of copies (required)</param>
        /// <param name="offset">copy spacing</param>
        /// <returns>general text representation of original and copy programs</returns>
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
        /// <summary>
        /// Offsets the original program by a given value in the X direction and returns the text representation of the program with the offset
        /// </summary>
        /// <param name="gcodeOriginal">original g-code program(required)</param>
        /// <param name="offset">X-axis offset(required)</param>
        /// <returns></returns>
        private List<string> CopyToX(List<string> gcodeOriginal, decimal offset)
        {
            Gcode gcode = new Gcode();
            gcode.SetCadres(gcodeOriginal);
            gcode.TranslateX(offset);
            return gcode.GetCadres();
        }
        /// <summary>
        /// Offsets the original program by a given value in the Y direction and returns the text representation of the program with the offset
        /// </summary>
        /// <param name="gcodeOriginal">original g-code program(required)</param>
        /// <param name="offset">Н-axis offset(required)</param>
        /// <returns></returns>
        private List<string> CopyToY(List<string> gcodeOriginal, decimal offset)
        {
            Gcode gcode = new Gcode();
            gcode.SetCadres(gcodeOriginal);
            gcode.TranslateY(offset);
            return gcode.GetCadres();
        }

        public List<string> CopyToRotate(List<string> gcodeOriginal,decimal angle)
        {
            Gcode gcode = new Gcode();
            gcode.SetCadres(gcodeOriginal);

            decimal Ymax = gcode.GetMaxY();
            decimal Ymin = gcode.GetMinY();
            decimal Xmax = gcode.GetMaxX();
            decimal Xmin = gcode.GetMinX();
            decimal deltaY = Ymax > Ymin ? Ymax - Ymin : Ymin - Ymax;
            decimal deltaX = Xmax > Xmin ? Xmax - Xmin : Xmin - Xmax;
            decimal centerPointX = Xmax > Xmin ? Xmin+ deltaX/2 : Xmax + deltaX / 2;
            decimal centerPointY = Ymax > Ymin ? Ymin + deltaY / 2 : Ymax + deltaY / 2;

            gcode.Rotate(angle, centerPointX, centerPointY);
            return gcode.GetCadres();
        }

    }
}
