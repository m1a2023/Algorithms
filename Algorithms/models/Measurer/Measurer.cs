using Algorithms.models.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.models.Measurer
{
	public class Measurer
	{
		public decimal MeasureExecutionTime<T>(AProcessingAlgorithm<T> algorithm, IList<T> data) 
			where T : INumber<T>
		{
			decimal res = 0;
			
			for (int i = 0; i < 5; i++)
				res += algorithm.GetExecutionTime();

			return res / 5;
		}

		public decimal MeasureExecutionTime<T>(ASortingAlgorithm<T> algorithm, IList<T> data)
			where T : INumber<T>
		{
			decimal res = 0;

			for (int i = 0; i < 5; i++)
				res += algorithm.GetExecutionTime();
		
			return res / 5;
		}
	}
}
