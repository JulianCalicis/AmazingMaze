using Model.Interfaces;
using System.Collections;

namespace Model.Representations
{
  /// <summary>
  /// Represents a maze.
  /// </summary>
  public class MazeModel : IEnumerable<IDisplayable>

  {
    #region Fields

    private SortedDictionary<MazePosition, IDisplayable> _grid;

    /// <summary>
    /// Represents each character linked to its representation symbol.
    /// </summary>
    /// <remarks>Corresponds to PersonagesMap</remarks>
    private Dictionary<char, Character> _characters;

    /// <summary>
    /// Represents the representation symbols of characters still present in the maze.
    /// </summary>
    private List<char> _characterKeys;

    private int _activeCharacter;

    #endregion Fields

    #region Properties

    /// <summary>
    /// Activates the next character using the list of representation symbols
    /// </summary>
    public void ActivateCharacter()
    {
      _activeCharacter++;
      if (_activeCharacter >= _characterKeys.Count)
        _activeCharacter = 0;
    }

    /// <summary>
    /// Activates a the character represented by <paramref name="representation"/>
    /// </summary>
    /// <param name="representation"></param>
    /// <exception cref="ArgumentException"></exception>
    public void ActivateCharacter(char representation)
    {
      int index = _characterKeys.IndexOf(representation);
      if (index < 0) throw new ArgumentException("Character doesn't exist");
      _activeCharacter = index;
    }

    /// <summary>
    /// Name of the maze.
    /// </summary>
    public string Name { get; private init; }

    /// <summary>
    /// Represents the player character of the maze.
    /// </summary>
    /// <remarks>
    /// Impossible de mettre la propriété en lecture seule si elle doit être initialisée par autre chose que le
    /// constructeur, dans ce cas, elle doit être initialisée par le setter de l'indexeur
    /// </remarks>
    public Character Player => _characters[_characterKeys[_activeCharacter]];

    /// <summary>
    /// Indexer that allows direct grid access using a <see cref="MazePosition"/>
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>

    public IDisplayable this[MazePosition position]
    {
      get { return _grid[position]; }
      set
      {
        if (value is IPlaceable valuePlaceable)
        {
          if (_grid[position] is not Room room)
            throw new Exception("Cannot place something in this tile");
          if (room.Content != null)
            throw new Exception("The newRoom is already occupied.");
          if (value is Character valueCharacter)
          {
            if (_characters.ContainsKey((char)valueCharacter.Representation))
              throw new Exception("Player already exists");
            _characters.Add((char)valueCharacter.Representation, valueCharacter);
            _characterKeys.Add((char)valueCharacter.Representation);
          }
          room.Content = valuePlaceable;
        }
        else
          _grid[position] = value;
      }
    }

    #endregion Properties

    #region Constructors

    public MazeModel(string name)
    {
      _grid = new SortedDictionary<MazePosition, IDisplayable>();
      _characterKeys = new List<char>();
      _characters = new Dictionary<char, Character>();
      _activeCharacter = 0;
      Name = name;
    }

    #endregion Constructors

    public void Move(MovementDirection direction)
    {
      if (Player == null) throw new Exception("Le personnage n'existe pas");
      MazePosition? NewPos = (Player.Position?[direction]);
      if (NewPos == null || !_grid.ContainsKey(NewPos))
      {
        ((Room)this[Player.Position]).Content = null;
        Player.Position = null;
        _characterKeys.Remove((char)Player.Representation);

        //throw new Exception("Le personnage est sorti du labyrinthe");
        if (_characterKeys.Count <= 0) throw new Exception("Partie Terminée");
      }
      else
      {
        if (this[NewPos] is not Room newRoom) throw new Exception("Le personnage essaie d'aller dans autre chose qu'une pièce");

        ((Room)this[Player.Position]).Content = null;
        newRoom.Visite(Player);
        Player.Position = NewPos;
      }
    }

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