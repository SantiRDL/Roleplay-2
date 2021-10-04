using NUnit.Framework;

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
            Character character = new Archer("Legolas");
            int attackvalue = character.AttackValue;
            int expected = 0;
            Assert.AreEqual(expected,attackvalue);
        }

        [Test]
        public void ValorDeDefensaSinItemsTest()
        {
            Character character = new Archer("Legolas");
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
            Character character2 = new Dwarf("Gandalf");
            character2.OffensiveItem = new Sword();
            character1.Attack(character2);
            character2.Attack(character1);
            Assert.GreaterOrEqual(character1.Health, character2.Health);
        }

        [Test]
        public void CurarTest()
        {
            Character character1 = new Knight("Caballero");
            character1.OffensiveItem = new Sword();
            Character character2 = new Dwarf("Gandalf");
            character1.Attack(character2);
            character2.Cure();
            int expected = 100;
            Assert.AreEqual(expected, character2.Health);
        }
        [Test]
        public void EncounterTest()
        {
            Character heroe1 = new Archer("Arquero", true);
            Character heroe2 = new Dwarf("Enano", true);
            Character enemigo1 = new Kniht("Caballero", false);

            Encounter encuentro = new Encounter();
            encuentro.AgregarPersonaje(heroe1);
            encuentro.AgregarPersonaje(heroe2);
            encuentro.AgregarPersonaje(enemigo1);
            encuentro.DoEncounter();
            
            Assert.AreEqual(encuentro.HayPersonajesVivos(encuentro.badGuys), false);

        [Test]
        public void EncounterTestMoreEnemysThanHeros()
        {
            Character heroe1 = new Knight("Caballero", true);
            Character enemigo1 = new Archer("Arquera", false);
            Character enemigo2 = new Wizard("Mago", false);

            Encounter encuentro = new Encounter();
            encuentro.AgregarPersonaje(heroe1);
            encuentro.AgregarPersonaje(enemigo1);
            encuentro.AgregarPersonaje(enemigo2);
            encuentro.DoEncounter();
            
            Assert.AreEqual(encuentro.HayPersonajesVivos(encuentro.heroes), false);

            
        }
        




        }
        
    }
}