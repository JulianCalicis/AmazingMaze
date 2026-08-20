using Model.Interfaces;

namespace Model.Representations
{
  /// <summary>
  /// Represents a maze Playable character.
  /// </summary>
  public class Character : IPlaceable
  {
    private char _representation;

    public MazeSymbol Representation { get => (MazeSymbol)_representation; private init => _representation = (char)value; }
    public MazePosition? Position { get; set; }
    public Inventory Bag { get; }

    public Character(MazePosition position, char representation = 'O')
    {
      Position = position;
      Bag = new Inventory();
      _representation = representation;
    }
  }
}