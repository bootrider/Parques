using System.Drawing;
using BoardLogic;
using Moq;

namespace Game.Tests
{
    [TestClass]
    public class RoundTests
    {
        [TestMethod]
        public void GetHouses_GivenBoard_ReturnProperNumberOfHouses()
        {
            // Arrange
            var round = new Round();
            var boardMock = new Mock<IBoard>();
            boardMock.Setup(m => m.Houses).Returns(new[] { new House(Color.Red) });
            round.Board = boardMock.Object;

            // Act
            var res = round.GetHouses();

            // Assert
            Assert.AreEqual(1, res.Count());
        }

        [TestMethod]
        public void GetHouses_GivenNoBoard_ThrowsException()
        {
            // Arrange
            var round = new Round();

            // Act
            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => { round.GetHouses(); });
        }

        [TestMethod]
        public void MoveToken_GivenTokenAndStep_ReturnTrue()
        {
            // Arrange
            var token = new Mock<IToken>();
            var boardMock = new Mock<IBoard>();
            var round = new Round();

            round.Board = boardMock.Object;

            //Act
            var pos = round.MoveToken(token.Object, 2);

            //Assert
            Assert.IsTrue(pos);
        }

        [TestMethod]
        public void MoveToken_GivenTokenAndStepAndNotStarted_ReturnFalse()
        {
            // Arrange
            var token = new Mock<IToken>();
            var boardMock = new Mock<IBoard>();
            var round = new Round();

            //Act
            var pos = round.MoveToken(token.Object, 2);

            //Assert
            Assert.IsFalse(pos);
        }

        [TestMethod]
        public void StarRound_GivenBoard_CallSetReadyInEachHouseReturnsDictionaryWithTokens()
        {
            // Arrange
            var round = new Round();
            var boardMock = new Mock<IBoard>();
            boardMock.Setup(m => m.Houses).Returns(new[] { new House(Color.Red) });
            boardMock.Setup(m => m.SetReady(It.IsAny<Color>())).Returns(new Token[] { new(), new(), new(), new() });

            round.Board = boardMock.Object;

            // Act
            var res = round.StartRound();

            // Assert
            Assert.AreEqual(4, res.First().Value.Count);
            boardMock.Verify(b => b.SetReady(Color.Red), Times.Once);
        }

        [TestMethod]
        public void StarRound_GivenNoBoard_ThrowsException()
        {
            // Arrange
            var round = new Round();

            // Act
            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => { round.StartRound(); });
        }
    }
}