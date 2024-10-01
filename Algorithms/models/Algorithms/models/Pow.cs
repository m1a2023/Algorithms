using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.models.Algorithms.models
{
	/// <summary>Implementation of pow</summary>
	public static class Pow
	{
		/// <summary>Implementation of simple pow algorithm</summary>
		/// <typeparam name="T">Supports Integer types between short and Int64</typeparam>
		public class Simple<T> : APow<T>
			where T : INumber<T>, IBinaryInteger<T>
		{
			/// <summary>Default constructor</summary>
			public Simple() { }

			/// <summary>Extended constructor</summary>
			/// <param name="factor"></param>
			/// <param name="exponent"></param>
			public Simple(T factor, T exponent) : base(factor, exponent) { Execute(); }

			/// <summary>General method that executes algorithm</summary>
			public override void Execute() { Result = Process(Factor, Exponent); }

			/// <summary>General method that executes algorithm with provided parameters</summary>
			/// <param name="factor"></param>
			/// <param name="exponent"></param>
			public override void Execute(T factor, T exponent) { Process(factor, exponent); }

			/// <summary>Processes the calculation of power</summary>
			/// <param name="factor"></param>
			/// <param name="exponent"></param>
			/// <returns>The result of the power calculation</returns>
			public override T Process(T factor, T exponent) { return Pow(factor, exponent); }

			/// <summary></summary>
			/// <param name="factor"></param>
			/// <param name="exponent"></param>
			/// <returns></returns>
			public override T Pow(T factor, T exponent)
			{
				Steps = 0;
				T result = T.One;

				for (long i = 0; i < Convert.ToInt64(exponent); i++)
				{
					result *= factor;
					Steps++;
				}

				return result;
			}
		}

		/// <summary>Implementation of recursive pow algorithm</summary>
		/// <typeparam name="T">Supports Integer types between short and Int128</typeparam>
		public class Recursive<T> : APow<T>
			where T : INumber<T>, IBinaryInteger<T>
		{
			/// <summary>Default constructor</summary>
			public Recursive() { }

			/// <summary>Extended constructor</summary>
			/// <param name="factor"></param>
			/// <param name="exponent"></param>
			public Recursive(T factor, T exponent) : base(factor, exponent) { Execute(); }

			/// <summary>General method that executes algorithm</summary>
			/// <param name="factor"></param>
			/// <param name="exponent"></param>
			/// <exception cref="ArgumentException"></exception>
			public override void Execute(T factor, T exponent) { Process(factor, exponent); }
			
			/// <summary>General method that executes algorithm, for extended constructor</summary>
			public override void Execute() { Process(Factor, Exponent); }
			
			/// <summary></summary>
			/// <param name="factor"></param>
			/// <param name="exponent"></param>
			/// <returns></returns>
			public override T Process(T factor, T exponent) { return Pow(factor, exponent); }

			/// <summary></summary>
			/// <param name="factor"></param>
			/// <param name="exponent"></param>
			/// <returns></returns>
			public override T Pow(T factor, T exponent)
			{
				Steps++; 

				if (exponent == T.Zero) return T.One;

				T f = Pow(factor, exponent / T.CreateChecked(2));
				
				Steps++;
				
				if (exponent % T.CreateChecked(2) == T.One)
				{ 	
					Steps++;
					return f * f * factor;
				}	
				else
				{
					Steps++;
					return f * f;
				}
			}
		}

		/// <summary>Implementation of quick pow algorithm</summary>
		/// <typeparam name="T"></typeparam>
		public class Quick<T> : APow<T>
			where T : INumber<T>, IBinaryInteger<T>
		{
			/// <summary>Default constructor</summary>
			public Quick() { }

			/// <summary>Extended constructor</summary>
			/// <param name="factor"></param>
			/// <param name="exponent"></param>
			public Quick(T factor, T exponent) : base(factor, exponent) { Execute(); }

			/// <summary>General method that executes algorithm</summary>
			/// <param name="factor"></param>
			/// <param name="exponent"></param>
			/// <exception cref="ArgumentException"></exception>
			public override void Execute(T factor, T exponent) { Process(factor, exponent); }

			/// <summary>General method that executes algorithm, for extended constructor</summary>
			public override void Execute() { Process(Factor, Exponent); }

			/// <summary></summary>
			/// <param name="factor"></param>
			/// <param name="exponent"></param>
			/// <returns></returns>
			public override T Process(T factor, T exponent) { return Pow(factor, exponent); }

			/// <summary></summary>
			/// <param name="factor"></param>
			/// <param name="exponent"></param>
			/// <returns></returns>
			public override T Pow(T factor, T exponent)
			{
				Steps++; 

				T f = exponent % T.CreateChecked(2) == T.One ? factor : T.One;

				while (exponent != T.Zero)
				{
					exponent /= T.CreateChecked(2);
					factor *= factor;

					Steps++;

					if (exponent % T.CreateChecked(2) == T.One)
					{
						Steps++; 
						f *= factor;
					}
				}

				return f;
			}
		}

		/// <summary>Implementation of classick quick pow algorithm</summary>
		/// <typeparam name="T"></typeparam>
		public class ClassicQuick<T> : APow<T>
			where T : INumber<T>, IBinaryInteger<T>
		{
			/// <summary>Default constructor</summary>
			public ClassicQuick() { }

			/// <summary>Extended constructor</summary>
			/// <param name="factor"></param>
			/// <param name="exponent"></param>
			public ClassicQuick(T factor, T exponent) : base(factor, exponent) { Execute(); }

			/// <summary>General method that executes algorithm</summary>
			/// <param name="factor"></param>
			/// <param name="exponent"></param>
			public override void Execute(T factor, T exponent) { Process(factor, exponent); }

			/// <summary>General method that executes algorithm for extended constructor</summary>
			public override void Execute() { Process(Factor, Exponent); }

			/// <summary>Method that processes the power calculation</summary>
			/// <param name="factor"></param>
			/// <param name="exponent"></param>
			/// <returns>The result of raising the factor to the power of exponent</returns>
			public override T Process(T factor, T exponent) { return Pow(factor, exponent); }

			/// <summary>Power calculation using the classic quick method</summary>
			/// <param name="factor"></param>
			/// <param name="exponent"></param>
			/// <returns></returns>
			public override T Pow(T factor, T exponent)
			{
				Steps++;
				T result = T.One;

				while (exponent != T.Zero)
				{
					if (exponent % T.CreateChecked(2) == T.Zero)
					{
						factor *= factor;
						exponent /= T.CreateChecked(2);
						Steps++; 
					}
					else
					{
						result *= factor;
						exponent -= T.One;
						Steps++;
					}
				}

				return result;
			}
		}
	}
}
