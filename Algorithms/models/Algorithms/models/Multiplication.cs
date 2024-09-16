using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Algorithms.models.Algorithms;

namespace Algorithms.models.Algorithms.models
{
    /// <summary>Implementation Multiplication algorithm</summary>
    /// <typeparam name="T">Inner data type</typeparam>
    public class Multiplication<T> : IAlgorithm<T>
        where T : INumber<T>
    {
        /// <summary>General method that executes algorithm</summary>
        /// <param name="data">Value collection, implemented via ICollection</param>
        /// <returns>Variable the same type as argument</returns>
        public T Execute(ICollection<T> data)
        {
            T tmp = T.One;

            foreach (T item in data)
            {
                tmp *= item;
            }

            return tmp;
        }

        /// <summary>Starts the stopwatch, executes algorithm and stops stopwatch</summary>
        /// <param name="data">Value collection, implemented via ICollection</param>
        /// <returns></returns>
        public decimal GetExecutionTime(ICollection<T> data)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            Execute(data);

            stopwatch.Stop();

            return new decimal(stopwatch.Elapsed.TotalMilliseconds);
        }

        public T Execute(T[] data) => Execute((ICollection<T>)data);
        public T Execute(List<T> data) => Execute((ICollection<T>)data);
        public decimal GetExecutionTime(T[] data) => GetExecutionTime((ICollection<T>)data);
        public decimal GetExecutionTime(List<T> data) => GetExecutionTime((ICollection<T>)data);
    }
}



