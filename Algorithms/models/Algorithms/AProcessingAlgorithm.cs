﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.models.Algorithms
{
	public abstract class AProcessingAlgorithm<T> : AAlgorithm<T>
		where T : INumber<T>
	{
		protected IList<T> Data;
		protected T Result;

		protected AProcessingAlgorithm() { } 
		protected AProcessingAlgorithm(IList<T> Data)
		{
			this.Data = Data ?? throw new ArgumentException();
			Result = Process(this.Data);
		}

		public abstract T Process(IList<T> Data);

		/// <summary>Getter for Data if exists</summary>
		/// <returns></returns>
		/// <exception cref="ArgumentException"></exception>
		public virtual IList<T> GetData()
		{
			if (Data == null) 
				throw new ArgumentException("Field Data has not any value. Use Extended constructor");
			return Data; 
		}

		/// <summary>Getter for Result if exists</summary>
		/// <returns></returns>
		/// <exception cref="ArgumentException"></exception>
		public virtual T GetResult() 
		{
			if (Result.Equals(default(T)))
				throw new ArgumentException("Field Result has not any value. Use Extended constructor");
			return Result; 
		}

		/// <summary>Additional method for extended constructor</summary>
		/// <returns>Execution algorithm time in milliseconds</returns>
		public virtual decimal GetExecutionTime()
		{
			Stopwatch stopwatch = Stopwatch.StartNew();	

			Execute(Data);

			stopwatch.Stop();

			return new decimal(stopwatch.Elapsed.TotalMilliseconds);
		}

		/// <summary>String information representation</summary>
		/// <returns>String of fields</returns>
		public virtual string ToString()
		{
			string data = String.Join(", ", Data);
			return $"Original collection: {data} [{Data.GetType()}]\n" +
				$"Result: {Result} [{Result.GetType()}]\n" +
				$"Execution time: {GetExecutionTime()}";
		}
	}
}
