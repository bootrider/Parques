using System.Drawing;

namespace BoardLogic
{
    public interface IBoard
    {
        House[] Houses { get; set; }

        void MoveToken(IToken token, int steps);

        Token[] SetReady(Color color);
    }
}