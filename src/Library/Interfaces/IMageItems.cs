namespace RoleplayGame
{
    /// <summary>
    /// Caracteriza a los items de magos, por ende, el mago utilizara items del tipo IMageItems.
    /// </summary>
    public interface IMageItems
    {
        int AttackValue {get; }
        int DefenseValue {get; }
    }
}