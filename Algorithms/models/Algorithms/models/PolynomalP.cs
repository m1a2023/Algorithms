using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.models.Algorithms.models
{
	public static class PolynomialP
	{
		//Naive<T> naive = new Naive<T>
		//Horner<T> horner = new Horner<T>

		public class Naive<T> : Algorithm<T> where T : INumber<T>
		{
			public override void Execute(IList<T> data)
			{
				
				return;
			}

			private void /*T*/ Straight(IList<T> data)
			{
				T res = data[0];

				for (int i = 1; i < data.Count; i++)
				{
					//res += data[i] * Math.Pow(1.5, i - 1);
				}
					
			}

		}   
		public class Horner<T> //:Algorithm<T> where T : INumber<T>
		{
			
		}
	}
}
