using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab1_Polynomial2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Polynomial2.Tests
{
    [TestClass()]
    public class PolynomialTests
    {

        [TestMethod()]
        public void CalcPol_EmptyPolynomialTest()
        {
            // Arrange
            Polynomial p = new Polynomial();
            //Action
            double result = p.CalcPol(5);
            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod()]
        public void CalcPol_SingleTermPolynomialTest()
        {
            //Arrange
            double[] coefs = { 2 };
            int[] powers = { 2 };
            Polynomial p = new Polynomial(coefs, powers);
            //Action
            double result = p.CalcPol(3);
            //Assert
            Assert.AreEqual(18, result); // 2(3^2) = 18
        }

        [TestMethod()]
        public void CalcPol_MultipleTermsPolynomialTest()
        {
            //Arrange
            double[] coefs = { 2, 3 };
            int[] powers = { 2, 1 };
            Polynomial p = new Polynomial(coefs, powers);
            //Action
            double result = p.CalcPol(3);
            //Assert
            Assert.AreEqual(27, result); // 2(3^2) + 3(3) = 27
        }

        [TestMethod()]
        public void CalcPol_LargeValueTest()
        {
            //Arrange
            double[] coefs = { 2, 3 };
            int[] powers = { 2, 1 };
            Polynomial p = new Polynomial(coefs, powers);
            //Action
            double result = p.CalcPol(1000);
            //Assert
            Assert.AreEqual(2003000, result); // 2(1000^2) + 3(1000) = 2003000
        }

        [TestMethod()]
        public void CalcPol_NegativeValueTest()
        {
            //Arrange
            double[] coefs = { 2, 3 };
            int[] powers = { 2, 1 };
            Polynomial p = new Polynomial(coefs, powers);
            //Action
            double result = p.CalcPol(-3);
            //Assert
            Assert.AreEqual(9, result); // 2(-3^2) + 3(-3) = 9
        }

        [TestMethod()]
        public void CalcPol_FractionValueTest()
        {
            //Arrange
            double[] coefs = { 2, 3 };
            int[] powers = { 2, 1 };
            Polynomial p = new Polynomial(coefs, powers);
            //Action
            double result = p.CalcPol(0.5);
            //Assert
            Assert.AreEqual(2, result); // 2(0.5^2) + 3(0.5) = 3.5
        }

        [TestMethod()]
        public void MultNum_EmptyPolynomialTest()
        {
            //Arrange
            Polynomial p = new Polynomial();
            //Action
            p = p.MultNum(5);
            //Assert
            Assert.AreEqual(0, p.Size);
        }

        [TestMethod()]
        public void MultNum_MultiplyByOneTest()
        {
            //Arrange
            double[] coefs = { 2, 3 };
            int[] powers = { 2, 0 };
            Polynomial p = new Polynomial(coefs, powers);
            //Action
            p = p.MultNum(1);
            //Assert
            Assert.AreEqual("2x^2 + 3", p.ToString());
        }

        [TestMethod()]
        public void MultNum_MultiplyByZeroTest()
        {
            //Arrange
            double[] coefs = { 2, 3 };
            int[] powers = { 2, 0 };
            Polynomial p = new Polynomial(coefs, powers);
            //Action
            p = p.MultNum(0);
            //Assert
            Assert.AreEqual("0", p.ToString());
        }

        [TestMethod()]
        public void MultNum_MultiplyByNegativeTest()
        {
            //Arrange
            double[] coefs = { 2, -3 };
            int[] powers = { 2, 0 };
            Polynomial p = new Polynomial(coefs, powers);
            //Action
            p = p.MultNum(-2);
            //Assert
            Assert.AreEqual("4x^2 + 6", p.ToString());
        }

        [TestMethod()]
        public void MultNum_MultiplyByFractionTest()
        {
            //Arrange
            double[] coefs = { 2, 4 };
            int[] powers = { 2, 0 };
            Polynomial p = new Polynomial(coefs, powers);
            //Action
            p = p.MultNum(0.5);
            //Assert
            Assert.AreEqual("x^2 + 2", p.ToString());
        }


        [TestMethod()]
        public void SubNum_SubtractFromConstantTest()
        {
            //Arrange
            double[] coefs = { 2, 3 };
            int[] powers = { 0, 2 };
            Polynomial p = new Polynomial(coefs, powers);
            //Action
            p = p.SubNum(1);
            //Assert
            Assert.AreEqual("1 + 3x^2", p.ToString());
        }
        [TestMethod()]
        public void SubNum_SubtractNegativeFromPolynomialWithoutConstantTest()
        {
            //Arrange
            double[] coefs = { 3 };
            int[] powers = { 2 };
            Polynomial p = new Polynomial(coefs, powers);
            //Action
            p = p.SubNum(-1);
            //Assert
            Assert.AreEqual("3x^2 + 1", p.ToString());
        }
        [TestMethod()]
        public void SubNum_SubtractZeroTest()
        {
            //Arrange
            double[] coefs = { 3, 4 };
            int[] powers = { 0, 2 };
            Polynomial p = new Polynomial(coefs, powers);
            //Action
            p = p.SubNum(0);
            //Assert
            Assert.AreEqual("3 + 4x^2", p.ToString());
        }
        [TestMethod()]
        public void SubNum_SubtractFromZeroPolynomialTest()
        {
            //Arrange
            double[] coefs = { 0 };
            int[] powers = { 0 };
            Polynomial p = new Polynomial(coefs, powers);
            //Action
            p = p.SubNum(1);
            //Assert
            Assert.AreEqual("-1", p.ToString());
        }

        [TestMethod()]
        public void SubNum_SubtractEqualValueTest()
        {
            //Arrange
            double[] coefs = { 5, 3 };
            int[] powers = { 0, 2 };
            Polynomial p = new Polynomial(coefs, powers);
            //Action
            p = p.SubNum(5);
            //Assert
            Assert.AreEqual("3x^2", p.ToString());
        }


        [TestMethod()]
        public void SumNum_AddToExistingConstantTest()
        {
            //Arrange
            double[] coefs = { 2, 3 };
            int[] powers = { 0, 2 };
            Polynomial p = new Polynomial(coefs, powers);
            //Action
            p = p.SumNum(5);
            //Assert
            Assert.AreEqual("7 + 3x^2", p.ToString());
        }

        [TestMethod()]
        public void SumNum_AddToPolynomialWithoutConstantTest()
        {
            //Arrange
            double[] coefs = { 3 };
            int[] powers = { 2 };
            Polynomial p = new Polynomial(coefs, powers);
            //Action
            p = p.SumNum(5);
            //Assert
            Assert.AreEqual("3x^2 + 5", p.ToString());
        }

        [TestMethod()]
        public void SumNum_AddZeroTest()
        {
            //Arrange
            double[] coefs = { 2, 3 };
            int[] powers = { 0, 2 };
            Polynomial p = new Polynomial(coefs, powers);
            //Action
            p = p.SumNum(0);
            //Assert
            Assert.AreEqual("2 + 3x^2", p.ToString()); 
        }
        [TestMethod()]
        public void SumNum_AddNegativeTest()
        {
            //Arrange
            double[] coefs = { 2, 3 };
            int[] powers = { 0, 2 };
            Polynomial p = new Polynomial(coefs, powers);
            //Action
            p = p.SumNum(-10);
            //Assert
            Assert.AreEqual("-8 + 3x^2", p.ToString());
        }

        [TestMethod()]
        public void SubPol_SubtractSamePolynomialTest()
        {
            //Arrange
            double[] coefs = { 4, 3 };
            int[] powers = { 0, 2 };

            Polynomial p1 = new Polynomial(coefs, powers);
            Polynomial p2 = new Polynomial(coefs, powers);
            //Act
            p1 = p1.SubPol(p2);
            //Assert
            Assert.AreEqual("0", p1.ToString());
        }

        [TestMethod()]
        public void SubPol_SubtractDifferentPowersTest()
        {
            //Arrange
            double[] coefs1 = { 5, 3, 7 };
            int[] powers1 = { 0, 1, 2 };

            double[] coefs2 = { 3, 2 };
            int[] powers2 = { 0, 3 };

            Polynomial p1 = new Polynomial(coefs1, powers1);
            Polynomial p2 = new Polynomial(coefs2, powers2);
            //Act
            p1 = p1.SubPol(p2);
            //Assert
            Assert.AreEqual("2 - 2x^3 + 3x^1 + 7x^2", p1.ToString());
        }

        [TestMethod()]
        public void SubPol_SubtractPartialOverlapTest()
        {
            // Arrange
            double[] coefs1 = { 5, 3, 1 };
            int[] powers1 = { 0, 1, 3 };

            double[] coefs2 = { 2, 1 };
            int[] powers2 = { 0, 1 };

            Polynomial p1 = new Polynomial(coefs1, powers1);
            Polynomial p2 = new Polynomial(coefs2, powers2);
            // Act
            p1 = p1.SubPol(p2);
            //Assert
            Assert.AreEqual("3 + 2x^1 + x^3", p1.ToString());
        }

        [TestMethod()]
        public void SubPol_SubtractFromEmptyTest()
        {
            //Arrange
            double[] coefs1 = { };
            int[] powers1 = { };

            double[] coefs2 = { 2, 1 };
            int[] powers2 = { 0, 1 };

            Polynomial p1 = new Polynomial(coefs1, powers1);
            Polynomial p2 = new Polynomial(coefs2, powers2);
            // Act
            p1 = p1.SubPol(p2);
            //Assert
            Assert.AreEqual("-2 - x^1", p1.ToString());
        }

        [TestMethod()]
        public void SumPol_AddTwoPolynomials_CorrectResult()
        {
            // Arrange
            double[] coefs1 = { 2, 3, 4 };
            int[] powers1 = { 2, 1, 0 };
            double[] coefs2 = { 1, 5, 2 };
            int[] powers2 = { 2, 1, 0 };
            Polynomial poly1 = new Polynomial(coefs1, powers1);
            Polynomial poly2 = new Polynomial(coefs2, powers2);
            // Act
            Polynomial result = poly1.SumPol(poly2);
            // Assert
            double[] expectedCoefs = { 3, 8, 6 }; // {2+1, 3+5, 4+2}
            int[] expectedPowers = { 2, 1, 0 };
            CollectionAssert.AreEqual(expectedCoefs, result.Coefs);
            CollectionAssert.AreEqual(expectedPowers, result.Powers);
        }

        [TestMethod()]
        public void SumPol_AddPolynomialWithDifferentPowers_CorrectResult()
        {
            // Arrange
            double[] coefs1 = { 2, 3, 4 };
            int[] powers1 = { 2, 1, 0 };
            double[] coefs2 = { 1, 5, 2 };
            int[] powers2 = { 3, 2, 0 };
            Polynomial poly1 = new Polynomial(coefs1, powers1);
            Polynomial poly2 = new Polynomial(coefs2, powers2);
            // Act
            Polynomial result = poly1.SumPol(poly2);
            // Assert
            double[] expectedCoefs = {1, 7, 3, 6};
            int[] expectedPowers = {3, 2, 1, 0};
            CollectionAssert.AreEqual(expectedCoefs, result.Coefs);
            CollectionAssert.AreEqual(expectedPowers, result.Powers);
        }

        [TestMethod()]
        public void SumPol_AddToEmptyPolynomial_CorrectResult()
        {
            // Arrange
            double[] coefs = { 2, 3, 4 };
            int[] powers = { 2, 1, 0 };
            Polynomial poly1 = new Polynomial(coefs, powers);
            Polynomial poly2 = new Polynomial();
            // Act
            Polynomial result = poly1.SumPol(poly2);
            // Assert
            CollectionAssert.AreEqual(poly1.Coefs, result.Coefs);
            CollectionAssert.AreEqual(poly1.Powers, result.Powers);
        }

        [TestMethod()]
        public void SumPol_AddNullPolynomial_ThrowsException()
        {
            // Arrange
            double[] coefs = { 2, 3, 4 };
            int[] powers = { 2, 1, 0 };
            Polynomial poly1 = new Polynomial(coefs, powers);
            // Act & Assert
            Assert.ThrowsException<NullReferenceException>(() => poly1.SumPol(null));
        }


        [TestMethod]
        public void Multi_MultiplyTwoPolynomials_CorrectResult()
        {
            // Arrange
            double[] coefs1 = { 2, 3 };
            int[] powers1 = { 2, 1 };
            double[] coefs2 = { 2, 3 };
            int[] powers2 = { 1, 0 };
            Polynomial poly1 = new Polynomial(coefs1, powers1);
            Polynomial poly2 = new Polynomial(coefs2, powers2);
            // Act
            Polynomial result = poly1.Multi(poly2);
            // Assert
            Assert.AreEqual("4x^3 + 12x^2 + 9x^1", result.ToString());
        }

        [TestMethod]
        public void Multi_MultiplyWithEmptyPolynomial_EmptyResult()
        {
            // Arrange
            double[] coefs1 = { 2, 3 };
            int[] powers1 = { 2, 1 };
            Polynomial poly1 = new Polynomial(coefs1, powers1);
            Polynomial poly2 = new Polynomial();
            // Act
            Polynomial result = poly1.Multi(poly2);
            // Assert
            Assert.AreEqual("0", result.ToString());
        }

        [TestMethod]
        public void Multi_MultiplyWithZeroPolynomial_ZeroResult()
        {
            // Arrange
            double[] coefs1 = { 2, 3 };
            int[] powers1 = { 2, 1 };
            double[] coefs2 = { 0, 0 };
            int[] powers2 = { 1, 0 };
            Polynomial poly1 = new Polynomial(coefs1, powers1);
            Polynomial poly2 = new Polynomial(coefs2, powers2);
            // Act
            Polynomial result = poly1.Multi(poly2);
            // Assert
            Assert.AreEqual("0", result.ToString());
        }

        [TestMethod]
        public void Multi_MultiplyTwoZeroPolynomials_ZeroResult()
        {
            // Arrange
            double[] coefs1 = { 0, 0 };
            int[] powers1 = { 2, 1 };
            double[] coefs2 = { 0, 0 };
            int[] powers2 = { 1, 0 };
            Polynomial poly1 = new Polynomial(coefs1, powers1);
            Polynomial poly2 = new Polynomial(coefs2, powers2);
            // Act
            Polynomial result = poly1.Multi(poly2);
            // Assert
            Assert.AreEqual("0", result.ToString());
        }

        [TestMethod]
        public void ToString_EmptyPolynomial_ReturnsZero()
        {
            //Arrange
            Polynomial p = new Polynomial();
            //Act
            string result = p.ToString();
            //Assert
            Assert.AreEqual("0", result);
        }

        [TestMethod]
        public void ToString_SingleTermPolynomial_ReturnsCorrectString()
        {
            //Arrange
            double[] coefs = { 3 };
            int[] powers = { 2 };
            Polynomial p = new Polynomial(coefs, powers);
            // Act
            string result = p.ToString();
            //Assert
            Assert.AreEqual("3x^2", result);
        }

        [TestMethod]
        public void ToString_MultiTermPolynomial_ReturnsCorrectString()
        {
            //Arrange
            double[] coefs = { 3, -4, 5 };
            int[] powers = { 2, 1, 0 };
            Polynomial p = new Polynomial(coefs, powers);
            // Act
            string result = p.ToString();
            //Assert
            Assert.AreEqual("3x^2 - 4x^1 + 5", result);
        }

        [TestMethod]
        public void ToString_PolynomialWithZeros_ReturnsCorrectString()
        {
            //Arrange
            double[] coefs = { 3, 0, 5 };
            int[] powers = { 2, 1, 0 };
            Polynomial p = new Polynomial(coefs, powers);
            // Act
            string result = p.ToString();
            //Assert
            Assert.AreEqual("3x^2 + 5", result);
        }

        [TestMethod]
        public void ToString_PolynomialWithSingleZeroCoefficient_ReturnsZero()
        {
            //Arrange
            double[] coefs = { 0 };
            int[] powers = { 2 };
            Polynomial p = new Polynomial(coefs, powers);
            // Act
            string result = p.ToString();
            //Assert
            Assert.AreEqual("0", result);
        }


        [TestMethod()]
        public void Equals_SamePolynomials_ReturnsTrue()
        {
            //Arrange
            double[] coefs1 = { 3, 4, 5 };
            int[] powers1 = { 2, 1, 0 };
            double[] coefs2 = { 3, 4, 5 };
            int[] powers2 = { 2, 1, 0 };
            Polynomial poly1 = new Polynomial(coefs1, powers1);
            Polynomial poly2 = new Polynomial(coefs2, powers2);
            // Act & Assert
            Assert.IsTrue(poly1.Equals(poly2));
        }

        [TestMethod()]
        public void Equals_DifferentCoefficients_ReturnsFalse()
        {
            //Arrange
            double[] coefs1 = { 3, 4, 5 };
            int[] powers1 = { 2, 1, 0 };
            double[] coefs2 = { 3, 5, 5 };
            int[] powers2 = { 2, 1, 0 };
            Polynomial poly1 = new Polynomial(coefs1, powers1);
            Polynomial poly2 = new Polynomial(coefs2, powers2);
            // Act & Assert
            Assert.IsFalse(poly1.Equals(poly2));
        }

        [TestMethod()]
        public void Equals_DifferentPowers_ReturnsFalse()
        {
            //Arrange
            double[] coefs1 = { 3, 4, 5 };
            int[] powers1 = { 2, 1, 0 };
            double[] coefs2 = { 3, 4, 5 };
            int[] powers2 = { 2, 1, 1 };
            Polynomial poly1 = new Polynomial(coefs1, powers1);
            Polynomial poly2 = new Polynomial(coefs2, powers2);
            // Act & Assert
            Assert.IsFalse(poly1.Equals(poly2));
        }

        [TestMethod()]
        public void Equals_OnePolynomialLongerThanOther_ReturnsFalse()
        {
            //Arrande
            double[] coefs1 = { 3, 4, 5 };
            int[] powers1 = { 2, 1, 0 };
            double[] coefs2 = { 3, 4 };
            int[] powers2 = { 2, 1 };
            Polynomial poly1 = new Polynomial(coefs1, powers1);
            Polynomial poly2 = new Polynomial(coefs2, powers2);
            // Act & Assert
            Assert.IsFalse(poly1.Equals(poly2));
        }

        [TestMethod()]
        public void Equals_CompareToNull_ReturnsFalse()
        {
            //arrange
            double[] coefs1 = { 3, 4, 5 };
            int[] powers1 = { 2, 1, 0 };
            Polynomial poly1 = new Polynomial(coefs1, powers1);

            // Act & Assert
            Assert.IsFalse(poly1.Equals(null));
        }

        [TestMethod]
        public void GetHashCode_TwoEqualPolynomials_SameHashCode()
        {
            // Arrange
            double[] coefs1 = { 2, 3, 4 };
            int[] powers1 = { 2, 1, 0 };
            double[] coefs2 = { 2, 3, 4 };
            int[] powers2 = { 2, 1, 0 };

            Polynomial poly1 = new Polynomial(coefs1, powers1);
            Polynomial poly2 = new Polynomial(coefs2, powers2);

            // Act & Assert
            Assert.AreEqual(poly1.GetHashCode(), poly2.GetHashCode());
        }

        [TestMethod]
        public void GetHashCode_TwoDifferentPolynomials_DifferentHashCodes()
        {
            // Arrange
            double[] coefs1 = { 2, 3, 4 };
            int[] powers1 = { 2, 1, 0 };
            double[] coefs2 = { 2, 4, 4 };
            int[] powers2 = { 2, 1, 0 };

            Polynomial poly1 = new Polynomial(coefs1, powers1);
            Polynomial poly2 = new Polynomial(coefs2, powers2);

            // Act & Assert
            Assert.AreNotEqual(poly1.GetHashCode(), poly2.GetHashCode());
        }
    }
}