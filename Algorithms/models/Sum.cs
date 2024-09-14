using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.models
{
    /// <summary>
    /// Implementation Sum of Element algorithm
    /// </summary>
    /// <typeparam name="T">Inner data type</typeparam>
    public class Sum<T> : IAlgorithm<T>
        where T : INumber<T> 
        //where D : INumber<D> 
    {
        /// <summary>
        /// General method that executes algorithm 
        /// </summary>
        /// <param name="data"></param>
        public void Execute(ICollection<T> data) {
            T tmp = T.Zero;

            foreach (T item in data)
            {
                tmp += item;
            }

            return;
        }
        /// <summary>
        /// Starts the stopwatch, executes algorithm and stops stopwatch
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Execution algorithm time in milliseconds</returns>
        public Decimal GetExecutionTime(ICollection<T> data) {
            Stopwatch executionTime = Stopwatch.StartNew();
            
            Execute(data);

            executionTime.Stop();

            return new Decimal(executionTime.Elapsed.TotalMilliseconds);
        }
        
        public void Execute(T[] data) => Execute((ICollection<T>)data);
        public void Execute(List<T> data) => Execute((ICollection<T>)data);
        public Decimal GetExecutionTime(T[] data) => GetExecutionTime((ICollection<T>)data);
        public Decimal GetExecutionTime(List<T> data) => GetExecutionTime((ICollection<T>)data);
    }
}
