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
            List<Int64> list = generator.GenerateList(10, 0, 100);

            bubbleSort.Execute(list);
            Console.WriteLine(String.Join(", ", list));
            //Console.WriteLine(bubbleSort.GetExecutionTime(list));

            //Console.WriteLine(new BubbleSort<long>([90, 11, 39, 0]).ToString());

            Console.WriteLine(new BubbleSort<long>(generator.GenerateArray(10, 0, 100)).ToString()); 
            Console.WriteLine(new BubbleSort<long>(generator.GenerateArray(10, 0, 100)).GetExecutionTime()); 
        }
    }
}
