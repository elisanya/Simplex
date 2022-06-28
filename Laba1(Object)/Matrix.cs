using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1_Object_
{
    public class Matrix
    {
        private double[,] data;
        private readonly int m;
        private readonly int n;

        public int M { get => this.m; }
        public int N { get => this.n; }
        public double this[int x, int y]
        {
            get
            {
                return this.data[x, y];
            }
            set
            {
                this.data[x, y] = value;
            }
        }

        public Matrix(int m, int n)
        {
            this.m = m;
            this.n = n;
            this.data = new double[m, n];
            SetDefaultValue();
        }

        #region MathOperations
        public static Matrix operator *(Matrix matrix, double value)
        {
            var result = new Matrix(matrix.M, matrix.N);
            result.ProcessFunctionOverData((i, j) =>
                result[i, j] = matrix[i, j] * value);
            return result;
        }
        public static Matrix operator *(Matrix matrix, Matrix matrix2)
        {
            if (matrix.N != matrix2.M)
            {
                throw new ArgumentException("matrixes can not be multiplied");
            }
            var result = new Matrix(matrix.M, matrix2.N);
            result.ProcessFunctionOverData((i, j) =>
            {
                for (var k = 0; k < matrix.N; k++)
                {
                    result[i, j] += matrix[i, k] * matrix2[k, j];
                }
            });
            return result;
        }
        public static Matrix operator +(Matrix matrix, Matrix matrix2)
        {
            if (matrix.N != matrix2.N || matrix.M != matrix2.M)
            {
                throw new ArgumentException("matrixes can not be added");
            }
            var result = new Matrix(matrix.M, matrix.N);
            result.ProcessFunctionOverData((i, j) =>
            {
                result[i, j] = matrix[i, j] + matrix2[i, j];
            });
            return result;
        }
        public static Matrix operator -(Matrix matrix, Matrix matrix2)
        {
            if (matrix.N != matrix2.N || matrix.M != matrix2.M)
            {
                throw new ArgumentException("matrixes can not be substract");
            }
            var result = new Matrix(matrix.M, matrix.N);
            result.ProcessFunctionOverData((i, j) =>
            {
                result[i, j] = matrix[i, j] - matrix2[i, j];
            });
            return result;
        }
        public static Matrix Transpose(Matrix matrix)
        {
            var result = new Matrix(matrix.N, matrix.M);
            result.ProcessFunctionOverData((i, j) =>
            {
                result[i, j] = matrix[j, i];
            });
            return result;
        }
        public static Matrix Pow(Matrix matrix, int power)
        {
            if (matrix.N != matrix.M)
            {
                throw new ArgumentException("matrix can not be powered");
            }
            if (power == 0)
            {
                return E(matrix.M);
            }
            var result = matrix;
            for (var i = 1; i < power; i++)
            {
                result *= matrix;
            }
            return result;
        }
        public static double Determinant(Matrix matrix)
        {
            double result = 0;
            if (matrix.M != matrix.N)
            {
                throw new ArgumentException("matrix didn't have determinant");
            }
            if (matrix.M == 1)
            {
                return matrix[0, 0];
            }
            for (int i = 0; i < matrix.M; i++)
            {
                result += matrix[i, 0] * Math.Pow(-1, i + 2) * Determinant(matrix.Decomposition(i, 0));
            }
            return result;
        }
        public static Matrix Inverse(Matrix matrix)
        {
            if (matrix.N != matrix.M)
            {
                throw new ArgumentException("matrix isn't square");
            }
            var result = new Matrix(matrix.M, matrix.N);
            result = Transpose(Union(matrix)) * (1 / Determinant(matrix));
            return result;

        }
        public static Matrix Union(Matrix matrix)
        {
            if (matrix.N != matrix.M)
            {
                throw new ArgumentException("matrix isn't square");
            }
            var result = new Matrix(matrix.M, matrix.N);
            result.ProcessFunctionOverData((i, j) =>
            {
                result[i, j] = Determinant(matrix.Decomposition(i, j)) * Math.Pow(-1, i + j + 2);
            });
            return result;
        }
        #endregion MathOperations

        public void Log(string matrixName = "")
        {
            if (!string.IsNullOrEmpty(matrixName))
            {
                Console.WriteLine(matrixName);
            }
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                    Console.Write(data[i, j] + " ");
                Console.WriteLine();
            }
        }
        public static Matrix E(int n)
        {
            var result = new Matrix(n, n);
            result.SetDefaultValue();
            result.ProcessFunctionOverData((i, j) =>
            {
                if (i == j)
                    result[i, j] = 1;
            });
            return result;
        }
        public void ProcessFunctionOverData(Action<int, int> func)
        {
            for (var i = 0; i < this.M; i++)
            {
                for (var j = 0; j < this.N; j++)
                {
                    func(i, j);
                }
            }
        }
        public static Matrix CopyData(Matrix matrix)
        {
            var result = new Matrix(matrix.M, matrix.N);
            result.ProcessFunctionOverData((i, j) =>
            {
                result[i, j] = matrix[i, j];
            });
            return result;
        }
        public Matrix Decomposition(int i, int j)
        {
            Queue<double> data = new Queue<double>();
            var result = new Matrix(this.M - 1, this.N - 1);
            for (int k = 0; k < this.M; k++)
                for (int l = 0; l < this.N; l++)
                    if (k == i || l == j) { }
                    else { data.Enqueue(this[k, l]); }
            for (int k = 0; k < result.M; k++)
                for (int l = 0; l < result.N; l++)
                    result[k, l] = data.Dequeue();
            return result;
        }

        private void SetDefaultValue()
        {
            this.ProcessFunctionOverData((i, j) => this.data[i, j] = 0);
        }
    }
}