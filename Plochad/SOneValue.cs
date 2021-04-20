using System;
using System.Collections.Generic;
using System.Linq;

/*В задании непонятно нужно ли делать определения степени и корня, а также должно ли быть предусмотренно ручной выбор фигуры или нет, также
 * непонятно надо ли округлять значения или нет*/
namespace Plochad
{
    //Проверка входных значений
    public class provercaValue
    {
        //Определение есть ли степень или корень
        public Tuple<double, double, double> InValue(string a = "0", string b = "0", string c = "0")
        {
            double write = 0;
            double one = 0;
            double two = 0;
            double three = 0;
            List<string> step = new List<string> { a, b, c };

            for (int i = 0; i < 3; i++)
            {
                if(step[i].Contains("^") && step[i].Contains("√"))
                {
                    string[] part = step[i].Split('√', '^');
                    double val = Convert.ToDouble(part[1]);
                    double Preo = 0;

                    if (part[0] == "")
                    {
                        Preo = Math.Sqrt(val);
                    }
                    else
                    {
                        double onePreo = Convert.ToDouble(part[0]);
                        Preo = Math.Pow(val, 1 / onePreo);
                    }

                    write = Math.Pow(Preo, Convert.ToDouble(part[2]));
                    step[i] = write.ToString();

                }
                //Проверка стоит ли степень
                else if (step[i].Contains('^'))
                {
                    string[] part = step[i].Split('^');
                    double Preo = Convert.ToDouble(part[0]);

                    write = Math.Pow(Preo, Convert.ToDouble(part[1]));
                    step[i] = write.ToString();
                }
                //Проверка стоит ли корень
                else if (step[i].Contains('√'))
                {
                    string[] part = step[i].Split('√');
                    double val = Convert.ToDouble(part[1]);
                    //Проверям стоит ли что-то перед корнем
                    if (part[0] == "")
                    {
                        write = Math.Sqrt(val);
                        step[i] = write.ToString();
                    }
                    else
                    {
                        double onePreo = Convert.ToDouble(part[0]);
                        write = Math.Pow(val, 1 / onePreo);
                        step[i] = write.ToString();
                    }
                }
                //Если нет степени ни корня
                else
                {
                    step[i] = step[i];
                }
            }

            one = Convert.ToDouble(step[0]);
            two = Convert.ToDouble(step[1]);
            three = Convert.ToDouble(step[2]);

            return Tuple.Create<double, double, double>(one, two, three);
        }
    }
    //Вычисление площади фигур с одним значением
    public class SOneValue
    {
        // Площадь круга по радиусу
        public double SRoundRadius(string radious, int tipe =0)
        {
            provercaValue PV = new provercaValue();
            return Math.PI * Math.Pow(PV.InValue(radious).Item1, 2);
        }

    }

    //Вычисления площади фигур с тремя значениями
    public class SThreeValue
    {

        //Площадь треугольника по трём сторонам
        public double STriangleThreeSide(string a, string b, string c)
        {
            provercaValue PV = new provercaValue();
            double a1 = PV.InValue(a, b,c).Item1;
            double b1 = PV.InValue(a,b,c).Item2;
            double c1 = PV.InValue(a, b, c).Item3;
            //полупериметр
            double p = (a1 + b1 + c1) / 2;

            return Math.Sqrt(p * (p - a1) * (p - b1) * (p - c1));

        }


    }

    // Определения типа фигур
    public class TipFigurs
    {

        // Определения типа треугольника по трём сторонам
        public string TipTriang(string a, string b, string c)
        {
            provercaValue PV = new provercaValue();
            double a1 = PV.InValue(a, b, c).Item1;
            double b1 = PV.InValue(a, b, c).Item2;
            double c1 = PV.InValue(a, b, c).Item3;

            List<double> tip = new List<double>() {a1,b1,c1 };
            //Сортировка массива
            tip.Sort();
            //Поиск максимального значения
            double max = tip.Max();

            //Проверям треугольник на равносторонность
            if(max!=tip[0] && max!=tip[1])
            {
                double ab = Math.Pow(tip[0], 2) + Math.Pow(tip[1], 2);

                //Проверяем треугольник по теореме пифагора
                if(ab==Math.Pow(max,2))
                {
                    
                    return "Треугольник прямоугольный";
                }
                else
                {
                    return "Треугольник не прямоугольный";
                }
            }
            else
            {
                return "Треугольник не прямоугольный";
            }

            
        }

        //Проверяет тип фигуры
        public string TipsFigur(string a, string b, string c)
        {

            TipFigurs TP = new TipFigurs();
            provercaValue PV = new provercaValue();
            double a1 = PV.InValue(a, b, c).Item1;
            double b1 = PV.InValue(a, b, c).Item2;
            double c1 = PV.InValue(a, b, c).Item3;

            //Проверка количество введённых значений
            if (a1 != 0 && b1== 0 && c1 == 0)
            {
                return "Круг";

            }
            else if (a1 != 0 && b1 != 0 && c1 != 0)
            {
                return TP.TipTriang(a, b, c);
            }
            else
            {
               return "Ошибка";
               
            }

        }

    }

    //Вывод значений
    public class OutputValues
    {

        

        public Tuple<double, string, int> output(string One ="0", string two="0" , string three="0", int tip=0)
        {
            SOneValue RK = new SOneValue();
            SThreeValue TS = new SThreeValue();
            TipFigurs TP = new TipFigurs();

            if(two =="" && three=="")
            {
                two = "0";
                three = "0";
            }

            string tp = TP.TipsFigur(One,two,three);

            switch(tip)
            {
                case 0:
                    if (tp == "Круг")
                    {

                        return Tuple.Create <double, string,  int> (RK.SRoundRadius(One), tp, tip);
                    }
                    else
                    {
                        return Tuple.Create <double, string, int> (TS.STriangleThreeSide(One, two, three), tp, tip);
                    }
                    break;
                case 1:
                    return Tuple.Create <double, string, int> (RK.SRoundRadius(One), tp, tip);
                    break;
                case 2:
                    return Tuple.Create <double, string, int> (TS.STriangleThreeSide(One, two, three), tp, tip);
                    break;
                default:
                    return Tuple.Create <double, string, int> (0, "Ошибка",tip);
                    break;
            }

        }

    }

}
