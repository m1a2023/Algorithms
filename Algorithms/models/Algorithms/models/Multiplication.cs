using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.models.Algorithms.models
{
    /// <summary>Implementation multiplication algorithm</summary>
    /// <typeparam name="T">Inner data type</typeparam>
    public class Multiplication<T> : Algorithm<T>
        where T : INumber<T>
    {
        protected IList<T> Data { get; private set; }        
        protected T Result { get; private set; }

        /// <summary>Default constructor</summary>
        public Multiplication() { } 

		/// <summary>Extended constructor</summary>
		/// <param name="Data"></param>
        public Multiplication(IList<T> Data)
        {
            this.Data = Data;
            Result = Multiplicate(this.Data);
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
            Multiplicate(data);
        }
       
        private T Multiplicate(IList<T> data)
        {
            T tmp = T.One;

            foreach (T item in data)
            {
                tmp *= item;
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
            string data = String.Join(", ", Data);
            return $"Original collection: {data} [{Data.GetType()}]\n" +
                $"Result: {Result} [{Result.GetType()}]\n" +
                $"Execution time: {GetExecutionTime()}";
        }
    }
}

