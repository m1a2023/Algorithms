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
        /// <summary>General method that executes algorithm</summary>
        /// <param name="data">Value collection, implemented via ICollection</param>
        /// <returns>Variable the same type as the argument</returns>
        public override void Execute(IList<T> data)
        {
            T tmp = T.Zero;

            foreach (T item in data)
            {
                tmp += item;
            }
            
            return;
        }
        //public void Execute(T[] data) => Execute((ICollection<T>)data);
        //public void Execute(List<T> data) => Execute((ICollection<T>)data);
    }
}
