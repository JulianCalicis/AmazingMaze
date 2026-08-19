namespace Model
{
  public static class MazeFactory
  {
    public static MazeModel MazeCreate(string name)
    {
      return new MazeModel(name);
    }
  }
}