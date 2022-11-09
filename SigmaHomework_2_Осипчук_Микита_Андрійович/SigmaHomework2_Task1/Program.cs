namespace SigmaHomework2_Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            MMMatrix verticalMatrix = new VerticalSnakeMatrix(7, 3);
            Console.WriteLine(verticalMatrix.Fill(false).ToString());
            Console.WriteLine(verticalMatrix.Fill(true).ToString()); // revert

            MMMatrix spiralMatrix = new SpiralMatrix(6, 8);
            Console.WriteLine(spiralMatrix.Fill(false).ToString());
            Console.WriteLine(spiralMatrix.Fill(true).ToString()); // revert

            MMMatrix diagonalMatrix = new DiagonalMatrix(6);
            Console.WriteLine(diagonalMatrix.Fill(false).ToString());
            Console.WriteLine(diagonalMatrix.Fill(true).ToString()); // revert

            Console.ReadKey();
        }
    }
}