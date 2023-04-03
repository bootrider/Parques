using System.Drawing;
using BoardLogic;

namespace Game
{
    public class Player
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Color Color { get; set; }

        public Token[] Tokens { get; set; }
    }
}