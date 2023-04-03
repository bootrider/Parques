namespace DiceLogic
{
    public class DiceResult
    {
        public DiceResult(int? dice1, int? dice2)
        {
            this.Die1 = dice1;
            this.Die2 = dice2;
        }

        public int? Die1 { get; private set; }
        public int? Die2 { get; private set; }

        public bool IsPair
        {
            get
            {
                if (this.Die1 is null || this.Die2 is null || !this.Die2.HasValue)
                {
                    return false;
                }

                return this.Die1.Value == this.Die2.Value;
            }
        }

        public int Total
        {
            get
            {
                if (this.Die1 is not null && this.Die2 is not null)
                {
                    return this.Die1.Value + this.Die2.Value;
                }
                if (this.Die1 is not null)
                {
                    return this.Die1.Value;
                }
                if (this.Die2 is not null)
                {
                    return this.Die2.Value;
                }
                return 0;
            }
        }
    }
}