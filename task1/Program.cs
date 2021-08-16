using System;
using System.Collections.Generic;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int n =Convert.ToInt32(Console.ReadLine());
            int m = Convert.ToInt32(Console.ReadLine());
            int endelem=1;
            int startelem =1;
            List <string> mass = new List<string> ();
            string otvet ="";


            do
            {
                startelem = endelem;
                //добавляем значение в список
                mass.Add(startelem.ToString());
                //узнаём последний элемент итерации
                for (int i = 1; i <= m; i++)
                {
                    if (startelem > n)
                    {
                        startelem = 1;
                    }
                    if (i == m)
                    {
                        endelem = startelem;
                    }
                    startelem++;
                }
            }
           while (endelem != 1);

            //записываем список в строку
            foreach (string item in mass)
            {
                otvet += item;    
            }
            Console.WriteLine(otvet);

        }
    }
}
