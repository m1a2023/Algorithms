using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Algorithms.models.Algorithms.models;

namespace AlgorithmsTests
{
    [TestClass]
    public class MultiplicationTests
    {
        Multiplication<BigInteger> mulInt = new();
        Multiplication<Double> mulDouble = new();

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
            BigInteger bigIntegerCheckMul = 1;
            foreach (var item in array) { bigIntegerCheckMul *= item; }

            /**
             *  Output 
             */
            Console.WriteLine("Execution " + array.GetType().Name + " array time: " + mulInt.GetExecutionTime(array));

            Assert.AreEqual(bigIntegerCheckMul, mulInt.Execute(array));
        }

        [TestMethod]
        public void ListTest()
        {
            /**
             *  Test Double list 
             */
            List<Double> list = new List<Double> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 1, 2, 999, 1000 };

            /**
             * 
             */
            Double listMul = 1;
            foreach (var item in list) { listMul *= item; }
            
            /**
             *  Output 
             */
            Console.WriteLine("Execution " + list.GetType().Name + " array time: " + mulDouble.GetExecutionTime(list));

            Assert.AreEqual(listMul, mulDouble.Execute(list));  
        }
    }
}
