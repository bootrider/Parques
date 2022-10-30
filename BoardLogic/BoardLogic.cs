namespace BoardLogic
{
    public class BoardLogic
    {
        int numberBoxSky = 8;
        public Box[] board;
        public BoxSky[,] ceil;
        //public Token[][] carcel; I need ¿what type i can to define to carcel

        public BoardLogic(int numberPlayers)
        { 
            board = new Box[numberPlayers*16];
            ceil = new BoxSky[numberPlayers,8]; 

        }
    }
}