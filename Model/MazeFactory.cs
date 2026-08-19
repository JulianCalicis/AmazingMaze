namespace Model
{
  public static class MazeFactory
  {
    public static MazeModel MazeCreate(string name)
    {
      //return new MazeModel(name);
      MazeModelBuilder builder = new MazeModelBuilder();
      MazeReader reader = new MazeReader(builder);
      reader.Read(name);
      return builder.Build();
    }
  }
}