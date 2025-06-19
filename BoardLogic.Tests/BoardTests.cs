namespace BoardLogic.Tests;

using System.Drawing;
using FluentAssertions;
using NSubstitute;

[TestClass]
public class BoardTests
{
    #region Methods

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
        Color.Violet.Should().Be(colorHouse0);
        Color.White.Should().Be(colorHouse1);
        Color.Black.Should().Be(colorHouse2);
        Color.Green.Should().Be(colorHouse3);
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
        Color.Violet.Should().Be(colorHouse1);
    }

    [TestMethod]
    public void Board_WithPlayers_ReturnTrue()
    {
        //Arrange
        int players = 3;

        //Act
        var board = new Board(players);
        int cantHouse = board.Houses.Length;

        //Assert
        cantHouse.Should().Be(players);
    }

    [TestMethod]
    public void SetReady_GivenAHouse_ShouldSetTokensInTheJail()
    {
        // Arrange
        int players = 1;
        var board = new Board(players);
        var house = Substitute.For<IHouse>();
        var jail = Substitute.For<IBox>();
        house.Jail = jail;

        // Act
        var tokens = board.SetReady(house);

        // Assert
        tokens.Should().NotBeNull();
        tokens.Length.Should().Be(4, "Each house should have 4 tokens");

        // Verify tokens are in jail boxes
        jail.Received(4).AddToken(Arg.Any<Token>());
    }
    #endregion
}