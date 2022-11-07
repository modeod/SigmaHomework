namespace SigmaHomework_4_Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            IntArrayWrapper wrapper = new IntArrayWrapper(0, 11, 16);
            Console.WriteLine(wrapper);


            FrequencyTable<int> frequencyTable = new FrequencyTable<int>();

            frequencyTable.FillFrequencyTable(wrapper.ToArray());

            Console.WriteLine(frequencyTable);
            Console.WriteLine(frequencyTable.Max);

            Console.WriteLine(new String('-', 10));

            frequencyTable.OrderByAscendingKeys();
            Console.WriteLine(frequencyTable);
            Console.WriteLine(frequencyTable.Max);

            Console.WriteLine(new String('-', 10));

            (ColorHorizontalLine longest, ColorHorizontalLine second) lines = wrapper.Find2GreaterPrimeSequences();
            if (lines.longest.Color != null)
                Console.WriteLine("LongestPrimeLine: " + lines.longest);

            if (lines.second.Color != null)
                Console.WriteLine("SecondPrimeLine: " + lines.second);

            Console.ReadKey();
        }
    }
}