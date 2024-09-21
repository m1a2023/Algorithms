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
	public class PowTests
	{
		Pow.Simple<long> simple = new Pow.Simple<long>();
		Pow.Recursive<Int128> recursive = new Pow.Recursive<Int128>();	
		Pow.Quick<long> quick = new Pow.Quick<long>();
		Pow.ClassicQuick<long> cquick = new Pow.ClassicQuick<long>();

		[TestMethod]
		public void ExecuteTest()
		{
			var arr = new long[] { 2, 5 };

            var _byte = new Pow.Simple<byte>(3, 5);
            Console.WriteLine(_byte.ToString());

            var _simple  = new Pow.Simple<short>(2, 2);
			Console.WriteLine(_simple.ToString());

			var _rec = new Pow.Recursive<Int128>(4, 40);
			Console.WriteLine(_rec.ToString());

			//var _quick = new Pow.Quick<long>(2, 10);
			Console.WriteLine(new Pow.Quick<long> (2, 10).ToString());

			Console.WriteLine(new Pow.ClassicQuick<long>(10, 10).ToString());
		}

		[TestMethod]
		public void PowSimpleTests()
		{
			/*
			 * Tests of constructrors
			 */

			//Default constructor
			var simplePowD = new Pow.Simple<long>();
            Console.WriteLine(simplePowD.GetExecutionTime([32155l, 5]));

			//Extended constructor
			var simplePowE = new Pow.Simple<int>(25, 3);
			Console.WriteLine(simplePowE.ToString());

            /*
			 * arithmetic tests
			 */

            //BytePow
            var simplePowB = new Pow.Simple<byte>(3, 5);
			Console.WriteLine(simplePowB.ToString());
            string expectedResultB = "Result: 243 [System.Byte]";
            Assert.IsTrue(simplePowB.ToString().Contains(expectedResultB));

            //ShortPow
            var simplePowS = new Pow.Simple<short>(181, 2);
            Console.WriteLine(simplePowS.ToString());
            string expectedResultS = "Result: 32761 [System.Int16]";
            Assert.IsTrue(simplePowS.ToString().Contains(expectedResultS));

            //IntPow
            var simplePowI = new Pow.Simple<int>(321, 0);
            Console.WriteLine(simplePowI.ToString());
            string expectedResultI = "Result: 1 [System.Int32]";
            Assert.IsTrue(simplePowI.ToString().Contains(expectedResultI));

            //LongPow
            var simplePowL = new Pow.Simple<long>(321, 4);
            Console.WriteLine(simplePowL.ToString());
            string expectedResultL = "Result: 10617447681 [System.Int64]";
            Assert.IsTrue(simplePowL.ToString().Contains(expectedResultL));
        }

        [TestMethod]
        public void PowRecursiveTests()
        {
            /*
			 * Tests of constructrors
			 */

            //Default constructor
            var recursivePowD = new Pow.Recursive<long>();
            Console.WriteLine(recursivePowD.GetExecutionTime([32155l, 5]));

            //Extended constructor
            var recursivePowE = new Pow.Recursive<int>(25, 3);
            Console.WriteLine(recursivePowE.ToString());

            /*
			 * Arithmetic tests
			 */

            //BytePow
            var recursivePowB = new Pow.Recursive<byte>(3, 5);
            Console.WriteLine(recursivePowB.ToString());
            string expectedResultB = "Result: 243 [System.Byte]";
            Assert.IsTrue(recursivePowB.ToString().Contains(expectedResultB));

            //ShortPow
            var recursivePowS = new Pow.Recursive<short>(181, 0);
            Console.WriteLine(recursivePowS.ToString());
            string expectedResultS = "Result: 1 [System.Int16]";
            Assert.IsTrue(recursivePowS.ToString().Contains(expectedResultS));

            //IntPow
            var recursivePowI = new Pow.Recursive<int>(321, 3);
            Console.WriteLine(recursivePowI.ToString());
            string expectedResultI = "Result: 33076161 [System.Int32]";
            Assert.IsTrue(recursivePowI.ToString().Contains(expectedResultI));

            //LongPow
            var recursivePowL = new Pow.Recursive<long>(321, 4);
            Console.WriteLine(recursivePowL.ToString());
            string expectedResultL = "Result: 10617447681 [System.Int64]";
            Assert.IsTrue(recursivePowL.ToString().Contains(expectedResultL));

            //BigIntPow
            var recursivePowBI = new Pow.Recursive<BigInteger>(3221, 5);
            Console.WriteLine(recursivePowBI.ToString());
            string expectedResultBI = "Result: 346699826322180101 [System.Numerics.BigInteger]";
            Assert.IsTrue(recursivePowBI.ToString().Contains(expectedResultBI));
        }

        [TestMethod]
        public void PowQuickTests()
        {
            /*
			 * Tests of constructrors
			 */

            //Default constructor
            var quickPowD = new Pow.Quick<long>();
            Console.WriteLine(quickPowD.GetExecutionTime([32155l, 5]));

            //Extended constructor
            var quickPowE = new Pow.Quick<int>(25, 3);
            Console.WriteLine(quickPowE.ToString());

            /*
			 * Arithmetic tests
			 */

            //BytePow
            var quickPowB = new Pow.Quick<byte>(3, 1);
            Console.WriteLine(quickPowB.ToString());
            string expectedResultB = "Result: 3 [System.Byte]";
            Assert.IsTrue(quickPowB.ToString().Contains(expectedResultB));

            //ShortPow
            var quickPowS = new Pow.Quick<short>(181, 2);
            Console.WriteLine(quickPowS.ToString());
            string expectedResultS = "Result: 32761 [System.Int16]";
            Assert.IsTrue(quickPowS.ToString().Contains(expectedResultS));

            //IntPow
            var quickPowI = new Pow.Quick<int>(321, 3);
            Console.WriteLine(quickPowI.ToString());
            string expectedResultI = "Result: 33076161 [System.Int32]";
            Assert.IsTrue(quickPowI.ToString().Contains(expectedResultI));

            //LongPow
            var quickPowL = new Pow.Quick<long>(321, 0);
            Console.WriteLine(quickPowL.ToString());
            string expectedResultL = "Result: 1 [System.Int64]";
            Assert.IsTrue(quickPowL.ToString().Contains(expectedResultL));

            //BigIntPow
            var quickPowBI = new Pow.Quick<BigInteger>(3221, 5);
            Console.WriteLine(quickPowBI.ToString());
            string expectedResultBI = "Result: 346699826322180101 [System.Numerics.BigInteger]";
            Assert.IsTrue(quickPowBI.ToString().Contains(expectedResultBI));
        }

        [TestMethod]
        public void PowClassicQuickTests()
        {
            /*
			 * Tests of constructrors
			 */

            //Default constructor
            var quickPowD = new Pow.ClassicQuick<long>();
            Console.WriteLine(quickPowD.GetExecutionTime([32155l, 5]));

            //Extended constructor
            var quickPowE = new Pow.ClassicQuick<int>(25, 3);
            Console.WriteLine(quickPowE.ToString());

            /*
			 * Arithmetic tests
			 */

            //BytePow
            var classicQuickPowB = new Pow.ClassicQuick<byte>(3, 1);
            Console.WriteLine(classicQuickPowB.ToString());
            string expectedResultB = "Result: 3 [System.Byte]";
            Assert.IsTrue(classicQuickPowB.ToString().Contains(expectedResultB));

            //ShortPow
            var classicQuickPowS = new Pow.ClassicQuick<short>(181, 2);
            Console.WriteLine(classicQuickPowS.ToString());
            string expectedResultS = "Result: 32761 [System.Int16]";
            Assert.IsTrue(classicQuickPowS.ToString().Contains(expectedResultS));

            //IntPow
            var classicQuickPowI = new Pow.ClassicQuick<int>(321, 3);
            Console.WriteLine(classicQuickPowI.ToString());
            string expectedResultI = "Result: 33076161 [System.Int32]";
            Assert.IsTrue(classicQuickPowI.ToString().Contains(expectedResultI));

            //LongPow
            var classicQuickPowL = new Pow.ClassicQuick<long>(321, 4);
            Console.WriteLine(classicQuickPowL.ToString());
            string expectedResultL = "Result: 10617447681 [System.Int64]";
            Assert.IsTrue(classicQuickPowL.ToString().Contains(expectedResultL));

            //BigIntPow
            var classicQuickPowBI = new Pow.ClassicQuick<BigInteger>(3221, 5);
            Console.WriteLine(classicQuickPowBI.ToString());
            string expectedResultBI = "Result: 346699826322180101 [System.Numerics.BigInteger]";
            Assert.IsTrue(classicQuickPowBI.ToString().Contains(expectedResultBI));
        }
    }
}
