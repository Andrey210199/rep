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
    public class SThreeValueTests
    {
        [TestMethod()]
            // площадь треугольника по трём сторонам
            public void STriangleThreeSide_3_4_5_6returned()
            {

                //arrange
                const string a = "3";
                const string b = "4";
                const string c = "5";
                const double expected = 6;

                //act
                SThreeValue S = new SThreeValue();
                double actual = S.STriangleThreeSide(a, b, c);

            //assert
            Assert.AreEqual(expected, actual, "Ожидаемый результат {0}, полученный результат {1}", expected, actual);
            }
        }
}