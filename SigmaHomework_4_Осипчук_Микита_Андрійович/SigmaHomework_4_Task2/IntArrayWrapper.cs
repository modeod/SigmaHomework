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
        private int _maxNumber;
        private int _minNumber;

        public int this[int index]
        {
            get => _array[index];
            set => _array[index] = value;
        }

        public int Lenght { get => _array.Length; }
        public int MaxNumber { get => _maxNumber; }
        public int MinNumber { get => _minNumber; }

        public IntArrayWrapper(int minValueInclusive = 0, int maxValueExclusive = 1, int lenght = 1)
        {
            GenerateArray(minValueInclusive, maxValueExclusive, lenght);
        }

        public IntArrayWrapper GenerateArray(int minValueInclusive, int maxValueExclusive, int lenght)
        {
            _minNumber = minValueInclusive;
            _maxNumber = maxValueExclusive;

            Random rnd = new Random();
            _array = new int[lenght];
            for (int i = 0; i < lenght; i++)
                _array[i] = rnd.Next(minValueInclusive, maxValueExclusive);


            //_array = new int[] { 0, 10, 9, 9, 1, 7, 7, 7, 5, 5, 9, 7, 9, 4, 3, 3, 3, 3 };
            //_array = new int[] { 3, 4, 6, 3, 6, 5, 8, 1, 1, 10, 4, 5, 8, 2, 5, 8 };
            return this;
        }

        public (ColorHorizontalLine longest, ColorHorizontalLine secondLongest) Find2GreaterPrimeSequences()
        {
            int[] primeArray = GeneratePrimeNumbersTo(_maxNumber);
            bool nextLine = false;

            ColorHorizontalLine longestLine = new ColorHorizontalLine(
                    0, 0, 0);
            ColorHorizontalLine secondlongestLine = new ColorHorizontalLine(
                    0, 0, 0); ;

            ColorHorizontalLine currentLine = new ColorHorizontalLine(
                    0, 0, 0);

            for (int x = 0; x < _array.Length; x++)
            {
                int currentColor = _array[x];
                if ( ! primeArray.Contains(currentColor))
                {
                    nextLine = true;
                    continue;
                }

                if (nextLine || currentColor != currentLine.Color)
                {
                    currentLine = new ColorHorizontalLine();
                    currentLine.FirstPoint = x;
                    currentLine.Color = currentColor;
                }

                currentLine.SecondPoint = x;


                if (currentLine.Lenght > longestLine.Lenght || longestLine.Color == 0)
                {
                    if(longestLine.FirstPoint != currentLine.FirstPoint)
                        secondlongestLine = longestLine;
                    longestLine = currentLine;
                }
                else if (currentLine.Lenght > secondlongestLine.Lenght || secondlongestLine.Color == 0 && currentLine.Color != longestLine.Color)
                { 
                    secondlongestLine = currentLine;
                }

                nextLine = false;
            }


            int longColor = (int)longestLine.Color;
            int secondColor = (int)secondlongestLine.Color;

            if (!primeArray.Contains(longColor))
                longestLine.Color = null;

            if (!primeArray.Contains(secondColor))
                secondlongestLine.Color = null;

            return (longestLine, secondlongestLine);
        }

        public int[] GeneratePrimeNumbersTo(int max)
        {
            List<int> primes = new List<int>();
            for (int i = 2; i <= max; i++)
            {
                bool b = true;
                for (int j = 2; j < i; j++)
                {// Особливо "цінна" друга частина умови)), а також плутаєте операцію  & і &&
               
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

        public override string ToString()
        {
            StringBuilder sb = new();
            for (int i = 0; i < _array.Length; i++)
                sb.Append(_array[i] + " ");
            return sb.ToString();
        }
    }
}
