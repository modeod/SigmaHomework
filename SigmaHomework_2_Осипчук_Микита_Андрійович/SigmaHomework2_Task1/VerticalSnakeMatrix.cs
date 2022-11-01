using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHomework2_Task1
{
    public class VerticalSnakeMatrix : MMMatrix
    {
        delegate void MatrixSet(ref int[,] toMatrix, int x, int y, int value);

        public VerticalSnakeMatrix(int m, int n) : base(m, n) { }

        public override MMMatrix Fill(bool revert = false)
        {
            int value = 1;
            MatrixSet setMatrixElement;
            int side1, side2;

            if (revert)
            {
                side1 = _n;
                side2 = _m;
                setMatrixElement = (ref int[,] toMatrix, int x, int y, int value) => toMatrix[x, y] = value;
            }
            else
            {
                side1 = _m;
                side2 = _n;
                setMatrixElement = (ref int[,] toMatrix, int x, int y, int value) => toMatrix[y, x] = value;
            }

            for (int x = 0; x < side1; x++)
            {
                if (x % 2 == 0)
                {
                    for (int y = 0; y < side2; y++)
                    {
                        setMatrixElement(ref _matrix, x, y, value);
                        value++;
                    }
                }
                else
                {
                    for (int y = side2 - 1; y >= 0; y--)
                    {
                        setMatrixElement(ref _matrix, x, y, value);
                        value++;
                    }
                }
            }

            return this;
        }
    }
}
