namespace RoleplayGame
{
    public class Character : IDefensiveItems , IOffensiveItems
    {
         public bool IsHero;

         public int VP;
         
         private int health = 100;


         public string Name { get; set; }
         
        /// <summary>
        /// El método es virtual para que cada clase lo sobreescriba en base a los items que posee.
        /// </summary>
        /// <value></value>
         public virtual int AttackValue
        {
            get
            {
                return 0;
            }
        }
        /// <summary>
        /// El método es virtual para que cada clase lo sobreescriba en base a los items que posee.
        /// </summary>
        /// <value></value>
        public virtual int DefenseValue
        {
            get
            {
                return 0;
            }
        }

        public int Health
        {
            get
            {
                return this.health;
            }
            set                           
            {
                this.health = value < 0 ? 0 : value;
            }
        }
        
        public void Attack(Character character)
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