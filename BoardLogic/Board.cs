using System.Drawing;

namespace BoardLogic
{
    public class Board : IBoard
    {
        public House[] Houses { get; set; }

        public Board(int players)
        {
            this.Houses = new House[players];
            for (int i = 0; i < players; i++)
            {
                Color selectedColor;
                switch (i)
                {
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

        public void MoveToken(Token token, int steps)
        {
            throw new NotImplementedException();
        }

        public Token[] SetReady(Color color)
        {
            throw new NotImplementedException();
        }
    }
}