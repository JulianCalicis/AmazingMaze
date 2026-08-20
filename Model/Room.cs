namespace Model
{
  /// <summary>
  /// Represents a maze room.
  /// </summary>
  public class Room : IDisplayable
  {
    public MazeSymbol Representation
    {
      get { return MazeSymbol.Room; }
    }

    public Room()
    {
    }
  }
}