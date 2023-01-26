//using NhlSystemClassLibrary;

namespace DemoTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [DataRow(97, "Conner McDavid", Position.C)]
        [DataRow(93, "Ryan Nugent-Hopkins", Position.C)]
        [DataRow(91, "Evander Kane", Position.C)]
        public void Constructor_ValidData_ShouldPass(int playerNo, string playerName, Position playerPosition)
        {
            //Arrange and Act
            Player player = new Player(97, "Conner McDavid", Position.C);
            //Assert
            Assert.AreEqual(playerNo, player.PlayerNo);
            Assert.AreEqual(playerName, player.Name);
            Assert.AreEqual(playerPosition, player.Position);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.Fail("not implemented yet");
        }
    }
}