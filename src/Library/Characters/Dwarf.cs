namespace RoleplayGame
{
    public class Dwarf : Character
    {
        
        public Dwarf(string name, bool isHero)
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

        public IDefensiveItems DefensiveItem1 { get; set; }

        public IDefensiveItems DefensiveItem2 { get; set; }

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
                return DefensiveItem1.DefenseValue + DefensiveItem2.DefenseValue;
            }
        }

    }
}