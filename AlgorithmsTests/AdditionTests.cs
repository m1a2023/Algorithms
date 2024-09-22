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

        StructGenerator sG = new StructGenerator();

        [TestMethod]
        public void ConstructorsTest() 
        {
            //Default constructor
            var additionDef = new Addition<long>();
            Assert.IsNotNull(additionDef);
            additionDef.GetExecutionTime(sG.GenerateArray(10000));

            //Extended constructor for array
            int[] dataArr = new[] {1, 2, 3, 4};
            var additionExtArr = new Addition<int>(dataArr);
            string output = additionExtArr.ToString();
            string expectedOutput = "Original collection: 1, 2, 3, 4 [System.Int32[]]";
            string expectedResult = "Result: 10 [System.Int32]";
            Assert.IsTrue(output.Contains(expectedOutput));
            Assert.IsTrue(output.Contains(expectedResult));
            Console.WriteLine(output);

            //Extended constructor for list
            List<long> dataList = new List<long> { 1, 2, 3, 4 };
            var additionExtList = new Addition<long>(dataList);
            output = additionExtList.ToString();
            expectedOutput = "Original collection: 1, 2, 3, 4 " +
                "[System.Collections.Generic.List`1[System.Int64]]";
            expectedResult = "Result: 10 [System.Int64]";
            Assert.IsTrue(output.Contains(expectedOutput));
            Assert.IsTrue(output.Contains(expectedResult));
            Console.WriteLine(output);
        }

        [TestMethod]
        public void AdditionCorrectAnswersTest()
        {
            for (int i = 0; i < 100; i++)
            {
                var array = sG.GenerateList(2000, -10000, 200000);
                var answerTest1 = new Addition<long>(array);
                //Console.WriteLine(answerTest1.ToString());
                Assert.AreEqual(answerTest1.GetResult(), array.Sum());
            }
        }

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
            Console.WriteLine("Execution " + array.GetType().Name + " array time: " + sumBigInteger.GetExecutionTime(array));
        
            Console.WriteLine(new Addition<long> ([ 19, 90, 100 ]).ToString());
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