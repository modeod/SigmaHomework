using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHomework_4_Task2
{
    internal class FrequencyTable<T> where T : struct, IComparable<T>
    {
        Dictionary<T, int> FrequencyTableDictionatry { get; set; }

        public FrequencyTable()
        {
            FrequencyTableDictionatry = new Dictionary<T, int>();
        }

        public FrequencyTable<T> FillFrequencyTable(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                T currentValue = array[i];
                int frqValue;

                if (FrequencyTableDictionatry.TryGetValue(currentValue, out frqValue))
                {
                    FrequencyTableDictionatry[currentValue]++;
                    continue;
                }

                FrequencyTableDictionatry[currentValue] = 1;
            }

            return this;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<T, int> kvp in FrequencyTableDictionatry)
            {
                sb.AppendLine($"Key = {kvp.Key}, Value = {kvp.Value}");
            }

            return sb.ToString();
        }

        public FrequencyTable<T> OrderedByAscendingKeys()
        {
            FrequencyTableDictionatry = FrequencyTableDictionatry.OrderBy(kv => kv.Key).ToDictionary(kv => kv.Key, kv => kv.Value);
            return this;
        }

        public FrequencyTable<T> OrderedByAscendingValues()
        {
            FrequencyTableDictionatry = FrequencyTableDictionatry.OrderBy(kv => kv.Value).ToDictionary(kv => kv.Key, kv => kv.Value);
            return this;
        }

        public FrequencyTable<T> OrderedByDescendingKeys()
        {
            FrequencyTableDictionatry = FrequencyTableDictionatry.OrderByDescending(kv => kv.Key).ToDictionary(kv => kv.Key, kv => kv.Value);
            return this;
        }

        public FrequencyTable<T> OrderedByDescendingValues()
        {
            FrequencyTableDictionatry = FrequencyTableDictionatry.OrderByDescending(kv => kv.Value).ToDictionary(kv => kv.Key, kv => kv.Value);
            return this;
        }
    }
}
