using System;

namespace RoleplayGame
{
    /// <summary>
    /// Caracteriza a los items ofensivos.
    /// De esta manera se podra equipar cualquier item ofensivo en el atributo correspondiente, pero no se podra equipar un item 
    /// defensivo.
    /// </summary>
    public interface IOffensiveItems
    {
        int AttackValue {get;}
    }
}