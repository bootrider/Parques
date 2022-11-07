using BoardLogic;
using System.Drawing;
using System.Text;
using Game;
using Moq;

namespace GameTests
{
    [TestClass]
    public class GameControllerTests
    {
        [TestMethod]
        public void StartGame_Given3Players_CallsSetPlayersAndStartRound()
        {
            // Arrange
            var controller = new GameController();
            var roundMock = new Mock<IRound>();
            var boardMock = new Mock<IBoard>();
            boardMock.Setup(m => m.Houses).Returns(new[] { new House(Color.Red) });
            roundMock.Setup(r => r.Board).Returns(boardMock.Object);
            controller.Round = roundMock.Object;

            // Act
            var res = controller.StartGame(3);

            //Assert
            Assert.IsTrue(res.Board is not null);
            roundMock.Verify(r => r.SetPlayers(3), Times.Once);
            roundMock.Verify(r => r.StartRound(), Times.Once);
        }

        [TestMethod]
        public void StartGame_Given3Players_CreatesTokensForEachPlayer()
        {
            // Arrange
            var controller = new GameController();
            var roundMock = new Mock<IRound>();

            roundMock.Setup(r => r.SetPlayers(3));

            roundMock.Setup(r => r.StartRound()).Returns(new Dictionary<Color, IList<Token>>()
            {
                { Color.Red,new Token[] { new(), new(), new(),new() } },
                { Color.Blue,new Token[] { new(), new(), new(),new() } },
                { Color.Yellow,new Token[] { new(), new(), new(),new() } },
            });
            controller.Round = roundMock.Object;

            // Act
            var res = controller.StartGame(3);

            //Assert
            Assert.AreEqual(3, controller.Tokens.Count);
        }
    }
}