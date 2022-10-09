
namespace DiceLogic.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void roll_given1to6_returnTrueInterval() //se puede probar un intervalo?
        {
            //arrange
            var dice = new Dice(); //solo me permite probar la clase public no internal

            //act
            int number = dice.roll();

            //assert
            Assert.IsTrue(number > 0);
            Assert.IsTrue(number < 7);
        }

        [TestMethod]
        public void roll_lessTo1_returnFalse()
        {
            //arrange
            var dice = new Dice(); //solo me permite probar la clase public no internal

            //act
            int number = dice.roll();

            //assert
            Assert.IsFalse(number < 1);
        }

        [TestMethod]
        public void roll_moreTo6_returnFalse()
        {
            //arrange
            var dice = new Dice(); //solo me permite probar la clase public no internal

            //act
            int number = dice.roll();

            //assert
            Assert.IsFalse(number > 6);
        }


        /*
         * El codigo quiere probar el lanzamiento de dados, no de uno solo.
         * Debería salir solo dos valores no 4 en el output de la prueba.
         */
        [TestMethod]
        public void diceRoll_dices_returnX()
        {
            //arrange
            var dice = new DiceLogicClass();

            //act
            var dado1 = dice.diceRoll();
            var dado2 = dice.diceRoll();

            //assert
            //Assert.IsTrue(number > 0);
            //Assert.IsTrue(number < 7);

        }
    }
}