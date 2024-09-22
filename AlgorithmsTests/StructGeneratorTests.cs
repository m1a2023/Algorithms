using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.models.Generator;

namespace AlgorithmsTests
{
    /// <summary>
    /// test
    /// </summary>
    [TestClass]
    public class StructGeneratorTests
    {
        StructGenerator structGenerator = new StructGenerator();
        
        [TestMethod]
        public void ArrayGenerationWithLimitsTest()
        {
            var size = 10;
            var minValue = -10;
            var maxValue = 1000;

            var arrayInt = structGenerator.GenerateArray(size, minValue, maxValue);
            Assert.AreEqual(size, arrayInt.Length);
            Assert.IsTrue(minValue <= arrayInt.Min());
            Assert.IsTrue(maxValue >= arrayInt.Max());
        }

        [TestMethod]
        public void ArrayGenerationOnlyWithSizeTest()
        {
            var size = 20;
            var arrayInt2 = structGenerator.GenerateArray(size);
            Assert.AreEqual(size, arrayInt2.Length);
            Assert.IsTrue(0 <= arrayInt2.Min());
            Assert.IsTrue(long.MaxValue >= arrayInt2.Max());
        }

        [TestMethod]
        public void ListGenerationWithLimitsTest() 
        {
            var size = 10;
            var minValue = -10;
            var maxValue = 1000;

            var listInt = structGenerator.GenerateList(size, minValue, maxValue);
            Assert.AreEqual(size, listInt.Count);
            Assert.IsTrue(minValue <= listInt.Min());
            Assert.IsTrue(maxValue >= listInt.Max());
        }

        [TestMethod]
        public void ListGenerationOnlyWithSizeTest()
        {
            var size = 20;
            var listInt2 = structGenerator.GenerateList(size);
            Assert.AreEqual(size, listInt2.Count);
            Assert.IsTrue(0 <= listInt2.Min());
            Assert.IsTrue(long.MaxValue >= listInt2.Max());
        }

        [TestMethod]
        public void ZeroSizeTests() 
        {
            var arrayInt = structGenerator.GenerateArray(0);
            Assert.AreEqual(0, arrayInt.Length);

            var listInt = structGenerator.GenerateList(0);
            Assert.AreEqual(0, listInt.Count);
        }

        [TestMethod]
        public void NegativeSizeTests()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => structGenerator.GenerateArray(-4));

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => structGenerator.GenerateList(-4));
        }
    }
}
