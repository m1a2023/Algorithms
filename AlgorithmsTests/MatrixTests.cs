using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.models.Generator;
using Algorithms.models.Matrix;

namespace AlgorithmsTests
{
	[TestClass]
	public class MatrixTests
	{
		[TestMethod]
		public void MatrixTest()
		{
			SquareMatrixMultiplication<int> smm = new SquareMatrixMultiplication<int>();


			Console.WriteLine(
				smm.Execute(smm.GetRandomMatrix(5, 0, 1000), smm.GetRandomMatrix(5, 0, 1000)).ToString()
				);

			Console.WriteLine(
				smm.GetExecutionTime(
					new SquareMatrixMultiplication<int>().GetRandomMatrix(5, 0, 1000),
					new SquareMatrixMultiplication<int>().GetRandomMatrix(5, 0, 1000)
					)
				);
		}

	}
}
