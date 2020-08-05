using CoordLibrary;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;

namespace CoordLibraryTested
{
    public class CoordinateTests
    {
        [Test]
        public void ToFormatedString_WithX0AndY0_FormatedString()
        {
            //Arrange
            var coordinateMock = new Mock<Coordinate>();

            var target = coordinateMock.Object;

            var correctStr = string.Format("X: {0} Y: {1}",0,0);

            //Act

            var result = target.ToFormatedString();

            //Assert

            Assert.AreEqual(correctStr,result);
        }
    }
}