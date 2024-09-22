using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.models.Generator;

namespace AlgorithmsTests
{
    [TestClass]
    public class DataGeneratorTests
    {
        DataGenerator dataGenerator = new DataGenerator();

        [TestMethod]
        public void GetRandomPositiveInt64Tests()
        {
            var randomUInt64 = dataGenerator.GetRandomPositiveInt64();
            Assert.IsTrue(randomUInt64 > 0 && randomUInt64 < Int64.MaxValue);
            Console.WriteLine(randomUInt64);
        }

        [TestMethod]
        public void GetRandomInt64Tests()
        {
            var randomInt64 = dataGenerator.GetRandomInt64();
            Assert.IsTrue(randomInt64 > Int32.MinValue && randomInt64 < Int32.MaxValue);
            Console.WriteLine(randomInt64);

            randomInt64 = dataGenerator.GetRandomInt64(-215151, 877722);
            Assert.IsTrue(randomInt64 > -215151 && randomInt64 < 877722);
            Console.WriteLine(randomInt64);
        }

        [TestMethod]
        public void ListGeneration()
        {
            var randomDouble = dataGenerator.GetRandomDouble();
            Assert.IsTrue(randomDouble > 0 && randomDouble < 1);
            Console.WriteLine(dataGenerator.GetRandomDouble());

            Console.WriteLine(dataGenerator.GetRandomDouble(7));              
        }
    }
}
