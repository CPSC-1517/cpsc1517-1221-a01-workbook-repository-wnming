using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhlSystemTestProject
{
    [TestClass]
    public class PlayerTest
    {
        [TestMethod]
        [DataRow(97, "Conner McDavid", Position.C)]
        [DataRow(93, "Ryan Nugent-Hopkins", Position.C)]
        [DataRow(91, "Evander Kane", Position.C)]
        public void Constructor_ValidData_ShouldPass(int playerNo, string playerName, Position playerPosition)
        {
            //Arrange and Act
            Player player = new Player(playerNo, playerName, playerPosition);
            //Assert
            Assert.AreEqual(playerNo, player.PlayerNo);
            Assert.AreEqual(playerName, player.Name);
            Assert.AreEqual(playerPosition, player.Position);
        }

        [TestMethod]
        [DataRow(0, "Conner McDavid", Position.C)]
        [DataRow(99, "Ryan Nugent-Hopkins", Position.C)]
        [DataRow(-1, "Evander Kane", Position.C)]
        [DataRow(100, "Evander Kane", Position.C)]
        public void PlayerNo_InvalidValue_ThrowArgumentException(int playerNo, string playerName, Position playerPosition)
        {
            try
            //Arrange and Act
            {
                Player player = new Player(playerNo, playerName, playerPosition);
                //Assert.Fail("An argumentException should have been thrown");
                //Assert
            }
            catch (ArgumentException ex)
            {
                StringAssert.Contains(ex.Message, "PlayerNo must be between 1 and 98");
                Assert.AreEqual(ex.Message, "PlayerNo must be between 1 and 98");
            }
            catch (Exception ex)
            {
                Assert.Fail("Incorrect exception type thrown");
            }
        }


        [TestMethod]
        [DataRow(1, "", Position.C)]
        [DataRow(2, "  ", Position.C)]
        [DataRow(3, "test test test", Position.C)]
        [DataRow(4, null, Position.C)]
        public void Name_InvalidValue_ThrowArgumentException(int playerNo, string playerName, Position playerPosition)
        {
            try
            //Arrange and Act
            {
                Player player = new Player(playerNo, playerName, playerPosition);
                //Assert.Fail("An argumentException should have been thrown");
                //Assert
            }
            catch (ArgumentException ex)
            {
                //StringAssert.Contains(ex.Message, "PlayerNo must be between 1 and 98");
                Assert.AreEqual(ex.Message, "Name cannot be blank");
            }
            catch (Exception ex)
            {
                Assert.Fail("Incorrect exception type thrown");
            }
        }

        //write test methods for propery validation for GamePlayed, Goal, Assists, Points
        [TestMethod]
        [DataRow(1, "Conner McDavid", Position.C, -5, 2, 2)]
        [DataRow(2, "Conner McDavid", Position.C, -1, 2, 2)]
        [DataRow(3, "Conner McDavid", Position.C, 0, 2, 2)]
        public void GamePlayed_InvalidValue_ThrowArgumentException(int playerNo, string playerName, Position playerPosition, int gamePlayed, int goals, int assists)
        {
            try
            //Arrange and Act
            {
                Player player = new Player(playerNo, playerName, playerPosition, gamePlayed, goals, assists);
                //Assert.Fail("An argumentException should have been thrown");
                //Assert
            }
            catch (ArgumentException ex)
            {
                //StringAssert.Contains(ex.Message, "PlayerNo must be between 1 and 98");
                Assert.AreEqual(ex.Message, "Game Played cannot be lower than 0");
            }
            catch (Exception ex)
            {
                Assert.Fail("Incorrect exception type thrown");
            }
        }

        //write test methods AddGamePlayed(), AddGoals(), AddAssist()

    }
}
