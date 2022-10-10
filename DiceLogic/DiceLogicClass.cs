namespace DiceLogic
{
    public class DiceLogicClass
    {
        public int generateNumberFace() //lanzar dado
        {
            int numberFace;
            Random random = new Random();
            numberFace = random.Next(1, 7);
            return numberFace;
        }

        public int putTogheter(int dice1,int dice2)
        {
            int total = dice1 + dice2;
            return total;
        }

        public int[] diceRoll()
        {
            int[] dataDice = new int[3];
            dataDice[0] = generateNumberFace();
            dataDice[1] = generateNumberFace();
            dataDice[2] = putTogheter(dataDice[0], dataDice[1]);
            return dataDice;
        }

    }
}