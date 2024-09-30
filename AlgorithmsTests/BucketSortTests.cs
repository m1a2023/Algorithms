using Algorithms.models.Algorithms.models;
using Algorithms.models.Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsTests
{
    [TestClass]
    public class BucketSortTests
    {
        BucketSort<int> bucketSort = new BucketSort<int>();
        StructGenerator generator = new StructGenerator();

        /// <summary>Test execution and output of the bucket sort</summary>
        [TestMethod]
        public void ExecutionTest()
        {
            // Generate a random array with 1,000 elements
            var _bucketSort = new BucketSort<int>(generator.GenerateArray<int>(1_000, 0, 1000));

            // Execute sorting and display the result
            Console.WriteLine(_bucketSort.ToString());
        }
    }
}
