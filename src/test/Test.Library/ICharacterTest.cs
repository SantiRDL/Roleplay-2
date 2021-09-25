using NUnit.Framework;
using System;
using RoleplayGame;

namespace Test.Library
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            ICharacter character = new Archer("Legolas");
            ICharacter character2 = new Dwarf("Gimli");
        }

        [Test]
        public void ValorDeAtaqueSinItemsTest()
        {
            int attackvalue = character.AttackValue;

            Assert.Pass();
        }
    }
}