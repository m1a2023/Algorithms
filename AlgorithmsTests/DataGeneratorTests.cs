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
        public void GetRandomInt64Tests()
        {
            Console.WriteLine(dataGenerator.GetRandomInt64());              
        }

        [TestMethod]
        public void ListGeneration()
        {
            Console.WriteLine(dataGenerator.GetRandomDouble(10));              
        }
    }
}
