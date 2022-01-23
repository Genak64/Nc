using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using NcLibrary;

namespace XTestNcCopy.ShapesModel
{
    public class Shape2D_test
    {
        Shape2D shape { get; set; }
        Path2D path { get; set; }
        Point2D point { get; set; }
        public Shape2D_test()
        {
            shape = new Shape2D();
            path = new Path2D();
            point = new Point2D();
        }

        [Fact]
        public void AddPathTest()
        {
            //Arrange

            //set path 1
            point.Set(0, 0);
            path.Add(point);
            point.Set(10, 0);
            path.Add(point);
            point.Set(10, 10);
            path.Add(point);
            point.Set(0, 10);
            path.Add(point);
            point.Set(0, 0);
            path.Add(point);


            //Act
            shape.AddPath(path);
            shape.AddPath(path);
            shape.AddPath(path);
            shape.AddPath(path);

            //Assert
            Assert.Equal(4, shape.GetPathCount());
        }

        [Fact]
        public void GetPathTest()
        {
            //Arrange

            //set path 1
            point.Set(0, 0);
            path.Add(point);
            point.Set(10, 0);
            path.Add(point);
            point.Set(10, 10);
            path.Add(point);
            point.Set(0, 10);
            path.Add(point);
            point.Set(0, 0);
            path.Add(point);


            //Act
            shape.AddPath(path);
            shape.AddPath(path);
            shape.AddPath(path);
            shape.AddPath(path);

            //Assert
            Assert.Equal(path, shape.GetPath(0));
            Assert.Equal(path, shape.GetPath(1));
            Assert.Equal(path, shape.GetPath(2));
            Assert.Equal(path, shape.GetPath(3));
            Assert.Equal(path, shape.GetPath(4));

        }
    }
}
