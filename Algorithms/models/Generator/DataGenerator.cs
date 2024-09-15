using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.models.Generator
{
    /// <summary>
    /// Implementation randomizer
    /// </summary>
    public class DataGenerator
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly Random random = new Random();
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Randomized long (64bit int) from 0 to Integer.MAX_VALUE</returns>
        public Int64 GetRandomInt64() { return random.NextInt64(); }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <returns>Randomized long (64bit int) from minValue to maxValue</returns>
        public Int64 GetRandomInt64(Int64 minValue, Int64 maxValue) 
        { 
            return random.NextInt64(minValue, maxValue); 
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Randomized Double from 0 to 1</returns>
        public Double GetRandomDouble() { return random.NextDouble(); }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="scale"></param>
        /// <returns>Randomized value multiplied by 10 ^ scale</returns>
        public Double GetRandomDouble(Int32 scale) 
        { 
            return random.NextDouble() * Math.Pow(10, scale); 
        }
        
    }
}
