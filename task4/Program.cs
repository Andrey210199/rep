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
                double srednee;
                int max = 0;
                int min = 0;

                //среднее значение
                srednee = Math.Round(mass.Average());

                //подшитывает количество операций
                while (min != 1)
                {
                    if (mass.Max() < srednee)
                    {
                        Array.Sort(mass);
                        mass[mass.Length - 1] += 1;
                        max += 1;

                    }
                    else if (mass.Min() < srednee)
                    {
                        Array.Sort(mass);
                        mass[0] += 1;
                        max += 1;
                    }
                    else if (mass.Min() > srednee)
                    {
                        Array.Sort(mass);
                        mass[0] -= 1;
                        max += 1;
                    }
                    else if (mass.Max() > srednee)
                    {
                        Array.Sort(mass);
                        mass[mass.Length - 1] -= 1;
                        max += 1;
                    }

                    //Проверяет одинаковы ли перевый и последний элемент
                    Array.Sort(mass);
                    if (mass[0] == mass[mass.Length - 1])
                    {
                        min = 1;
                    }
                }

                Console.WriteLine(max);
            }

    }
}
