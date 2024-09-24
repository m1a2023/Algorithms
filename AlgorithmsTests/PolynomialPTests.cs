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
		StructGenerator generator = new StructGenerator();	

		[TestMethod]
		public void ExecuteTest()
		{

			Console.WriteLine(new PolynomialP.Naive<decimal> ([190, 10, 10, 22, 100]));

			Console.WriteLine(new PolynomialP.Horner<decimal> ([190, 10, 10, 22, 100]));
		}
	}
}
