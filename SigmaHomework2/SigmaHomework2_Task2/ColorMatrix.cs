using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHomework2_Task2
{
    internal class ColorMatrix
    {
        private byte[,] _matrix;
        private readonly int _n;
        private readonly int _m;

        //TODO: Add indexator for matrix to check if value > 16

        public ColorMatrix(int y = 5, int x = 5)
        {
            _matrix = new byte[y, x];
            _n = y; _m = x;
        }

        public ColorHorizontalLine FindLongestHorizontalOneColorLine()
        {
            ColorHorizontalLine longestLine = new ColorHorizontalLine(
                new Point(0, 0),
                new Point(0, 0),
                _matrix[0, 0]);

            for (int y = 0; y < _n; y++)
            {
                ColorHorizontalLine currentLine = new ColorHorizontalLine(
                    new Point(y, 0),
                    new Point(y, 0),
                    _matrix[y, 0]);

                for (int x = 1; x < _m; x++)
                {
                    byte currentColor = _matrix[y, x]; 

                    if (currentColor != currentLine.Color)
                    {
                        currentLine = new ColorHorizontalLine();
                        currentLine.FirstPoint = new Point(x, y);
                        currentLine.Color = currentColor;
                    }

                    currentLine.SecondPoint = new Point(x, y);

                    if (currentLine.LenghtHorizontal > longestLine.LenghtHorizontal)
                    {
                        longestLine = currentLine;
                    }
                }
            }

            return longestLine;
        }

        public ColorMatrix Generate()
        {
            Random rnd = new Random();

            //for (int y = 0; y < _n; y++)
            //    for (int x = 0; x < _m; x++)
            //        _matrix[y, x] = (byte)rnd.Next(0, 17);

            _matrix = new byte[,]
            {
                {10, 4, 0, 15, 14 },
                { 8, 0, 6, 3, 0},
                { 15, 11, 7, 14, 2},
                {0, 6, 9, 13, 5},
                {7, 10, 2, 11, 11 },
            };

            return this;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Matrix " + this.GetType().ToString() + ": ");
            for (int y = 0; y < _n; ++y)
            {
                for (int x = 0; x < _m; ++x)
                {
                    stringBuilder.Append(_matrix[y, x] + " ");
                }
                stringBuilder.Append("\n");
            }

            return stringBuilder.ToString();
        }

    }
}
