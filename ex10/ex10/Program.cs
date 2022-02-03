using System;
using System.IO;

namespace ex10
{
    internal class Program
    {
        // ex 10.

        static void Main(string[] args)
        {
            FileStream fs = new FileStream("./../../../../input.in", FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            int n = int.Parse(sr.ReadLine().Trim());
            int m = int.Parse(sr.ReadLine().Trim());

            int min = n * 2 >= n ? 0 : n - 2 * m;

            int k = 0;
            while (k * (k - 1) / 2 < m) k++;
            int max = n - k;

            Console.WriteLine($"{min} {max}");
        }
    }
}
