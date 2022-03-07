using NUnit.Framework;
using StringCalculator;
using System;

namespace UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void EmptyStringReturnsZero()
        {
            Assert.AreEqual(SCC.Calc(""), 0);
        }

        [Test]
        public void SingleNumberReturnsNumber()
        {
            Assert.AreEqual(SCC.Calc("5"), 5);
            Assert.AreEqual(SCC.Calc("0"), 0.0);
            Assert.AreEqual(SCC.Calc("76"), 76);
        }

        [Test]
        public void ReturnsSum()
        {
            Assert.AreEqual(SCC.Calc("0,0"), 0);
            Assert.AreEqual(SCC.Calc("0,12"), 12);
            Assert.AreEqual(SCC.Calc("1,12"), 13);
            Assert.AreEqual(SCC.Calc("45,125"), 170);
        }

        [Test]
        public void ReturnsSum2()
        {
            Assert.AreEqual(SCC.Calc("0\n0"), 0);
            Assert.AreEqual(SCC.Calc("0\n12"), 12);
            Assert.AreEqual(SCC.Calc("1\n12"), 13);
            Assert.AreEqual(SCC.Calc("45\n125"), 170);
        }

        [Test]
        public void ReturnsSum3()
        {
            Assert.AreEqual(SCC.Calc("0\n0,0"), 0);
            Assert.AreEqual(SCC.Calc("2,0\n12"), 14);
            Assert.AreEqual(SCC.Calc("5\n1\n12"), 18);
            Assert.AreEqual(SCC.Calc("45\n125,5"), 175);
        }

        [Test]
        public void NegativeThrows()
        {
            Assert.Throws<ArgumentException>(() => { SCC.Calc("-54"); });
            Assert.Throws<ArgumentException>(() => { SCC.Calc("-43,5"); });
            Assert.Throws<ArgumentException>(() => { SCC.Calc("5\n-1\n12"); });
            Assert.Throws<ArgumentException>(() => { SCC.Calc("45\n125,-5"); });
        }

        [Test]
        public void IgnoreAbove1000()
        {
            Assert.AreEqual(SCC.Calc("1000\n0,0"), 1000);
            Assert.AreEqual(SCC.Calc("2,0\n1001"), 2);
            Assert.AreEqual(SCC.Calc("5\n1\n120000"), 6);
            Assert.AreEqual(SCC.Calc("45\n475893,47893"), 45);
        }

        [Test]
        public void AdditionalSeparator()
        {
            Assert.AreEqual(SCC.Calc("//$1000$6$5"), 1011);
            Assert.Throws<ArgumentException>(() => { SCC.Calc("//[2[0[1001"); });
            Assert.AreEqual(SCC.Calc("//#5#1,120000"), 6);
            Assert.AreEqual(SCC.Calc("//;45;475893,47893"), 45);
        }

        [Test]
        public void AdditionalLongSeparator()
        {
            Assert.AreEqual(SCC.Calc("//[$:]1000$:6$:5"), 1011);
            Assert.AreEqual(SCC.Calc("//[#abs]5#abs1,120000"), 6);
            Assert.AreEqual(SCC.Calc("//[;]45;475893,47893"), 45);
        }
    }
}