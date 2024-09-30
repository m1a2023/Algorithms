using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.models.Algorithms.models
{
	/// <summary>Implementation Constant function algorithm</summary>
	/// <typeparam name="T">Inner data type</typeparam>
	public class Constant<T> : AProcessingAlgorithm<T>
		where T : INumber<T>
	{
		/// <summary>Default constructor</summary>
		public Constant() { } 
        
		/// <summary>Extended constructor</summary>
        /// <param name="Data"></param>
		public Constant(IList<T> Data) : base(Data) { }

        public override T Process(IList<T> Data)
        {
			return T.CreateChecked(1);
        }

        /// <summary>general methond that executes algorithm</summary>
        /// <param name="data">value collection, implemented via icollection</param>
        public override void Execute(IList<T> data) { Process(data); }
    }
}
