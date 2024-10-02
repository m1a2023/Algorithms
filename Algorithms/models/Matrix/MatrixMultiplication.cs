using Algorithms.models.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Algorithms.models.Generator;
using System.Diagnostics;

namespace Algorithms.models.Matrix
{
	public class SquareMatrixMultiplication<T> 
		where T : INumber<T>
	{
		private Matrix<T> M1;
		private Matrix<T> M2;

		public SquareMatrixMultiplication () { }
		public SquareMatrixMultiplication (Matrix<T> M1, Matrix<T> M2) { this.M1 = M1; this.M2 = M2; }

		public Matrix<T> GetMatrix(int size)
		{
			return  new Matrix<T>(size, size);
		}

		public Matrix<T> GetRandomMatrix(int size, Int32 minValue, Int32 maxValue)
		{
			return new StructGenerator().GenerateMatrix<T>(size, minValue, maxValue);
		}

		public void Execute(Matrix<T> m1, Matrix<T> m2)
		{
			Process(m1, m2);
		}
		
		public Matrix<T> Process(Matrix<T> m1, Matrix<T> m2)
		{
			return m1 * m2;
		}
			
		public void SetMatrices(Matrix<T> m1, Matrix<T> m2) { this.M1 = m1; this.M2 =  m2; }

		public double GetExecutionTime() { return GetExecutionTime(this.M1, this.M2); }

		public double GetExecutionTime(Matrix<T> m1, Matrix<T> m2)
		{
			Stopwatch stopwatch = Stopwatch.StartNew();

			Execute(m1, m2);

			stopwatch.Stop();

			return stopwatch.Elapsed.TotalMilliseconds;
		}
    }
}
