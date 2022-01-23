using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using NcLibrary;

namespace WinNcCopy
{
    public class DrawShapes
    {
        Graphics _graphics { get; set; }
        List<Shape2D> _shapes { get; set; }
        Size _viewPort { get; set; }
        decimal _scale { get; set; }
        Pen _axisPen { get; set; }
        Pen _shapePen { get; set; }
        Color _backgrColor { get; set; }

        public DrawShapes(Graphics graphics)
        {
            _graphics = graphics;
            _viewPort= Size.Empty;
            _scale = 1;
            _axisPen= new Pen(Color.Coral, 1);
            _shapePen= new Pen(Color.Black, 1);
            _backgrColor = Color.WhiteSmoke;
            _shapes = new List<Shape2D>();
        }

        public Size SetViewport(int Width,int Height)
        {
            Size viewPort = Size.Empty;
            viewPort.Width = Width;
            viewPort.Height = Height;
            _viewPort = viewPort;
            return viewPort;
        }

        public void SetShapes(List<Shape2D> shapes)
        {
            _shapes.Clear();
            _shapes.AddRange(shapes);
        }
        public void SetScale(decimal scale)
        {
            _scale = scale;
        }

        public void SetAxisPen(Pen pen)
        {
            _axisPen = pen;
        }

        public void SetBackGroundColor(Color color)
        {
            _backgrColor = color;
        }
        public void Axis()
        {
             _graphics.Clear(_backgrColor);

            _graphics.TranslateTransform(10, _viewPort.Height-10);

            if (_scale > 1)
            {
                _graphics.DrawLine(_axisPen, 0, 0, 0, -_viewPort.Height * (float)_scale);
                _graphics.DrawLine(_axisPen, 0, 0, _viewPort.Width * (float)_scale, 0);
            }
            else
            {
                _graphics.DrawLine(_axisPen, 0, 0, 0, -_viewPort.Height / (float)_scale);
                _graphics.DrawLine(_axisPen, 0, 0, _viewPort.Width / (float)_scale, 0);
            }
        }

        public void Shapes()
        {

            foreach (var shape in _shapes)
            {
                foreach (var path in shape)
                {
                    Path(path);
                }
                
            }
        }


        private void Path(Path2D path)
        {
            Point2D beginPoint = path.GetPoint(0);
            Point2D endPoint = path.GetPoint(1);

            _graphics.DrawLine(_shapePen, (int)(beginPoint.x * _scale), -(int)(beginPoint.y * _scale), (int)(endPoint.x * _scale), -(int)(endPoint.y * _scale));

            for (int i = 2; i < path.Count(); i++)
            {
                _graphics.DrawLine(_shapePen, (int)(path.GetPoint(i - 1).x * _scale), -(int)(path.GetPoint(i - 1).y * _scale), (int)(path.GetPoint(i).x * _scale), -(int)(path.GetPoint(i).y * _scale));
            }
        }

    }
}
