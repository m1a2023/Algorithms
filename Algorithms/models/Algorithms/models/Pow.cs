using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.models.Algorithms.models
{
	public static class Pow
	{
		/// <summary> TODO </summary>
		/// <typeparam name="T">Supports Integer types between short and Int64</typeparam>
		public class Simple<T> : Algorithm<T> where T : INumber<T>
		{
			protected T Base { get; private set; }
			protected T Exponent { get; private set; }
			protected T Result { get; private set; }
			protected decimal Time { get; private set; }
			
			/// <summary>Default constructor</summary>
			public Simple() { }
				
			/// <summary>Extended constructor</summary>
			/// <param name="Base"></param>
			/// <param name="Exponent"></param>
			public Simple(T Base, T Exponent)
			{
				this.Base = Base;
				this.Exponent = Exponent; 
				Result = Pow(Base, Exponent);
			}

			public override void Execute(IList<T> data)
			{
				Pow(data[0], data[1]);
			}
			
			private T Pow(T factor, T exponent)
			{
				T res = T.One;
				
				for (int i = 0; i < Convert.ToInt64(exponent); i++)
				{
					res *= factor;
				}  

				return res;
			}
			
			private Int64 Pow(Int64 factor, Int64 exponent) => Pow(Convert.ToInt64(factor), Convert.ToInt64(exponent));
			private decimal Pow(double factor, double exponent) => Pow(Convert.ToDouble(factor), Convert.ToDouble(exponent));
			
			/// <summary>String information representation</summary>
			/// <returns>String of fields</returns>
			public override string ToString()
            {
				return $"Base: {Base} [{Base.GetType()}], Exponent: {Exponent} [{Exponent.GetType()}], \n" +
					$"Result: {Result} [{Result.GetType()}], Time: {GetExecutionTime([Base, Exponent])}ms";
            }			
		}
		
		/// <summary> TODO </summary>
		/// <typeparam name="T">Supports Integer types between short and Int128</typeparam>
		public class Recursive<T> : Algorithm<T> where T : INumber<T>
		{
			protected T Base { get; private set; }
			protected T Exponent { get; private set; }
			protected T Result { get; private set; }
			protected decimal Time { get; private set; }

			/// <summary>Default constructor</summary>
			public Recursive() { }

			/// <summary>Extended constructor</summary>
			/// <param name="Base"></param>
			/// <param name="Exponent"></param>
			public Recursive(T Base, T Exponent)
            {
				this.Base = Base;
				this.Exponent = Exponent; 
				Result = Pow(Base, Exponent);
            }
			
            public override void Execute(IList<T> data)
			{
				if (data.Count != 2)
					throw new ArgumentException("Invalid elements quantity exception");
				
				Pow(data[0], data[1]);
			}
			
			private T Pow(T factor, T exponent)
			{
				if (exponent == T.Zero) return T.One;

				T f = Pow(factor, exponent / T.CreateChecked(2));

				if (exponent % T.CreateChecked(2) == T.One)
					return f * f * factor;
				else
					return f * f;
			}

			private Int128 Pow(Int64 factor, Int64 exponent) => Pow(Convert.ToInt64(factor), Convert.ToInt64(exponent));
			private decimal Pow(double factor, double exponent) => Pow(Convert.ToDouble(factor), Convert.ToDouble(exponent));
			
			/// <summary>String information representation</summary>
			/// <returns>String of fields</returns>
            public override string ToString()
            {
				return $"Base: {Base} [{Base.GetType()}], Exponent: {Exponent} [{Exponent.GetType()}], \n" +
					$"Result: {Result} [{Result.GetType()}], Time: {GetExecutionTime([Base, Exponent])}ms";
            }
        }

		public class Quick
		{

		}

		public class ClassicQuick
		{

		}
	}
}
