using System;

namespace RoleplayGame
{
    public interface ICharacter
    {
        int Health{get;set;}

        void ReceiveAttack(int power);
        void Cure();


    }
}