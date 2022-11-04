using System.Drawing;
using System.Globalization;
using System.Xml;

namespace BoardLogic
{
    public class House
    {
        //public Jail Jail{ get; set; }
        public Token[] Jail { get; set; } = new Token[4];

        public Box[] Sky { get; set; } = new Box[8];

        public Box[] Path { get; set; } = new Box[16];

        public Color Color { get; set; }

        public House(Color color)
        {
            //inicializated color
            this.Color = color;
            
            //inicializated the pathNormal
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

            //inicializated The SkyPath //THIS COULD TO BE A RULER 
            for (int i = 0; i < Sky.Length; i++)
                this.Sky[i] = new BoxSafe(i);

            //Inicializated the Jail //I THINGS SO
            for (int i = 0; i < Jail.Length; i++)
                this.Jail[i] = new Token();
        }
    }
}