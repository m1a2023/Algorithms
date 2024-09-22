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
		public class Naive<T> : Algorithm<T> 
			where T : INumber<T>, IFloatingPoint<T>
		{
			protected IList<T> Data { get; private set; } 
			protected T Result { get; private set; }
		
			/// <summary>Default constructor</summary>
			public Naive() { }
			
			/// <summary>Extended constructor</summary>
			/// <param name="Data"></param>
			public Naive(IList<T> Data)
			{
				this.Data = Data;
				Result = Calculate(this.Data);
			}

			public T GetResult()
			{
				if (Result == default) throw new ArgumentException("Field Result has not any value. Use Extended constructor");
				return Result;
			}

			/// <summary>General method that executes algorithm</summary>
			/// <param name="data">Value collection, implemented via ICollection</param>
			public override void Execute(IList<T> data)
			{
				if (data.Count == 0)
					throw new ArgumentException("Invalid elements quantity exception");
				
				Calculate(data);
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
			
			/// <summary>Additional method for extended constructor</summary>
			/// <returns>Execution algorithm time in milliseconds</returns>
			public decimal GetExecutionTime()
			{
				Stopwatch stopwatch = Stopwatch.StartNew();

				Execute(Data);

				stopwatch.Stop();

				return new decimal(stopwatch.Elapsed.TotalMilliseconds);
			}

			/// <summary>String information representation</summary>
			/// <returns>String of fields</returns>
            public override string ToString()
            {
				string data = String.Join(", ", Data);
				return $"Original collection: {data} [{Data.GetType()}]\n" +
					$"Result: {Result} [{Result.GetType()}]\n" +
					$"Execution time: {GetExecutionTime()}";
            }
        }   
		public class Horner<T> : Algorithm<T> 
			where T : INumber<T>
		{
			protected IList<T> Data { get; private set; } 
			protected T Result { get; private set; }

			/// <summary>Default constructor</summary>
			public Horner() { }

			public Horner(IList<T> Data)
			{
				this.Data = Data;
				Result = Calculate(this.Data);
			}

			public T GetResult()
			{
				if (Result == default) throw new ArgumentException("Field Result has not any value. Use Extended constructor");
				return Result;
			}
			
			/// <summary>General method that executes algorithm</summary>
			/// <param name="data">Value collection, implemented via ICollection</param>
            public override void Execute(IList<T> data)
            {
				Calculate(data);
            }

            public void Execute()
            {
				Calculate(Data);
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

			/// <summary>Additional method for extended constructor</summary>
			/// <returns>Execution algorithm time in milliseconds</returns>
			public decimal GetExecutionTime()
			{
				Stopwatch stopwatch = Stopwatch.StartNew();

				Execute(Data);

				stopwatch.Stop();

				return new decimal(stopwatch.Elapsed.TotalMilliseconds);
			}

			/// <summary>String information representation</summary>
			/// <returns>String of fields</returns>
            public override string ToString()
			{
				string data = String.Join(", ", Data);
				return $"Original collection: {data} [{Data.GetType()}]\n" +
					$"Result: {Result} [{Result.GetType()}]\n" +
					$"Execution time: {GetExecutionTime()}";
			}
		}
	}
}
