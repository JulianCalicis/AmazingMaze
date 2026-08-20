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

    public void Finish()
    {
    }

    public MazeModel Build()
    {
      return _model;
    }
  }
}