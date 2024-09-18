using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.models.Algorithms.models
{
    public class QuickSort<T> : Algorithm<T> 
        where T : INumber<T>, IComparable<T>
    {
        
        /// <summary>General method that executes algorithm</summary>
        /// <param name="data">Value collection, implemented via IList</param>
        public override void Execute(IList<T> data)
        {
            QuickSortInternal(data, 0, data.Count - 1);
        }
        
        private void QuickSortInternal(IList<T> data, int left, int right)
        {
            if (left > right)
                return;

            int partition = PartitionInternal(data, left, right);

            QuickSortInternal(data, left, partition - 1);
            QuickSortInternal(data, partition + 1, right);
        }

        private int PartitionInternal(IList<T> data, int left, int right)
        {
            T partition = data[right];

            int swapIndex = left;

            for (int i = left; i < right; i++)
            {
                T item = data[i];

                if (item.CompareTo(partition) <= 0)
                {
                    (data[i], data[swapIndex]) = (data[swapIndex], data[i]);
                    
                    swapIndex++;
                }
            }

            (data[right], data[swapIndex]) = (data[swapIndex], data[right]);

            return swapIndex;
        }
    }
}
