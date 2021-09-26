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
        }

        [Test]
        public void ValorDeAtaqueSinItemsTest()
        {
            ICharacter character = new Archer("Legolas");
            int attackvalue = character.AttackValue;
            int expected = 0;
            Assert.AreEqual(expected,attackvalue);
        }

        [Test]
        public void ValorDeDefensaSinItemsTest()
        {
            ICharacter character = new Archer("Legolas");
            int defensevalue = character.DefenseValue;
            int expected = 0;
            Assert.AreEqual(expected,defensevalue);
        }

        [Test]
        public void AtaqueEntrePersonajesTest()
        {
            SpellsBook book = new SpellsBook();
            book.Spells = new Spell[]{ new Spell() };
            Wizard character1 = new Wizard("Gandalf");
            character1.Staff = new Staff();
            character1.SpellsBook = book;
            ICharacter character2 = new Dwarf("Gandalf");
            character2.OffensiveItem = new Sword();
            character1.Attack(character2);
            character2.Attack(character1);
            Assert.GreaterOrEqual(character1.Health, character2.Health);
        }

        [Test]
        public void CurarTest()
        {
            ICharacter character1 = new Knight("Caballero");
            character1.OffensiveItem = new Sword();
            ICharacter character2 = new Dwarf("Gandalf");
            character1.Attack(character2);
            character2.Cure();
            int expected = 100;
            Assert.AreEqual(expected, character2.Health);
        }
    }
}