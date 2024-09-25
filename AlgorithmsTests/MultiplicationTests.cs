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
            /**
             *  Test integer array
             */
            BigInteger[] array = new BigInteger[] { 0, 10000000000000, 1000000000000, 2034987847, 278452895827094857, 2938457928759237, 02937459248290745, 923485729083759832, 928347592873590274, 98472983752389, 283974582705};
            /**
             *  
             */
        
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
