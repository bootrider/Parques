using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoardLogic;
using Moq;
using System.Drawing;

namespace Game.Tests
{
    [TestClass()]
    public class RoundTests
    {
        [TestMethod()]
        public void GetHouses_GivenBoard_ReturnProperNumberOfHouses()
        {
            // Arrange
            var round = new Round();
            var boardMock = new Mock<IBoard>();
            boardMock.Setup(m => m.Houses).Returns(new[] { new House(Color.Red)});
            round.Board = boardMock.Object;

            // Act
            var res = round.GetHouses();

            // Assert
            Assert.AreEqual(1, res.Count());
        }

        [TestMethod()]
        public void GetHouses_GivenNoBoard_ThrowsException()
        {
            // Arrange
            var round = new Round();
            
            // Act
            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => { round.GetHouses();});
        }

        [TestMethod()]
        public void StarRound_GivenNoBoard_ThrowsException()
        {
            // Arrange
            var round = new Round();

            // Act
            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => { round.StartRound(); });
        }

        [TestMethod()]
        public void StarRound_GivenBoard_CallSetReadyInEachHouseReturnsDictionaryWithTokens()
        {
            // Arrange
            var round = new Round();
            var boardMock = new Mock<IBoard>();
            boardMock.Setup(m => m.Houses).Returns(new[] { new House(Color.Red) });
            boardMock.Setup(m => m.SetReady(It.IsAny<Color>())).Returns(new Token[] { new(), new(), new(),new() });

            round.Board = boardMock.Object;

            // Act
            var res = round.StartRound();

            // Assert
            Assert.AreEqual(4, res.First().Value.Count);
            boardMock.Verify(b => b.SetReady(Color.Red), Times.Once);
        }
    }
}