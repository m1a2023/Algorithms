using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.models.Algorithms.models;
using Algorithms.models.Generator;

namespace AlgorithmsTests
{
	[TestClass]
	public class PolynomialPTests
	{
		PolynomialP.Naive<long> naive = new PolynomialP.Naive<long>();
		StructGenerator generator = new StructGenerator();	

		[TestMethod]
		public void ExecuteTest()
		{
			var arr = new int[] { 2, 5 };

		}
	}
}
