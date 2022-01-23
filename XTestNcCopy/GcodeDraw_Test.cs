using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using NcLibrary;

namespace XTestNcCopy
{
    public class GcodeDraw_Test
    {
        GcodeDraw draw { get; set; }

        List<Cadr> cadres { get; set; }

        List<string> gcode { get; set; }


        public GcodeDraw_Test()
        {
            draw = new GcodeDraw();
            cadres = new List<Cadr>();
            gcode = new List<string>();

            Cadr cadr = new Cadr();

            gcode.Add("M5");
            gcode.Add("G0X65.75Y52.79");
            gcode.Add("M4 S110");
            gcode.Add("G1X65.59Y50.48F10000");
            gcode.Add("X65.15Y48.27");
            gcode.Add("X64.43Y46.18");
            gcode.Add("X63.45Y44.22");
            gcode.Add("X62.24Y42.41");
            gcode.Add("M5");
            gcode.Add("M5");
            gcode.Add("M5");

           // cadres.Add(cadr.StringToCadr("M5"));
            cadres.Add(cadr.StringToCadr("G0X65.75Y52.79"));
            cadres.Add(cadr.StringToCadr("M4 S110"));
            cadres.Add(cadr.StringToCadr("G1X65.59Y50.48F10000"));
            cadres.Add(cadr.StringToCadr("X65.15Y48.27"));
            cadres.Add(cadr.StringToCadr("X64.43Y46.1"));
            cadres.Add(cadr.StringToCadr("X63.45Y44.22"));
            cadres.Add(cadr.StringToCadr("X62.24Y42.41"));
            cadres.Add(cadr.StringToCadr("M5"));
            cadres.Add(cadr.StringToCadr("M5"));
            cadres.Add(cadr.StringToCadr("M5"));


            draw.SetCadres(gcode);
        }

       

        [Fact]
        public void CreatePathTest()
        {
            //Arrange
            Point2D point = new Point2D();
            Path2D path = new Path2D();
            Path2D pathExp = new Path2D();

            //Act
            path.Add(new Point2D(65.75M, 52.79M));
            path.Add(new Point2D(65.59M, 50.48M));
            path.Add(new Point2D(65.15M, 48.27M));
            path.Add(new Point2D(64.43M, 46.1M));
            path.Add(new Point2D(63.45M, 44.22M));
            path.Add(new Point2D(62.24M, 42.41M));
            path.closed = true;

            pathExp = CreatePath(cadres);

            Console.WriteLine(path.ToString());

            //Assert
            Assert.Equal(path.GetPoint(0).x, pathExp.GetPoint(0).x);
            Assert.Equal(path.GetPoint(0).y, pathExp.GetPoint(0).y);
            Assert.Equal(path.GetPoint(5).x, pathExp.GetPoint(5).x);
            Assert.Equal(path.GetPoint(5).y, pathExp.GetPoint(5).y);
        }


        [Fact]
        public void SetPointTest_M5()
        {
            //Arrange
            Cadr cadr = new Cadr();
            Point2D point = new Point2D();

            //Act
            cadr=cadr.StringToCadr("M5");

            //Assert
            Assert.Equal(point.x, SetPoint(cadr).x);
            Assert.Equal(point.y, SetPoint(cadr).y);
        }

        [Fact]
        public void SetPointTest_M4()
        {
            //Arrange
            Cadr cadr = new Cadr();
            Point2D point = new Point2D();

            //Act
            cadr = cadr.StringToCadr("M4 S110");

            //Assert
            Assert.Equal(point.x, SetPoint(cadr).x);
            Assert.Equal(point.y, SetPoint(cadr).y);
        }

        [Fact]
        public void SetPointTest_GO()
        {
            //Arrange
            Cadr cadr = new Cadr();
            Point2D point = new Point2D();
            

            //Act
            cadr=cadr.StringToCadr("G0X65.75Y52.79");
            point.Set(65.75M, 52.79M);


            //Assert
            Assert.Equal(point.x, SetPoint(cadr).x);
            Assert.Equal(point.y, SetPoint(cadr).y);

        }

        [Fact]
        public void SetPointTest_G1()
        {
            //Arrange
            Cadr cadr = new Cadr();
            Point2D point = new Point2D();


            //Act
            cadr = cadr.StringToCadr("G1X65.59Y50.48F10000");
            point.Set(65.59M, 50.48M);


            //Assert
            Assert.Equal(point.x, SetPoint(cadr).x);
            Assert.Equal(point.y, SetPoint(cadr).y);

        }
        
        [Fact]
        public void SetPointTest_XY()
        {
            //Arrange
            Cadr cadr = new Cadr();
            Point2D point = new Point2D();


            //Act
            cadr = cadr.StringToCadr("X65.15Y48.27");
            point.Set(65.15M, 48.27M);


            //Assert
            Assert.Equal(point.x, SetPoint(cadr).x);
            Assert.Equal(point.y, SetPoint(cadr).y);

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
                        path.closed = true;
                        return path;
                        break;
                }
            }

            return path;
        }

    }
}
