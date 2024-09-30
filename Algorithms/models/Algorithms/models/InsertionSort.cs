using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.models.Algorithms.models
{
    public class InsertionSort<T> : ASortingAlgorithm<T>
        where T : INumber<T>
    {
        /// <summary>Default constructor</summary>
        public InsertionSort() { }

        /// <summary>Extended constructor</summary>
        /// <param name="Data"></param>
        public InsertionSort(IList<T> Data) : base(Data) { }

        /// <summary>General methond that executes algorithm</summary>
        /// <param name="data">value collection, implemented via icollection</param>
        public override void Execute(IList<T> data)
        {
            Sort(data);
        }

        public void Sort(IList<T> data)
        {
            for (int j = 1; j < data.Count; j++)
            {
                T key = data[j];
                int i = j - 1;
                while (i >= 0 && data[i] > key)
                {
                    data[i + 1] = data[i];
                    i--;
                }
                data[i + 1] = key;
            }

            return;
        }
    }
}
