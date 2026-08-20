using Model.Interfaces;

namespace Model
{
  /// <summary>
  /// Represents a maze wall.
  /// </summary>
  public class Wall : IDisplayable
  {
    public MazeSymbol Representation { get; } = MazeSymbol.Wall;
  }
}