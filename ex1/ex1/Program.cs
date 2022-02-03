using System;
using System.IO;

namespace ex1
{
    /*
        1. 
            Scrieţi un program C# care citeşte de la tastatură două numere naturale din 
            intervalul [3,50], n şi m, și elementele unui tablou bidimensional cu n linii şi m 
            coloane, numere naturale din intervalul [0,104]. Programul modifică în memorie 
            tabloul dat, atribuind valoarea elementului aflat pe ultima linie și pe ultima coloană
            a tabloului fiecărui element aflat pe conturul acestuia (pe prima linie, ultima linie, 
            prima coloană, ultima coloană), apoi afişează pe ecran tabloul modificat, câte o linie 
            a tabloului pe câte o linie a ecranului, elementele fiecărei linii fiind separate prin 
            câte un spaţiu.
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            FileStream fsOut = new FileStream("./../../../../output.txt",FileMode.Create);
            
            StreamWriter sw = new StreamWriter(fsOut);

            int[,] a = ReadData();

            int value = a[a.GetLength(0) - 1, a.GetLength(1) - 1];
           
            for (int i = 0; i < a.GetLength(0);i++) 
            {
                a[i,0] = value;
                a[i,a.GetLength(1)-1] = value;
            }
            for (int i = 0; i < a.GetLength(1);i++)
            {
                a[0,i] = value;
                a[a.GetLength(0)-1, i] = value;
            }


            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                    sw.Write($"{a[i, j]} ");
                sw.WriteLine();
            }

            sw.Close();
            fsOut.Close();

            Console.WriteLine("Da. Ai facut bine.");
            Console.WriteLine("Vezi ca este un fisier output.txt in folderul exervitiului. Acolo e rezultatul.");
        }
        public static int[,] ReadData()
        {
            FileStream fsInt = new FileStream("./../../../../input.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fsInt);

            int n = int.Parse(sr.ReadLine());
            int m = int.Parse(sr.ReadLine());
            int[,] a = new int[n, m];
            int rowIndex=0;
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] elements = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
              
                for(int i=0;i<elements.Length;i++)
                    a[rowIndex,i]=int.Parse(elements[i]);
            
                rowIndex++;
            }
            sr.Close();
            fsInt.Close();


            return a;
        }
    }
}
