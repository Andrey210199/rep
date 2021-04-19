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
    public class provercaValueTests
    {
        //Проверка степени
        [TestMethod()]
        public void InValue_5_4_6_25_16_36returned()
        {
            //arrange
            const string a = "5^2";
            const string b = "4";
            const string c ="6^2";
            Tuple<double, double, double> expected = Tuple.Create<double,double,double>(25,4,36);
            const double delta = 0.03;

            //act
            provercaValue val = new provercaValue();
            double actual = val.InValue(a, b, c).Item1;
            double actual1 = val.InValue(a, b, c).Item2;
            double actual2 = val.InValue(a, b, c).Item3;


            //assert
            Assert.AreEqual(expected.Item1, actual, delta, "Ожидаемый результат {0}, полученный результат {1}", expected.Item1, actual);
            Assert.AreEqual(expected.Item2, actual1, delta, "Ожидаемый результат {0}, полученный результат {1}", expected.Item2, actual1);
            Assert.AreEqual(expected.Item3, actual2, delta, "Ожидаемый результат {0}, полученный результат {1}", expected.Item3, actual2);

        }

        //Проверка корня
       [TestMethod()]
        public void InValue_123_4_26_5_4_6returned()
        {
            //arrange
            const string a = "3√125";
            const string b = "4";
            const string c = "√36";
            Tuple<double, double, double> expected = Tuple.Create<double, double, double>(5, 4, 6);
            const double delta = 0.03;

            //act
            provercaValue val = new provercaValue();
            double actual = val.InValue(a, b, c).Item1;
            double actual1 = val.InValue(a, b, c).Item2;
            double actual2 = val.InValue(a, b, c).Item3;


            //assert
            Assert.AreEqual(expected.Item1, actual, delta, "Ожидаемый результат {0}, полученный результат {1}", expected.Item1, actual);
            Assert.AreEqual(expected.Item2, actual1, delta, "Ожидаемый результат {0}, полученный результат {1}", expected.Item2, actual1);
            Assert.AreEqual(expected.Item3, actual2, delta, "Ожидаемый результат {0}, полученный результат {1}", expected.Item3, actual2);

        }

        //Проверка степень и корень
        [TestMethod()]
        public void InValue_cor_125in3_4_cor36_125_4_6returned()
        {
            //arrange
            const string a = "3√125^3";
            const string b = "4";
            const string c = "√36";
            Tuple<double, double, double> expected = Tuple.Create<double, double, double>(125, 4, 6);
            const double delta = 0.03;

            //act
            provercaValue val = new provercaValue();
            double actual = val.InValue(a, b, c).Item1;
            double actual1 = val.InValue(a, b, c).Item2;
            double actual2 = val.InValue(a, b, c).Item3;


            //assert
            Assert.AreEqual(expected.Item1, actual, delta, "Ожидаемый результат {0}, полученный результат {1}", expected.Item1, actual);
            Assert.AreEqual(expected.Item2, actual1, delta, "Ожидаемый результат {0}, полученный результат {1}", expected.Item2, actual1);
            Assert.AreEqual(expected.Item3, actual2, delta, "Ожидаемый результат {0}, полученный результат {1}", expected.Item3, actual2);

        }
    }
}