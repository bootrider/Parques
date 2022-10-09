using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceLogic
{
    public class Dice
    {
        public int roll() //tirar dado (1)
        {
            int numberFace;
            Random random = new Random();
            numberFace = random.Next(1, 7);
            return numberFace;
        }
    }
}
