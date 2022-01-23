using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using NcLibrary;

namespace XTestNcCopy.ShapesModel
{
    public class Path2D_test
    {
        Path2D path { get; set; }

        public Path2D_test()
        {
            path = new Path2D();
        }

        [Fact]
        public void PathCountTest()
        {
            //Arrange
            Point2D point = new Point2D();

            //Act
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

            //Assert
            Assert.Equal(5, path.Count());
        }

        [Fact]
        public void PathGetPointTest()
        {
            //Arrange
            Point2D point = new Point2D();

            //Act
            point.Set(0, 0);
            path.Add(point);

            point.Set(10, 0);
            path.Add(point);

            point.Set(10, 10);
            path.Add(point);

            point.Set(0, 10);
            path.Add(point);

            point.Set(1, 1);
            path.Add(point);

            //Assert
            point.Set(0, 0);
            Assert.Equal(point, path.GetPoint(0));

            point.Set(0, 10);
            Assert.Equal(point, path.GetPoint(3));

            point.Set(1, 1);
            Assert.Equal(point, path.GetPoint(4));

            point.Set(1, 1);
            Assert.Equal(point, path.GetPoint(6));
        }

        [Fact]
        public void SetLastPointXTest()
        {
            //Arrange
            Point2D point = new Point2D();

            //Act
            point.Set(0, 0);
            path.Add(point);

            point.Set(10, 0);
            path.Add(point);

            point.Set(10, 10);
            path.Add(point);

            point.Set(0, 10);
            path.Add(point);

            point.Set(0, 1);
            path.Add(point);

            path.SetLastPointX(10);
            point.Set(10, 1);
            //Assert
            Assert.Equal(point, path.GetPoint(6));
        }

        [Fact]
        public void SetLastPointYTest()
        {
            //Arrange
            Point2D point = new Point2D();

            //Act
            point.Set(0, 0);
            path.Add(point);

            point.Set(10, 0);
            path.Add(point);

            point.Set(10, 10);
            path.Add(point);

            point.Set(0, 10);
            path.Add(point);

            point.Set(10, 1);
            path.Add(point);

            path.SetLastPointY(20);
            point.Set(10, 20);
            //Assert
            Assert.Equal(point, path.GetPoint(6));
        }
    }
}
