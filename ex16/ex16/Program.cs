using System;
using System.IO;

namespace ex16
{
    internal class Program
    {
        // ex 16.

        static void Main(string[] args)
        {
            int h1;
            int m1;
            int x;

            GetData(out h1, out m1, out x);

            int h2 = h1;
            int m2 = m1;

            h2 += (m1 + x) / 60;
            
            m2 += x % 60;
            m2 = m2 % 60;

            Console.WriteLine($"{h2} : {m2}");
        }

        public static void GetData(out int h, out int m, out int x)
        {
            FileStream fs = new FileStream("./../../../../input.in", FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            h = int.Parse(sr.ReadLine().Trim());
            m = int.Parse(sr.ReadLine().Trim());
            x = int.Parse(sr.ReadLine().Trim());

            sr.Close();
            fs.Close();
        }
    }
}
