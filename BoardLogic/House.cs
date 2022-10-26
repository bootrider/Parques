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
            var sky = new BoxCeilSafe();
            sky.SkyEntrance = new BoxSky();
            sky.SkyEntrance.Next = new BoxSky();
            sky.SkyEntrance.Next.Next = new BoxSky();

            var Path = new Box();
            // aqui faltan 4
            Path.Next = new BoxStart();
            Path.Next.Next = new Box();
            // aqui faltan 6
            Path.Next.Next.Next = new BoxSafe();
            Path.Next.Next.Next.Next = new Box();

            sky.Next = Path;

            this.Color = color;
        }

        public House(Color color,  bool AsArray):
            this(color)
        {
            this.Path[0] = new BoxCeilSafe();
            //llenar las otras
            this.Path[5] = new BoxStart();
            // llenar las otras
            this.Path[12] = new BoxSafe();
        }
    }
}