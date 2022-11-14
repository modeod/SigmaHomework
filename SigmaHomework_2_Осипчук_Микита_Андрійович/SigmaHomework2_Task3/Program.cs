namespace SigmaHomework2_Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte[,,] cubick = new byte[,,]
            {
                {
                    {1, 1, 0, 1},
                    {1, 1, 1, 1 },
                    {1, 1, 1, 1 },
                    {1, 1, 1, 1 }
                },
                {
                    {1, 0, 0, 1 },
                    {0, 1, 1, 1 },
                    {0, 1, 1, 1 },
                    {1, 1, 1, 1 }
                },
                {
                    {1, 1, 1, 1 },
                    {1, 1, 1, 1 },
                    {1, 1, 1, 1 },
                    {1, 1, 1, 1 }
                },
                {
                    {1, 1, 1, 1 },
                    {1, 1, 0, 1 },
                    {1, 1, 1, 1 },
                    {1, 1, 0, 1}
                }
            };

            Cube cube = new Cube(cubick);

            bool doesLineExists = cube.IsThereAThroughHole(
                out (int I, int J, int K) startPoint,
                out (int I, int J, int K) endPoint);

            Console.WriteLine(doesLineExists);

            if (doesLineExists)
            {
                Console.WriteLine(startPoint);
                Console.WriteLine(endPoint);
            }
            
        }
    }
}