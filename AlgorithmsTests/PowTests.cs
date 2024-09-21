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
		Pow.Quick<long> quick = new Pow.Quick<long>();
		Pow.ClassicQuick<long> cquick = new Pow.ClassicQuick<long>();

		[TestMethod]
		public void ExecuteTest()
		{
			var arr = new long[] { 2, 5 };
			
			var _simple  = new Pow.Simple<short>(2, 2);
			Console.WriteLine(_simple.ToString());

			var _rec = new Pow.Recursive<Int128>(4, 40);
			Console.WriteLine(_rec.ToString());

			//var _quick = new Pow.Quick<long>(2, 10);
			Console.WriteLine(new Pow.Quick<long> (2, 10).ToString());

			Console.WriteLine(new Pow.ClassicQuick<long>(10, 10).ToString());
		}
	}
}
