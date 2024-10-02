using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.models.Algorithms.models
{
	/// <summary>Implementation of stooge sort algorithm</summary>
	/// <typeparam name="T"></typeparam>
	public class StoogeSort<T> : ASortingAlgorithm<T>
	where T : INumber<T>
	{
		/// <summary>Default constructor</summary>
		public StoogeSort() { }

		/// <summary>Extended constructor</summary>
		/// <param name="Data"></param>
		public StoogeSort(IList<T> Data) : base(Data) { }

		/// <summary>General methond that executes algorithm</summary>
		/// <param name="data">value collection, implemented via icollection</param>
		public override void Execute(IList<T> data)
		{
			Sort(data, 0, data.Count - 1);
		}

		public void Sort(IList<T> data, int left, int right)
		{
			T temp;
			int k;
			if (data[left] > data[right])
			{
				temp = data[left];
				data[left] = data[right];
				data[right] = temp;
			}
			if ((left + 1) >= right)
			{
				return;
			}

			k = (int)((right - left + 1) / 3);
			Sort(data, left, right - k);
			Sort(data, left + k, right);
			Sort(data, left, right - k);
			return;
		}
	}

}
