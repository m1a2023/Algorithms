using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.models.Algorithms.models
{
    /// <summary>
    /// Implementation of bubble sort algorithm
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BubbleSort<T> : Algorithm<T> 
        where T : INumber<T>
    {
        /// <summary>General methond that executes algorithm</summary>
        /// <param name="data">value collection, implemented via icollection</param>
        public override void Execute(IList<T> data)
        {

            for (Int64 i = 0; i < data.Count; i++)
            {
                for (int j = 0; j < data.Count - 1; j++)
                    if (data[j] > data[j + 1])
                    {
                        var tmp = data[j];
                        data[j] = data[j + 1];
                        data[j + 1] = tmp;
                    }
            }

            return;
        }
    }
}
