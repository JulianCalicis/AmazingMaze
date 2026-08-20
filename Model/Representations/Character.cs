using Model.Interfaces;

namespace Model.Representations
{
  /// <summary>
  /// Represents a maze Playable character.
  /// </summary>
  public class Character : IPlaceable
  {
    public MazeSymbol Representation { get; } = MazeSymbol.Character;
    public MazePosition? Position { get; set; }
    public Inventory Bag { get; }

    public Character(MazePosition position)
    {
      Position = position;
      Bag = new Inventory();
    }
  }
}