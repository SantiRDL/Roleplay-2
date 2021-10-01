namespace RoleplayGame
{
    public class Archer : Character, IOffensiveItems, IDefensiveItems
    {
        public Archer(string name, bool isHero)
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

      
        public IOffensiveItems OffensiveItem { get; set; }

        public IDefensiveItems DefensiveItem { get; set; }

        public override int AttackValue
        {
            get
            {
                return OffensiveItem.AttackValue;
            }
        }

        public override int DefenseValue
        {
            get
            {
                return DefensiveItem.DefenseValue;
            }
        }

    }
}