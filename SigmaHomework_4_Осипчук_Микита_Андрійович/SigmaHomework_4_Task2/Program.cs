namespace SigmaHomework_4_Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            IntArrayWrapper wrapper = new IntArrayWrapper(0, 16, 16);
            FrequencyTable<int> frequencyTable = new FrequencyTable<int>();

            Console.WriteLine(frequencyTable.FillFrequencyTable(wrapper.ToArray()));
            Console.WriteLine(frequencyTable.Max);

            (ColorHorizontalLine longest, ColorHorizontalLine second) lines = wrapper.Find2GreaterPrimeSequences();
            if (lines.longest.Color != null)
                Console.WriteLine("LongestPrimeLine: " + lines.longest);

            if (lines.second.Color != null)
                Console.WriteLine("SecondPrimeLine: " + lines.longest);

            Console.ReadKey();
        }
    }
}