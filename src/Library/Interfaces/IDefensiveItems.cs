using System;

namespace RoleplayGame
{
    /// <summary>
    /// Caracteriza a los items defensivos.
    /// Se podra equipar cualquier item defensivo en el respectivo atributo pero no se podra equipar items ofensivos.
    /// </summary>
    public interface IDefensiveItems
    {
        int DefenseValue {get;}
    }
}