
namespace DiceLogic.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void generateNumberFace_given1to6_returnTrueInterval() //se puede probar un intervalo?
        {
            //arrange
            var dice = new DiceLogicClass(); //solo me permite probar la clase public no internal

            //act
            int number = dice.generateNumberFace();

            //assert
            Assert.IsTrue(number > 0);
            Assert.IsTrue(number < 7);
        }

        [TestMethod]
        public void generateNumberFace_lessTo1_returnFalse()
        {
            //arrange
            var dice = new DiceLogicClass(); //solo me permite probar la clase public no internal

            //act
            int number = dice.generateNumberFace();

            //assert
            Assert.IsFalse(number < 1);
        }

        [TestMethod]
        public void generateNumberFace_moreTo6_returnFalse()
        {
            //arrange
            var dice = new DiceLogicClass(); //solo me permite probar la clase public no internal

            //act
            int number = dice.generateNumberFace();

            //assert
            Assert.IsFalse(number > 6);
        }

        [TestMethod]
        public void putTogheter_isDice2and4_return6()
        {
            //arrange
            var dice = new DiceLogicClass();

            //act
            int total = dice.putTogheter(2,4);

            //assert
            Assert.AreEqual(6,total);
        }

        [TestMethod]
        public void diceRoll_arrayisNotNull_returnArray()
        {
            //arrange
            var dice = new DiceLogicClass();

            //act
            var total = dice.diceRoll();

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