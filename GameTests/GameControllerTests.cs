using BoardLogic;
using System.Drawing;
using System.Text;
using Game;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

        [TestMethod]
        public void ThrowDie_GivenNullPlayerId_ShouldReturnNull()
        {
            //Arrange
            var controller = GameController.Instance;

            //Act
            var res = controller.ThrowDie(null);

            //Assert
            Assert.IsNull(res);
        }

        [TestMethod]
        public void ThrowDie_GivenNonExistingPlayerId_ShouldReturnArgumentException()
        {
            //Arrange
            var controller = GameController.Instance;
            controller.JoinPlayer("Mario");
            controller.JoinPlayer("Luigi");
            controller.JoinPlayer("Peach");

            //Act
            //Assert
            Assert.ThrowsException<ArgumentException>(() => { controller.ThrowDie(Guid.NewGuid()); });
        }

        [TestMethod]
        public void ThrowDie_GivenExistingPlayerId_ShouldReturnIntegerBetween1and6()
        {
            //Arrange
            var controller = GameController.Instance;
            var mario = controller.JoinPlayer("Mario");

            //Act
            var res = controller.ThrowDie(mario.Id);

            //Assert
            Assert.IsTrue(res >=1 && res <=6);
        }

        [TestMethod]
        public void MoveToken_GivingExistingPlayerIdAndTotalSteps_ShouldCurrentPlayerBeNext()
        {
            // Arrange
            var controller = GameController.Instance;
            var mario = controller.JoinPlayer("Mario");
            var luigi = controller.JoinPlayer("Luigi");

            var roundMock = new Mock<IRound>();

            roundMock.Setup(r => r.SetPlayers(2));

            roundMock.Setup(r => r.StartRound()).Returns(new Dictionary<Color, IList<Token>>()
            {
                { Color.Red,new Token[] { new(), new(), new(),new() } },
                { Color.Green,new Token[] { new(), new(), new(),new() } }                
            });
            controller.Round = roundMock.Object;

            // Act
            controller.StartGame();
            var diceResult = controller.ThrowDice(mario.Id);
            controller.MoveToken(mario.Id, mario.Tokens.First(), diceResult.Total);

            // Assert
            var currentPlayer = controller.CurrentPlayer;
            Assert.IsNotNull(currentPlayer);
            Assert.AreEqual(luigi.Id, currentPlayer);
        }

        [TestMethod]
        public void MoveToken_GivingExistingPlayerIdAndDice1Steps_ShouldCurrentPlayerBeSame()
        {
            // Arrange
            var controller = GameController.Instance;
            var mario = controller.JoinPlayer("Mario");
            var luigi = controller.JoinPlayer("Luigi");

            var roundMock = new Mock<IRound>();

            roundMock.Setup(r => r.SetPlayers(2));

            roundMock.Setup(r => r.StartRound()).Returns(new Dictionary<Color, IList<Token>>()
            {
                { Color.Red,new Token[] { new(), new(), new(),new() } },
                { Color.Green,new Token[] { new(), new(), new(),new() } }
            });
            controller.Round = roundMock.Object;

            // Act
            controller.StartGame();
            var diceResult = controller.ThrowDice(mario.Id);
            controller.MoveToken(mario.Id, mario.Tokens.First(), diceResult.Die1.Value);

            // Assert
            var currentPlayer = controller.CurrentPlayer;
            Assert.IsNotNull(currentPlayer);
            Assert.AreEqual(mario.Id, currentPlayer);
        }

        [TestMethod]
        public void MoveToken_GivingExistingPlayerIdAndDice2Steps_ShouldCurrentPlayerBeSame()
        {
            // Arrange
            var controller = GameController.Instance;
            var mario = controller.JoinPlayer("Mario");
            var luigi = controller.JoinPlayer("Luigi");

            var roundMock = new Mock<IRound>();

            roundMock.Setup(r => r.SetPlayers(2));

            roundMock.Setup(r => r.StartRound()).Returns(new Dictionary<Color, IList<Token>>()
            {
                { Color.Red,new Token[] { new(), new(), new(),new() } },
                { Color.Green,new Token[] { new(), new(), new(),new() } }
            });
            controller.Round = roundMock.Object;

            // Act
            controller.StartGame();
            var diceResult = controller.ThrowDice(mario.Id);
            controller.MoveToken(mario.Id, mario.Tokens.First(), diceResult.Die2.Value);

            // Assert
            var currentPlayer = controller.CurrentPlayer;
            Assert.IsNotNull(currentPlayer);
            Assert.AreEqual(mario.Id, currentPlayer);
        }
    }
}