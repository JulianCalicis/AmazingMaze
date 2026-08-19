using System.Collections;

namespace Model
{
  public class MazeModel : IEnumerable<MazeElement>
  {
    public string Name { get; private init; }

    private SortedDictionary<MazePosition, MazeElement> _grid;

    public MazeModel(string name)
    {
      _grid = new SortedDictionary<MazePosition, MazeElement>();
      Name = name;
    }

    public IEnumerator<MazeElement> GetEnumerator()
    {
      return _grid.Values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }
  }

  public enum MazeElement
  {
    Wall = '*', Room = '.'
  }
}