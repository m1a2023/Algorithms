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
        Multiplication<Int64> mulInt = new();
        Multiplication<Int64> mulDouble = new();
        
        StructGenerator structGenerator = new StructGenerator();

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
            Int64 bigIntegerCheckMul = 1;
            foreach (var item in array) { bigIntegerCheckMul *= item; }

            /**
             *  Output 
             */
            Console.WriteLine("Execution " + array.GetType().Name + " array time: " + mulInt.GetExecutionTime(array));
        }

        [TestMethod]
        public void ListTest()
        {
            /**
             *  Test list 
             */
            List<Int64> list = structGenerator.GenerateList(1_000_000);

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
