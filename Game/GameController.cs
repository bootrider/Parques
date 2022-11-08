using System.Drawing;
using BoardLogic;

namespace Game
{
    public class GameController
    {
        private IRound? myRound;
        public IRound Round
        {
            get { return this.myRound ??= new Round(); }
            set { this.myRound = value; }
        }

        public Dictionary<Color, IList<Token>> Tokens { get; set; } = new Dictionary<Color, IList<Token>>();

        public IRound StartGame(int players)
        {            
            this.Round.SetPlayers(players);

            this.Tokens = this.Round.StartRound();

            return this.Round;
        }
    }
}