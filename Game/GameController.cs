using System.Drawing;
using BoardLogic;

namespace Game
{
    /// <summary>
    /// This class implements the singleton pattern,
    /// which assures only a single instance. She is responsible for creating and maintaining its
    /// own unique instance, it will introduce troubles for the unit-testing.
    /// </summary>
    public class GameController
    {
        private static GameController myInstance = null;

        private IRound? myRound;

        private GameController()
        {
            this.IsRunning = false;
        }

        public static GameController Instance
        {
            get
            {
                if (GameController.myInstance is null)
                {
                    myInstance = new GameController();
                }

                return GameController.myInstance;
            }
        }

        public Player CurrentPlayer { get; set; }
        public bool IsRunning { get; private set; }
        public IRound Round
        {
            get { return this.myRound ??= new Round(); }
            set { this.myRound = value; }
        }

        public Dictionary<Color, IList<Token>> Tokens { get; set; } = new Dictionary<Color, IList<Token>>();

        public static void ResetController()
        {
            GameController.myInstance = null;
        }

        public IRound StartGame(int players)
        {    
            this.Round.SetPlayers(players);

            this.Tokens = this.Round.StartRound();

            return this.Round;
        }
    }
}