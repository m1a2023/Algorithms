using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.models.Algorithms.models
{
    /// <summary>
    /// Implementation sum element algorithm
    /// </summary>
    /// <typeparam name="T">Inner data type</typeparam>
    public class Addition<T> : IAlgorithm<T>
        where T : INumber<T>
    {
        /// <summary>
        /// General method that executes algorithm 
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Variable the same type as the argument</returns>
        public T Execute(ICollection<T> data)
        {
            T tmp = T.Zero;

            foreach (T item in data)
            {
                tmp += item;
            }

            return tmp;
        }

        /// <summary>
        /// Starts the stopwatch, executes algorithm and stops stopwatch
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Execution algorithm time in milliseconds</returns>
        public decimal GetExecutionTime(ICollection<T> data)
        {
            Stopwatch executionTime = Stopwatch.StartNew();

            Execute(data);

            executionTime.Stop();

            return new decimal(executionTime.Elapsed.TotalMilliseconds);
        }

        public T Execute(T[] data) => Execute((ICollection<T>)data);
        public T Execute(List<T> data) => Execute((ICollection<T>)data);
        public decimal GetExecutionTime(T[] data) => GetExecutionTime((ICollection<T>)data);
        public decimal GetExecutionTime(List<T> data) => GetExecutionTime((ICollection<T>)data);
    }
}
