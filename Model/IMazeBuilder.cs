namespace Model
{
  /// <summary>
  /// Interface that forces implementers to have its actions
  /// </summary>
  public interface IMazeBuilder
  {
    /// <summary>
    /// Begin the creation of the maze.
    /// </summary>
    /// <param name="name">Name of the maze to create.</param>
    void Start(string name);

    //TODO: Utiliser MazePosition
    /// <summary>
    /// Add a room at the designated <paramref name="row"/> and <paramref name="column"/>.
    /// </summary>
    /// <param name="row">The row index.</param>
    /// <param name="column">The column index.</param>
    void AddRoom(int row, int column);

    //TODO: Utiliser MazePosition
    /// <summary>
    /// Add a wall at the designated <paramref name="row"/> and <paramref name="column"/>.
    /// </summary>
    /// <param name="row">The row index.</param>
    /// <param name="column">The column index.</param>
    void AddWall(int row, int column);

    /// <summary>
    /// Add a character at the designated <paramref name="row"/> and <paramref name="column"/>.
    /// </summary>
    /// <param name="row">The row index.</param>
    /// <param name="column">The column index.</param>
    void AddPlayer(int row, int column);

    /// <summary>
    /// End the creation of the maze.
    /// </summary>
    void Finish();
  }
}