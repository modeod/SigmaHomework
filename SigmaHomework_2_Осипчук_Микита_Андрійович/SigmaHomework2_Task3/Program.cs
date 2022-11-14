namespace SigmaHomework2_Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte[,,] cubick = new byte[,,]
            {
                {
                    {1, 1, 1, 1},
                    {1, 1, 1, 1 },
                    {1, 1, 1, 1 },
                    {1, 1, 1, 1 }
                },
                {
                    {1, 1, 0, 1 },
                    {1, 1, 0, 1 },
                    {0, 1, 1, 1 },
                    {1, 1, 1, 1 }
                },
                {
                    {1, 1, 1, 1 },
                    {1, 1, 1, 1 },
                    {1, 1, 1, 0 },
                    {1, 1, 1, 1 }
                },
                {
                    {1, 1, 1, 1 },
                    {1, 1, 1, 1 },
                    {1, 1, 1, 1 },
                    {1, 1, 1, 1}
                }
            };

            Cube cube = new Cube(cubick);

            Console.WriteLine(cube.IsThereAThroughHole());
        }
    }
}