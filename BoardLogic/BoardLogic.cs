namespace BoardLogic
{
    public class BoardLogic
    {
        int numberBoxSky = 8;
        public Box[] board;
        public BoxSky[][] ceil;
        //public Token[][] carcel;

        public BoardLogic(int numberPlayers)
        { 
            board = new Box[numberPlayers*16];
            ceil = new BoxSky[numberPlayers][]; //no me reconoce el 8 al final

        }
    }
}