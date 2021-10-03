using System;
using RoleplayGame;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            SpellsBook book = new SpellsBook();
            book.Spells = new Spell[]{ new Spell() };

            Wizard gandalf = new Wizard("Gandalf", true);
            gandalf.Staff = new Staff();
            gandalf.SpellsBook = book;

            Dwarf gimli = new Dwarf("Gimli", false);
            gimli.OffensiveItem = new Axe();
            gimli.DefensiveItem1 = new Helmet();

            Console.WriteLine($"Gimli has ❤️ {gimli.Health}");
            Console.WriteLine($"Gandalf attacks Gimli with ⚔️ {gandalf.AttackValue}");

            gimli.Attack(gandalf);

            Console.WriteLine($"Gimli has ❤️ {gimli.Health}");

            gimli.Cure();

            Console.WriteLine($"Gimli has ❤️ {gimli.Health}");

            
        }
    }
}
