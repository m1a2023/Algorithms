using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.models
{
    /// <summary>
    /// Represents algorithm and it's methods
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal interface IAlgorithm<T>
        where T : INumber<T>
    {
        Decimal GetExecutionTime(ICollection<T> data);
        void Execute(ICollection<T> data);
    }
}
