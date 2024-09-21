using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.models.Algorithms.models
{
	/// <summary>Implementation Constant function algorithm</summary>
	/// <typeparam name="T">Inner data type</typeparam>
	public class Constant<T> : Algorithm<T>
		where T : INumber<T>
	{
		protected IList<T> Data { get; private set; }
		protected T Result { get; private set; }

		/// <summary>Default constructor</summary>
		public Constant() { } 
        
		/// <summary>Extended constructor</summary>
        /// <param name="Base"></param>
        /// <param name="Exponent"></param>
		public Constant(IList<T> Data)
		{
			this.Data = Data;
			Result = T.One;
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

		/// <summary>general methond that executes algorithm</summary>
		/// <param name="data">value collection, implemented via icollection</param>
		public override void Execute(IList<T> data) { return; }

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
