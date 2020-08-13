using GCDLibrary;
using NUnit.Framework;

namespace GCDLibraryTested
{
    public class GCDFinderTests
    {
        //Arrange
        readonly decimal _digitOne = 30M;
        readonly decimal _digitTwo = 18M;
        readonly decimal _expectedGCD = 6M;

        [Test]
        public void EuclideanAlg_TwoNormalDigits_CorrectGCD()
        {
            //Act
            var target = GCDFinder.EuclideanAlg(_digitOne, _digitTwo);
            //Assert
            Assert.AreEqual(_expectedGCD, target);
        }

        [Test]
        public void EuclideanAlg_NegativeDigits_CorrectGCD()
        {
            //Act
            var target = GCDFinder.EuclideanAlg(_digitOne * -1, _digitTwo * -1);
            //Assert
            Assert.AreEqual(_expectedGCD, target);
        }

        [Test]
        public void EuclideanAlg_LotsOfDigits_CorrectGCD()
        {
            //Arrange
            var otherDigits = new decimal[] { 570, 36 };
            //Act
            var target = GCDFinder.EuclideanAlg(_digitOne,_digitTwo,otherDigits);
            //Assert
            Assert.AreEqual(_expectedGCD,target);
        }

        [Test]
        public void BinaryEuclideanAlg_TwoNormalDigits_CorrectGDC()
        {
            //Act
            var target = GCDFinder.BinaryEuclideanAlg(_digitOne,_digitTwo);
            //Assert
            Assert.AreEqual(_expectedGCD,target);
        }

        [Test]
        public void BinaryEuclideanAlg_NegativeDigits_CorrectGCD() {
            //Act
            var target = GCDFinder.BinaryEuclideanAlg(_digitOne * -1, _digitTwo * -1);
            //Assert
            Assert.AreEqual(_expectedGCD,target);
        }

        [Test]
        public void BinaryEuclideanAlg_LotsOfDigits_CorrectGCD()
        {
            //Arrange
            var otherDigits = new decimal[] { 570, 36 };
            //Act
            var target = GCDFinder.EuclideanAlg(_digitOne, _digitTwo, otherDigits);
            //Assert
            Assert.AreEqual(_expectedGCD, target);
        }
    }
}