using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardLogic
{

    public class Token : IToken
    {
        public Color Color { get; set; }

        public Position GetPosition(Box box)
        {
            // TODO: this method is intended to be used implementing the Visitor pattern.
            throw new NotImplementedException();
        }

    }
}
