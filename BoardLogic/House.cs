using System.Drawing;
using System.Globalization;
using System.Xml;

namespace BoardLogic
{
    using System.Runtime.CompilerServices;

    public class House : IHouse
    {
        public IBox Jail { get; set; } = new Box(0);

        public Box[] SkyPath { get; set; } = new Box[8];

        public Box[] Path { get; set; } = new Box[16];

        public Color Color { get; set; }

        public House(Color color)
        {
            //initialized color
            this.Color = color;
            
            //initialized the pathNormal
            for (int i = 0; i < Path.Length; i++)
            {
                switch (i)
                {
                    case 0: this.Path[0] = new BoxSkySafe(i); break; 
                    case 5: this.Path[5] = new BoxStart(i); break;
                    case 12: this.Path[12] = new BoxSafe(i); break;
                    default: // TODO: Fill the other
                        this.Path[i] = new BoxNormal(i);
                        break;
                }
            }

            //initialized The SkyPath 
            for (int i = 0; i < this.SkyPath.Length; i++)
                this.SkyPath[i] = new BoxPathSky(i);
           
        }
    }
}