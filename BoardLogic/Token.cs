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
        public Guid Id { get; set; } = Guid.NewGuid();

        public Color Color { get; set; }

        public Position GetPosition(Box box)
        {
            throw new NotImplementedException();
        }

        public Position CurrentPosition { get; set; }

    }
}
