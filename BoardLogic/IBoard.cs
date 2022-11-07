using System.Drawing;

namespace BoardLogic
{
    public interface IBoard
    {
        House[] Houses { get; set; }

        void MoveToken(Token token, int steps);

        Token[] SetReady(Color color);
    }
}