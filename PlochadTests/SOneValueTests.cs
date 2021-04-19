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
    public class SOneValueTests
    {

        // площадь круга по радиусу
        [TestMethod()]
        public void SRound_10_314returned()
        {

            //arrange
          const  string R = "10";
          const  double expected = 314.15;
          const  double delta = 0.04;

            //act
            SOneValue S = new SOneValue();
           double actual = S.SRoundRadius(R);

            //assert
            Assert.AreEqual(expected, actual, delta, "Ожидаемый результат {0}, полученный результат {1}", expected,actual);


        }
    }

}