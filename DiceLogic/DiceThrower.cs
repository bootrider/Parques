namespace DiceLogic
{
    public class DiceThrower
    {
        public int GenerateNumberFace() //lanzar dado
        {
            int numberFace;
            Random random = new Random();
            numberFace = random.Next(1, 7);
            return numberFace;
        }

        public DiceResult RollTwoDice()
        {
            DiceResult dataDice = new(this.GenerateNumberFace(), this.GenerateNumberFace());
            return dataDice;
        }

        public DiceResult RollOneDie()
        {
            DiceResult dataDice = new(this.GenerateNumberFace(), null);
            return dataDice;
        }
    }
}