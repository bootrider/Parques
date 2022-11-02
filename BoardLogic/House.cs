using System.Drawing;
using System.Globalization;
using System.Xml;

namespace BoardLogic
{
    public class House
    {
        public Jail Jail{ get; set; }

        public Box[] Sky { get; set; } = new Box[8];

        public Box[] Path { get; set; } = new Box[16];

        public Color Color { get; set; }

        public House(Color color)
        {
            for (int i = 0; i < Path.Length; i++)
            {
                switch (i)
                {
                    case 0: this.Path[0] = new BoxSkySafe(i); break; 
                    case 5: this.Path[5] = new BoxStart(i); break;
                    case 12: this.Path[12] = new BoxSafe(i); break;
                    default: //llenar las otras
                        this.Path[i] = new BoxNormal(i);
                        break;
                }
            } 
        }
    }
}