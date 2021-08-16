using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.ReadLine(), System.Text.Encoding.Default);
            StreamReader sr1 = new StreamReader(Console.ReadLine(), System.Text.Encoding.Default);

            var failread = new List<string>();
            var failread1 = new List<string>();

            //кординаты и радиус окружности
            float Xc, Yc, r;
            //кординаты точки
            float x, y;
            int i = 0;

            //читает файл
            while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                string[] mass = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                //Убираем пробелы для преобразование в числа
                foreach (string s in mass)
                {

                    if (s.Trim() != "")
                        failread.Add(s);
                }

            }

            //читает файл
            while (!sr1.EndOfStream)
            {
                string line = sr1.ReadLine();
                string[] mass = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                //Убираем пробелы для преобразование в числа
                foreach (string s in mass)
                {

                    if (s.Trim() != "")
                        failread1.Add(s);
                }
            }

             
               //значения круга
               Xc = float.Parse(failread[0]);
               Yc = float.Parse(failread[1]);
               r = float.Parse(failread[2]);

            //вычисление точек
            do
            {
                //значение точек
                x = float.Parse(failread1[i]);
                y = float.Parse(failread1[++i]);

                 //высчитываем где находится точка относительно круга
                  if ((Math.Pow((x - Xc), 2) + Math.Pow((y - Yc), 2)) < Math.Pow(r, 2))
                  {
                      Console.WriteLine("1");
                  }
                  else if ((Math.Pow((x - Xc), 2) + Math.Pow((y - Yc), 2)) == Math.Pow(r, 2))
                  {
                      Console.WriteLine("0");
                  }
                  else
                  {
                      Console.WriteLine("2");
                  }
                i++;
            }
            while (i< failread1.Count);
              

        }
    }
}
