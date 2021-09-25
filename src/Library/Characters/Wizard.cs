namespace RoleplayGame
{
    public class Wizard : ICharacter, IMageItems
    {
        private int health = 100;

        public Wizard(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
/// <summary>
/// Estos atributos son ahora del tipo de la interfaz.
/// </summary>
/// <value></value>
        public IMageItems SpellsBook { get; set; }
        public IMageItems Staff { get; set; }

        public int AttackValue
        {
            get
            {
                return SpellsBook.AttackValue + Staff.AttackValue;
            }
        }

        public int DefenseValue
        {
            get
            {
                return SpellsBook.DefenseValue + Staff.DefenseValue;
            }
        }

        public int Health
        {
            get
            {
                return this.health;
            }
            set //Quitamos private porque no funcionaba la interfaz
            {
                this.health = value < 0 ? 0 : value;
            }
        }
        /// <summary>
        /// Teniendo la interfaz ICharacter, ahora se puede hacer un metodo de ataque en vez de uno de recibir ataque.
        /// </summary>
        /// <param name="character"></param>
        public void Attack(ICharacter character)
        {
            if (this.AttackValue > character.DefenseValue)
            {
                character.Health -= this.AttackValue - character.DefenseValue;
            }
        }
        public void Cure()
        {
            this.Health = 100;
        }
    }
}