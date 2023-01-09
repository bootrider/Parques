using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceLogic
{
    public class DiceResult
    {
        public int Dice1 { get; private set; }
        public int Dice2 { get; private set; }

        public int Total => this.Dice1 + this.Dice2;

        public DiceResult(int dice1, int dice2)
        {
            this.Dice1 = dice1;
            this.Dice2 = dice2;
        }
    }
}
