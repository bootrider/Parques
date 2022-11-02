using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardLogic
{
    
    public class Token
    {
        internal object getHouse;
        private Color Color;

        Color Color1 { get => Color; set => Color = value; }

        internal string getColor()
        {
            throw new NotImplementedException();
        }
    }
}
