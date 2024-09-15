using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.models.Generator
{
    public class StructGenerator
    {
        private readonly DataGenerator dataGenerator; 
        
        /// <summary>
        /// Generates array with limit value
        /// </summary>
        /// <param name="size">Size of array</param>
        /// <param name="minValue">Min value that can be generated</param>
        /// <param name="maxValue">Max value that can be generated</param>
        /// <returns>Generated array</returns>
        public Int64[] GenerateArray(Int64 size, Int64 minValue, Int64 maxValue) 
        {
            Int64[] arr = new Int64[size];
            
            for (Int64 i = 0; i < size; i++)
            {
                arr[i] = dataGenerator.GetRandomInt64(minValue, maxValue);
            }
             
            return arr;
        }
        
        /// <summary>
        /// Generates array with limit value 
        /// </summary>
        /// <param name="size">Size of array</param>
        /// <returns>Generated array</returns>
        public Int64[] GenerateArray(Int64 size)
        {
            return GenerateArray(size, 0, long.MaxValue);
        }
    }
}
