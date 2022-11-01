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
            var sky = new BoxSkySafe();
            
            sky.SkyEntrance = new BoxPathSky();
            //sky.SkyEntrance.Next = new BoxPathSky();
            //sky.SkyEntrance.Next.Next = new BoxPathSky();

            var Path = new Box();
            // aqui faltan 4
            //Path.Next = new BoxStart();
            //Path.Next.Next = new Box();
            // aqui faltan 6
            //Path.Next.Next.Next = new BoxSafe();
            //Path.Next.Next.Next.Next = new Box();

            //sky.Next = Path;

            this.Color = color;
        }

        public House(Color color,  bool AsArray):
            this(color)
        {
            this.Path = Path;
            for (int i = 0; i < Path.Length; i++)
            {
                switch (i)
                {
                    case 0: this.Path[0] = new BoxSkySafe(); break;
                    case 5: this.Path[5] = new BoxStart(); break;
                    case 12: this.Path[12] = new BoxSafe(); break;
                    default: //llenar las otras
                        this.Path[i] = new BoxNormal();
                        break;
                }
            } 
        }
    }
}