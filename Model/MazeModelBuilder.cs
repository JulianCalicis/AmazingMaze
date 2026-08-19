namespace Model
{
  public class MazeModelBuilder : IMazeBuilder
  {
    private MazeModel _model;

    public void AddRoom(int row, int column)
    {
      throw new NotImplementedException();
    }

    public void AddWall(int row, int column)
    {
      throw new NotImplementedException();
    }

    public void Finish()
    {
      throw new NotImplementedException();
    }

    public void Start(string name)
    {
      _model = new MazeModel(name);
      throw new NotImplementedException();
    }
  }
}