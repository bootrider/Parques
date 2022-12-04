using System.Drawing;
using BoardLogic;

namespace Game
{
    public interface IRound
    {
        IBoard? Board { get; set; }

        IEnumerable<House> GetHouses();

        void SetPlayers(int players);

        Dictionary<Color, IList<Token>> StartRound();
    }
}