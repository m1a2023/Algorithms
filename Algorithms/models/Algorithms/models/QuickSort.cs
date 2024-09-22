using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.models.Algorithms.models
{
	/// <summary>Implementation quick sort algorithm</summary>
	/// <typeparam name="T">Inner data type</typeparam>
	public class QuickSort<T> : Algorithm<T> 
		where T : INumber<T>, IComparable<T>
	{
		protected IList<T> Data { get; private set; }
		protected IList<T> SortedData { get; private set; }

		/// <summary>Default constructor</summary>
		public QuickSort() { }
		
		/// <summary>Extended constructor</summary>
		/// <param name="Data"></param>
		public QuickSort(IList<T> Data)
		{
			this.Data = Data;
			
			SortedData = new T[this.Data.Count];

			for (int i = 0; i < this.Data.Count; i++) { SortedData[i] = this.Data[i];}

			Execute(SortedData);
		}

		public IList<T> GetSortedData()
		{
			if (Data == default) throw new ArgumentException("Field Data has not any value. Use Extended constructor");
			
			return SortedData;	
		}
			
		/// <summary>General method that executes algorithm</summary>
		/// <param name="data">Value collection, implemented via IList</param>
		public override void Execute(IList<T> data)
		{
			QuickSortInternal(data, 0, data.Count - 1);
		}
		
		/// <summary>Additional method for extended constructor</summary>
		/// <returns>Execution algorithm time in milliseconds</returns>
		public decimal GetExecutionTime()
		{
			if (Data == default) throw new ArgumentException("Field Data has not any value. Use Extended constructor");

			IList<T> tmp = new T[Data.Count];
			for (int i = 0; i < Data.Count; i++) { tmp[i] = Data[i];}

			Stopwatch stopwatch = Stopwatch.StartNew(); 
			
			Execute(tmp);
			
			stopwatch.Stop();

			return new decimal (stopwatch.Elapsed.TotalMilliseconds);
		}

		/// <summary>String information representation</summary>
		/// <returns>String of fields</returns>
        public override string ToString()
        {
			string data = String.Join(", ", Data);
			string sortedData = String.Join(", ", SortedData);
			return $"Original collection: {data} [{Data.ToString()}], \n" +
				$"Sorted collection: {sortedData} [{SortedData.ToString()}], \n" +
				$"Execution time: {GetExecutionTime()}";
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
