namespace Model.Interfaces
{
  /// <summary>
  /// Represents elements that can be displayed in the View
  /// </summary>
  /// <remarks>Corresponds to ISymbol</remarks>
  public interface IDisplayable
  {
    //TODO: This should belong to the view
    public MazeSymbol Representation { get; }
  }
}