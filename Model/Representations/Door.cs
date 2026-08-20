namespace Model.Representations
{
  /// <summary>
  /// Represents a Door
  /// </summary>
  public class Door : Room
  {
    public bool IsOpen { get; private set; } = false;

    public override MazeSymbol Representation
    {
      get
      {
        if (Content != null)
          return Content.Representation;
        return IsOpen ? MazeSymbol.OpenedDoor : MazeSymbol.ClosedDoor;
      }
    }

    public override void Visite(Character character)
    {
      if (!IsOpen)
      {
        Key test = (Key?)character.Bag.FirstOrDefault(i => i.GetType() == typeof(Key)) ?? throw new Exception("Le joueur a foncé dans une porte fermée");
        IsOpen = true;
        character.Bag.Remove(test);
      }
      Content = character;
    }
  }
}