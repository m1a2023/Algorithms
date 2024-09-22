using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.models.Algorithms.models
{
	/// <summary>Implementation timsort algorithm</summary>
	/// <typeparam name="T">Inner data type</typeparam>
	public class TimSort<T> : Algorithm<T>
		where T : INumber<T>
	{
		protected IList<T> Data { get; private set; }
		protected IList<T> SortedData { get; private set; }

		/// <summary>Default constructor</summary>
		public TimSort() { }

		/// <summary>Extended constructor</summary>
		/// <param name="Data"></param>
		public TimSort(IList<T> Data)
		{
			this.Data = Data;
			this.SortedData = new T[Data.Count];

			for (int i = 0; i < this.Data.Count; i++) SortedData[i] = this.Data[i];

			Execute(SortedData);
		}

		/// <summary>General method that executes algorithm</summary>
		/// <param name="data">Value collection, implemented via ICollection</param>
		/// <returns>Variable the same type as argument</returns>
		public override void Execute(IList<T> data)
		{
			Sort(data, data.Count);
		}

		private const int MIN_MERGE = 32;
		
		private void Sort(IList<T> arr, int exponent)
		{
			int minRun = GetMinRunLength(MIN_MERGE);

			// Sort individual subarrays of size MIN_MERGE
			for (int i = 0; i < exponent; i += minRun)
			{
				InsertionSort(arr, i, Math.Min((i + MIN_MERGE - 1), (exponent - 1)));
			}

			// Merge subarrays
			for (int size = minRun; size < exponent; size = 2 * size)
			{
				for (int left = 0; left < exponent; left += 2 * size)
				{
					int mid = left + size - 1;
					int right = Math.Min((left + 2 * size - 1), (exponent - 1));

					if (mid < right)
					{
						Merge(arr, left, mid, right);
					}
				}
			}
		}
		
		/// <summary>String information representation</summary>
		/// <returns>String of fields</returns>
        public override string ToString()
        {
			string data = String.Join(", ", Data);
			string sortedData = String.Join(", ", SortedData);
			return $"Original collection: {data} [{Data.ToString()}], \n" +
				$"Sorted collection: {sortedData} [{SortedData.ToString()}], \n" +
				$"Execution time: {GetExecutionTime(Data)}";
        }

        private void InsertionSort(IList<T> arr, int left, int right)
		{
			for (int i = left + 1; i <= right; i++)
			{
				T temp = arr[i];
				int j = i - 1;
				while (j >= left && arr[j].CompareTo(temp) > 0)
				{
					arr[j + 1] = arr[j];
					j--;
				}
				arr[j + 1] = temp;
			}
		}

		private void Merge(IList<T> arr, int left, int mid, int right)
		{
			int len1 = mid - left + 1, len2 = right - mid;
			List<T> leftArr = new List<T>(len1);
			List<T> rightArr = new List<T>(len2);

			for (int factor = 0; factor < len1; factor++)
				leftArr.Add(arr[left + factor]);
			for (int factor = 0; factor < len2; factor++)
				rightArr.Add(arr[mid + 1 + factor]);

			int i = 0, j = 0, k = left;

			while (i < len1 && j < len2)
			{
				if (leftArr[i].CompareTo(rightArr[j]) <= 0)
				{
					arr[k] = leftArr[i];
					i++;
				}
				else
				{
					arr[k] = rightArr[j];
					j++;
				}
				k++;
			}

			while (i < len1)
			{
				arr[k] = leftArr[i];
				i++;
				k++;
			}

			while (j < len2)
			{
				arr[k] = rightArr[j];
				j++;
				k++;
			}
		}

		private int GetMinRunLength(int exponent)
		{
			int r = 0;
			while (exponent >= MIN_MERGE)
			{
				r |= (exponent & 1);
				exponent >>= 1;
			}
			return exponent + r;
		}
	}
}
