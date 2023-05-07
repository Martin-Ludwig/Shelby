using FluentValidation;
using Shelby.Library.Model;
using Shelby.Library.System;
using Shelby.Library.Validation;

namespace Shelby.UnitTests.CombatTests
{
    [TestClass]
    public class CombatTests
    {

        [TestMethod]
        [DataTestMethod]
        [DataRow("Alice", 100, 10, "Bob", 100, 7)]
        public void Battle_TwoCharacters_ReturnsWinningCharacter(string aliceName, int aliceHealth, int aliceStrength, string bobName, int bobHealth, int bobStrength)
        {
            // Arrange
            var players = new List<Character>
            {
                new Character(aliceName, aliceHealth, aliceStrength),
                new Character(bobName, bobHealth, bobStrength)
            };
            var combat = new Combat(players);

            // Act
            var winner = combat.Battle();

            // Assert
            Assert.IsNotNull(winner);
            Assert.IsTrue(winner.Health > 0);
            Assert.IsTrue(players.Contains(winner));
        }

    }
}
