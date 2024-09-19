using System;
using System.Collections.Generic;
using System.Linq;
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

		[TestMethod]
		public void ExecuteTest()
		{
			var arr = new long[] { 2, 5 };

			var simple1  = new Pow.Simple<short>(2, 2);
			Console.WriteLine(simple1.ToString());

			var rec1 = new Pow.Recursive<Int128>(4, 40);
			Console.WriteLine(rec1.ToString());
		}
	}
}
