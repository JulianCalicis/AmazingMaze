namespace Model
{
  /// <summary>
  /// Represents a Position of the maze, using Row and Column indexes
  /// </summary>
  public class MazePosition : IComparable<MazePosition>
  {
    //TODO: permettre à MazePosition de savoir le nombre de colonnes dans le labyrinthe pour donner une signification à la valeur de comparaison.
    public MazePosition(int row, int column)
    {
      Row = row;
      Column = column;
    }

    public int Row { get; }
    public int Column { get; }

    public int CompareTo(MazePosition? other)
    {
      if (Row > other.Row) return 1;
      else if (Row < other.Row) return -1;
      else if (Column > other.Column) return 1;
      else if (Column < other.Column) return -1;
      else return 0;
    }

    public override string ToString()
    {
      return $"({Row},{Column})";
    }
  }
}