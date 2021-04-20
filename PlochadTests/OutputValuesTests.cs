using Microsoft.VisualStudio.TestTools.UnitTesting;
using Plochad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Plochad.Tests
{
    [TestClass()]
    public class OutputValuesTests
    {

        //Круг
        [TestMethod()]
        public void output_10_round314_15()
        {
            //arrange
            const string a = "10";
            Tuple<double, string> expected = Tuple.Create<double, string>(314.15, "Круг");
           const double delta = 0.03;

            //act
           OutputValues val = new OutputValues();
           double actual =val.output(a).Item1;
            string actual1 = val.output(a).Item2;


            //assert
            Assert.AreEqual(expected.Item1, actual, delta,"Ожидаемый результат {0}, полученный результат {1}", expected.Item1, actual);
            Assert.AreEqual(expected.Item2, actual1, "Ожидаемый результат {0}, полученный результат {1}", expected.Item2, actual1);
        }

        //Прямоугольник
        [TestMethod()]
        public void output_3_4_5_pram()
        {
            //arrange
            const string a = "3";
            const string b = "4";
            const string c = "5";
            Tuple<double, string> expected = Tuple.Create<double, string>(6, "Треугольник прямоугольный");

            //act
            OutputValues val = new OutputValues();
            double actual = val.output(a, b ,c).Item1;
            string actual1 = val.output(a, b ,c).Item2;


            //assert
            Assert.AreEqual(expected.Item1, actual, "Ожидаемый результат {0}, полученный результат {1}", expected.Item1, actual);
            Assert.AreEqual(expected.Item2, actual1, "Ожидаемый результат {0}, полученный результат {1}", expected.Item2, actual1);
        }

        // Не прямоугольный треугольник
        [TestMethod()]
        public void output_3_5_5_nopram()
        {
            //arrange
            const string a = "5";
            const string b = "4";
            const string c = "4";
            Tuple<double, string> expected = Tuple.Create<double, string>(7.8, "Треугольник не прямоугольный");
            const double delta = 0.03;

            //act
            OutputValues val = new OutputValues();
            double actual = val.output(a, b, c).Item1;
            string actual1 = val.output(a, b, c).Item2;


            //assert
            Assert.AreEqual(expected.Item1, actual, delta, "Ожидаемый результат {0}, полученный результат {1}", expected.Item1, actual);
            Assert.AreEqual(expected.Item2, actual1, "Ожидаемый результат {0}, полученный результат {1}", expected.Item2, actual1);
        }

        //Тестирование ручного определения
        [TestMethod()]
        public void output_3_1_round()
        {
            //arrange
            const string a = "10";
            const int tip = 1;
            Tuple<double, string, int> expected = Tuple.Create<double, string,int>(314.15, "Круг", 1);
            const double delta = 0.03;

            //act
            OutputValues val = new OutputValues();
            double actual =Convert.ToDouble(val.output(a,"", "",tip).Item1);
            int actual1 = val.output(a,"", "", tip).Item3;
            string actual2 = val.output(a,"","",tip).Item2;


            //assert
           Assert.AreEqual(expected.Item1, actual,delta, "Ожидаемый результат {0}, полученный результат {1}", expected.Item1, actual);
           Assert.AreEqual(expected.Item3, actual1, "Ожидаемый результат {0}, полученный результат {1}", expected.Item3, actual1);
           Assert.AreEqual(expected.Item2, actual2, "Ожидаемый результат {0}, полученный результат {1}", expected.Item2, actual2);
        }
    }
}