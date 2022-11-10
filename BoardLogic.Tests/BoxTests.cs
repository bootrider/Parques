using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardLogic.Tests
{
    [TestClass]
    public class BoxTests
    {
        [TestMethod]

        public void GetTokensOverview_FirstColorsElementViolet_ReturTrue()
        {
            //Arrange
            int indice = 2;
            Box myBox = new Box(2);

            Token token1 = new Token();
            token1.Color = Color.Violet;

            myBox.AddToken(token1);

            //Act
            var overview = myBox.GetTokensOverview();

            //Assert
            Assert.AreEqual(overview.First().Key, Color.Violet.Name);
        }

        [TestMethod]
        public void RemoveAtoken_AddThreeTokensRemoveOne_ReturnTwoTokens()
        {
            //Arrange
            Box myBox = new Box(5);

            Token token1 = new Token();
            token1.Color = Color.Violet;

            Token token2 = new Token();
            token2.Color = Color.White;

            Token token3 = new Token();
            token3.Color = Color.Red;

            myBox.AddToken(token1);
            myBox.AddToken(token2);
            myBox.AddToken(token3);

            //Act
            myBox.RemoveAToken(token1);
            var overview = myBox.GetTokensOverview();

            //Assert
            Assert.AreEqual(overview.Count,2);
            Assert.AreEqual(overview.First().Key, Color.White.Name);
            
        }

        [TestMethod]
        public void RemoveAtoken_AddThreeTokensRemoveTwo_ReturnOneTokens()
        {
            //Arrange
            Box myBox = new Box(5);

            Token token1 = new Token();
            token1.Color = Color.Violet;

            Token token2 = new Token();
            token2.Color = Color.Violet;

            Token token3 = new Token();
            token3.Color = Color.Red;

            myBox.AddToken(token1);
            myBox.AddToken(token2);
            myBox.AddToken(token3);

            //Act
            myBox.RemoveAToken(token1);
            myBox.RemoveAToken(token2);
            var overview = myBox.GetTokensOverview();

            //Assert
            Assert.AreEqual(overview.Count, 1);
            Assert.AreEqual(overview.First().Key, Color.Red.Name);
        }

        [TestMethod]
        public void ClearBox_AddThreeTokensRemoveAll_isNull()
        {
            //Arrange
            Box myBox = new Box(5);

            Token token1 = new Token();
            token1.Color = Color.Violet;

            Token token2 = new Token();
            token2.Color = Color.Violet;

            Token token3 = new Token();
            token3.Color = Color.Red;

            myBox.AddToken(token1);
            myBox.AddToken(token2);
            myBox.AddToken(token3);

            //Act
            myBox.clearBox();
            var overview = myBox.GetTokensOverview();

            //Assert
            Assert.AreEqual(overview.Count, 0);
        
        }

    }
}
