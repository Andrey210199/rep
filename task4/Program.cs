using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;


namespace task4
{
    class Program
    {
        static void Main(string[] args)
        {
             StreamReader sr = new StreamReader(Console.ReadLine(), System.Text.Encoding.Default);

                  var failread = new List<string>();
                  //читает файл
                  while (!sr.EndOfStream)
                  {
                      string line = sr.ReadLine();
                      failread.Add(line);

                  }

                  int[] mass = new int[failread.Count];

                  //делает массив из списка
                  for (int i = 0; i < failread.Count; i++)
                  {
                      mass[i] = Convert.ToInt32(failread[i]);
                  }

            int[] b = new int[mass.Length]; //Копия массива
            Array.Copy(mass, b, mass.Length);

                int max = mass.Max();
                int min = mass.Min();
                int j = 0;
            int otvet = 0;
            int prover = 0;

            for (int i = min; i< max; i++ )
            {
                while(j==0)
                {
                    for (int k = 0; k < b.Length; k++)
                    {
                        if (b[k] < i)
                        {
                            b[k]++;
                            prover++;
                        }
                        else if(b[k]>i)
                        {
                            b[k]--;
                            prover++;
                        }
                        
                    }
                    //Проверяет одинаковы ли перевый и последний элемент
                    Array.Sort(b);
                    if (b[0] == b[b.Length - 1])
                    {
                        j = 1;
                        
                    }
                   
                }
                
                if (prover < otvet || otvet == 0)
                {
                    otvet = prover;
                }

               Array.Copy(mass, b, mass.Length); //Делает копию изначального массива
                prover = 0;
                j = 0;

            }

                Console.WriteLine(otvet);
            }

    }
}
