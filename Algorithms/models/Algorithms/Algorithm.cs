using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.models.Algorithms
{
    public abstract class Algorithm<T>
        where T : INumber<T>
    {

        /// <summary>General method that executes algorithm</summary>
        /// <param name="data">Value collection, implemented via ICollection</param>
        public abstract void Execute(IList<T> data);

        /// <summary>Starts the stopwatch, executes algorithm and stops stopwatch</summary>
        /// <param name="data">Value collection, implemented via ICollection</param>
        /// <returns>Execution algorithm time in milliseconds</returns>
        public decimal GetExecutionTime(IList<T> data)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            Execute(data);

            stopwatch.Stop();

            return new decimal(stopwatch.Elapsed.TotalMilliseconds);
        }
    }
}
