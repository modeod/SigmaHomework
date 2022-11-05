using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHomework_4_Task2
{
    internal class IntArrayWrapper : IEnumerable<int>
    {
        private int[] _array;

        public int this[int index]
        {
            get => _array[index];
            set => _array[index] = value;
        }

        public int Lenght { get => _array.Length; }

        public IntArrayWrapper(int minValueInclusive = 0, int maxValueExclusive = 1, int lenght = 1)
        {
            GenerateArray(minValueInclusive, maxValueExclusive, lenght);
        }

        public IntArrayWrapper GenerateArray(int minValueInclusive, int maxValueExclusive, int lenght)
        {
            Random rnd = new Random();
            _array = new int[lenght];
            for (int i = 0; i < lenght; i++)
                _array[i] = rnd.Next(minValueInclusive, maxValueExclusive);

            return this;    
        }

        public (ColorHorizontalLine, ColorHorizontalLine) Find2GreaterPrimeSequences()
        {
            int[] primeArray = GeneratePrimeNumbersTo(_array.Length);

            ColorHorizontalLine longestLine = new ColorHorizontalLine(
                    new Point(0, 0),
                    new Point(0, 0),
                    _array[0]);
            ColorHorizontalLine secondlongestLine = new ColorHorizontalLine(
                    new Point(0, 0),
                    new Point(0, 0),
                    _array[0]);

            ColorHorizontalLine currentLine = new ColorHorizontalLine(
                    new Point(0, 0),
                    new Point(0, 0),
                    _array[0]);

            for (int x = 1; x < _array.Length; x++)
            {
                int currentColor = _array[x];

                if (currentColor != currentLine.Color)
                {
                    currentLine = new ColorHorizontalLine();
                    currentLine.FirstPoint = new Point(x, 0);
                    currentLine.Color = currentColor;
                }

                currentLine.SecondPoint = new Point(x, 0);

                if (currentLine.Color != null)
                {
                    int currenThisColor = (int)currentLine.Color;
                    if (primeArray.Contains(currenThisColor))
                    {
                        if (currentLine.LenghtHorizontal > longestLine.LenghtHorizontal)
                        {
                            longestLine = currentLine;
                            secondlongestLine = longestLine;
                        }
                        else if (currentLine.LenghtHorizontal > secondlongestLine.LenghtHorizontal)
                        {
                            secondlongestLine = currentLine;
                        }
                    }
                }
            }

            ColorHorizontalLine longestLineToReturn = longestLine;
            ColorHorizontalLine secondLineToReturn = secondlongestLine;


            int longColor = (int)longestLineToReturn.Color;
            int secondColor = (int)secondLineToReturn.Color;

            if (!primeArray.Contains(longColor))
                longestLineToReturn.Color = null;

            if (!primeArray.Contains(secondColor))
                secondLineToReturn.Color = null;

            return (longestLineToReturn, secondLineToReturn);
        }

        public int[] GeneratePrimeNumbersTo(int max)
        {
            List<int> primes = new List<int>();
            primes.Add(1);
            for (int i = 2; i <= max; i++)
            {
                bool b = true;
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0 & i % 1 == 0)
                        b = false;
                }

                if (b)
                    primes.Add(i);
            }

            return primes.ToArray();
        }

        public int[] ToArray()
        {
            return _array;
        }

        public IEnumerator<int> GetEnumerator()
        {
            foreach (int o in _array)
            {
                yield return o;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
