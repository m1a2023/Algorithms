using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Algorithms.models.Algorithms.models
{
	/// <summary>Implementation of polynomial algorithm</summary>
	public static class PolynomialP
	{
		/// <summary>Implementation of naive polynomial algorithm</summary>
		/// <typeparam name="T"></typeparam>
		public class Naive<T> : AProcessingAlgorithm<T>
			where T : INumber<T>, IFloatingPoint<T>
		{
			/// <summary>Default constructor</summary>
			public Naive() { }
			
			/// <summary>Extended constructor</summary>
			/// <param name="Data"></param>
			public Naive(IList<T> Data) : base(Data) { }

			/// <summary>General method that executes algorithm</summary>
			/// <param name="data">Value collection, implemented via ICollection</param>
			public override void Execute(IList<T> data)
			{
				if (data.Count == 0)
					throw new ArgumentException("Invalid elements quantity exception");
				
				Calculate(data);
			}

            public override T Process(IList<T> Data)
            {
                return Calculate(Data);
            }

            private T Calculate(IList<T> data)
			{
				T res = T.Zero;

				for (int i = 0; i < data.Count; i++)
				{
					res += data[i] * T.CreateChecked(Math.Pow(1.5, data.Count - i - 1));
				}
				
				return res;
			}
        }   
		public class Horner<T> : AProcessingAlgorithm<T>
			where T : INumber<T>
		{
			/// <summary>Default constructor</summary>
			public Horner() { }
			
			/// <summary>Extended constructor</summary>
			/// <param name="Data"></param>
			public Horner(IList<T> Data) : base(Data) { }
			
			/// <summary>General method that executes algorithm</summary>
			/// <param name="data">Value collection, implemented via ICollection</param>
            public override void Execute(IList<T> data)
            {
				Calculate(data);
            }

            public override T Process(IList<T> Data)
            {
				return Calculate(Data);
            }

            private T Calculate(IList<T> data)
			{
				T res = data[0];
				T x = T.CreateChecked(1.5);

				for (int i = 1; i < data.Count; i++)
				{
					res = res * x + data[i];
				}

				return res;
			}
		}
	}
}
