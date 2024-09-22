using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.models.Matrix
{
	public class Matrix<T> where T : INumber<T>
	{
		private T[,] Data;
		private int Rows {  get; }
		private int Columns { get; }

		public Matrix(int Rows, int Columns) 
		{
			this.Rows = Rows;
			this.Columns = Columns;
			Data = new T[this.Rows, this.Columns];
		}
			
		public T this[int row, int col]
		{
			get => Data[row, col];
			set => Data[row, col] = value;
		}

		public static Matrix<T> operator +(Matrix<T> a, Matrix<T> b)
		{
			if (a.Rows != b.Rows || a.Columns != b.Columns)
				throw new ArgumentException("Matrices have different dimmensions");

			Matrix<T> result = new Matrix<T>(a.Rows, a.Columns);

			for (int i = 0; i < a.Rows; i++)
			{
				for (int j = 0; j < a.Columns; j++)
				{
					result[i, j] = a[i, j] + b[i, j];
				}
			}

			return result;
		}

        public static Matrix<T> operator -(Matrix<T> a, Matrix<T> b)
        {
            if (a.Rows != b.Rows || a.Columns != b.Columns)
                throw new ArgumentException("Matrices must have the same dimensions for subtraction.");

            Matrix<T> result = new Matrix<T>(a.Rows, a.Columns);
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Columns; j++)
                {
                    result[i, j] = a[i, j] - b[i, j];
                }
            }
            return result;
        }

        public static Matrix<T> operator *(Matrix<T> matrix, T scalar)
        {
            Matrix<T> result = new Matrix<T>(matrix.Rows, matrix.Columns);
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    result[i, j] = matrix[i, j] * scalar;
                }
            }
            return result;
        }

        public static Matrix<T> operator *(Matrix<T> a, Matrix<T> b)
        {
            if (a.Columns != b.Rows)
                throw new ArgumentException("The number of columns in matrix A must be equal to the number of rows in matrix B.");

            Matrix<T> result = new Matrix<T>(a.Rows, b.Columns);
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < b.Columns; j++)
                {
                    result[i, j] = T.Zero;
                    for (int k = 0; k < a.Columns; k++)
                    {
                        result[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return result;
        }

        public Matrix<T> Transpose()
        {
            Matrix<T> result = new Matrix<T>(Columns, Rows);
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    result[j, i] = Data[i, j];
                }
            }
            return result;
        }

        // ToString override for easier display
        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    result += $"{Data[i, j]} ";
                }
                result += Environment.NewLine;
            }
            return result;
        }
    }
}
