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
            long[] testArray = structGenerator.GenerateArray(10, 0, 100);
            
            foreach (var item in testArray) Console.Write(item + " ");
            
            timSort.Execute(testArray);

            Console.WriteLine();
            foreach (var item in testArray) Console.Write(item + " ");
        }
    }
}
