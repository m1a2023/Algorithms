﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.models.Algorithms
{
    public abstract class ASortingAlgorithm<T> : AAlgorithm<T>
        where T : INumber<T>
    {
        protected IList<T> Data;
        protected IList<T> SortedData;
        
        /// <summary>Default constructor</summary>
        public ASortingAlgorithm() { }
        
        /// <summary>Extended constructor</summary>
        /// <param name="Data"></param>
        public ASortingAlgorithm(IList<T> Data)
        {
            this.Data = Data;
            SortedData = new T[this.Data.Count];    

            for (int i = 0; i < this.Data.Count; i++) 
                SortedData[i] = this.Data[i];

            Execute(SortedData);
        }

        public virtual IList<T> GetData()
        {
			if (Data == null) throw new ArgumentException("Field Data has not any value. Use Extended constructor");
            return SortedData;	
        }

        public virtual IList<T> GetSortedData()
        {
			if (SortedData == null) throw new ArgumentException("Field SortedData has not any value. Use Extended constructor");
            return SortedData;	
        }
        
		/// <summary>Additional method for extended constructor</summary>
		/// <returns>Execution algorithm time in milliseconds</returns>
        public virtual decimal GetExecutionTime()
        {
			if (Data == null) throw new ArgumentException("Field Data has not any value. Use Extended constructor");

			IList<T> tmp = new T[Data.Count];
			for (int i = 0; i < Data.Count; i++) { tmp[i] = Data[i];}

			Stopwatch stopwatch = Stopwatch.StartNew(); 
			
			Execute(tmp);
			
			stopwatch.Stop();

			return new decimal (stopwatch.Elapsed.TotalMilliseconds);
        }
        
		/// <summary>String information representation</summary>
		/// <returns>String of fields</returns>
        public virtual string ToString()
        {
			string data = String.Join(", ", Data);
			string sortedData = String.Join(", ", SortedData);
			return $"Original collection: {data} [{Data.ToString()}], \n" +
				$"Sorted collection: {sortedData} [{SortedData.ToString()}], \n" +
				$"Execution time: {GetExecutionTime()}";
        }
    }
}
