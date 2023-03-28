using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceLogic
{
    public class DiceResult
    {
        public int? Die1 { get; private set; }
        public int? Die2 { get; private set; }

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

        public DiceResult(int? dice1, int? dice2)
        {
            this.Die1 = dice1;
            this.Die2 = dice2;
        }
    }
}
