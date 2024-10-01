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
        private readonly Multiplication<BigInteger> mulInt = new();
        private readonly Multiplication<long> mulDouble = new();
        
        private readonly StructGenerator structGenerator = new StructGenerator();

        [TestMethod]
        public void ArrayTest()
        {
            Console.WriteLine(
                    new Multiplication<int> (
                        structGenerator.GenerateArray<int>(10, 0, 10)
                        ).ToString());
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
