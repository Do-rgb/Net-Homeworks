using BinaryRepresentationLibrary;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork4Tested
{
    public class BinaryRepresentatorTests
    {
        [Test]
        public void ConvertStandart_SimpleDigit_CorrectAnswer()
        {
            //Arrange
            uint digit = 8;
            var expectedAnswer = "1000";
            //Act
            var target = BinaryRepresentator.ConvertStandart(digit);
            //Assert
            Assert.AreEqual(target,expectedAnswer);
        }

        [Test]
        public void ConvertMyAlg_SimpleDigit_CorrectAnswer()
        {
            //Arrange
            uint digit = 8;
            var expectedAnswer = "1000";
            //Act
            var target = BinaryRepresentator.ConvertMyAlg(digit);
            //Assert
            Assert.AreEqual(target, expectedAnswer);
        }

        [Test]
        public void ConvertMyAlg_RangeOfNumbers_AlwaysCorrectReturn() {
            //Arrange
            for (uint i = 0; i <= 1000; i++)
            {
                //Act
                var target = BinaryRepresentator.ConvertMyAlg(i);
                //Assert
                Assert.AreEqual(target,Convert.ToString(i,2));
            }
        }
    }
}
