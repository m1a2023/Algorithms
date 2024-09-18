using Algorithms.models.Algorithms.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.models.Generator;


namespace AlgorithmsTests
{
    [TestClass]
    public class BubbleSortTest
    {
        StructGenerator generator = new StructGenerator();
        
        [TestMethod]
        public void ExecutionTest()
        {
            BubbleSort<Int64> bubbleSort = new BubbleSort<Int64>();
            List<Int64> list = generator.GenerateList(10);

            bubbleSort.Execute(list);

            Console.WriteLine(bubbleSort.GetExecutionTime(list));
        }
    }
}
