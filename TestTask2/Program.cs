using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int k = int.Parse(Console.ReadLine());
            DateTime start = DateTime.Now;
            string numbers = "";

            var tasks = new List<Task<string>>();
            tasks.Add(Task.Run(() => SearchFrindlyNumber(2, k / 16, k)));
            tasks.Add(Task.Run(() => SearchFrindlyNumber(k / 16, k / 16 * 2, k)));
            tasks.Add(Task.Run(() => SearchFrindlyNumber(k / 16 * 2, k / 16 * 3, k)));
            tasks.Add(Task.Run(() => SearchFrindlyNumber(k / 16 * 3, k / 16 * 4, k)));
            tasks.Add(Task.Run(() => SearchFrindlyNumber(k / 16 * 4, k / 16 * 5, k)));
            tasks.Add(Task.Run(() => SearchFrindlyNumber(k / 16 * 5, k / 16 * 6, k)));
            tasks.Add(Task.Run(() => SearchFrindlyNumber(k / 16 * 6, k / 16 * 7, k)));
            tasks.Add(Task.Run(() => SearchFrindlyNumber(k / 16 * 7, k / 16 * 8, k)));
            tasks.Add(Task.Run(() => SearchFrindlyNumber(k / 16 * 8, k / 16 * 9, k)));
            tasks.Add(Task.Run(() => SearchFrindlyNumber(k / 16 * 9, k / 16 * 10, k)));
            tasks.Add(Task.Run(() => SearchFrindlyNumber(k / 16 * 10, k / 16 * 11, k)));
            tasks.Add(Task.Run(() => SearchFrindlyNumber(k / 16 * 11, k / 16 * 12, k)));
            tasks.Add(Task.Run(() => SearchFrindlyNumber(k / 16 * 12, k / 16 * 13, k)));
            tasks.Add(Task.Run(() => SearchFrindlyNumber(k / 16 * 13, k / 16 * 14, k)));
            tasks.Add(Task.Run(() => SearchFrindlyNumber(k / 16 * 14, k / 16 * 15, k)));
            tasks.Add(Task.Run(() => SearchFrindlyNumber(k / 16 * 15, k, k)));

            Task.WhenAll(tasks);

            foreach (var task in tasks)
            {
                numbers += task.Result;
            }

            Console.WriteLine(numbers);
            Console.WriteLine(DateTime.Now - start);
            Console.ReadLine();
        }

        static string SearchFrindlyNumber(int startSearch, int finishSearch, int k)
        {
            string numbers = "";

            for (int i = startSearch; i < finishSearch; i++)
            {
                int divisorSum1 = 0;
                int divisorSum2 = 0;

                for (int j = 1; j <= i / 2; j++)
                {
                    if (i % j == 0)
                    {
                        divisorSum1 += j;
                    }
                }

                if (divisorSum1 > i && divisorSum1 < k)
                {
                    for (int j = 1; j <= divisorSum1 / 2; j++)
                    {
                        if (divisorSum1 % j == 0)
                        {
                            divisorSum2 += j;
                        }
                    }
                }

                if (divisorSum2 == i)
                {
                    numbers += i + " и " + divisorSum1 + "\n";
                }
            }

            return numbers;
        }
    }
}
