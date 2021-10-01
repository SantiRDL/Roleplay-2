namespace RoleplayGame
{
    public class Wizard : Character, IMageItems
    {
        

        public Wizard(string name, bool isHero)
        {
            this.Name = name;
            this.IsHero = isHero;
            if (isHero)
            {
                VP = 0;
            }
            else 
            {
                VP = 3;
            }
        }


        public IMageItems SpellsBook { get; set; }
        public IMageItems Staff { get; set; }

        public override int AttackValue
        {
            get
            {
                return SpellsBook.AttackValue + Staff.AttackValue;
            }
        }

        public override int DefenseValue
        {
            get
            {
                return SpellsBook.DefenseValue + Staff.DefenseValue;
            }
        }

        
    }
}