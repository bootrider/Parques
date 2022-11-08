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
        [TestMethod]
        public void House_Type5BoxStar_returnTrue()
        {
            // Arrange

            // Act
            var house = new House(Color.Violet);

            // Assert
            Assert.AreEqual(typeof(BoxStart), house.Path[5].GetType());
            Assert.IsInstanceOfType(house.Path[5], typeof(BoxStart));
        }

        [TestMethod]
        public void House_TypeBox0BoxSky_returnTrue()
        {
            // Arrange

            // Act
            var house = new House(Color.Violet);

            // Assert
            Assert.AreEqual(typeof(BoxSkySafe), house.Path[0].GetType());
            Assert.IsInstanceOfType(house.Path[0], typeof(BoxSkySafe));
        }

        [TestMethod]
        public void House_TypeBoxNormal_returnTrue()
        {
            // Arrange
            int index = 2;
            // Act
            var house = new House(Color.Violet);

            // Assert
            Assert.AreEqual(typeof(BoxNormal), house.Path[index].GetType());
            Assert.IsInstanceOfType(house.Path[index], typeof(BoxNormal));
        }

        [TestMethod]
        public void House_TypeBoxPathSky_returnTrue()
        {
            // Arrange
            int index = 0;
            // Act
            var house = new House(Color.Violet);

            // Assert
            Assert.AreEqual(typeof(BoxPathSky), house.Sky[index].GetType());
            Assert.IsInstanceOfType(house.Sky[index], typeof(BoxPathSky));
        }

        [TestMethod]
        public void House_houseHaveJail_returnTrue()
        {
            // Arrange
          
            // Act
            var house = new House(Color.Violet);

            // Assert
            Assert.AreEqual(typeof(Token[]), house.Jail.GetType());
            Assert.IsInstanceOfType(house.Jail, typeof(Token[]));
        }


    }
}
