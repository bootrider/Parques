using System.Drawing;
using BoardLogic;

namespace Game
{
    /// <summary>
    /// This class holds the information of an active game, it will contains the singleton for the Board and the tokens.
    /// </summary>
    public class Round : IRound
    {
        public IBoard? Board { get; set; }

        public IEnumerable<House> GetHouses()
        {
            if (this.Board is not null)
            {
                return this.Board.Houses.AsEnumerable(); 
            }

            throw new ArgumentNullException(nameof(this.Board));
        }

        public void SetPlayers(int players)
        {
           this.Board = new Board(players);
        }

        public Dictionary<Color, IList<Token>> StartRound()
        {
            if (this.Board is null)
            {
                throw new ArgumentNullException(nameof(this.Board));
            }

            var dict = new Dictionary<Color, IList<Token>>();
            foreach (var house in this.Board.Houses)
            {
                dict.TryAdd(house.Color, this.Board.SetReady(house.Color));
            }

            return dict;
        }

    }
}