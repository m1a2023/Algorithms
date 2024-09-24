using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Algorithms.models.Algorithms.models;

namespace AlgorithmsTests
{
	[TestClass]
	public class ConstantTests
	{
		Constant<Int64> constantInt = new();
		Constant<Double> constantDouble = new();

		[TestMethod]
		public void ArrayTest()
		{
			/**
			 *  Test integer array
			 */
			Int64[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 90 };

			/**
			 *  
			 */
			BigInteger one = BigInteger.One;   

			/**
			 *  Output 
			 */
			Console.WriteLine("Execution " + array.GetType().Name + " array time: " + constantInt.GetExecutionTime(array));

			Console.WriteLine(new Constant<long>(array).ToString());
		}

		[TestMethod]
		public void ListTest()
		{
			/**
			 *  Test Double list 
			 */
			List<Double> list = new List<Double> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 1, 2, 999, 1000 };
			
			/**
			 * 
			 */
			Double one = 1;
			
			/**
			 *  Output 
			 */
			Console.WriteLine("Execution " + list.GetType().Name + " array time: " + constantDouble.GetExecutionTime(list));
		}
	}
}
