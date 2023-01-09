using System.Drawing;

namespace BoardLogic
{
    public interface IToken
    {
        Color Color { get; set; }

        Position GetPosition(Box box);
    }
}