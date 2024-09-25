using Algorithms.models.Algorithms.models;
using System.Diagnostics;
using System.Numerics;
using Algorithms.models.Generator;

namespace AlgorithmsTests
{
    [TestClass]
    public class AdditionTests
    {
        Addition<BigInteger> sumBigInteger = new Addition<BigInteger>();
        Addition<Double> sumDouble = new Addition<Double>();
        
        [TestMethod]
        public void ArrayTest()
        {
            /**
             *  Test integer array
             */
            BigInteger[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 90 };

            /**
             *  Calculating elements sum
             */
            BigInteger bigIntegerCheckSum = 0, Zero = 0;
            foreach (var item in array) { bigIntegerCheckSum += item; }

            /**
             *  Output 
             */
            Console.WriteLine("Execution " + array.GetType().Name + " array time: " + sumBigInteger.GetExecutionTime([10, 10, 10]));
        }

        [TestMethod]
        public void ListTest()
        {
            /**
             *  Test Double list
             */
            List<Double> list = new List<Double> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 1, 2, 999, 1000 };
                
            /**
             *  Output
             */
            Console.WriteLine("Execution " + list.GetType().Name + " list time: " + sumDouble.GetExecutionTime(list));
        }
   }
}