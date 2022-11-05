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

            Console.ReadKey();
        }
    }
}