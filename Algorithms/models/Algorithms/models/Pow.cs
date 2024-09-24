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
		public class Simple<T> : AProcessingAlgorithm<T>
			where T : INumber<T>, IBinaryInteger<T>
		{
			/// <summary>Default constructor</summary>
			public Simple() { }

			/// <summary>Extended constructor</summary>
			/// <param name="Data"></param>
			public Simple(IList<T> Data) : base(Data) { }
			
			public override void Execute(IList<T> data)
			{
				if (data.Count != 2)
					throw new ArgumentException("There must collection with two values");
				Pow(data);
			}

			public override T Process(IList<T> Data)
			{
				return Pow(Data); 
			}

			private T Pow(IList<T> data)
			{
				T factor = data[0], exponent = data[1];
				T res = T.One;
				
				for (int i = 0; i < Convert.ToInt64(exponent); i++)
				{
					res *= factor;
				}  

				return res;
			}
		}
		
		/// <summary>Implementation of recursive pow algorithm</summary>
		/// <typeparam name="T">Supports Integer types between short and Int128</typeparam>
		public class Recursive<T> :  AProcessingAlgorithm<T>
			where T : INumber<T>
		{
			/// <summary>Default constructor</summary>
			public Recursive() { }

			/// <summary>Extended constructor</summary>
			/// <param name="Base"></param>
			/// <param name="Exponent"></param>
			public Recursive(IList<T> Data) : base(Data) { }
		  
			public override void Execute(IList<T> data)
			{
				if (data.Count != 2)
					throw new ArgumentException("Invalid elements quantity exception");
				
				Pow(data);
			}
			
			public override T Process(IList<T> Data)
			{
				return Pow(Data);
			}

			private T Pow(IList<T> data)
			{
				T factor = data[0], exponent = data[1];

				if (exponent == T.Zero) return T.One;

				T f = Pow([factor, exponent / T.CreateChecked(2)]);

				if (exponent % T.CreateChecked(2) == T.One)
					return f * f * factor;
				else
					return f * f;
			}
		}

		/// <summary>Implementation of quick pow algorithm</summary>
		/// <typeparam name="T"></typeparam>
		public class Quick<T> : AProcessingAlgorithm<T>
			where T : INumber<T>

		{
			/// <summary>Default constructor</summary>
			public Quick() { }

			/// <summary>Extended constructor</summary>
			/// <param name="Base"></param>
			/// <param name="Exponent"></param>
			public Quick(IList<T> Data) : base(Data) { }
			
			public override void Execute(IList<T> data)
			{
				if (data.Count != 2)
					throw new ArgumentException("Invalid elements quantity exception");
				
				Pow(data);
			}

			public override T Process(IList<T> Data)
			{
				return Pow(Data);
			}

			private T Pow(IList<T> data)
			{
				T f, factor = data[0], exponent = data[1];

				if (exponent % T.CreateChecked(2) == T.One)
					f = factor;
				else
					f = T.One;
				
				while (exponent != T.Zero)
				{
					exponent /= T.CreateChecked(2);

					factor *= factor;

					if (exponent % T.CreateChecked(2) == T.One) 
						f = f * factor;
				}

				return f;
			}
		}

		/// <summary>Implementation of classick quick pow algorithm</summary>
		/// <typeparam name="T"></typeparam>
		public class ClassicQuick<T> : AProcessingAlgorithm<T>
			where T : INumber<T>
		{
			
			/// <summary>Default constructor</summary>
			public ClassicQuick() { }

			/// <summary>Extended constructor</summary>
			/// <param name="Base"></param>
			/// <param name="Exponent"></param>
			public ClassicQuick(IList<T> Data) : base(Data) { }
			
			public override void Execute(IList<T> data)
			{
				if (data.Count != 2)
					throw new ArgumentException("Invalid elements quantity exception");
				
				Pow(data);
			}

            public override T Process(IList<T> Data)
            {
				return Pow(Data);
            }

            private T Pow(IList<T> data)
			{
				T f = T.One, factor = data[0], exponent = data[1];

				while (exponent != T.Zero)
				{
					if (exponent % T.CreateChecked(2) == T.Zero)
					{
						factor *= factor;
						exponent /= T.CreateChecked(2);
					}
					else
					{
						f = f * factor;
						exponent -= T.One;
					}
				}

				return f;
			}
		}
	}
}
