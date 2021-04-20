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
    public class TipFigursTests
    {
        [TestMethod()]
        public void TipsFigur_3_5_4_pramougol()
        {
            //arrange
            const string a = "3";
            const string b = "5";
            const string c = "4";
            const string expected = "Треугольник прямоугольный";

            //act
            TipFigurs tip = new TipFigurs();
            string actual = tip.TipsFigur(a, b, c);

            //assert
            Assert.AreEqual(expected, actual, "Ожидаемый результат {0}, полученный результат {1}", expected, actual);
        }

        [TestMethod()]
        public void TipsFigur_3_5_5_nopramougol()
        {
            //arrange
            const string a = "3";
            const string b = "5";
            const string c = "5";
            const string expected = "Треугольник не прямоугольный";

            //act
            TipFigurs tip = new TipFigurs();
            string actual = tip.TipsFigur(a, b, c);

            //assert
            Assert.AreEqual(expected, actual, "Ожидаемый результат {0}, полученный результат {1}", expected, actual);


        }

    }
}