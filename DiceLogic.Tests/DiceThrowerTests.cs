
namespace DiceLogic.Tests
{
    [TestClass]
    public class DiceThrowerTests
    {
        [TestMethod]
        public void generateNumberFace_given1to6_returnTrueInterval() //se puede probar un intervalo?
        {
            //arrange
            var dice = new DiceThrower(); //solo me permite probar la clase public no internal

            //act
            int number = dice.GenerateNumberFace();

            //assert
            Assert.IsTrue(number > 0);
            Assert.IsTrue(number < 7);
        }

        [TestMethod]
        public void generateNumberFace_lessTo1_returnFalse()
        {
            //arrange
            var dice = new DiceThrower(); //solo me permite probar la clase public no internal

            //act
            int number = dice.GenerateNumberFace();

            //assert
            Assert.IsFalse(number < 1);
        }

        [TestMethod]
        public void generateNumberFace_moreTo6_returnFalse()
        {
            //arrange
            var dice = new DiceThrower(); //solo me permite probar la clase public no internal

            //act
            int number = dice.GenerateNumberFace();

            //assert
            Assert.IsFalse(number > 6);
        }
               

        [TestMethod]
        public void diceRoll_arrayisNotNull_returnArray()
        {
            //arrange
            var dice = new DiceThrower();

            //act
            var total = dice.Roll();

            //assert
            Assert.IsNotNull(total);
        }

        /*
         * Como puedo probar los datos del arreglo?
        [TestMethod]
        public void diceRoll_X_returnArray()
        {
            //arrange
            var dice = new DiceLogicClass();

            //act
            var total = dice.diceRoll();

            //assert
            Assert.;
        }
        */
    }
}