namespace RoleplayGame
{
    public class Archer : ICharacter, IOffensiveItems, IDefensiveItems
    {
        private int health;


        public Archer(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
        
        public IOffensiveItems OffensiveItem { get; set; }

        public IDefensiveItems DefensiveItem { get; set; }

        public int AttackValue
        {
            get
            {
                return OffensiveItem.AttackValue;
            }
        }

        public int DefenseValue
        {
            get
            {
                return DefensiveItem.DefenseValue;
            }
        }

        public int Health
        {
            get
            {
                return this.health;
            }
            set                           //Quitamos private porque no funcionaba la interfaz
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