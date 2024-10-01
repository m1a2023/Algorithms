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
		[TestMethod]
		public void ExecuteTest()
		{
			Console.WriteLine(
				new Pow.Quick<long>(2, 5).ToString()
				);
		}
	}
}
