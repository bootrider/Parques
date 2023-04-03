﻿using System.Collections.ObjectModel;
using System.Drawing;
using BoardLogic;
using DiceLogic;

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
        private TurnController<Guid> myTurnController;

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
                    GameController.myInstance = new GameController();
                }

                return GameController.myInstance;
            }
        }

        public Guid? CurrentPlayer { get; set; }
        public bool IsRunning { get; private set; }

        public ReadOnlyDictionary<Guid, Player> Players => new ReadOnlyDictionary<Guid, Player>(this.myPlayers);

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

        public void MoveToken(Guid? playerId, Token token, int steps)
        {
            this.CurrentPlayer = this.myTurnController.TokenMoved(steps);
        }

        public IRound? StartGame()
        {
            if (this.myPlayers.Count > 1)
            {
                this.Round.SetPlayers(this.myPlayers.Count);

                this.Tokens = this.Round.StartRound();

                this.myPlayers.Values.ToList().ForEach(p => p.Color = this.Tokens.Keys.ToList()[this.myPlayers.Values.ToList().IndexOf(p)]);
                this.myPlayers.Values.ToList().ForEach(p => p.Tokens = this.Tokens[p.Color].ToArray());

                this.IsRunning = true;
                this.myTurnController = TurnController<Guid>.Instance;
                this.myTurnController.LoadPlayers(this.myPlayers.Keys);
                this.CurrentPlayer = this.myTurnController.CurrentPlayer();

                return this.Round;
            }

            return null;
        }

        public DiceResult ThrowDice(Guid? playerId)
        {
            if (playerId is null)
            {
                return null;
            }

            if (!this.myPlayers.ContainsKey(playerId.Value))
            {
                throw new ArgumentException("The Player does not exist");
            }

            var thrower = new DiceThrower();
            var result = thrower.RollTwoDice();
            this.CurrentPlayer = this.myTurnController.DiceThrown(result);
            return result;
        }

        public int? ThrowDie(Guid? playerId)
        {
            if (playerId is null)
            {
                return null;
            }

            if (!this.myPlayers.ContainsKey(playerId.Value))
            {
                throw new ArgumentException("The Player does not exist");
            }

            var thrower = new DiceThrower();
            return thrower.RollOneDie().Die1;
        }
    }
}