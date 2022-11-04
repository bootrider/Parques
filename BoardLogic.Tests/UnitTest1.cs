namespace BoardLogic.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Board_WithPlayers_ReturnTrue()
        {
            int players = 3;
            //Arrange
            var board = new Board(players);

            //Act
            int cantHouse = board.Houses.Length;

            //Assert
            Assert.AreEqual(players, cantHouse);
        }
    }
}