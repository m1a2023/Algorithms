using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Algorithms.models.Algorithms
{
	/// <summary>
	/// Abstract class for implementing power algorithms. 
	/// Utilizes a generic type <typeparamref name="T"/> that must implement the <see cref="INumber{T}"/> interface.
	/// It stores the base value (Factor), exponent (Exponent), result (Result), and the number of steps (Steps).
	/// </summary>
	/// <typeparam name="T">The generic type that implements <see cref="INumber{T}"/>.</typeparam>
	public abstract class APow<T> where T : INumber<T>
	{
		protected T Factor;
		protected T Exponent;
		protected T Result;
		protected long Steps;

		/// <summary> Empty constructor for the power algorithm.  </summary>
		protected APow() { }

		/// <summary> Constructor that initializes the base and exponent values.  It also calculates the result using the Process method.  </summary>
		/// <param name="Factor">The base value of the power calculation.</param>
		/// <param name="Exponent">The exponent of the power calculation.</param>
		protected APow(T Factor, T Exponent)
		{
			this.Factor = Factor;
			this.Exponent = Exponent;
			Result = Process(Factor, Exponent);
		}
	
		/// <summary>Set data using setters</summary>
		/// <param name="Factor"></param>
		/// <param name="Exponent"></param>
		public virtual void SetData(T Factor, T Exponent)
		{
			SetFactor(Factor);
			SetExponent(Exponent);
			Result = GetResult();
		}

		/// <summary> Gets the current base value (Factor).  </summary>
		/// <returns>The base value.</returns>
		public virtual T GetFactor() { return Factor; }

		/// <summary> Gets the current exponent value (Exponent).  </summary> 
		/// <returns>The exponent value.</returns>
		public virtual T GetExponent() { return Exponent; }

		/// <summary> Returns the result of the power calculation.  It invokes the Process method to perform the calculation.  </summary>
		/// <returns>The result of raising Factor to the power of Exponent.</returns>
		public virtual T GetResult() { return Process(Factor, Exponent); }

		/// <summary> Sets the base value (Factor).  </summary>
		/// <param name="Factor">The new base value.</param>
		public virtual void SetFactor(T Factor) { this.Factor = Factor; }

		/// <summary> Sets the exponent value (Exponent).  </summary>
		/// <param name="Exponent">The new exponent value.</param>
		public virtual void SetExponent(T Exponent) { this.Exponent = Exponent; }

		/// <summary> Abstract method to perform the power calculation.  Subclasses must implement this to define how the power is calculated.  </summary>
		/// <param name="factor">The base value.</param>
		/// <param name="exponent">The exponent value.</param>
		/// <returns>The result of raising the base to the power of the exponent.</returns>
		public abstract T Process(T factor, T exponent);

		/// <summary> Returns the number of steps taken during the power calculation.  </summary> <returns>The number of steps performed.</returns>
		public virtual long GetSteps() { var tmp = Steps; Steps = 0; return tmp; }

		/// <summary> Abstract method to execute the power calculation.  This should be implemented by derived classes to define how to perform the calculation without parameters.  </summary>
		public abstract void Execute();

		/// <summary> Abstract method to execute the power calculation with specific base and exponent values.  This should be implemented by derived classes.</summary>
		/// <param name="factor">The base value.</param>
		/// <param name="exponent">The exponent value.</param>
		public abstract void Execute(T factor, T exponent);

		/// <summary>
		/// Abstract method that must be implemented by subclasses to define the core power calculation logic.
		/// </summary>
		/// <param name="factor">The base value.</param>
		/// <param name="exponent">The exponent value.</param>
		/// <returns>The result of the power calculation.</returns>
		public abstract T Pow(T factor, T exponent);

		/// <summary>Returns a string representation of the current state of the object. Includes the base value, exponent, result, and the number of steps taken.</summary>
		/// <returns>A string representation of the object.</returns>
		public override string ToString()
		{
			return $"Factor: {Factor} [{Factor.GetType()}]\n" +
				   $"Exponent: {Exponent} [{Exponent.GetType()}]\n" +
				   $"Result: {Result} [{Result.GetType()}]\n" +
				   $"Quantity steps: {Steps}";
		}
	}
}
