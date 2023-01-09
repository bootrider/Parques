using System.Drawing;

namespace BoardLogic
{
    public class Position
    {
        public Color House { get; set; }
        public bool IsInSky { get; set; }
        public int Step { get; set; }
    }
}