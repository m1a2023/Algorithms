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
            Console.WriteLine(
                    new BubbleSort<int>().GetExecutionTime(
                            generator.GenerateArray<int>(20000, 1, 1000) 
                        )
                );
            Console.WriteLine(
                    new BubbleSort<int> (generator.GenerateArray<int>(20000, 1, 100)
                    ).ToString() 
                );

        }
    }
}
