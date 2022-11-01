namespace SigmaHomework2_Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            while (true)
            {
                ColorMatrix matrix = new ColorMatrix();
                Console.WriteLine(matrix.Generate().ToString());

                ColorHorizontalLine line = matrix.FindLongestHorizontalOneColorLine();

                Console.WriteLine(line);
                Console.WriteLine(new String('-', 10));

                if (line.LenghtHorizontal >= 4) break;
            }
        }
    }
}