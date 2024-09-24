using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.models.Algorithms.models
{
    /// <summary>Implementation sum element algorithm</summary>
    /// <typeparam name="T">Inner data type</typeparam>
    public class Addition<T> : AProcessingAlgorithm<T>
        where T : INumber<T>
    {

        /// <summary>Default constructor</summary>
        public Addition() { } 

		/// <summary>Extended constructor</summary>
		/// <param name="Data"></param>
        public Addition(IList<T> Data) : base(Data) { }
        
        /// <summary>General method that executes algorithm</summary>
        /// <param name="data">Value collection, implemented via ICollection</param>
        /// <returns>Variable the same type as the argument</returns>
        public override void Execute(IList<T> data)
        {
            Add(data);
        }

        public override T Process(IList<T> Data)
        {
            return Add(Data);
        }

        private T Add(IList<T> data) 
        {
            T tmp = T.Zero;

            foreach (T item in data)
            {
                tmp += item;
            }
            
            return tmp;
        }
    }
}
