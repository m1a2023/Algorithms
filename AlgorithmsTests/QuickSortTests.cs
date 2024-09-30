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
            var _qs = new QuickSort<int>(generator.GenerateArray<int>(1_000_000, 0, 1000));

            Console.WriteLine(_qs.ToString());
        }
    }
}
