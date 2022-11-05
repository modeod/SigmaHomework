using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHomework_4_Task2
{
    internal class FrequencyTable<T> where T : struct, IComparable<T>
    {
        private Dictionary<T, int> _frequencyTableDictionatry { get; set; }
        private T max;

        public Dictionary<T, int> FrequencyTableDictionatry { get => new Dictionary<T, int>(_frequencyTableDictionatry); }
        public T Max { get => max; }
        public FrequencyTable()
        {
            _frequencyTableDictionatry = new Dictionary<T, int>();
        }

        public FrequencyTable<T> FillFrequencyTable(T[] array)
        {
            max = default(T);
            for (int i = 0; i < array.Length; i++)
            {
                T currentValue = array[i];
                int frqValue;

                if(currentValue.CompareTo(max) > 0)
                {
                    max = currentValue;
                }

                if (_frequencyTableDictionatry.TryGetValue(currentValue, out frqValue))
                {
                    _frequencyTableDictionatry[currentValue]++;
                    continue;
                }

                _frequencyTableDictionatry[currentValue] = 1;
            }

            return this;
        }
        
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<T, int> kvp in _frequencyTableDictionatry)
            {
                sb.AppendLine($"Key = {kvp.Key}, Value = {kvp.Value}");
            }

            return sb.ToString();
        }

        

        public FrequencyTable<T> OrderedByAscendingKeys()
        {
            _frequencyTableDictionatry = _frequencyTableDictionatry.OrderBy(kv => kv.Key).ToDictionary(kv => kv.Key, kv => kv.Value);
            return this;
        }

        public FrequencyTable<T> OrderedByAscendingValues()
        {
            _frequencyTableDictionatry = _frequencyTableDictionatry.OrderBy(kv => kv.Value).ToDictionary(kv => kv.Key, kv => kv.Value);
            return this;
        }

        public FrequencyTable<T> OrderedByDescendingKeys()
        {
            _frequencyTableDictionatry = _frequencyTableDictionatry.OrderByDescending(kv => kv.Key).ToDictionary(kv => kv.Key, kv => kv.Value);
            return this;
        }

        public FrequencyTable<T> OrderedByDescendingValues()
        {
            _frequencyTableDictionatry = _frequencyTableDictionatry.OrderByDescending(kv => kv.Value).ToDictionary(kv => kv.Key, kv => kv.Value);
            return this;
        }
    }
}
