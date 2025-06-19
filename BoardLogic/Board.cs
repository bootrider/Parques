using System.Drawing;

namespace BoardLogic
{
    public class Board : IBoard
    {
        private List<IToken> myTokens = new();
        public House[] Houses { get; set; }

        public Board(int players)
        {
            this.Houses = new House[players];
            for (var i = 0; i < players; i++)
            {
                Color selectedColor;
                switch (i)
                {
                    case 0: selectedColor = Color.Violet; break;
                    case 1: selectedColor = Color.White; break;
                    case 2: selectedColor = Color.Black; break;
                    case 3: selectedColor = Color.Green; break;
                    case 4: selectedColor = Color.Red; break;
                    case 5: selectedColor = Color.Blue; break;
                    case 6: selectedColor = Color.Yellow; break;
                    case 7: selectedColor = Color.Pink; break;
                    case 8: selectedColor = Color.Orange; break;
                    case 9: selectedColor = Color.Gray; break;
                    case 10: selectedColor = Color.Purple; break;
                    case 11: selectedColor = Color.Brown; break;
                    case 12: selectedColor = Color.Fuchsia; break;
                    default: selectedColor = Color.Violet; break;
                }

                this.Houses[i] = new House(selectedColor);
            }

        }

        public void MoveToken(IToken token, int steps)
        {
            throw new NotImplementedException();
        }

        public void MoveToken(IToken token, Position newPosition)
        {
            
        }

        public Token[] SetReady(IHouse house)
        {
            // Create 4 tokens for the house
            var tokens = new Token[4];

            for (var i = 0; i < 4; i++)
            {
                // Create a new token with the same color as the house
                tokens[i] = new Token
                {
                    Color = house.Color,
                };

                // Add the token to the house's jail box
                house.Jail.AddToken(tokens[i]);
            }

            this.myTokens.AddRange(tokens);
            return tokens;
        }
    }
}