using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class Matrix<T> where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        // Fields
        private int row;
        private int column;
        private T[,] matrixArray;
        

        // Properties
        public int Row
        {
            get
            {
                return this.row;
            }
            set
            {
                if (value < 1)
                {
                    throw new IndexOutOfRangeException("Row must be positive");
                }
                else
                {
                    this.row = value;
                }
            }
        }
        public int Column
        {
            get
            {
                return this.column;
            }
            set
            {
                if (value < 1)
                {
                    throw new IndexOutOfRangeException("column must be positive");
                }
                else
                {
                    this.column = value;
                }
            }
        }
        // indexer
        public T this[int row, int column]
        {
            get
            {
                if ((row > -1) && (column > -1) && ((row < this.Row) && (column < this.Column)))
                {
                    return this.matrixArray[row, column];
                }
                else
                {

                    throw new IndexOutOfRangeException("Matrix indexes must be positive");
                }
            }
            set
            {
                if ((row > -1) && (column > -1) && ((row < this.Row) && (column < this.Column)))
                {
                    matrixArray[row, column] = value;
                    
                }
                else
                {
                    throw new IndexOutOfRangeException("Matrix indexes");
                }
            }
        }

        // Constructor
        public Matrix(T[,] matrix)
        {
            this.Row = matrix.GetLength(0);
            this.Column = matrix.GetLength(1);
            this.matrixArray = (T[,])matrix.Clone();            
        }
        public Matrix(int row, int column)
        {
            this.Row = row;
            this.Column = column;
            this.matrixArray = new T [row,column];
        }

        // Methods
        public static Matrix<T> operator +(Matrix<T> m1, Matrix<T> m2)
        {
            if (m1.row != m2.row && m1.column != m2.column)
            {
                throw new System.ArgumentException("To add matrixes, they must be with same dimentions");
            }
            else
            {
                Matrix<T> result = new Matrix<T>(m1.row, m1.column);
                for (int i = 0; i < m1.row; i++)
                {
                    for (int j = 0; j < m1.column; j++)
                    {
                        result[i, j] = (dynamic)m1[i, j] + m2[i, j];
                    }
                }
                return result;
            }
        }
        public static Matrix<T> operator -(Matrix<T> m1, Matrix<T> m2)
        {
            if (m1.row != m2.row && m1.column != m2.column)
            {
                throw new System.ArgumentException("To substract matrixes, they must be with same dimentions");
            }
            else
            {
                Matrix<T> result = new Matrix<T>(m1.row, m1.column);
                for (int i = 0; i < m1.row; i++)
                {
                    for (int j = 0; j < m1.column; j++)
                    {
                        result[i, j] = (dynamic)m1[i, j] - m2[i, j];
                    }
                }
                return result;
            }
        }
        public static Matrix<T> operator *(Matrix<T> m1, Matrix<T> m2)
        {
            if (m1.row != m2.column)
            {
                throw new System.ArgumentException("To multiply matrixes, rows of first must be same as columns of second");
            }
            else
            {
                Matrix<T> result = new Matrix<T>(m1.row, m1.column);
                for (int i = 0; i < m1.row; i++)
                {
                    for (int j = 0; j < m1.column; j++)
                    {
                        result[i, j] = default(T);
                        for (int k = 0; k < m1.column; k++)
                        {
                            result[i, j] += (dynamic)m1[i, k] * m2[k, j];
                        }
                    }
                }
                return result;
            }
        }
        public static bool operator true(Matrix<T> m)
        {
            for (int i = 0; i < m.Row; i++)
            {
                for (int j = 0; j < m.Column; j++)
                {
                    if (!m[i,j].Equals(default(T)))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool operator false(Matrix<T> m)
        {
            for (int i = 0; i < m.Row; i++)
            {
                for (int j = 0; j < m.Column; j++)
                {
                    if (!m[i, j].Equals(default(T)))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static bool operator !(Matrix<T> m)
        {
            if (m)
            {
                return false;
            }

            else
            {
                return true;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int j = 0; j < this.row; j++)
            {
                sb.Append("------");
            }
            sb.Append("\n");
            for (int i = 0; i < this.row; i++)
            {
                for (int j = 0; j < this.column; j++)
                {
                    if (j == 0)
                    {
                        sb.Append( "|".PadRight(3));
                    }
                    sb.Append(Convert.ToString(this.matrixArray[i, j]).PadRight(3));
                    sb.Append("|".PadRight(3));
                }
                sb.Append("\n");
                for (int j = 0; j < this.row; j++)
                {
                    sb.Append("------");
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }

    }
}
