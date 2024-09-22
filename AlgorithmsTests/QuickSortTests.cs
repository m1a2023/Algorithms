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
    public class QuickSortTests
    {
        QuickSort<int> qs = new QuickSort<int>();
        StructGenerator generator = new StructGenerator();

        [TestMethod]
        public void ExecutionTest()
        {
            var qs = new QuickSort<long>(generator.GenerateArray(10, 0, 100));
            Console.WriteLine(qs.ToString()); 
            Console.WriteLine(qs.GetExecutionTime());
        }
    }
}
