using System.Collections;

namespace Model
{
  /// <summary>
  /// Represents a maze.
  /// </summary>
  public class MazeModel : IEnumerable<IDisplayable>
  {
    #region Fields

    private SortedDictionary<MazePosition, IDisplayable> _grid;

    #endregion Fields

    #region Properties

    /// <summary>
    /// Name of the maze.
    /// </summary>
    public string Name { get; private init; }

    /// <summary>
    /// Indexer that allows direct grid access using a <see cref="MazePosition"/>
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>

    public IDisplayable this[MazePosition position]
    {
      get { return _grid[position]; }
      set { _grid[position] = value; }
    }

    #endregion Properties

    #region Constructors

    public MazeModel(string name)
    {
      _grid = new SortedDictionary<MazePosition, IDisplayable>();
      Name = name;
    }

    #endregion Constructors

    public IEnumerator<IDisplayable> GetEnumerator()
    {
      return _grid.Values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    /// <summary>
    /// Used to view the contents of the grid for debug purposes
    /// </summary>
    /// <remarks>
    /// It retransforms the optimized _grid into an unoptimized readable string
    /// </remarks>
    /// <returns>The formatted grid representation</returns>
    public override string ToString()
    {
      string result = "";
      int previousRow = 0;
      int previousColumn = 0;
      foreach (var test in _grid)
      {
        //previousColumn = test.Key.Column;
        if (previousRow != test.Key.Row)
        {
          result += Environment.NewLine;
          previousRow = test.Key.Row;
          previousColumn = 0;
        }
        while (previousColumn < test.Key.Column)
        {
          result += ' ';
          previousColumn++;
        }
        result += (char)test.Value.Representation;
        previousColumn++;
      }
      return result;
    }
  }
}