
namespace NcLibrary
{
    public class Point2D
    {
        public decimal x { get; set; }
        public decimal y { get; set; }

        public Point2D()
        {
            x = 0;
            y = 0;
        }

        public Point2D(decimal newX, decimal newY)
        {
            x = newX;
            y = newY;
        }

        public void Set(decimal newX,decimal newY)
        {
            x = newX;
            y = newY;
        }
    }
}
