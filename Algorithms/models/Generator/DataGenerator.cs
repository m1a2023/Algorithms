using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.models.Generator
{
    /// <summary>Implementation randomizer</summary>
    public class DataGenerator
    {
        private readonly Random random = new Random();
        
        /// <summary>Returns a random integer that is within a specified range.</summary>
        /// <returns>Randomized long (64bit int) from 0 to Integer.MAX_VALUE</returns>
        public Int32 GetRandomUInt32() { return random.Next();  }
            
        /// <summary>Returns a random integer that is within a specified range.</summary>
        /// <returns>Randomized long (64bit int) from Int32.MinValue to Int32.MaxValue</returns>
        public Int32 GetRandomInt32() { return random.Next(int.MinValue, int.MaxValue); }
        
        /// <summary>Returns a random integer that is within a specified range.</summary>
        /// <returns>Randomized long (64bit int) from 0 to Integer.MAX_VALUE</returns>
        public Int64 GetRandomPositiveInt64() { return random.NextInt64(); }
            
        /// <summary>Returns a random integer that is within a specified range.</summary>
        /// <returns>Randomized long (64bit int) from Int32.MinValue to Int32.MaxValue</returns>
        public Int64 GetRandomInt64() { return random.Next(Int32.MinValue, Int32.MaxValue); }
        
        /// <summary>Returns a random integer that is within a specified range.</summary>
        /// <param name="minValue">The inclusive lower bound of the random number returned.</param>
        /// <param name="maxValue">The exclusive upper bound of the random number returned. <paramref name="maxValue"/> must be greater than or equal to <paramref name="minValue"/>.</param>
        /// <returns>Randomized long (64bit int) from minValue to maxValue</returns>
        public Int64 GetRandomInt64(Int64 minValue, Int64 maxValue) 
        { 
            return random.NextInt64(minValue, maxValue); 
        }
        
        /// <summary>Returns a random Double</summary>
        /// <returns>Randomized Double from 0 to 1</returns>
        public Double GetRandomDouble() { return random.NextDouble(); }
        
        /// <summary>Returns a random Double with scaling factor</summary>
        /// <param name="scale"></param>
        /// <returns>Randomized value multiplied by 10 ^ scale</returns>
        public Double GetRandomDouble(Int32 scale) 
        { 
            return random.NextDouble() * Math.Pow(10, scale); 
        }
        
    }
}
