using System.Drawing;

namespace BoardLogic.Tests
{
    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void Board_WithPlayers_ReturnTrue()
        {
            //Arrange
            int players = 3;

            //Act
            var board = new Board(players); 
            int cantHouse = board.Houses.Length;

            //Assert
            Assert.AreEqual(players, cantHouse);
        }

        [TestMethod]
        public void Board_ColorHouseWhite_ReturnTrue()
        {
            //Arrange
            int players = 1;

            //Act
            var board = new Board(players);
            var colorHouse1 = board.Houses[0].Color;

            //Assert
            Assert.AreEqual(colorHouse1, Color.Violet);
   
        }
        [TestMethod]
        public void Board_ColorHouseVioletWhiteBlackAndGreen_ReturnTrue()
        {
            //Arrange
            int players = 4;

            //Act
            var board = new Board(players);
            var colorHouse0 = board.Houses[0].Color;
            var colorHouse1 = board.Houses[1].Color;
            var colorHouse2 = board.Houses[2].Color;
            var colorHouse3 = board.Houses[3].Color;

            //Assert
            Assert.AreEqual(colorHouse0, Color.Violet);
            Assert.AreEqual(colorHouse1, Color.White);
            Assert.AreEqual(colorHouse2, Color.Black);
            Assert.AreEqual(colorHouse3, Color.Green);
        }

    }
}