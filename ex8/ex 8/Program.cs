using System;
using System.IO;

namespace ex_8
{
    internal class Program
    {
        // 8.

        public static int[] array;

        static void Main(string[] args)
        {
            FileStream fs = new FileStream("./../../../../input.in", FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            int n = int.Parse(sr.ReadLine().Trim());
            int k = int.Parse(sr.ReadLine().Trim());
            array = new int[k];

            sr.Close();
            fs.Close();

            Backtracking(n, k);
        }

        public static bool Verify(int position, int[] arr)
        {
            for (int i = 0; i < position; i++)
                if (arr[position] == arr[i])
                    return false;

            return true;
        }

        public static void Backtracking(int n, int k, int position = 0)
        {
            for(int i = 0; i < n; i++)
            {
                array[position] = i;
                if (Verify(position, array))
                {
                    if(position == k - 1)
                    {
                        for(int j = 0; j < k; j++)
                            Console.Write($"{array[j] + 1} ");
                        Console.WriteLine();
                    }
                    else
                        Backtracking(n, k, position + 1);
                }
            }
        }
    }
}
