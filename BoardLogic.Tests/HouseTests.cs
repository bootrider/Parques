using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardLogic.Tests
{
    [TestClass]
    public class HouseTests
    {
        [TestMethod]
        public void House_NoParameters_12thBoxIsSafe()
        {
            // Arrange


            // Act
            var house = new House(Color.Red);

            // Assert
            Assert.AreEqual(typeof(BoxSafe), house.Path[12].GetType());
            Assert.IsInstanceOfType(house.Path[12], typeof(BoxSafe));
        }

    }
}
