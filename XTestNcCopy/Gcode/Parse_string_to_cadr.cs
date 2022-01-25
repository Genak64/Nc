using System;
using Xunit;
using NcLibrary;


namespace XTestNcCopy
{
    public class Parse_string_to_cadr
    {
        [InlineData("M5")]
        [InlineData("M5 ")]
        [InlineData(" M5 ")]
        [InlineData(" M5")]
        [InlineData("M5S500 ")]
        [Theory]
        public void parseM5(string cadrString)
        {
            //Arrange
            Cadr cadr = new Cadr();

            //Act
            cadr = cadr.StringToCadr(cadrString);

            //Assert
            Assert.Equal("M5", cadr.type);
        }

        [InlineData("M3 S500")]
        [InlineData("M3S500")]
        [InlineData(" M3 S500 ")]
        [InlineData(" M3S500 ")]
        [InlineData(" M3 S500")]
        [InlineData("M3 S500 ")]
        [Theory]
        public void parseM3(string cadrString)
        {
            //Arrange
            Cadr cadr = new Cadr();

            //Act
            cadr = cadr.StringToCadr(cadrString);

            //Assert
            Assert.Equal("M3", cadr.type);
            Assert.Equal(500, cadr.S);
        }

        [InlineData("M4 S500")]
        [InlineData("M4S500")]
        [InlineData(" M4 S500 ")]
        [InlineData(" M4S500 ")]
        [InlineData(" M4 S500")]
        [InlineData("M4 S500 ")]
        [Theory]
        public void parseM4(string cadrString)
        {
            //Arrange
            Cadr cadr = new Cadr();

            //Act
            cadr = cadr.StringToCadr(cadrString);

            //Assert
            Assert.Equal("M4", cadr.type);
            Assert.Equal(500, cadr.S);
        }

        [InlineData("G0X0.51Y5.62")]
        [InlineData("G0 X0.51 Y5.62")]
        [InlineData(" G0X0.51Y5.62")]
        [InlineData("G0X0.51Y5.62 ")]
        [InlineData(" G0X0.51Y5.62 ")]
        [InlineData("G0 X0.51Y5.62")]
        [InlineData("G0X0.51 Y5.62")]
        [InlineData("G0 X0.51 Y5.62 Z0 dsfdfsdf")]
        [InlineData("G0X0.51Y5.62Z0dsfdfsdf")]
       
        [Theory]
        public void parseG0(string cadrString)
        {
            //Arrange
            Cadr cadr = new Cadr();

            //Act
            cadr = cadr.StringToCadr(cadrString);

            //Assert
            Assert.Equal("G0", cadr.type);
            Assert.Equal(0.51M, cadr.X);
            Assert.Equal(5.62M, cadr.Y);
        }

        [InlineData("G0X-0.51Y-5.62")]
        [InlineData("G0X0.51Y-5.62")]
        [InlineData("G0X-0.51Y5.62")]

        [Theory]
        public void parseG0Sign(string cadrString)
        {
            //Arrange
            Cadr cadr = new Cadr();

            //Act
            cadr = cadr.StringToCadr(cadrString);

            //Assert
            Assert.Equal("G0", cadr.type);
            Assert.Equal(0.51M, Math.Abs(cadr.X));
            Assert.Equal(5.62M, Math.Abs(cadr.Y));
        }


        [InlineData("G1X0.51Y5.62F1200")]
        [InlineData("G1 X0.51 Y5.62 F1200")]
        [InlineData(" G1X0.51Y5.62F1200")]
        [InlineData("G1X0.51Y5.62F1200 ")]
        [InlineData(" G1X0.51Y5.62F1200 ")]
        [InlineData("G1 X0.51Y5.62F1200")]
        [InlineData("G1X0.51 Y5.62F1200")]
        [Theory]
        public void parseG1(string cadrString)
        {
            //Arrange
            Cadr cadr = new Cadr();

            //Act
            cadr = cadr.StringToCadr(cadrString);

            //Assert
            Assert.Equal("G1", cadr.type);
            Assert.Equal(0.51M, cadr.X);
            Assert.Equal(5.62M, cadr.Y);
            Assert.Equal(1200, cadr.F);
        }


        [InlineData("X0.51Y5.62")]
        [InlineData("X0.51 Y5.62")]
        [InlineData(" X0.51Y5.62")]
        [InlineData("X0.51Y5.62 ")]
        [Theory]
        public void parseXY(string cadrString)
        {
            //Arrange
            Cadr cadr = new Cadr();

            //Act
            cadr = cadr.StringToCadr(cadrString);

            //Assert
            Assert.Equal("XY", cadr.type);
            Assert.Equal(0.51M, cadr.X);
            Assert.Equal(5.62M, cadr.Y);
        }

        [InlineData("X0.51")]
        [InlineData("X0.51 ")]
        [InlineData(" X0.51")]
        [InlineData(" X0.51 ")]
        [Theory]
        public void parseX(string cadrString)
        {
            //Arrange
            Cadr cadr = new Cadr();

            //Act
            cadr = cadr.StringToCadr(cadrString);

            //Assert
            Assert.Equal("XX", cadr.type);
            Assert.Equal(0.51M, cadr.X);
        }

        [InlineData("Y5.62")]
        [InlineData(" Y5.62")]
        [InlineData(" Y5.62 ")]
        [InlineData("Y5.62 ")]
        [Theory]
        public void parseY(string cadrString)
        {
            //Arrange
            Cadr cadr = new Cadr();

            //Act
            cadr = cadr.StringToCadr(cadrString);

            //Assert
            Assert.Equal("YY", cadr.type);
            Assert.Equal(5.62M, cadr.Y);
        }

    }
}
