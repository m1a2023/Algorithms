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
    public class Multiplication<T> : Algorithm<T>
        where T : INumber<T>
    {
        /// <summary>General method that executes algorithm</summary>
        /// <param name="data">Value collection, implemented via ICollection</param>
        /// <returns>Variable the same type as argument</returns>
        public override void Execute(IList<T> data)
        {
            T tmp = T.One;

            foreach (T item in data)
            {
                tmp *= item;
            }

            return;
        }
    }
}

