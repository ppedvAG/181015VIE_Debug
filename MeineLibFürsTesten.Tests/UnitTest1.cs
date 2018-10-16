using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MeineLibFürsTesten.Tests
{
    [TestClass]
    public class TaschenrechnerTests
    {
        [TestMethod]
        public void Taschenrechner_Add_1_AND_1_Results_2()
        {
            // Arrange
            // Act
            // Assert

            Taschenrechner tr = new Taschenrechner();
            var result = tr.Add(1, 1);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Taschenrechner_Add_INTMax_AND_1_throws_OverflowException()
        {
            Taschenrechner tr = new Taschenrechner();
            Assert.ThrowsException<OverflowException>(() => tr.Add(Int32.MaxValue, 1));
        }

        [TestMethod]
        public void Taschenrechner_Add_INTMin_AND_N1_throws_OverflowException()
        {
            Taschenrechner tr = new Taschenrechner();
            Assert.ThrowsException<OverflowException>(() => tr.Add(Int32.MinValue, -1));
        }
    }
}
