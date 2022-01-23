using System;
using Xunit;
using NcLibrary;

namespace XTestNcCopy
{
    public class Parse_cadr_to_string
    {
       
        [Fact]
        public void parseM5()
        {
            //Arrange
            Cadr cadr = new Cadr();
            cadr.type = "M5";

            //Act
            string cadrString = cadr.CadrToString(cadr);

            //Assert
            Assert.Equal("M5", cadrString);
        }

        [Fact]
        public void parseM3()
        {
            //Arrange
            Cadr cadr = new Cadr();
            cadr.type = "M3";
            cadr.S = 500;

            //Act
            string cadrString = cadr.CadrToString(cadr);

            //Assert
            Assert.Equal("M3S500", cadrString);
        }

        [Fact]
        public void parseM4()
        {
            //Arrange
            Cadr cadr = new Cadr();
            cadr.type = "M4";
            cadr.S = 500;

            //Act
            string cadrString = cadr.CadrToString(cadr);

            //Assert
            Assert.Equal("M4S500", cadrString);
        }

        [Fact]
        public void parseG0()
        {
            //Arrange
            Cadr cadr = new Cadr();
            cadr.type = "G0";
            cadr.X = 0.51M;
            cadr.Y = 5.62M;
            cadr.xEnable = true;
            cadr.yEnable = true;

            //Act
            string cadrString = cadr.CadrToString(cadr);

            //Assert
            Assert.Equal("G0X0.51Y5.62", cadrString);
        }

        [Fact]
        public void parseG1()
        {
            //Arrange
            Cadr cadr = new Cadr();
            cadr.type = "G1";
            cadr.X = 0.51M;
            cadr.Y = 5.62M;
            cadr.xEnable = true;
            cadr.yEnable = true;
            cadr.F = 1200;

            //Act
            string cadrString = cadr.CadrToString(cadr);

            //Assert
            Assert.Equal("G1X0.51Y5.62F1200", cadrString);
        }

        [Fact]
        public void parseXY()
        {
            //Arrange
            Cadr cadr = new Cadr();
            cadr.type = "XY";
            cadr.X = 0.51M;
            cadr.Y = 5.62M;
            cadr.xEnable = true;
            cadr.yEnable = true;

            //Act
            string cadrString = cadr.CadrToString(cadr);

            //Assert
            Assert.Equal("X0.51Y5.62", cadrString);
        }

        [Fact]
        public void parseX()
        {
            //Arrange
            Cadr cadr = new Cadr();
            cadr.type = "XX";
            cadr.X = 0.51M;
            cadr.xEnable = true;

            //Act
            string cadrString = cadr.CadrToString(cadr);

            //Assert
            Assert.Equal("X0.51", cadrString);
        }

        [Fact]
        public void parseY()
        {
            //Arrange
            Cadr cadr = new Cadr();
            cadr.type = "YY";
            cadr.Y = 5.62M;
            cadr.yEnable = true;

            //Act
            string cadrString = cadr.CadrToString(cadr);

            //Assert
            Assert.Equal("Y5.62", cadrString);
        }
    }
}
