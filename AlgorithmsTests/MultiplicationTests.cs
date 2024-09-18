using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Algorithms.models.Algorithms.models;
using Algorithms.models.Generator;

namespace AlgorithmsTests
{
    [TestClass]
    public class MultiplicationTests
    {
        private readonly Multiplication<Int64> mulInt = new();
        private readonly Multiplication<long> mulDouble = new();
        
        private readonly StructGenerator structGenerator = new StructGenerator();

        [TestMethod]
        public void ArrayTest()
        {
            /**
             *  Test integer array
             */
            Int64[] array = structGenerator.GenerateArray(1_000_000);

            /**
             *  
             */
        
            Console.WriteLine("Execution " + array.GetType().Name + " array time: " + mulInt.GetExecutionTime(array));
        }

        [TestMethod]
        //GenerationListInt64Test()
        public void ListTest()
        {
            /**
             *  Test list 
             */
            List<long> list = structGenerator.GenerateList(1_000_000, 0, 19999);

            /**
             * 
             */
            Int64 listMul = 1;
            foreach (var item in list) { listMul *= item; }
            
            /**
             *  Output 
             */
            Console.WriteLine("Execution " + list.GetType().Name + " array time: " + mulDouble.GetExecutionTime(list));
        }
    }
}
