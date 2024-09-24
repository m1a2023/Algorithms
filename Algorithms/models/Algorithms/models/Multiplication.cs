using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.models.Algorithms.models
{
    /// <summary>Implementation multiplication algorithm</summary>
    /// <typeparam name="T">Inner data type</typeparam>
    public class Multiplication<T> : AProcessingAlgorithm<T>
        where T : INumber<T>
    {
        /// <summary>Default constructor</summary>
        public Multiplication() { }

		/// <summary>Extended constructor</summary>
		/// <param name="Data"></param>
        public Multiplication(IList<T> Data) : base(Data) { }

        /// <summary>General method that executes algorithm</summary>
        /// <param name="data">Value collection, implemented via ICollection</param>
        public override void Execute(IList<T> data)
        {
            Process(data);
        }

        public override T Process(IList<T> Data)
        {
            return Multiplicate(Data);  
        }

        private T Multiplicate(IList<T> data)
        {
            T tmp = T.One;

            foreach (T item in data)
            {
                tmp *= item;
            }

            return tmp; 
        }
    }
}

