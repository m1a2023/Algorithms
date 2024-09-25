﻿using System;
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
		/// <typeparam name="T">Inner data type</typeparam>
		/// <param name="size">Size of array</param>
		/// <param name="minValue">Min value that can be generated</param>
		/// <param name="maxValue">Max value that can be generated</param>
		/// <returns>Generated array</returns>
		public IList<T> GenerateArray<T>(int size, Int64 minValue, Int64 maxValue) where T : INumber<T>
		{
			IList<T> arr = new T[size];
			 
			for (int i = 0; i < size; i++)
			{
				arr[i] = T.CreateChecked(dataGenerator.GetRandomUInt32());	
			}

			return arr;
		}


		/// <summary>Generates array with selected values</summary>
		/// <param name="size">Size of array</param>
		/// <param name="minValue">Min value that can be generated</param>
		/// <param name="maxValue">Max value that can be generated</param>
		/// <returns>Generated array</returns>
		public Int64[] GenerateInt64Array(int size, Int64 minValue, Int64 maxValue) 
		{
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
		public Int64[] GenerateArray(int size)
		{
			return GenerateInt64Array(size, 0, long.MaxValue);
		}
		
		/// <summary>Generates list with selected values</summary>
		/// <param name="size">Size of list</param>
		/// <param name="minValue">Min value that can be generated</param>
		/// <param name="maxValue">Max value that can be generated</param>
		/// <returns>Generated list</returns>
		public List<Int64> GenerateList(int size, Int64 minValue, Int64 maxValue)
		{
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
		public List<Int64> GenerateList(int size)
		{
			return GenerateList(size, 0, long.MaxValue);
		}
		
	}
}