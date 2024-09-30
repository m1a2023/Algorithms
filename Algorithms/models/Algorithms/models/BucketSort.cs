using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.models.Algorithms.models
{
    /// <summary>Implementation of the bucket sort algorithm</summary>
    /// <typeparam name="T">Inner data type</typeparam>
    public class BucketSort<T> : ASortingAlgorithm<T>
        where T : INumber<T>, IComparable<T>
    {
        /// <summary>Default constructor</summary>
        public BucketSort() { }

        /// <summary>Extended constructor</summary>
        /// <param name="Data"></param>
        public BucketSort(IList<T> Data) : base(Data) { }

        /// <summary>General method that executes algorithm</summary>
        /// <param name="data">Value collection, implemented via IList</param>
        public override void Execute(IList<T> data)
        {
            Sort(data);
        }

        /// <summary>Internal method that performs the bucket sort</summary>
        /// <param name="data">Value collection, implemented via IList</param>
        private void Sort(IList<T> data)
        {
            if (data == null || data.Count == 0)
                return;

            int numberOfBuckets = (int)Math.Sqrt(data.Count);
            List<T>[] buckets = new List<T>[numberOfBuckets];

            for (int i = 0; i < numberOfBuckets; i++)
            {
                buckets[i] = new List<T>();
            }

            T minValue = data[0];
            T maxValue = data[0];

            foreach (T item in data)
            {
                if (item.CompareTo(minValue) < 0)
                    minValue = item;
                if (item.CompareTo(maxValue) > 0)
                    maxValue = item;
            }

            for (int i = 0; i < data.Count; i++)
            {
                int bucketIndex = Convert.ToInt32((data[i] - minValue) / (maxValue - minValue + T.One) * T.CreateChecked(numberOfBuckets - 1));
                buckets[bucketIndex].Add(data[i]);
            }

            int index = 0;
            for (int i = 0; i < numberOfBuckets; i++)
            {
                buckets[i].Sort(); 

                foreach (T item in buckets[i])
                {
                    data[index++] = item;
                }
            }
        }
    }
}
