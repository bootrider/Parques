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
    }
}