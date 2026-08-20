using Model.Interfaces;

namespace Model.Representations
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

    public void Visite(Character character)
    {
      if (Content is Key key)
    {
        character.Bag.Add(key);
        Content = null;
      }
      Content = character;
    }
  }
}