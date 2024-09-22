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
    public class BubbleSort<T> : Algorithm<T> 
        where T : INumber<T>
    {
        protected IList<T> Data { get; private set; }
        protected IList<T> SortedData { get; private set; }
        
        /// <summary>Default constructor</summary>
        public BubbleSort() { } 

		/// <summary>Extended constructor</summary>
		/// <param name="Data"></param>
        public BubbleSort(IList<T> Data)
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

        /// <summary>General methond that executes algorithm</summary>
        /// <param name="data">value collection, implemented via icollection</param>
        public override void Execute(IList<T> data)
        {
            Sort(data);
        }

        public void Sort(IList<T> data)
        {
            for (Int64 i = 0; i < data.Count; i++)
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
    }
}
