using System.Collections.Generic;

namespace NcLibrary
{
    public class GcodeDraw
    {
        private List<Cadr> cadres { get; set; }
        private List<Shape2D> shapes { get; set; }

        public GcodeDraw()
        {
            cadres = new List<Cadr>();
            shapes = new List<Shape2D>();
        }

        public void SetCadres(List<string> listStringCadres)
        {
            cadres.Clear();
            foreach (string item in listStringCadres)
            {
                Cadr cadr = new Cadr();

                cadres.Add(cadr.StringToCadr(item));
            }
        }

        public List<Shape2D> GetShapes()
        {
            shapes.Add(CreateShape(cadres));

            return shapes;
        }

        private Shape2D CreateShape(List<Cadr> cadres)
        {
            Shape2D shape = new Shape2D();
            List<Cadr> pathCadres = new List<Cadr>();

            for (int i = 1; i < cadres.Count; i++)
            {
                if (cadres[i].type != "M5")
                {
                    pathCadres.Add(cadres[i]);
                }
                else
                {
                    Path2D path = CreatePath(pathCadres);
                    if (path.Count()!=0) shape.AddPath(CreatePath(pathCadres));
                    pathCadres.Clear();
                }
            }
            return shape;
        }

        private Path2D CreatePath(List<Cadr> pathCadres)
        {
            Path2D path = new Path2D();

            foreach (Cadr item in pathCadres)
            {
                switch (item.type)
                {
                    case "G0":
                        path.Add(SetPoint(item));
                        break;
                    case "G1":
                        path.Add(SetPoint(item));
                        if (!item.xEnable) path.SetLastPointX(path.GetPoint(path.Count() - 2).x);
                        if (!item.yEnable) path.SetLastPointY(path.GetPoint(path.Count() - 2).y);
                        break;
                    case "XY":
                        path.Add(SetPoint(item));
                        if (!item.xEnable) path.SetLastPointX(path.GetPoint(path.Count() - 2).x);
                        if (!item.yEnable) path.SetLastPointY(path.GetPoint(path.Count() - 2).y);
                        break;
                    case "XX":
                        path.Add(SetPoint(item));
                        if (!item.xEnable) path.SetLastPointX(path.GetPoint(path.Count() - 2).x);
                        if (!item.yEnable) path.SetLastPointY(path.GetPoint(path.Count() - 2).y);
                        break;
                    case "YY":
                        path.Add(SetPoint(item));
                        if (!item.xEnable) path.SetLastPointX(path.GetPoint(path.Count() - 2).x);
                        if (!item.yEnable) path.SetLastPointY(path.GetPoint(path.Count() - 2).y);
                        break;
                    case "M5":
                        if (path.Count() == 0)
                        {
                            continue;
                        } else
                        {
                            path.closed = true;
                            return path;
                        }
                    default:
                        continue;

                }
            }

            return path;
        }

        private Point2D SetPoint(Cadr cadr)
        {
            Point2D point = new Point2D();

            if (cadr.xEnable)
            {
                point.x = cadr.X;
            }
           
            if (cadr.yEnable) 
            { 
                point.y = cadr.Y; 
            }

            return point;
        }




    }
}
