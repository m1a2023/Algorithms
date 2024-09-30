using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.models.Algorithms.models;
using Algorithms.models.Generator;

namespace AlgorithmsTests
{
    [TestClass]
    public class TimSortTests
    {
        private readonly TimSort<long> timSort = new();
        private readonly StructGenerator structGenerator = new();
        
        [TestMethod] 
        public void ExecuteTest()
        {
            Console.WriteLine(new TimSort<int> (new StructGenerator().GenerateArray<int>(1, 0, 1000000)).ToString());
            Console.WriteLine(new TimSort<int> (new StructGenerator().GenerateArray<int>(1_000_000, 0, 1000000)).ToString());
        }   
    }
}
