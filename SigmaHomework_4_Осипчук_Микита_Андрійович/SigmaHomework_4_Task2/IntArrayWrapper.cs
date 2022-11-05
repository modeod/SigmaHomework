using System;
using System.Collections;
using System.Collections.Generic;
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
