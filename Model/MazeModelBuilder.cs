using Model.Interfaces;
using Model.Representations;

namespace Model
{
  public class MazeModelBuilder : IMazeBuilder
  {
    /// <summary>
    /// The maze being built.
    /// </summary>
    private MazeModel _model;

    public void Start(string name)
    {
      _model = new MazeModel(name);
    }

    public void AddRoom(int row, int column)
    {
      //TODO: Vérifier si c'est pas déjà créé
      _model[new(row, column)] = new Room();
    }

    public void AddWall(int row, int column)
    {
      //TODO: Vérifier si c'est pas déjà créé
      _model[new(row, column)] = new Wall();
    }

    public void AddPlayer(int row, int column)
    {
      MazePosition position = new(row, column);
      _model[position] = new Room();
      _model[position] = new Character(position);
    }

    public void AddDoor(int row, int column)
    {
      _model[new(row, column)] = new Door();
    }

    public void AddKey(int row, int column)
    {
      MazePosition position = new(row, column);
      _model[position] = new Room();
      _model[position] = new Key();
    }

    public void Finish()
    {
    }

    public MazeModel Build()
    {
      return _model;
    }
  }
}