using System;
using Xunit;
using NcLibrary;
using System.Collections.Generic;

namespace XTestNcCopy
{
    public class Gcode_method_test
    {
        private Gcode gcode { get; set; }
        private List<string> gcodeString { get; set; }
        private int CadrCount {get;set;}

        public Gcode_method_test()
        {
            gcodeString = new List<string>();
            gcodeString.Add("M5");
            gcodeString.Add("M4S500.00");
            gcodeString.Add("G0X10.5Y1.5");
            gcodeString.Add("G1X11.5Y2.5F1200");
            gcodeString.Add("X0.5Y5.5");
            gcodeString.Add("M5");
            gcodeString.Add(" ");
            CadrCount = 7;
        }


        [Fact]
        public void SetCadresTest()
        {
            //Arrange
            Gcode gcode = new Gcode();

            //Act
            gcode.SetCadres(gcodeString);

            //Assert
            Assert.Equal(CadrCount,gcode.GetCadresCount());
        }

        [Fact]
        public void AddCadresTest()
        {
            //Arrange
            Gcode gcode = new Gcode();

            //Act
            gcode.SetCadres(gcodeString);
            gcode.AddCadres(gcodeString);

            //Assert
            Assert.Equal(CadrCount*2, gcode.GetCadresCount());
        }

        [Fact]
        public void GetCadresTest()
        {
            //Arrange
            Gcode gcode = new Gcode();
            List<string> codeString = new List<string>();
            //Act
            gcode.SetCadres(gcodeString);
            codeString = gcode.GetCadres();

            //Assert
            Assert.Equal(CadrCount, codeString.Count) ;
        }

        [Fact]
        public void GetMaxXtest()
        {
            //Arrange
            Gcode gcode = new Gcode();
           
            //Act
            gcode.SetCadres(gcodeString);
            
            //Assert
            Assert.Equal(11.5M, gcode.GetMaxX());
        }

        [Fact]
        public void GetMinXtest()
        {
            //Arrange
            Gcode gcode = new Gcode();

            //Act
            gcode.SetCadres(gcodeString);

            //Assert
            Assert.Equal(0.5M, gcode.GetMinX());
        }

        [Fact]
        public void GetMaxYtest()
        {
            //Arrange
            Gcode gcode = new Gcode();

            //Act
            gcode.SetCadres(gcodeString);

            //Assert
            Assert.Equal(5.5M, gcode.GetMaxY());
        }

        [Fact]
        public void GetMinYtest()
        {
            //Arrange
            Gcode gcode = new Gcode();

            //Act
            gcode.SetCadres(gcodeString);

            //Assert
            Assert.Equal(1.5M, gcode.GetMinY());
        }

        [Fact]
        public void TranslateXtest()
        {
            //Arrange
            Gcode gcode = new Gcode();

            //Act
            gcode.SetCadres(gcodeString);
            decimal xmax = gcode.GetMaxX();
            gcode.TranslateX(12.5M);

            //Assert
            Assert.Equal((xmax+12.5M), gcode.GetMaxX());
        }

        [Fact]
        public void TranslateYtest()
        {
            //Arrange
            Gcode gcode = new Gcode();

            //Act
            gcode.SetCadres(gcodeString);
            decimal ymax = gcode.GetMaxY();
            gcode.TranslateY(12.5M);

            //Assert
            Assert.Equal((ymax + 12.5M), gcode.GetMaxY());
        }
    }
}
