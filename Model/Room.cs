namespace Model
{
  /// <summary>
  /// Represents a maze room.
  /// </summary>
  public class Room : IDisplayable
  {
    public MazeSymbol Representation
    {
      get
      {
        if (Content != null)
          return Content.Representation;
        return MazeSymbol.Room;
      }
    }

    public IPlaceable? Content { get; set; }

    public Room()
    {
    }

    public Room(IPlaceable content)
    {
      Content = content;
    }
  }
}