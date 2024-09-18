using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.models.Algorithms.models;


namespace AlgorithmsTests
{
    [TestClass]
    public class QuickSortTests
    {
        QuickSort<int> qs = new QuickSort<int>();

        [TestMethod]
        public void ExecutionTest()
        {
            int[] ints = { 10000000, 99, 91, 100, 23, 51, 0 };
            
            qs.Execute(ints);

            foreach (int i in ints) Console.WriteLine(i);
        }
    }
}
