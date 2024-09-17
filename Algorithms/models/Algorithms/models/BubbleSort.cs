using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.models.Algorithms.models
{
    public class BubbleSort<T> : Algorithm<T> 
        where T : INumber<T>
    {
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public override void Execute(IList<T> data)
        {
            Comparer<T> comparer = Comparer<T>.Default;

            bool stillGoing = true;

            while (stillGoing)
            {
                stillGoing = false;
                for (int i = 0; i < data.Count; i++)
                {
                    T x = data[i];
                    T y = data[i + 1];

                    if (comparer.Compare(x, y) > 0)
                    {
                        data[i] = y;
                        data[i + 1] = x;
                        stillGoing = true; 
                    }
                }
            }

            return;
        }
    }
}
