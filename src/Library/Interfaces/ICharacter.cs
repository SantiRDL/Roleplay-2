using System;

namespace RoleplayGame
{
    /// <summary>
    /// Contiene las caracteristicas generales de los personajes.
    /// </summary>
    public interface ICharacter
    {
        int Health {get; set; }
        int AttackValue {get; }

        int DefenseValue {get; }

        void Attack(ICharacter character);
        void Cure();


    }
}