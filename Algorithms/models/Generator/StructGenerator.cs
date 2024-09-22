using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.models.Generator
{
	/// <summary>Implementation of struct generator</summary>
	public class StructGenerator
	{
		private readonly DataGenerator dataGenerator = new DataGenerator(); 
		
		/// <summary>Generates array with selected values</summary>
		/// <param name="size">Size of array</param>
		/// <param name="minValue">Min value that can be generated</param>
		/// <param name="maxValue">Max value that can be generated</param>
		/// <returns>Generated array</returns>
		public Int64[] GenerateArray(Int64 size, Int64 minValue, Int64 maxValue) 
		{
			if (size < 0)
				throw new ArgumentOutOfRangeException("size");

			Int64[] arr = new Int64[size];
			
			for (Int64 i = 0; i < size; i++)
			{
				arr[i] = dataGenerator.GetRandomInt64(minValue, maxValue);
			}
			 
			return arr;
		}
		
		/// <summary>Generates array with limit value from 0 to Int64.MaxValue</summary>
		/// <param name="size">Size of array</param>
		/// <returns>Generated array</returns>
		public Int64[] GenerateArray(Int64 size)
		{
			return GenerateArray(size, 0, long.MaxValue);
		}
		
		/// <summary>Generates list with selected values</summary>
		/// <param name="size">Size of list</param>
		/// <param name="minValue">Min value that can be generated</param>
		/// <param name="maxValue">Max value that can be generated</param>
		/// <returns>Generated list</returns>
		public List<Int64> GenerateList(Int64 size, Int64 minValue, Int64 maxValue)
		{
            if (size < 0)
                throw new ArgumentOutOfRangeException("size");

            List<Int64> list = new List<Int64>();

			for (Int64 i = 0;  i < size; i++)
			{
				list.Add(dataGenerator.GetRandomInt64(minValue, maxValue));
			}

			return list;
		}
		
		/// <summary>Generates list with limit value from 0 to Int64.MaxValue</summary>
		/// <param name="size">Size of list</param>
		/// <returns>Generated list</returns>
		public List<Int64> GenerateList(Int64 size)
		{
			return GenerateList(size, 0, long.MaxValue);
		}
		
	}
}