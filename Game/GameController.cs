using System.Collections.ObjectModel;
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
        private static GameController? myInstance = null;

        private Dictionary<Guid, Player> myPlayers = new();
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

        public Player? CurrentPlayer { get; set; }
        public bool IsRunning { get; private set; }

        public ReadOnlyDictionary<Guid, Player> Players  => new ReadOnlyDictionary<Guid, Player>(this.myPlayers);

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

        public Player? JoinPlayer(string name)
        {
            if (!this.IsRunning)
            {
                var player = new Player
                {
                    Id = Guid.NewGuid(),
                    Name = name
                };
                this.myPlayers.Add(player.Id, player);
                return player; 
            }

            return null;
        }

        public IRound? StartGame()
        {
            if (this.myPlayers.Count > 1)
            {
                this.Round.SetPlayers(this.myPlayers.Count);

                this.Tokens = this.Round.StartRound();

                this.myPlayers.Values.ToList().ForEach(p => p.Color = this.Tokens.Keys.ToList()[this.myPlayers.Values.ToList().IndexOf(p)]);
                
                this.IsRunning = true;

                return this.Round; 
            }
            
            return null;
        }
    }
}