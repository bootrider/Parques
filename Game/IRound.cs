using System.Drawing;
using BoardLogic;

namespace Game
{
    public interface IRound
    {
        IBoard? Board { get; set; }

        IEnumerable<House> GetHouses();

        bool MoveToken(IToken token, int step);

        void SetPlayers(int players);

        Dictionary<Color, IList<Token>> StartRound();
    }
}