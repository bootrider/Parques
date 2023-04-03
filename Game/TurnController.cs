using DiceLogic;

namespace Game
{
    internal class TurnController<T>
    {
        private static TurnController<T>? myInstance;

        private DiceResult myCurrentDiceResult;

        private bool myDice1Done, myDice2Done;

        private int myIndex;

        private int? myNextIndex;

        private IList<T> myPlayers;

        public static TurnController<T> Instance
        {
            get
            {
                TurnController<T>.myInstance ??= new TurnController<T>();
                return TurnController<T>.myInstance;
            }
        }

        public static void ResetController()
        {
            TurnController<T>.myInstance = null;
        }

        public T CurrentPlayer()
        {
            return myPlayers[this.myIndex];
        }

        public T DiceThrown(DiceResult diceResult)
        {
            this.myCurrentDiceResult = diceResult;
            if (diceResult.IsPair)
            {
                return this.CurrentPlayer();
            }

            this.myNextIndex = this.myIndex < this.myPlayers.Count ? this.myIndex+1 : 0;
            return this.CurrentPlayer();
        }

        public void LoadPlayers(IEnumerable<T> playerIds)
        {
            myPlayers = playerIds.ToList<T>();
            this.myIndex = 0;
        }

        public T TokenMoved(int steps)
        {
            if (steps == this.myCurrentDiceResult.Total)
            {
                this.SetNextPlayer();
                return this.CurrentPlayer();
            }
            if (steps == this.myCurrentDiceResult.Die1.Value)
            {
                this.myDice1Done = true;
            }
            if (steps == this.myCurrentDiceResult.Die2.Value)
            {
                this.myDice2Done = true;
            }

            if (this.myDice1Done && this.myDice2Done)
            {
                this.SetNextPlayer();
            }

            return this.CurrentPlayer();
        }

        private void SetNextPlayer()
        {
            this.myDice1Done = this.myDice2Done = false;
            this.myIndex = this.myNextIndex.Value;
            this.myNextIndex = null;
            this.myCurrentDiceResult = null;
        }
    }
}