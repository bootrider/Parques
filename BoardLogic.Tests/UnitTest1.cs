namespace BoardLogic.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Board_WithPlayers_ReturnTrue()
        {
            //Arrange
            int players = 3;
            var board = new Board(players);

            //Act
            int cantHouse = board.Houses.Length; //here debe to go a method for to test

            //Assert
            Assert.AreEqual(players, cantHouse);
        }
    }
}