using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHomework2_Task1
{
    public abstract class MMMatrix
    {

        protected readonly int _m;
        protected readonly int _n;
        protected int[,] _matrix;

        public MMMatrix(int m, int n)
        {
            _m = m;
            _n = n;
            _matrix = new int[n, m];

            for (int y = 0; y < _n; y++)
            {
                for (int x = 0; x < _m; x++)
                {
                    _matrix[y, x] = default;
                }
            }
        }

        public abstract MMMatrix Fill(bool revert = false);

        public override string ToString()
        {
            int maxNumLenght = (_n * _m).ToString().Length;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Matrix " + this.GetType().ToString() + ": ");

            for (int y = 0; y < _n; ++y)
            {
                for (int x = 0; x < _m; ++x)
                {
                    stringBuilder.Append(_matrix[y, x].ToString().PadLeft(maxNumLenght, ' ') + " ");
                }
                stringBuilder.Append('\n');
            }
            stringBuilder.Append("\n");

            return stringBuilder.ToString();
        }
    }
}
