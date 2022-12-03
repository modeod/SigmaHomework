using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHomework_7_Task1
{
    public static class ConsoleAnswers
    {
        public delegate T Parser<T>(string s);

        public static T GetAnswerAndParse<T>(string message, Parser<T> parser, Predicate<T> predicate)
        {
            while (true)
            {
                Console.Write(message + " ");
                try
                {
                    string? answer = Console.ReadLine();
                    if (answer == null)
                        throw new NullReferenceException();


                    T result = parser(answer);
                    if (predicate(result))
                        return result;

                    throw new ArgumentOutOfRangeException();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Wrong input, try again.");
                }
            }
        }

        public static string GetAnswer(string message)
        {
            while (true)
            {
                Console.Write(message + " ");
                try
                {
                    string? answer = Console.ReadLine();
                    if (answer == null || answer == "")
                        throw new NullReferenceException();

                    return answer;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Wrong input, try again.");
                }
            }
        }

        public static int GetIndexAnswerByArray<T>(List<T> array, string message)
        {
            while (true)
            {
                for (int i = 0; i < array.Count; i++)
                    Console.WriteLine($" {i} - {array[i]}");

                Console.Write(message + " ");
                if (int.TryParse(Console.ReadLine(), out int answer))
                {
                    if (answer < 0 || answer >= array.Count)
                    {
                        Console.WriteLine("Wrong input");
                        continue;
                    }

                    return answer;
                }
            }
        }
    }
}
