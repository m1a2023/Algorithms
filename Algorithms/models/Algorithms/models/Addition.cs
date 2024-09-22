using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.models.Algorithms.models
{
    /// <summary>Implementation sum element algorithm</summary>
    /// <typeparam name="T">Inner data type</typeparam>
    public class Addition<T> : Algorithm<T>
        where T : INumber<T>
    {
        protected IList<T> Data { get; private set; }        
        protected T Result { get; private set; }

        /// <summary>Default constructor</summary>
        public Addition() { } 

		/// <summary>Extended constructor</summary>
		/// <param name="Base"></param>
		/// <param name="Exponent"></param>
        public Addition(IList<T> Data)
        {
            this.Data = Data;
            Result = Add(this.Data);
        }
        
        /// <summary>General method that executes algorithm</summary>
        /// <param name="data">Value collection, implemented via ICollection</param>
        /// <returns>Variable the same type as the argument</returns>
        public override void Execute(IList<T> data)
        {
            Add(data);
        }

        private T Add(IList<T> data) 
        {
            T tmp = T.Zero;

            foreach (T item in data)
            {
                tmp += item;
            }
            
            return tmp;
        }

		/// <summary>Additional method for extended constructor</summary>
		/// <returns>Execution algorithm time in milliseconds</returns>
        public decimal GetExecutionTime()
        {
            Stopwatch stopwatch = Stopwatch.StartNew(); 

            Execute(Data);

            stopwatch.Stop();   

            return new decimal (stopwatch.Elapsed.TotalMilliseconds);
        }

		/// <summary>String information representation</summary>
		/// <returns>String of fields</returns>
        public override string ToString()
        {
            string data = String.Join(", ", this.Data);
            return $"Original collection: {data} [{Data.GetType()}]\n" +
                $"Result: {Result} [{Result.GetType()}]\n" +
                $"Execution time: {GetExecutionTime()}";
        }
    }
}
