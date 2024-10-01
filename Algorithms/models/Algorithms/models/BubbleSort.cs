using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.models.Algorithms.models
{
    /// <summary>Implementation of bubble sort algorithm </summary>
    /// <typeparam name="T"></typeparam>
    public class BubbleSort<T> : ASortingAlgorithm<T>
        where T : INumber<T>
    {
        /// <summary>Default constructor</summary>
        public BubbleSort() { } 

		/// <summary>Extended constructor</summary>
		/// <param name="Data"></param>
        public BubbleSort(IList<T> Data) : base(Data) { }

        /// <summary>General methond that executes algorithm</summary>
        /// <param name="data">value collection, implemented via icollection</param>
        public override void Execute(IList<T> data)
        {
            Sort(data);
        }

        public void Sort(IList<T> data)
        {
            for (int i = 0; i < data.Count; i++)
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
