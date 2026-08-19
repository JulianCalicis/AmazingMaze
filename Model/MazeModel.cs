namespace Model
{
  public class MazeModel
  {
    public string Name { get; private init; }

    public MazeModel(string name)
    {
      Name = name;
    }
  }
}