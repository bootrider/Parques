using System.Drawing;

namespace BoardLogic
{
    public interface IToken
    {
        Guid Id { get; set; }

        Color Color { get; set; }

        Position GetPosition(Box box);
    }
}