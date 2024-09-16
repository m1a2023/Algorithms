using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.models.Generator;

namespace AlgorithmsTests
{
    [TestClass]
    public class StructGeneratorTests
    {
        StructGenerator structGenerator = new StructGenerator();
        
        [TestMethod]
        public void ArrayGenerationTest()
        {
            var sg = structGenerator.GenerateArray(10, 0, 1000);

        }
    }
}
