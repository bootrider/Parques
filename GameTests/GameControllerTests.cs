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
        [TestCleanup]
        public void CleanEnvironment()
        {
            GameController.ResetController();
        }

        [TestMethod]
        public void JoinPlayer_GivenExistingName_PlayerIsReturnedAndAddedToGame()
        {
            // Arrange
            var controller = GameController.Instance;
            controller.JoinPlayer("Mario");

            // Act
            var player = controller.JoinPlayer("Mario");

            // Assert
            Assert.IsNotNull(player);
            Assert.AreEqual(2, controller.Players.Count);
            Assert.AreEqual("Mario", controller.Players[player.Id].Name);
        }

        [TestMethod]
        public void JoinPlayer_GivenName_PlayerIsReturnedAndAddedToGame()
        {
            // Arrange
            var controller = GameController.Instance;

            // Act
            var player = controller.JoinPlayer("Mario");

            // Assert
            Assert.IsNotNull(player);
            Assert.AreEqual(1, controller.Players.Count);
            Assert.AreEqual("Mario", controller.Players[player.Id].Name);
        }

        [TestMethod]
        public void JoinPlayer_GivenNameAndGameIsRunning_ReturnsNull()
        {
            // Arrange
            var controller = GameController.Instance;
            var roundMock = new Mock<IRound>();

            roundMock.Setup(r => r.SetPlayers(3));

            roundMock.Setup(r => r.StartRound()).Returns(new Dictionary<Color, IList<Token>>()
            {
                { Color.Red,new Token[] { new(), new(), new(),new() } },
                { Color.Blue,new Token[] { new(), new(), new(),new() } },
                { Color.Yellow,new Token[] { new(), new(), new(),new() } },
            });
            controller.Round = roundMock.Object;
            controller.JoinPlayer("Luigi");
            controller.JoinPlayer("Peach");
            controller.StartGame();

            // Act
            var player = controller.JoinPlayer("Mario");

            // Assert
            Assert.IsNull(player);
        }

        [TestMethod]
        public void StartGame_Given3Players_CallsSetPlayersAndStartRound()
        {
            // Arrange
            var controller = GameController.Instance;
            var roundMock = new Mock<IRound>();
            var boardMock = new Mock<IBoard>();
            boardMock.Setup(m => m.Houses).Returns(new[] { new House(Color.Red) });
            roundMock.Setup(r => r.Board).Returns(boardMock.Object);
            controller.Round = roundMock.Object;
            controller.JoinPlayer("Mario");
            controller.JoinPlayer("Luigi");
            controller.JoinPlayer("Peach");

            // Act
            var res = controller.StartGame();

            //Assert
            Assert.IsTrue(res.Board is not null);
            roundMock.Verify(r => r.SetPlayers(3), Times.Once);
            roundMock.Verify(r => r.StartRound(), Times.Once);
        }

        [TestMethod]
        public void StartGame_Given3Players_CreatesTokensForEachPlayer()
        {
            // Arrange
            var controller = GameController.Instance;
            var roundMock = new Mock<IRound>();

            roundMock.Setup(r => r.SetPlayers(3));

            roundMock.Setup(r => r.StartRound()).Returns(new Dictionary<Color, IList<Token>>()
            {
                { Color.Red,new Token[] { new(), new(), new(),new() } },
                { Color.Blue,new Token[] { new(), new(), new(),new() } },
                { Color.Yellow,new Token[] { new(), new(), new(),new() } },
            });
            controller.Round = roundMock.Object;

            controller.JoinPlayer("Mario");
            controller.JoinPlayer("Luigi");
            controller.JoinPlayer("Peach");

            // Act
            var res = controller.StartGame();

            //Assert
            Assert.AreEqual(3, controller.Tokens.Count);
        }

        [TestMethod]
        public void StartGame_GivenLessThan2Players_ReturnNull()
        {
            // Arrange
            var controller = GameController.Instance;
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
            var res = controller.StartGame();

            //Assert
            Assert.IsNull(res);
        }
    }
}