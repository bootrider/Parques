using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardLogic
{
    public class Board
    {
        public House[] Houses { get; set; }

        public Board(int players)
        {
            this.Houses = new House[players];
            for (int i = 0; i < players; i++)
            {
                Color selectedColor;
                switch (i)
                {
                    case 1: selectedColor = Color.White;
                        break;
                    case 2: selectedColor = Color.Black;
                        break;
                    case 3: selectedColor = Color.Green;
                        break;
                    default: selectedColor = Color.Red;
                        break;
                }
                
                this.Houses[i] = new House(selectedColor);
            }
        }


    }
}
