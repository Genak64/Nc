using System.Collections.Generic;

namespace NcLibrary
{
    public class Path2D: IPath2D
    {
        public List<Point2D> path { get; set; }
        public bool closed { get; set; }
        public Path2D()
        {
            path = new List<Point2D>();
        }

        public void Add (Point2D point)
        {
            path.Add(point);
        }

        public int Count()
        {
            return path.Count;
        }

        public Point2D GetPoint(int index)
        {
            if (index<0) return path[0];
            if (path.Count-1 >= index) return path[index];
            else return path[path.Count-1];
        }

        public void SetLastPointX(decimal x)
        {
            path[path.Count-1].x = x;
        }

        public void SetLastPointY(decimal y)
        {
            path[path.Count-1].y = y;
        }
    }
}
