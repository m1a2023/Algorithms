using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.models.Algorithms
{
    // ! DEPRICATED
    //  DO NOT USE! 
    /// <summary>Represents algorithm and it's methods</summary>
    /// <typeparam name="T"></typeparam>
    public interface IAlgorithm<T>
        where T : INumber<T>
    {
        decimal GetExecutionTime(ICollection<T> data);
        void Execute(ICollection<T> data);
    }
}
