namespace DiceLogic
{
    public class DiceLogicClass
    {
        public object diceRoll() //lanzar dados
        {
            //no se especifico la firma del metodo, que retorna.
            Dice dice1 = new Dice();
            Dice dice2 = new Dice();
            Console.WriteLine(dice1.roll()); 
            Console.WriteLine(dice2.roll());
            return null;
        }
        
    }
}