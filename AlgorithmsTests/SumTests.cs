using Algorithms.models;
using System.Diagnostics;
using System.Numerics;

namespace AlgorithmsTests
{
    [TestClass]
    public class SumTests
    {
        Sum<BigInteger> sumBigInteger = new Sum<BigInteger>();
        Sum<Double> sumDouble = new Sum<Double>();
        
        [TestMethod]
        public void ArrayTest()
        {
            /**
             *  Test integer array
             */
            BigInteger[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 90 };
            
            /**
             *  
             */
            Console.WriteLine("Execution " + array.GetType().Name + " array time: " + sumBigInteger.GetExecutionTime(array));
        }

        [TestMethod]
        public void ListTest()
        {
            /**
             *  Test integer list
             */
            List<Double> list = new List<Double> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 1, 2, 999, 1000 };

            Console.WriteLine("Execution " + list.GetType().Name + " list time: " + sumDouble.GetExecutionTime(list));
        }
   }
}